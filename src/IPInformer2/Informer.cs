using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Timers;

namespace IPInformer2
{
    public class CountyAlarmEventArgs : EventArgs
    {
        public string IP { get; set; }
        public string Country { get; set; }
        public string ISOCode { get; set; }        
        public bool InREMOTE_ADDR { get; set; }
        public bool InHTTP_HEADERS { get; set; }
        public bool InOTHER { get; set; }
    }

    public class ScriptWarningsEventArgs : EventArgs
    {
        public string IP { get; set; }                
        public string ScriptMessage { get; set; }
    }

    public class Informer
    {
        public delegate void OnFatalError(object sender);
        public delegate void OnNetError(object sender);
        public delegate void OnCountryAlarm(object sender, CountyAlarmEventArgs e);
        public delegate void OnScriptWarnings(object sender, ScriptWarningsEventArgs e);
        public delegate void OnConnecting(object sender);
        public delegate void OnIPOK(object sender);
        public delegate void OnNewIP(object sender);

        public event OnFatalError FatalError;
        public event OnNetError NetError;
        public event OnCountryAlarm CountryAlarm;
        public event OnScriptWarnings ScriptWarnings;
        public event OnConnecting Connecting;
        public event OnIPOK IPOK;
        public event OnNewIP NewIP;
        
        private string ScriptAddr = "";
        private SendRequest sendReq = null;
        private IPData ipData = null;
        private NetSettings netSettings = null;
        private appSettings appsettings = null;
        private Dictionary<string, string> stoplist = null;
        private Timer InternalTimer = null;
        System.Threading.Thread WorkThread = null;        
        private List<string> CurrentIPs = null;        

        public string ErrorMessage { get; private set; }
        public string IPShortInfo { get; private set; }
        public bool Stopped { get; private set; }
        

        //инициализируем запрашивалку
        private bool InitSend()
        {
            //читаем конфиг сети
            netSettings = new NetSettings(CommonFunctions.SettingsPath +
                CommonFunctions.NetSettingsFile);
            if (netSettings.LoadConfig()==NetConfigStatus.Error)
            {
                ErrorMessage = netSettings.ConfigError;
                return false;
            }

            //создаем список для хранения текущих ip и детекции новых
            CurrentIPs = new List<string>();

            //конфиг программы
            appsettings = new appSettings(CommonFunctions.SettingsPath +
                CommonFunctions.AppSettingsFile);
            if (!appsettings.LoadConfig())
            {
                ErrorMessage = appsettings.ConfigError;
                return false;
            }
            
            ScriptAddr = appsettings.CurrentScriptAddr;

            //Проверяем БД SxGeo
            if (!CommonFunctions.ValidateSxGeo())
            {
                ErrorMessage = "SxGeo files missed or invalid!";
                return false;
            }

            //получаем стоп-лист
            stoplist = appsettings.GetStopList();
            
            //подгатавливаем анализатор данных
            ipData = new IPData();

            //устанавливаем параметры запроса
            sendReq = new SendRequest(ScriptAddr);
            
            sendReq.ConnectionType = netSettings.ConnectionType;
            sendReq.ProxyAddress = netSettings.ProxyAddress;
            sendReq.ProxyPort = netSettings.ProxyPort;
            sendReq.ProxyUser = netSettings.ProxyUser;
            sendReq.ProxyPassword = netSettings.ProxyPassword;
            sendReq.ConnectionTimeout = netSettings.ConnectionTimeout;            

            return true;
        }

        public System.Data.DataView GetIPInfo()
        {
            //получение своего IP
            if (!InitSend()) return null;
            
            if (!sendReq.CreateRequest())
            {
                ErrorMessage = sendReq.ErrorMessage;
                return null;
            }
            
            string IPRawData = sendReq.Send();
            if (IPRawData == null)
            {
                ErrorMessage = sendReq.ErrorMessage;
                return null;
            }
            
            //заполняем таблицы с данными
            if (!ipData.FillIPTable(IPRawData))
            {
                ErrorMessage = ipData.ErrorMessage;
                return null;
            }
            
            ipData.FillInfoTable();
            return ipData.dsIP.Tables["Info"].DefaultView;
        }

        public System.Data.DataView GetIPInfo(string IP)
        {
            IPData ipManData = new IPData();

            string IPRawData = "IPINF031\n---START-DATA---\n" +
                IP + "|MANUAL\n" + "---END-DATA---\n";
            
            //заполняем таблицы с данными
            if (!ipManData.FillIPTable(IPRawData))
            {
                ErrorMessage = ipData.ErrorMessage;
                return null;
            }

            ipManData.FillInfoTable();
            return ipManData.dsIP.Tables["Info"].DefaultView;
        }

        //главная функция слежения за IP
        private void GetWatchData()
        {
            bool neterr = false;
            bool scripterr = false;
            
            if (Stopped) return;
            
            if (!sendReq.CreateRequest())
            {
                ErrorMessage = sendReq.ErrorMessage;
                CurrentIPs.Clear();
                if (FatalError != null) FatalError(this);
                return;
            }

            //отправка запроса
            string IPRawData = sendReq.Send();
            if (IPRawData == null) //ошибка сети или сервера
            {
                ErrorMessage = "";
                if (sendReq.NetworkError) ErrorMessage = "Network error\n";
                if (sendReq.ProtocolError) ErrorMessage = "Protocol error\n";
                ErrorMessage = ErrorMessage + sendReq.ErrorMessage;
                neterr = true;
                CurrentIPs.Clear();

                if (appsettings.ComScriptChange == ScriptChangeType.ChangeIfError)
                {
                    appsettings.SetNextScript();
                    sendReq.URL = appsettings.CurrentScriptAddr;
                }

                if (NetError != null) NetError(this);
            }

            //обрабатываем полученные данные
            if (!neterr)
            {
                if (!ipData.FillIPTable(IPRawData))
                {
                    //Если тут что-то пошло не так, 
                    //значит либо сдох наш скрипт
                    //либо в другом не нашлось IP
                    //ошибка скрипта приравнивается к ошибке сети
                    CurrentIPs.Clear();
                    ErrorMessage = "Script error\n No IP addresses or internal error!";
                    scripterr = true;

                    if (appsettings.ComScriptChange == ScriptChangeType.ChangeIfError)
                    {
                        appsettings.SetNextScript();
                        sendReq.URL = appsettings.CurrentScriptAddr;
                    }

                    if (NetError != null) NetError(this);
                }

                //Проверка данных
                if (!scripterr)
                {
                    CheckIP(ipData.dsIP);
                }
            }
            
            //все доделали - запускаем паузу
            InternalTimer.Enabled = true;
        }

        void sendReq_Connecting(object sender)
        {
            if (Connecting != null) Connecting(this);
        }

        //получение основной информации 
        //проверка на попадание в стоп-лист
        //предупреждения скрипта
        private void CheckIP(DataSet ds) 
        {
            //List для сбора всех обнаруженных IP для определения смены IP
            List <string> NewIPInfo = new List<string>();             
            bool stoplist = false;            
            bool InREMOTE_ADDR = false;
            bool InHTTP_HEADERS = false;
            bool InOTHER = false;
            CountyAlarmEventArgs e = new CountyAlarmEventArgs();

            foreach (DataRow dr in ds.Tables["IP"].Rows)
            {
                string buf = "";
                //проверка на предупреждения скрипта
                if (dr["status"].ToString().Trim() != "OK")
                {
                    ScriptWarningsEventArgs swea = new ScriptWarningsEventArgs();                    
                    swea.IP = dr["ip"].ToString().Trim();                    
                    swea.ScriptMessage = dr["status"].ToString().Trim();
                    if (swea.ScriptMessage == string.Empty)
                    {
                        swea.ScriptMessage = "Unknow Warning, check script!";
                    }
                    if (ScriptWarnings != null) ScriptWarnings(this, swea);
                }

                //проверка на попадание в стоп-лист если предупреждения не отключены.
                if (InStopList(dr["country_iso"].ToString())&&
                    (appsettings.ComAlarmLevel!=IPAlarmLevel.None))
                {
                    switch (dr["field"].ToString().Trim())
                    {
                        case "REMOTE_ADDR":
                            {
                                InREMOTE_ADDR = true;
                            }; break;
                        case "OTHER":
                            {
                                InOTHER = true;
                            }; break;
                        default:
                            {
                                InHTTP_HEADERS = true;
                            }; break;
                    }
                    
                    e.InREMOTE_ADDR = InREMOTE_ADDR;
                    e.InHTTP_HEADERS = InHTTP_HEADERS;
                    e.InOTHER = InOTHER;
                    e.Country = dr["country_name_en"].ToString().Trim();
                    e.IP = dr["ip"].ToString().Trim();
                    e.ISOCode = dr["country_iso"].ToString().Trim();
                    stoplist = true;
                }
                
                //инфо для краткой подсказки и обнаружения новых IP
                buf = buf + dr["ip"].ToString() + " " + dr["country_name_en"].ToString() + " (" +
                    dr["country_iso"].ToString() + ")";
                
                NewIPInfo.Add(buf);
            }



            IPShortInfo = string.Join("\n", NewIPInfo.ToArray());
            if (NewIPDetect(NewIPInfo))
            {
                if (NewIP != null) NewIP(this);
            }

            if (stoplist)
            {
                if (CountryAlarm != null) CountryAlarm(this, e);
            }
            else
            {
                if (IPOK != null)
                    IPOK(this);
            }
        }

        //детектим изменение IP
        private bool NewIPDetect(List<string> IPs)
        {
            bool DetectingNew = false;            
            foreach (string IP in IPs)
            {
                //нету в текущих, значит новый есть
                if (!CurrentIPs.Contains(IP)) DetectingNew = true;
            }
            
            //обновляем список - все переданные считаются текущими
            CurrentIPs.Clear();
            CurrentIPs.AddRange(IPs);

            return DetectingNew;
        }

        private bool InStopList(string ISOCode)
        {
            if (stoplist != null)
            {
                if (stoplist.ContainsKey(ISOCode)) return true;
            }

            return false;
        }

        public void StartWatch()
        {
            //инициализация и формирование запроса
            if (!InitSend())
            {
                if (FatalError != null) FatalError(this);
                return;
            }
            
            sendReq.Connecting+=new SendRequest.OnConnecting(sendReq_Connecting);
            
            //инициализация таймера
            InitTimer();

            //сбрасываем флаг останова
            Stopped = false;

            //запускаем следилку за IP в отдельном потоке
            WorkThread = new System.Threading.Thread(GetWatchData);
            WorkThread.Start();
        }

        public void StopWatch()
        {
            Stopped = true;
            if (InternalTimer != null)
            {
                InternalTimer.Stop();
                //InternalTimer.Dispose();                
            }

            if (WorkThread != null)
            {
                WorkThread.Abort();
                WorkThread = null;
            }
        }

        private void InitTimer()
        {
            InternalTimer = new Timer();
            InternalTimer.AutoReset = false; //перезапуск в функции GetWatchData
            
            //задаем интервал из конфига
            int interval = appsettings.ComTimeInterval;
            if (interval < 1) interval = 1;
            if (appsettings.ComTime == TimeUnits.Minutes)
            {
                interval = interval * 60;
            }
            interval = interval * 1000;
            InternalTimer.Interval = interval;

            //события
            InternalTimer.Elapsed += new ElapsedEventHandler(InternalTimer_Elapsed);            

            //синхронизируем с этим потоком?
            //InternalTimer.SynchronizingObject = this;
        }
        
        void InternalTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Stopped) return;

            GetWatchData();
        }
    }
}
