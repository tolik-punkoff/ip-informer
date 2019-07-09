using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace IPInformer2
{
    public static class DataLoader
    {
        public static string ErrorMessage { get; private set; }

        //загружает в DataSet CSV без заголовков
        //колонки передаются в соотв. переменной, через ';'
        public static bool LoadCSV(string FileName, char divider, DataSet ds, string TableName, string Colonums)
        {
            string[] data = null;
            try //читаем файл
            {
                data = File.ReadAllLines(FileName);
            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
                return false;
            }

            if (data.Length == 0)
            {
                ErrorMessage="Нет данных в файле " + FileName;
                return false;
            }

            ds.Tables.Add(TableName); //добавляем таблицу в DataSet
            string[] cols = Colonums.Split(';');
            foreach (string col in cols) //колонки тоже добавляем
            {
                ds.Tables[TableName].Columns.Add(col);
            }

            int stringscount = 0;
            foreach (string str in data) //пробегаем по массиву с данными
            {
                stringscount++;
                if (str.Trim() != String.Empty) //если строка не пустая
                {
                    string[] records = str.Trim().Split(divider); //делим CSV-строки на записи
                    if (records.Length == ds.Tables[TableName].Columns.Count) //если строк столько же, сколько колонок
                    { //в таблице - добавляем
                        try
                        {
                            ds.Tables[TableName].Rows.Add(records); //кидаем в нужную таблицу
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage=ex.Message;
                            return false;
                        }
                    }
                    else //иначе строка не соответствует формату (больше или меньше записей чем надо)
                    {
                        ErrorMessage="Ошибка формата в строке " + stringscount.ToString();
                        return false;
                    }
                }
            }

            if (ds.Tables[TableName].Rows.Count == 0)
            {
                ErrorMessage = "Нет данных в файле " + FileName;
                return false;
            }

            return true;
        }

        //CSV из строки
        public static bool LoadCSVString(string CSVData, char divider, DataSet ds, string TableName, string Colonums)
        {
            string[] data = null;
            
            //разбиваем строку по переводу строк
            CSVData = CSVData.Replace("\r","");
            data = CSVData.Split('\n');
            
            if (data.Length == 0)
            {
                ErrorMessage = "Нет данных";
                return false;
            }

            ds.Tables.Add(TableName); //добавляем таблицу в DataSet
            string[] cols = Colonums.Split(';');
            foreach (string col in cols) //колонки тоже добавляем
            {
                ds.Tables[TableName].Columns.Add(col);
            }

            int stringscount = 0;
            foreach (string str in data) //пробегаем по массиву с данными
            {
                stringscount++;
                if (str.Trim() != String.Empty) //если строка не пустая
                {
                    string[] records = str.Trim().Split(divider); //делим CSV-строки на записи
                    if (records.Length == ds.Tables[TableName].Columns.Count) //если строк столько же, сколько колонок
                    { //в таблице - добавляем
                        try
                        {
                            ds.Tables[TableName].Rows.Add(records); //кидаем в нужную таблицу
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = ex.Message;
                            return false;
                        }
                    }
                    else //иначе строка не соответствует формату (больше или меньше записей чем надо)
                    {
                        ErrorMessage = "Ошибка формата в строке " + stringscount.ToString();
                        return false;
                    }
                }
            }

            if (ds.Tables[TableName].Rows.Count == 0)
            {
                ErrorMessage = "Нет данных";
                return false;
            }

            return true;
        }
    }
}
