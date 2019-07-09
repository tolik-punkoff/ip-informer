using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmPanic : Form
    {
        public string IP = "";
        public string Country = "";        
        public string Command = "";
        
        public delegate void OnPanicFormClosed(bool StopTracking);
        public event OnPanicFormClosed PanicFormClosed;

        public frmPanic()
        {
            InitializeComponent();
        }

        private void RunCommand()
        {
            if (Command.Trim() != String.Empty)
            {
                ProcessCommand com = RunProcess.GetCommandAndArguments(Command);
                if (com.IsWrong())
                {
                    lblCmdMessage.Text = "Ошибка в команде " + Command;
                }
                else
                {
                    if (RunProcess.OpenProcess("\"" + com.Command + "\"", com.Arguments,false))
                    {
                        lblCmdMessage.Text = "Команда " + Command + " выполнена";
                    }
                    else
                    {
                        lblCmdMessage.Text = "Команда " + Command + " не выполнена";
                    }
                }
            }
            else
            {
                lblCmdMessage.Text = "";
            }
        }
                

        private void frmPanic_Load(object sender, EventArgs e)
        {            
            this.BackColor = Color.Red;
            lblWrn.ForeColor = Color.White;

            lblIP.Text = IP;                
            lblCountry.Text = Country;                
            RunCommand();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (PanicFormClosed != null) PanicFormClosed(false);
            this.Close();
        }

        private void btnEndTracking_Click(object sender, EventArgs e)
        {
            if (PanicFormClosed != null) PanicFormClosed(true);
            this.Close();
        }
    }
}
