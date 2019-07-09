using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace IPInformer2
{
    public struct ProcessCommand
    {
        public string Command;
        public string Arguments;

        public bool IsWrong()
        {
            return string.IsNullOrEmpty(Command);
        }
    }
    public static class RunProcess
    {
        public static string ErrorMessage { get; private set; }
        
        public static ProcessCommand GetCommandAndArguments(string ca)
        {
            ProcessCommand ret = new ProcessCommand();
            ca = ca.Trim();
            if (ca.StartsWith("\"")) //если строка стартовала с кавычки - ищем вторую, посреди команда
            {
                //вытащили команду
                int endc = ca.LastIndexOf('"');
                if (endc == 0)
                {
                    return ret;
                }
                ret.Command = ca.Substring(1, endc - 1);
                //и параметры
                ret.Arguments = ca.Substring(endc + 1, ca.Length - endc - 1).Trim();
            }
            else //иначе ищем первый пробел
            {
                int endc = ca.IndexOf(' ');
                if (endc == -1) //команда без аргументов
                {
                    ret.Command = ca;
                    ret.Arguments = string.Empty;
                }
                else //с аргументами
                {
                    ret.Command = ca.Substring(0, ca.Length - endc + 1);
                    ret.Arguments = ca.Substring(endc + 1, ca.Length - endc - 1);
                }
            }

            return ret;
        }

        public static bool OpenProcess(string proc, string arg, bool ShellEx)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = proc;
            psi.Arguments = arg;
            psi.UseShellExecute = ShellEx;
            
            try
            {
                Process.Start(proc, arg);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }


    }
}
