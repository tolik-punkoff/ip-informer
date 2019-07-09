using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SxGeoSharp;

namespace IPInformer2
{
    public partial class frmCommonSettings : Form
    {
        public bool Changed = false;
        private FormWorker fWorker = null;
        private appSettings settings = null;
        
        public frmCommonSettings()
        {
            InitializeComponent();
        }

        private void frmCommonSettings_Load(object sender, EventArgs e)
        {
            settings = new appSettings(CommonFunctions.SettingsPath + 
                CommonFunctions.AppSettingsFile);

            if (!settings.LoadConfig())
            {
                CommonFunctions.ErrMessage(settings.ConfigError);
                return;
            }
            fWorker = new FormWorker(settings, this);
            fWorker.FillForm();
        }

        private void chkSoundAlarm_CheckedChanged(object sender, EventArgs e)
        {
            btnSoundPlay.Enabled = btnSoundFile.Enabled =
                btnEmbedSound.Enabled = chkComAlarmSound.Checked;
        }

        private void btnSoundFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = dlgOpenSound.ShowDialog();
            if (dr == DialogResult.Cancel) return;
            txtComAlarmSoundPath.Text = dlgOpenSound.FileName;
        }

        private void btnSoundPlay_Click(object sender, EventArgs e)
        {
            if (txtComAlarmSoundPath.Text != "")
            {
                CommonFunctions.PlaySound(txtComAlarmSoundPath.Text);
            }
            else
            {
                CommonFunctions.PlaySound(Properties.Resources.panicsound);
            }
        }

        private void btnStopCountry_Click(object sender, EventArgs e)
        {
            frmStopList fsl = new frmStopList();
            fsl.StopList = settings.GetStopList();
            fsl.ShowDialog();
            if (fsl.Chanded)
            {
                settings.CreateStopList(fsl.StopList);

                if (!settings.SaveConfig())
                {
                    CommonFunctions.ErrMessage(settings.ConfigError);
                    return;
                }
                
                Changed = true;
            }
        }

        private void btnAutostart_Click(object sender, EventArgs e)
        {
            try
            {
                StartupProgramm.AddToStartup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Описание ошибки: " + ex.Message,
                    "Ошибка создания ярлыка автозагрузки", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Создан ярлык в автозагрузке текущего пользователя",
                 "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtComTimeInterval.Text.Trim() == string.Empty)
            {
                txtComTimeInterval.Text = "1";
            }

            int cti = 0;
            try
            {
                cti=Convert.ToInt32(txtComTimeInterval.Text);
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage("Время опроса скрипта:\n" + ex.Message);
                return;
            }

            if ( cti <= 0)
            {
                txtComTimeInterval.Text = "1";
            }

            if (settings.GetScriptsList().Count == 0)
            {
                CommonFunctions.ErrMessage("Скрипты не добавлены. \n"+
                    "Добавьте хотя бы один скрипт!");
                return;
            }
            
            if (!fWorker.GetData())
            {
                CommonFunctions.ErrMessage(fWorker.ErrorMessage);
                return;
            }
            if (!settings.SaveConfig())
            {
                CommonFunctions.ErrMessage(settings.ConfigError);
                return;
            }
            
            Changed = true;
            this.Close();
        }

        private void txtTimeInterval_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnEmbedSound_Click(object sender, EventArgs e)
        {
            txtComAlarmSoundPath.Text = string.Empty;
        }

        private void btnUptateSxGeo_Click(object sender, EventArgs e)
        {
            DialogResult Ans = dlgOpenSxG.ShowDialog();
            if (Ans == DialogResult.Cancel) return;
            string ResultMess = "";
            string srcpath = CommonFunctions.AddSlash(dlgOpenSxG.SelectedPath)
                + CommonFunctions.SxGeoCountry;
            string dstpath = CommonFunctions.AddSlash(CommonFunctions.AddSlash(
                CommonFunctions.SettingsPath) +
                CommonFunctions.SxGeoDir) + CommonFunctions.SxGeoCountry;

            //ищем файл SxGeoCountry
            IPGeoinfo tmpGeoInfo = new IPGeoinfo(srcpath);
            if (tmpGeoInfo.IsValidSxGeoFile())
            {
                ResultMess = "Файл " + CommonFunctions.SxGeoCountry + " найден. \n"
                    + CommonFunctions.CopyFile(srcpath, dstpath) + "\n";
            }
            else
            {
                ResultMess = "Файл " + CommonFunctions.SxGeoCountry + ": "
                    + tmpGeoInfo.ErrorMessage + "\n";
            }

            //ищем файл SxGeoCity
            srcpath = CommonFunctions.AddSlash(dlgOpenSxG.SelectedPath)
                + CommonFunctions.SxGeoCity;
            dstpath = CommonFunctions.AddSlash(CommonFunctions.AddSlash
                (CommonFunctions.SettingsPath) +
                CommonFunctions.SxGeoDir) + CommonFunctions.SxGeoCity;

            tmpGeoInfo = new IPGeoinfo(srcpath);
            if (tmpGeoInfo.IsValidSxGeoFile())
            {
                ResultMess = ResultMess + "Файл " + CommonFunctions.SxGeoCity + " найден. \n"
                    + CommonFunctions.CopyFile(srcpath, dstpath);
            }
            else
            {
                ResultMess = ResultMess + "Файл " + CommonFunctions.SxGeoCity + ": "
                    + tmpGeoInfo.ErrorMessage;
            }

            CommonFunctions.ValidateSxGeo();

            MessageBox.Show(ResultMess, "Результат обновления",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnScripts_Click(object sender, EventArgs e)
        {
            frmScripts fScripts = new frmScripts();
            fScripts.Scripts = settings.GetScriptsList();
            fScripts.ShowDialog();
            if (fScripts.Changed)
            {
                settings.CreateScriptsList(fScripts.Scripts);

                if (!settings.SaveConfig())
                {
                    CommonFunctions.ErrMessage(settings.ConfigError);
                    return;
                }

                Changed = true;
            }
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            DialogResult Ans =
                MessageBox.Show("Вы действительно хотите сбросить настройки?",
                "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Ans == DialogResult.No) return;

            CommonFunctions.DelCfg();
            Changed = true;
            this.Close();
        }
        
    }
}
