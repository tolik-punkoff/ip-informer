using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;

namespace IPInformer2
{
    #region common_enums
    public enum IPAlarmLevel
    {
        All = 0,
        REMOTE_ADDR = 1,
        HTTP_HEADERS = 2,
        OnlyWarning =3,
        None = 4
    }
    public enum TimeUnits
    {
        Secounds = 0,
        Minutes = 1
    }
    public enum NetErrorMessage
    {
        Window = 0,
        Baloon = 1
    }
    public enum ScriptChangeType
    {
        OnlyFirst=0,
        ChangeIfError=1
    }
    #endregion
    public class appSettings
    {
        public IPAlarmLevel ComAlarmLevel {get; set;} //уровень оповещения
        public TimeUnits ComTime { get; set; } //единицы измерения интервала
        public NetErrorMessage ComNetErr { get; set; } //что показывать при сбое сети
        public ScriptChangeType ComScriptChange { get; set; } //смена скриптов
        public int ComTimeInterval { get; set; }
        public bool ComAlarmSound { get; set; }
        public bool ComNewIPMessage { get; set; }
        public bool ComCheckExit { get; set; }
        public string ComAlarmSoundPath { get; set; }
        public string ComRunCommand { get; set; }

        public string CurrentScriptAddr { get; private set; }
        public string ConfigError { get; private set; }
        
        private string TableName = "";
        private string configFile = "";
        private DataSet dsConfig = new DataSet();
        private int CurrentScriptNum = 0;

        public appSettings(string filename)
        {
            configFile = filename;
            TableName = this.GetType().Name;
            CreateDataSet();
            string s = Path.GetDirectoryName(filename);
            try
            {
                Directory.CreateDirectory(s);
            }
            catch { }

            ComAlarmLevel = IPAlarmLevel.All;
            ComTime = TimeUnits.Minutes;
            ComNetErr = NetErrorMessage.Window;
            ComTimeInterval = 1;
            ComAlarmSound = false;            
            ComCheckExit = true;            
            ComAlarmSoundPath = "";
            ComRunCommand = "";

        }

        private bool CreateDefaultConfig(string FileName)
        {
            try
            {
                File.WriteAllText(FileName,
                    Properties.Resources.main_def);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }

            return true;
        }

        public bool LoadConfig()
        {
            //файла нет, создаем конфиг по умолчанию
            if (!File.Exists(configFile))
            {
                if (!CreateDefaultConfig(configFile))
                {                    
                    return false;
                }
            }

            //почистим таблицы DataSet перед загрузкой
            foreach (DataTable table in dsConfig.Tables)
            {
                table.Rows.Clear();
            }

            //файл есть, пробуем загрузить в DataSet
            try
            {
                dsConfig.ReadXml(configFile);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }

            //загрузка полей класса из DataSet
            if (dsConfig.Tables[TableName].Rows.Count > 0)
            {
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo pr in properties)
                {
                    string propName = pr.Name;
                    object propValue = dsConfig.Tables[TableName].Rows[0][propName];
                    if (propValue.GetType() != typeof(System.DBNull))
                    {
                        pr.SetValue(this, propValue, null);
                    }
                }                
            }
            
            //загружаем первый адрес из списка скриптов
            if (dsConfig.Tables["ScriptsList"].Rows.Count > 0)
            {
                CurrentScriptAddr =
                    dsConfig.Tables["ScriptsList"].Rows[0][0].ToString();
                CurrentScriptNum = 0;
            }
            else
            {
                ConfigError = "No script address!";
                return false;
            }
            return true;
        }

        public bool SaveConfig()
        {         
            ConfigError = null;
            CurrentScriptAddr = null;

            dsConfig.Tables[TableName].Rows.Clear();
            DataRow dr = dsConfig.Tables[TableName].NewRow();


            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo pr in properties)
            {
                string propName = pr.Name;
                object propValue = pr.GetValue(this, null);
                dr[propName] = propValue;
            }

            dsConfig.Tables[TableName].Rows.Add(dr);

            try
            {
                dsConfig.WriteXml(configFile);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }

            return true;
        }

        private void CreateDataSet()
        {
            dsConfig.Tables.Add(TableName);

            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (PropertyInfo pr in properties)
            {
                dsConfig.Tables[TableName].Columns.Add(pr.Name, pr.PropertyType);
            }

            dsConfig.Tables.Add("StopList");
            dsConfig.Tables["StopList"].Columns.Add("ISO", typeof(string));
            dsConfig.Tables["StopList"].Columns.Add("Country", typeof(string));
            dsConfig.Tables["StopList"].Columns["ISO"].Unique = true;

            dsConfig.Tables.Add("ScriptsList");
            dsConfig.Tables["ScriptsList"].Columns.Add("URL", typeof(string));
            dsConfig.Tables["ScriptsList"].Columns["URL"].Unique = true;
        }

        public void ClearStopList()
        {
            dsConfig.Tables["StopList"].Rows.Clear();
        }

        public void ClearScriptsList()
        {
            dsConfig.Tables["ScriptsList"].Rows.Clear();
        }

        public bool AddStopCountry(string ISO, string Country)
        {
            try
            {
                dsConfig.Tables["StopList"].Rows.Add(ISO, Country);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }
            return true;
        }

        public bool AddScript(string URL)
        {
            try
            {
                dsConfig.Tables["ScriptsList"].Rows.Add(URL);
            }
            catch (Exception ex)
            {
                ConfigError = ex.Message;
                return false;
            }
            return true;
        }
        
        public bool CreateStopList(Dictionary<string, string> stoplist)
        {
            ClearStopList();

            foreach (KeyValuePair<string, string> kvp in stoplist)
            {
                if (!AddStopCountry(kvp.Key, kvp.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CreateScriptsList(List<string> scriptslist)
        {
            ClearScriptsList();

            foreach (string item in scriptslist)
            {
                if (!AddScript(item))
                {
                    return false;
                }
            }
            return true;
        }

        public Dictionary<string, string> GetStopList()
        {
            Dictionary<string, string> result = new Dictionary<string,string>();

            foreach (DataRow dr in dsConfig.Tables["StopList"].Rows)
            {
                result.Add(dr["ISO"].ToString(), dr["Country"].ToString());
            }

            return result;
        }

        public List<string> GetScriptsList()
        {
            List<string> result = new List<string>();

            foreach (DataRow dr in dsConfig.Tables["ScriptsList"].Rows)
            {
                result.Add(dr["URL"].ToString());
            }

            return result;
        }

        public void SetNextScript()
        {
            if (dsConfig.Tables["ScriptsList"].Rows.Count > 0)
            {
                if (CurrentScriptNum == dsConfig.Tables["ScriptsList"].Rows.Count - 1)
                {
                    CurrentScriptNum = 0;
                }
                else
                {
                    CurrentScriptNum++;
                }
                CurrentScriptAddr =
                    dsConfig.Tables["ScriptsList"].Rows[CurrentScriptNum][0]
                    .ToString();
            }
        }
    }
}
