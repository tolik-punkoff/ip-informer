using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmInputIP : Form
    {
        public string IPAddress = "";
        public frmInputIP()
        {
            InitializeComponent();
        }
                
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IPAddress = ipAddr.Text;
            this.Close();
        }

        private void ipAddr_KeyUp(object sender, KeyEventArgs e)
        //в IP-аддресс контроле по умолчанию не работает вставка и копирование
        //тут исправление
        {
            IDataObject iData = Clipboard.GetDataObject();//получаем объект из клипборда

            if (e.Control) //детектим нажатый контрол
            {
                if (e.KeyValue == 86) //ctrl+v
                {
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        ipAddr.Text = (String)iData.GetData(DataFormats.Text);//вставляем данные из клипборда в контрол
                        //проверка на валидность работает нормально
                    }
                }
                if (e.KeyValue == 67) //ctrl+c
                {
                    Clipboard.SetText(ipAddr.Text);
                }
                if (e.KeyValue == 88) //ctrl+x
                {
                    Clipboard.SetText(ipAddr.Text);
                    ipAddr.Text = "";
                }
                if (e.KeyValue == 46) //ctrl+del
                {
                    ipAddr.Text = "";
                }
            }
            if (e.Shift) //детектим нажатый шифт
            {
                if (e.KeyValue == 45) //shift+ins
                {
                    ipAddr.Text = (String)iData.GetData(DataFormats.Text); //аналогично вышеизложенному
                }
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ipAddr.Text);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();//получаем объект из клипборда
            if (iData.GetDataPresent(DataFormats.Text))
            {
                ipAddr.Text = (String)iData.GetData(DataFormats.Text);//вставляем данные из клипборда в контрол
                //проверка на валидность работает нормально
            }
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ipAddr.Text);
            ipAddr.Text = "";
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            ipAddr.Text = "";
        }
    }
}
