using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmNetworkSettings : Form
    {        
        public bool Chanded = false;
        FormWorker formWorker = null;
        NetSettings settings = new NetSettings(CommonFunctions.SettingsPath +
            CommonFunctions.NetSettingsFile);

        public frmNetworkSettings()
        {
            InitializeComponent();
        }

        private void frmNetworkSettings_Load(object sender, EventArgs e)
        {            
            NetConfigStatus cstat = settings.LoadConfig();
            if (cstat==NetConfigStatus.Error)
            {
                MessageBox.Show("Файл конфигурации поврежден!\n"+
                    settings.ConfigError,
                    "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            formWorker = new FormWorker(settings, this);
            formWorker.FillForm();

            if (cstat == NetConfigStatus.ProxyPassNotDecrypted)
            {
                txtProxyPassword.Text = "";
                lblErrorMessage.Text = "Сохраненный пароль не был расшифрован.";
            }                        
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }            
        }
        private void txtTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }            
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {

            btnSystemProxy.Enabled = rbConnectionTypeSystemProxy.Checked;
            grpProxy.Enabled = rbConnectionTypeManualProxy.Checked;            
        }
        

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowChars.Checked)
            {
                txtProxyPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtProxyPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (Int32.TryParse(txtProxyPort.Text, out tmp))
            {
                if (tmp > 65535)
                {
                    lblErrorMessage.Text = "Порт должен быть не больше 65535";                        
                    return;
                }
            }
            else
            {
                lblErrorMessage.Text ="Номер порта задан неверно!";                    
                return;
            }
            
            if (Int32.TryParse(txtConnectionTimeout.Text, out tmp))
            {
                if (tmp > 55999)
                {
                    lblErrorMessage.Text ="Таймаут соединения должен быть не больше 55999";
                    return;
                }
            }
            else
            {
                lblErrorMessage.Text = "Таймаут задан неверно!";
                return;
            }

            if (rbConnectionTypeManualProxy.Checked)
            {
                if (txtProxyAddress.Text.Trim() == string.Empty)
                {
                    lblErrorMessage.Text = "Не задан адрес прокси!";
                    return;
                }

                if ((txtProxyPassword.Text != string.Empty) &&
                    (txtProxyUser.Text == string.Empty))
                {
                    lblErrorMessage.Text = "Не указано имя пользователя, но указан пароль!";
                    return;
                }
            }

            formWorker.GetData();

            if (!settings.SaveConfig())
            {
                lblErrorMessage.Text ="Не удалось сохранить настройки! \n";
                return;
            }

            Chanded = true;
            this.Close();
        }                

        private void btnSystemProxy_Click(object sender, EventArgs e)
        {
            NetSettings.ShowSystemProxyWindow();
        }

        
    }
}
