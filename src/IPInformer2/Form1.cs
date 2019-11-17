using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        appSettings settings = null;
        Informer WatchIP = new Informer();
        bool ScriptWarnings = false;
        TrayIconType CurrentIcon = TrayIconType.Off;

        string prevNetError = string.Empty;
        bool prevPanic = false; //чтобы не паниковать несколько раз, пока ip не поменялся
        bool PlayAlarm = true;  //если звук в текущем предупреждении не звучал,
                                //то надо воспроизвести
       
        frmPanicNet fPanicNet = null;
        frmPanic fPanic = null;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //ставим черную иконку (загрузка программы)
            TrayIcons.TrayIcon(TrayIconType.Off, niMain, false);
            niMain.Text = "IP informer loading...";
            this.Hide(); //прячем главное окно

            //читаем настройки
            settings = new appSettings(CommonFunctions.SettingsPath +
                CommonFunctions.AppSettingsFile);
            
            if (!settings.LoadConfig())
            {
                //ошибка при загрузке конфигурации
                TrayIcons.TrayIcon(TrayIconType.Panic, niMain, false);
                niMain.Text = "Config Error!";
                niMain.ShowBalloonTip(5000, "Config Error!", settings.ConfigError,
                    ToolTipIcon.Error);
                return;
            }

            //подключаем события и запускаем следилку
            WatchIP.Connecting += new Informer.OnConnecting(WatchIP_Connecting);
            WatchIP.CountryAlarm += new Informer.OnCountryAlarm(WatchIP_CountryAlarm);
            WatchIP.IPOK += new Informer.OnIPOK(WatchIP_IPOK);
            WatchIP.NetError += new Informer.OnNetError(WatchIP_NetError);
            WatchIP.ScriptWarnings += new Informer.OnScriptWarnings(WatchIP_ScriptWarnings);
            WatchIP.FatalError += new Informer.OnFatalError(WatchIP_FatalError);
            WatchIP.NewIP += new Informer.OnNewIP(WatchIP_NewIP);
            WatchIP.StartWatch();
        }

        //остановка отслеживания пользователем
        void UserStop(bool FromMenu)
        {
            WatchIP.StopWatch();
            niMain.ShowBalloonTip(5000, "Внимание!",
                "Отслеживание IP остановлено пользователем!", ToolTipIcon.Warning);

            if (FromMenu) //из меню (меняем иконку и подсказку)
            {
                TrayIcons.TrayIcon(TrayIconType.Warning, niMain, false);
                niMain.Text = "IP не отслеживается. Приостановлено пользователем.";
            }
            //иначе ничего не меняем, пусть 
            //остаются безмолвным напоминанием

            mnuStopWatching.Text = "Возобновить";
        }

        void ResetWatch()
        {
            prevNetError = string.Empty;            
            PlayAlarm = true;
            prevPanic = false;
               
            WatchIP.StopWatch();
            System.Threading.Thread.Sleep(1000);
            if (!settings.LoadConfig())
            {
                //ошибка при загрузке конфигурации
                TrayIcons.TrayIcon(TrayIconType.Panic, niMain, false);
                niMain.Text = "Config Error!";
                niMain.ShowBalloonTip(5000, "Config Error!", settings.ConfigError,
                ToolTipIcon.Error);
                return;
             }
            WatchIP.StartWatch();
            mnuStopWatching.Text = "Остановить"; 
        }


        void WatchIP_FatalError(object sender)
        {
            CurrentIcon = TrayIconType.Panic;
            
            BeginInvoke((MethodInvoker)delegate
            {
                mnuMyIP.Enabled = false;
                mnuOthIP.Enabled = false;                

                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);
                niMain.Text = "Fatal error";
                niMain.ShowBalloonTip(5000, "Fatal Error",WatchIP.ErrorMessage,
                    ToolTipIcon.Error);
                CommonFunctions.ErrMessage(WatchIP.ErrorMessage);
                WatchIP.StopWatch();
            });
            
        }

        void WatchIP_ScriptWarnings(object sender, ScriptWarningsEventArgs e)
        {
            ScriptWarnings = true;

            BeginInvoke((MethodInvoker)delegate
            {                
                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);
                niMain.Text = 
                    CommonFunctions.CutTipText("Script warning: "+e.IP+" "+
                    e.ScriptMessage);
                niMain.ShowBalloonTip(5000, "Script warning!", e.ScriptMessage,
                    ToolTipIcon.Warning);
            });
        }

        private bool IsFormOpen(string FormName)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == FormName)
                {
                    f.Focus();
                    return true;
                }
            }
            return false;
        }

        #region okandstate
        void WatchIP_Connecting(object sender)
        {
            ScriptWarnings = false;
            CurrentIcon = TrayIconType.Connecting;

            BeginInvoke((MethodInvoker)delegate
            {
                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);
                niMain.Text = CommonFunctions.CutTipText(("Connecting...\n" + niMain.Text));
            });
        }

        void WatchIP_NewIP(object sender)
        {
            //новый IP, сбросим звуковое предупреждение
            //и паника если что будет новой
            PlayAlarm = true;
            prevPanic = false;

            //включаем пункты меню мой ip и другой ip
            BeginInvoke((MethodInvoker)delegate
                {
                    mnuMyIP.Enabled = true;
                    mnuOthIP.Enabled = true;
                });

            //всплывающее уведомление если надо оповещать о смене IP
            if (settings.ComNewIPMessage)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    niMain.ShowBalloonTip(5000, "Новый IP", WatchIP.IPShortInfo,
                        ToolTipIcon.Info);
                });
            }
        }

        void WatchIP_IPOK(object sender)
        {
            CurrentIcon = TrayIconType.OK;
            prevNetError = string.Empty;
            prevPanic = false;
            PlayAlarm = true;

            BeginInvoke((MethodInvoker)delegate
            {
                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);
                niMain.Text = CommonFunctions.CutTipText(WatchIP.IPShortInfo);
            });
        }
        #endregion

        #region networkerror
        void WatchIP_NetError(object sender)
        {
            prevPanic = false;
            //в любом случае устанавливаем серую иконку, текст подсказки
            //и отключаем пункты меню с информацией об IP
            CurrentIcon = TrayIconType.NoNetwork;
            BeginInvoke((MethodInvoker)delegate
            {
                mnuMyIP.Enabled = false;
                mnuOthIP.Enabled = false;
                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);                
                niMain.Text = CommonFunctions.CutTipText(WatchIP.ErrorMessage);
            });
            
            //ошибка уже была и была такая же, уходим
            if (prevNetError == WatchIP.ErrorMessage) return;
            else prevNetError = WatchIP.ErrorMessage;            

            //другая ошибка или первый раз
            //показываем balloon
            BeginInvoke((MethodInvoker)delegate
            {                
                niMain.ShowBalloonTip(5000, "Network Error!",
                    WatchIP.ErrorMessage, ToolTipIcon.Warning);             
            });

            //если надо - покажем окошко
            if (settings.ComNetErr == NetErrorMessage.Window)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    if (fPanicNet == null)
                    {
                        fPanicNet = new frmPanicNet();
                        fPanicNet.ErrorMessage = WatchIP.ErrorMessage;
                        fPanicNet.FormPanicNetClosed += new frmPanicNet.OnFormPanicNetClosed(fPanicNet_FormPanicNetClosed);
                        fPanicNet.Show();
                    }
                });                
            }
        }        

        void fPanicNet_FormPanicNetClosed(bool StopTracking)
        {
            fPanicNet.Dispose();
            fPanicNet = null;
            if (StopTracking)
            {
                UserStop(false);
            }
        }
        #endregion

        #region countryalarm
        void WatchIP_CountryAlarm(object sender, CountyAlarmEventArgs e)
        {
            
            prevNetError = string.Empty;            

            switch (settings.ComAlarmLevel)
            {
                //уровень паники
                case IPAlarmLevel.None: //вообще не реагировать
                    {
                        return;
                    }
                case IPAlarmLevel.OnlyWarning: //только предупреждение
                    {
                        CountryWarning(e.IP,e.Country,e.ISOCode);
                    }; break;
                case IPAlarmLevel.HTTP_HEADERS: //в заголовках HTTP
                    {
                        if (e.InHTTP_HEADERS||e.InOTHER) // если IP в заголовках HTTP (или скрипте, который не поддерживает разделение) - паника и предупреждение
                        {
                            CountryWarning(e.IP, e.Country, e.ISOCode);
                            CountryPanic(e.IP, e.Country, e.ISOCode);
                        }
                        else //иначе предупреждение
                        {
                            CountryWarning(e.IP, e.Country, e.ISOCode);
                        }
                    }; break;
                case IPAlarmLevel.REMOTE_ADDR: //в REMOTE_ADDR 
                    {
                        if (e.InREMOTE_ADDR||e.InOTHER)
                        {
                            CountryWarning(e.IP, e.Country, e.ISOCode);
                            CountryPanic(e.IP, e.Country, e.ISOCode);
                        }
                        else
                        {
                            CountryWarning(e.IP, e.Country, e.ISOCode);
                        }
                    }; break;
                case IPAlarmLevel.All: //везде - и паника и предупреждение
                    {
                        CountryWarning(e.IP, e.Country, e.ISOCode);
                        CountryPanic(e.IP, e.Country, e.ISOCode);
                    }; break;
            }

        }

        void CountryWarning(string IP, string Country, string ISOCode)
        {
            string msg = "Обнаружен IP нежелательной страны: " +
                    IP + " " + Country + " (" + ISOCode + ")";

            CurrentIcon = TrayIconType.Panic;
            BeginInvoke((MethodInvoker)delegate
            {
                TrayIcons.TrayIcon(CurrentIcon, niMain, ScriptWarnings);
                niMain.Text = CommonFunctions.CutTipText(msg);
                if (PlayAlarm)
                {
                    niMain.ShowBalloonTip(5000, "Нежелательный IP", msg, 
                        ToolTipIcon.Error);
                }
            });

            CommonFunctions.PlayAlarmSound(settings.ComAlarmSoundPath,
                Properties.Resources.panicsound,
                settings.ComAlarmSound && PlayAlarm);
            
            PlayAlarm = false;
        }
        
        void CountryPanic(string IP, string Country, string ISOCode)
        {
            //чтоб не паниковать подряд по поводу одной и той же страны
            if (prevPanic) return;
            else prevPanic = true;
            
            BeginInvoke((MethodInvoker)delegate
            {
                if (fPanic == null)
                {
                    fPanic = new frmPanic();
                    fPanic.PanicFormClosed += new frmPanic.OnPanicFormClosed(fPanic_PanicFormClosed);
                    fPanic.IP = IP;
                    fPanic.Country = Country + " (" + ISOCode + ")";
                    fPanic.Command = settings.ComRunCommand;
                    fPanic.Show();
                }
            });
        }

        void fPanic_PanicFormClosed(bool StopTracking)
        {
            fPanic.Dispose();
            fPanic = null;
            if (StopTracking)
            {
                UserStop(false);
            }
        }
        #endregion

        #region menuitems
        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (settings.ComCheckExit)
            {
                frmExit fExit = new frmExit();
                DialogResult Ans = fExit.ShowDialog();
                if (Ans == DialogResult.No) return;
                else
                {
                    settings.ComCheckExit = fExit.ComCheckExit;
                    if (!settings.SaveConfig())
                    {
                        CommonFunctions.ErrMessage(settings.ConfigError);
                    }
                }
            }

            Application.Exit();
        }

        private void mnuNetworkSettings_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmNetworkSettings")) return;

            frmNetworkSettings fNS = new frmNetworkSettings();
            fNS.ShowDialog();
            if (fNS.Chanded)
            {
                ResetWatch();
            }
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmCommonSettings")) return;

            frmCommonSettings fCS = new frmCommonSettings();
            fCS.ShowDialog();
            if (fCS.Changed)
            {
                ResetWatch();
            }
        }

        private void mnuMyIP_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmIPInfo")) return;

            frmIPInfo fII = new frmIPInfo();
            Informer inf = new Informer();
            object tmpDataSource = inf.GetIPInfo();
            if (tmpDataSource != null)
            {
                fII.TableDataSource = tmpDataSource;
                fII.Show();
            }
            else
            {
                CommonFunctions.ErrMessage(inf.ErrorMessage);
            }
        }

        private void mnuOthIP_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmInputIP")) return;

            frmInputIP fInpIP = new frmInputIP();
            fInpIP.ShowDialog();
            if (fInpIP.IPAddress != "")
            {
                frmIPInfo fII = new frmIPInfo();
                Informer inf = new Informer();
                object tmpDataSource = inf.GetIPInfo(fInpIP.IPAddress);
                if (tmpDataSource != null)
                {
                    fII.TableDataSource = tmpDataSource;
                    fII.Show();
                }
                else
                {
                    CommonFunctions.ErrMessage(inf.ErrorMessage);
                }
            }
        }

        private void mnuStopWatching_Click(object sender, EventArgs e)
        {
            if (WatchIP.Stopped)
            {
                ResetWatch();
                mnuStopWatching.Text = "Остановить";
            }
            else
            {
                UserStop(true);
            }            
        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            ResetWatch();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmAbout")) return;

            frmAbout fAbout = new frmAbout();
            fAbout.Show();
        }

        private void mnuTechinfo_Click(object sender, EventArgs e)
        {
            if (IsFormOpen("frmInfo")) return;

            frmInfo fInfo = new frmInfo();
            fInfo.DBPath = CommonFunctions.SxPath;
            fInfo.CurrentScript = settings.CurrentScriptAddr;
            fInfo.ShowDialog();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            CommonFunctions.ShowHelp();
        }
        #endregion
    }
}
