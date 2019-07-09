using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.IO;
using System.Windows.Forms;
using System.Data;
using SxGeoSharp;

namespace IPInformer2
{
    public enum SxGeoBaseType
    {
        SxGeoCity=0,
        SxGeoCountry=1,
        SxGeoNone=2
    }
    
    public static class CommonFunctions
    {        
        public static string SettingsPath = "";
        public static string NetSettingsFile = "network.xml";
        public static string AppSettingsFile = "settings.xml";
        public static string HelpFile = Application.StartupPath 
            + "\\help\\help.chm";
        public static bool NoPortable = false;

        public static string SxPath = "";
        public static string SxGeoDir = "SxGeo";
        public static string SxGeoCity = "SxGeoCity.dat";
        public static string SxGeoCountry = "SxGeo.dat";
        public static SxGeoBaseType SxGeoBase = SxGeoBaseType.SxGeoCountry;

        public static string CutTipText(string TipText)
        {
            const int MaxLen = 63;
            if (TipText.Length <= MaxLen)
            {
                return TipText;
            }
            else
            {
                TipText = TipText.Substring(0, MaxLen - 3);
                TipText = TipText + "...";
                return TipText;
            }
        }

        public static bool PlaySound(Stream stream)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(stream);
                player.Load();
                player.Play();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool PlaySound(string FileName)
        {
            if (string.IsNullOrEmpty(FileName)) return false;
            if (File.Exists(FileName))
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = FileName;
                try
                {
                    player.Load();
                    player.Play();
                }
                catch
                {
                    return false;
                }
            }
            else return false;

            return true;
        }

        //проигрывание звука при аларме по ip
        public static void PlayAlarmSound(string FileName, Stream Sound, bool Play)
        {
            if (!Play) return; //для выключения звука
            if (!PlaySound(FileName)) //пытаемся проиграть звук из файла
            {
                PlaySound(Sound); //не получилось - из потока Sound
            }
        }

        public static bool ValidateSxGeo()
        {
            //проверяем наличие БД SxGeo
            SxPath = AddSlash(AddSlash (SettingsPath) + SxGeoDir) + SxGeoCity;
            IPGeoinfo tmpGeoInfo = new IPGeoinfo(SxPath);
            if (tmpGeoInfo.IsValidSxGeoFile()) //SxGeoSity найдена и валидная
            {                
                SxGeoBase = SxGeoBaseType.SxGeoCity;
                return true;
            }
            else
            {
                SxPath = AddSlash(AddSlash(SettingsPath) + SxGeoDir) + SxGeoCountry;
                tmpGeoInfo = new IPGeoinfo(SxPath);
                if (tmpGeoInfo.IsValidSxGeoFile()) //SxGeoCountry найдена и валидная
                {
                    SxGeoBase = SxGeoBaseType.SxGeoCountry;
                    return true;
                }
                else
                {
                    SxGeoBase = SxGeoBaseType.SxGeoNone;
                    SxPath = string.Empty;
                    return false;
                }
            }
        }

        public static string AddSlash(string st)
        {
            if (st.EndsWith("\\"))
            {
                return st;
            }

            return st + "\\";
        }

        public static string CopyFile(string src, string dest)
        {
            FileInfo fi = new FileInfo(dest);
            if (!Directory.Exists(fi.DirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }
                catch (Exception ex)
                {
                    return "Ошибка " + ex.Message;
                }
            }

            try
            {
                File.Copy(src, dest, true);
            }
            catch (Exception ex)
            {
                return "Ошибка " + ex.Message;
            }

            return "Успешно скопирован.";
        }

        public static void ShowHelp()
        {
            if (!File.Exists(HelpFile))
            {
                MessageBox.Show("И чего тут непонятного?", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (!RunProcess.OpenProcess(HelpFile, "", true))
            {
                ErrMessage(RunProcess.ErrorMessage);
            }
        }

        public static void DelCfg()
        {
            try
            {
                File.Delete(SettingsPath + NetSettingsFile);
                File.Delete(SettingsPath + AppSettingsFile);
            }
            catch (Exception ex)
            {
                ErrMessage("Невозможно удалить файлы конфигурации!\n"+
                    ex.Message);
            }
        }
        
        public static void ErrMessage(string stMessage)
        {
            MessageBox.Show(stMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        

    }
}
