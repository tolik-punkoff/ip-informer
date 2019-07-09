using System;
using System.Collections.Generic;
using System.Text;
using vbAccelerator.Components.Shell;
using System.Windows.Forms;

namespace IPInformer2
{
    public static class StartupProgramm
    {
        public static void AddToStartup()
        {
            string StartupDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Startup);
            string LNKName = "\\IPInformer.lnk";
            string Target = Application.ExecutablePath;
            string WorkDir = Application.StartupPath;

            ShellLink shortcut = new ShellLink();
            shortcut.ShortCutFile = StartupDirectory + LNKName;
            shortcut.Target = Target;
            shortcut.WorkingDirectory = WorkDir;
            shortcut.IconPath = Target;
            shortcut.IconIndex = 0;
            shortcut.Description = "IP Informer";
            if (CommonFunctions.NoPortable)
            {
                shortcut.Arguments = "/np";
            }
            else
            {
                shortcut.Arguments = "";
            }
            shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
            shortcut.Save();
        }
    }
}
