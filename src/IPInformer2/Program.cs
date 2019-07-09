using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IPInformer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] buf = Environment.GetCommandLineArgs(); //пкс
            List <string> cline = new List<string>();

            foreach (string s in buf)
            {
                cline.Add(s.ToLowerInvariant());
            }

            if (cline.Contains("/np")) //не портабельный режим
            {
                //данные в C:\Users\<пользователь>\AppData\Local\IPInformer2\
                CommonFunctions.SettingsPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
                    "\\IPInformer2\\";
                CommonFunctions.NoPortable = true;
            }
            else
            {
                //данные в папке с экзешником\data\
                CommonFunctions.SettingsPath = CommonFunctions.AddSlash(Application.StartupPath) +
                    "data\\";
                CommonFunctions.NoPortable = false;

            }

            if (cline.Contains("/?") || cline.Contains("/h") ||
                cline.Contains("/help") || cline.Contains("-help") ||
                cline.Contains("--help") || cline.Contains("-h"))
            {
                CommonFunctions.ShowHelp();
                return;
            }

            if (cline.Contains("/delcfg"))
            {
                CommonFunctions.DelCfg();

                return;
            }

            Application.Run(new frmMain());
        }
    }
}
