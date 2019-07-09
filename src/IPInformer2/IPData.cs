using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using SxGeoSharp;

namespace IPInformer2
{    
    public class IPData
    {        
        public DataSet dsIP = new DataSet();

        private Dictionary<string, string> Fields = new Dictionary<string, string>();
        private static string StartData = "---START-DATA---\n";
        private static string EndData = "---END-DATA---\n";
        private static char LineBreak = '\n';

        public string ErrorMessage { get; private set; }

        public IPData()
        {
            CreateDataSet();            
        }

        private void CreateDataSet()
        {            
            //вытаскиваем поля и строим таблицу DataSet
            IPGeoinfo tmpGeoInfo = new IPGeoinfo(CommonFunctions.SxPath);
            tmpGeoInfo.Open();
            Dictionary<string,Type> Fields = tmpGeoInfo.GetAllFields();
            Fields.Add("field", typeof(string));
            tmpGeoInfo.Close();

            dsIP.Tables.Add("Info");
            dsIP.Tables["Info"].Columns.Add("Parameter", typeof(string));
            dsIP.Tables["Info"].Columns.Add("Data", typeof(string));

            dsIP.Tables.Add("IP");
            foreach (string key in Fields.Keys)
            {
                dsIP.Tables["IP"].Columns.Add(key, Fields[key]);
            }            
        }

        private bool DumpToDataSet(DataSet ds, string TableName, string[] Data, char Divider)
        {
            IPGeoinfo GeoInfo = new IPGeoinfo(CommonFunctions.SxPath);
            if (!GeoInfo.Open())
            {
                ErrorMessage = GeoInfo.ErrorMessage;
                return false;
            }
            ds.Tables[TableName].Rows.Clear();
            foreach (string rec in Data) //обходим массив входных строк
            {
                if (rec.Trim() != string.Empty)
                {
                    string[] val = rec.Split(Divider); //разделяем строки на составляющие части
                    string IP = "";
                    string Field = "";
                    try
                    {
                        IP = val[0];
                        Field = val[1];
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        GeoInfo.Close();
                        return false;
                    }

                    // вытаскиваем из БД информацию об IP
                    Dictionary<string, object> IPInfo = GeoInfo.GetIPInfo(IP);

                    //раскладываем ее в DataSet
                    try
                    {
                        DataRow dr = ds.Tables[TableName].Rows.Add();
                        foreach (string Key in IPInfo.Keys)
                        {                            
                            dr[Key] = IPInfo[Key];
                        }
                        dr["Field"] = Field;
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        GeoInfo.Close();
                        return false;
                    }
                }
            }

            GeoInfo.Close();
            return true;
        }

        private string[] GetStrings(string RawData)
        {
            string[] ret = null;

            if (RawData.Trim() == String.Empty)
            {
                ErrorMessage = "Cтрока пуста";
                return ret;
            }

            if (RawData.StartsWith("IPINF031")) //наш скрипт с IP
            {
                int start = RawData.IndexOf(StartData);
                if (start == -1) //данные повреждены, не найден маркер начала
                {
                    ErrorMessage = "Данные повреждены, не найден маркер начала сообщения";
                    return ret;
                }

                int end = RawData.IndexOf(EndData);
                if (end == -1) //данные повреждены, не найден маркер конца
                {
                    ErrorMessage = "Данные повреждены, не найден маркер конца сообщения";
                    return ret;
                }

                RawData = RawData.Substring((start + StartData.Length), end - (start + StartData.Length));

                ret = RawData.Split(LineBreak);
            }
            else //скрипт откуда угодно
            {
                //распарсить и найти все IP
                ret=ParseIPs(RawData);
            }

            return ret;
        }

        public bool FillIPTable(string RawData)
        {
            string[] Data = GetStrings(RawData);
            if (Data == null) return false;

            if (!DumpToDataSet(dsIP, "IP", Data, '|')) return false;
            
            return true;
        }

        public void FillInfoTable()
        {
            foreach (DataRow dr in dsIP.Tables["IP"].Rows)
            {
                foreach (DataColumn dcol in dsIP.Tables["IP"].Columns)
                {
                    string key = dcol.ColumnName;
                    string parameter = "";
                    string value = "";
                    if (Fields.ContainsKey(key))
                    {
                        parameter = Fields[key];
                    }
                    else
                    {
                        parameter = key;
                    }
                    value = dr[key].ToString();

                    dsIP.Tables["Info"].Rows.Add(key, value);
                }
            }
        }

        private string[] ParseIPs(string RawData)
        {
            string[] ret = null;
            
            string IPRegexp=@"(25[0-5]|2[0-4]\d|[01]?\d\d?)(\.(25[0-5]|2[0-4]\d|[01]?\d\d?)){3}";
            Regex regex = new Regex(IPRegexp);
            List<string> buf = new List<string>();

            MatchCollection matches = regex.Matches(RawData);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string s = match.Value + "|OTHER";
                    if (!buf.Contains(s))
                    {
                        buf.Add(s);
                    }
                }
                ret = buf.ToArray();
            }
            
            return ret;
        }

    }
}
