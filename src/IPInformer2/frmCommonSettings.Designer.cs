namespace IPInformer2
{
    partial class frmCommonSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommonSettings));
            this.grpSignal = new System.Windows.Forms.GroupBox();
            this.rbComAlarmLevelNone = new System.Windows.Forms.RadioButton();
            this.rbComAlarmLevelOnlyWarning = new System.Windows.Forms.RadioButton();
            this.rbComAlarmLevelHTTP_HEADERS = new System.Windows.Forms.RadioButton();
            this.rbComAlarmLevelREMOTE_ADDR = new System.Windows.Forms.RadioButton();
            this.rbComAlarmLevelAll = new System.Windows.Forms.RadioButton();
            this.chkComAlarmSound = new System.Windows.Forms.CheckBox();
            this.txtComAlarmSoundPath = new System.Windows.Forms.TextBox();
            this.btnSoundFile = new System.Windows.Forms.Button();
            this.btnSoundPlay = new System.Windows.Forms.Button();
            this.txtComRunCommand = new System.Windows.Forms.TextBox();
            this.btnStopCountry = new System.Windows.Forms.Button();
            this.btnAutostart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblRun = new System.Windows.Forms.Label();
            this.chkComCheckExit = new System.Windows.Forms.CheckBox();
            this.dlgOpenSound = new System.Windows.Forms.OpenFileDialog();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.rbComTimeMinutes = new System.Windows.Forms.RadioButton();
            this.rbComTimeSecounds = new System.Windows.Forms.RadioButton();
            this.txtComTimeInterval = new System.Windows.Forms.TextBox();
            this.grpNetErr = new System.Windows.Forms.GroupBox();
            this.rbComNetErrBaloon = new System.Windows.Forms.RadioButton();
            this.rbComNetErrWindow = new System.Windows.Forms.RadioButton();
            this.lblPanicInfo = new System.Windows.Forms.Label();
            this.chkComNewIPMessage = new System.Windows.Forms.CheckBox();
            this.btnEmbedSound = new System.Windows.Forms.Button();
            this.btnUptateSxGeo = new System.Windows.Forms.Button();
            this.dlgOpenSxG = new System.Windows.Forms.FolderBrowserDialog();
            this.btnScripts = new System.Windows.Forms.Button();
            this.grpScripts = new System.Windows.Forms.GroupBox();
            this.rbComScriptChangeChangeIfError = new System.Windows.Forms.RadioButton();
            this.rbComScriptChangeOnlyFirst = new System.Windows.Forms.RadioButton();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.grpSignal.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.grpNetErr.SuspendLayout();
            this.grpScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSignal
            // 
            this.grpSignal.Controls.Add(this.rbComAlarmLevelNone);
            this.grpSignal.Controls.Add(this.rbComAlarmLevelOnlyWarning);
            this.grpSignal.Controls.Add(this.rbComAlarmLevelHTTP_HEADERS);
            this.grpSignal.Controls.Add(this.rbComAlarmLevelREMOTE_ADDR);
            this.grpSignal.Controls.Add(this.rbComAlarmLevelAll);
            this.grpSignal.Location = new System.Drawing.Point(4, 4);
            this.grpSignal.Name = "grpSignal";
            this.grpSignal.Size = new System.Drawing.Size(464, 89);
            this.grpSignal.TabIndex = 0;
            this.grpSignal.TabStop = false;
            this.grpSignal.Text = "Cигнализировать об опасности при обнаружении IP стоп-страны:";
            // 
            // rbComAlarmLevelNone
            // 
            this.rbComAlarmLevelNone.AutoSize = true;
            this.rbComAlarmLevelNone.Location = new System.Drawing.Point(133, 42);
            this.rbComAlarmLevelNone.Name = "rbComAlarmLevelNone";
            this.rbComAlarmLevelNone.Size = new System.Drawing.Size(172, 17);
            this.rbComAlarmLevelNone.TabIndex = 3;
            this.rbComAlarmLevelNone.Text = "Не сигнализировать вообще";
            this.rbComAlarmLevelNone.UseVisualStyleBackColor = true;
            // 
            // rbComAlarmLevelOnlyWarning
            // 
            this.rbComAlarmLevelOnlyWarning.AutoSize = true;
            this.rbComAlarmLevelOnlyWarning.Location = new System.Drawing.Point(134, 19);
            this.rbComAlarmLevelOnlyWarning.Name = "rbComAlarmLevelOnlyWarning";
            this.rbComAlarmLevelOnlyWarning.Size = new System.Drawing.Size(150, 17);
            this.rbComAlarmLevelOnlyWarning.TabIndex = 2;
            this.rbComAlarmLevelOnlyWarning.Text = "Только предупреждение";
            this.rbComAlarmLevelOnlyWarning.UseVisualStyleBackColor = true;
            // 
            // rbComAlarmLevelHTTP_HEADERS
            // 
            this.rbComAlarmLevelHTTP_HEADERS.AutoSize = true;
            this.rbComAlarmLevelHTTP_HEADERS.Location = new System.Drawing.Point(8, 65);
            this.rbComAlarmLevelHTTP_HEADERS.Name = "rbComAlarmLevelHTTP_HEADERS";
            this.rbComAlarmLevelHTTP_HEADERS.Size = new System.Drawing.Size(125, 17);
            this.rbComAlarmLevelHTTP_HEADERS.TabIndex = 1;
            this.rbComAlarmLevelHTTP_HEADERS.Text = "В заголовках HTTP";
            this.rbComAlarmLevelHTTP_HEADERS.UseVisualStyleBackColor = true;
            // 
            // rbComAlarmLevelREMOTE_ADDR
            // 
            this.rbComAlarmLevelREMOTE_ADDR.AutoSize = true;
            this.rbComAlarmLevelREMOTE_ADDR.Location = new System.Drawing.Point(8, 42);
            this.rbComAlarmLevelREMOTE_ADDR.Name = "rbComAlarmLevelREMOTE_ADDR";
            this.rbComAlarmLevelREMOTE_ADDR.Size = new System.Drawing.Size(118, 17);
            this.rbComAlarmLevelREMOTE_ADDR.TabIndex = 1;
            this.rbComAlarmLevelREMOTE_ADDR.Text = "В REMOTE_ADDR";
            this.rbComAlarmLevelREMOTE_ADDR.UseVisualStyleBackColor = true;
            // 
            // rbComAlarmLevelAll
            // 
            this.rbComAlarmLevelAll.AutoSize = true;
            this.rbComAlarmLevelAll.Checked = true;
            this.rbComAlarmLevelAll.Location = new System.Drawing.Point(8, 19);
            this.rbComAlarmLevelAll.Name = "rbComAlarmLevelAll";
            this.rbComAlarmLevelAll.Size = new System.Drawing.Size(56, 17);
            this.rbComAlarmLevelAll.TabIndex = 0;
            this.rbComAlarmLevelAll.TabStop = true;
            this.rbComAlarmLevelAll.Text = "Везде";
            this.rbComAlarmLevelAll.UseVisualStyleBackColor = true;
            // 
            // chkComAlarmSound
            // 
            this.chkComAlarmSound.AutoSize = true;
            this.chkComAlarmSound.Location = new System.Drawing.Point(5, 268);
            this.chkComAlarmSound.Name = "chkComAlarmSound";
            this.chkComAlarmSound.Size = new System.Drawing.Size(143, 17);
            this.chkComAlarmSound.TabIndex = 4;
            this.chkComAlarmSound.Text = "Звуковое оповещение:";
            this.chkComAlarmSound.UseVisualStyleBackColor = true;
            this.chkComAlarmSound.CheckedChanged += new System.EventHandler(this.chkSoundAlarm_CheckedChanged);
            // 
            // txtComAlarmSoundPath
            // 
            this.txtComAlarmSoundPath.Location = new System.Drawing.Point(154, 266);
            this.txtComAlarmSoundPath.Name = "txtComAlarmSoundPath";
            this.txtComAlarmSoundPath.ReadOnly = true;
            this.txtComAlarmSoundPath.Size = new System.Drawing.Size(314, 20);
            this.txtComAlarmSoundPath.TabIndex = 5;
            // 
            // btnSoundFile
            // 
            this.btnSoundFile.Enabled = false;
            this.btnSoundFile.Location = new System.Drawing.Point(171, 292);
            this.btnSoundFile.Name = "btnSoundFile";
            this.btnSoundFile.Size = new System.Drawing.Size(98, 27);
            this.btnSoundFile.TabIndex = 6;
            this.btnSoundFile.Text = "Открыть файл";
            this.btnSoundFile.UseVisualStyleBackColor = true;
            this.btnSoundFile.Click += new System.EventHandler(this.btnSoundFile_Click);
            // 
            // btnSoundPlay
            // 
            this.btnSoundPlay.Enabled = false;
            this.btnSoundPlay.Image = global::IPInformer2.Properties.Resources.sound;
            this.btnSoundPlay.Location = new System.Drawing.Point(275, 292);
            this.btnSoundPlay.Name = "btnSoundPlay";
            this.btnSoundPlay.Size = new System.Drawing.Size(31, 27);
            this.btnSoundPlay.TabIndex = 9;
            this.btnSoundPlay.UseVisualStyleBackColor = true;
            this.btnSoundPlay.Click += new System.EventHandler(this.btnSoundPlay_Click);
            // 
            // txtComRunCommand
            // 
            this.txtComRunCommand.Location = new System.Drawing.Point(137, 325);
            this.txtComRunCommand.Name = "txtComRunCommand";
            this.txtComRunCommand.Size = new System.Drawing.Size(331, 20);
            this.txtComRunCommand.TabIndex = 10;
            // 
            // btnStopCountry
            // 
            this.btnStopCountry.Location = new System.Drawing.Point(4, 388);
            this.btnStopCountry.Name = "btnStopCountry";
            this.btnStopCountry.Size = new System.Drawing.Size(126, 34);
            this.btnStopCountry.TabIndex = 11;
            this.btnStopCountry.Text = "Список стоп-стран";
            this.btnStopCountry.UseVisualStyleBackColor = true;
            this.btnStopCountry.Click += new System.EventHandler(this.btnStopCountry_Click);
            // 
            // btnAutostart
            // 
            this.btnAutostart.Location = new System.Drawing.Point(136, 385);
            this.btnAutostart.Name = "btnAutostart";
            this.btnAutostart.Size = new System.Drawing.Size(126, 37);
            this.btnAutostart.TabIndex = 12;
            this.btnAutostart.Text = "Добавить в автозагрузку";
            this.btnAutostart.UseVisualStyleBackColor = true;
            this.btnAutostart.Click += new System.EventHandler(this.btnAutostart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4, 429);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.Location = new System.Drawing.Point(6, 328);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(125, 13);
            this.lblRun.TabIndex = 15;
            this.lblRun.Text = "Выполнить программу:";
            // 
            // chkComCheckExit
            // 
            this.chkComCheckExit.AutoSize = true;
            this.chkComCheckExit.Location = new System.Drawing.Point(8, 363);
            this.chkComCheckExit.Name = "chkComCheckExit";
            this.chkComCheckExit.Size = new System.Drawing.Size(149, 17);
            this.chkComCheckExit.TabIndex = 16;
            this.chkComCheckExit.Text = "Спрашивать при выходе";
            this.chkComCheckExit.UseVisualStyleBackColor = true;
            // 
            // dlgOpenSound
            // 
            this.dlgOpenSound.Filter = "Wave files|*.wav";
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.rbComTimeMinutes);
            this.grpTime.Controls.Add(this.rbComTimeSecounds);
            this.grpTime.Controls.Add(this.txtComTimeInterval);
            this.grpTime.Location = new System.Drawing.Point(4, 100);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(205, 71);
            this.grpTime.TabIndex = 17;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Опрашивать скрипт через каждые:";
            // 
            // rbComTimeMinutes
            // 
            this.rbComTimeMinutes.AutoSize = true;
            this.rbComTimeMinutes.Checked = true;
            this.rbComTimeMinutes.Location = new System.Drawing.Point(9, 46);
            this.rbComTimeMinutes.Name = "rbComTimeMinutes";
            this.rbComTimeMinutes.Size = new System.Drawing.Size(55, 17);
            this.rbComTimeMinutes.TabIndex = 2;
            this.rbComTimeMinutes.TabStop = true;
            this.rbComTimeMinutes.Text = "минут";
            this.rbComTimeMinutes.UseVisualStyleBackColor = true;
            // 
            // rbComTimeSecounds
            // 
            this.rbComTimeSecounds.AutoSize = true;
            this.rbComTimeSecounds.Location = new System.Drawing.Point(67, 46);
            this.rbComTimeSecounds.Name = "rbComTimeSecounds";
            this.rbComTimeSecounds.Size = new System.Drawing.Size(60, 17);
            this.rbComTimeSecounds.TabIndex = 1;
            this.rbComTimeSecounds.Text = "секунд";
            this.rbComTimeSecounds.UseVisualStyleBackColor = true;
            // 
            // txtComTimeInterval
            // 
            this.txtComTimeInterval.Location = new System.Drawing.Point(9, 20);
            this.txtComTimeInterval.Name = "txtComTimeInterval";
            this.txtComTimeInterval.Size = new System.Drawing.Size(155, 20);
            this.txtComTimeInterval.TabIndex = 0;
            this.txtComTimeInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeInterval_KeyPress);
            // 
            // grpNetErr
            // 
            this.grpNetErr.Controls.Add(this.rbComNetErrBaloon);
            this.grpNetErr.Controls.Add(this.rbComNetErrWindow);
            this.grpNetErr.Location = new System.Drawing.Point(215, 100);
            this.grpNetErr.Name = "grpNetErr";
            this.grpNetErr.Size = new System.Drawing.Size(253, 71);
            this.grpNetErr.TabIndex = 18;
            this.grpNetErr.TabStop = false;
            this.grpNetErr.Text = "При сбое сети показывать:";
            // 
            // rbComNetErrBaloon
            // 
            this.rbComNetErrBaloon.AutoSize = true;
            this.rbComNetErrBaloon.Location = new System.Drawing.Point(7, 43);
            this.rbComNetErrBaloon.Name = "rbComNetErrBaloon";
            this.rbComNetErrBaloon.Size = new System.Drawing.Size(156, 17);
            this.rbComNetErrBaloon.TabIndex = 1;
            this.rbComNetErrBaloon.Text = "Всплывающую подсказку";
            this.rbComNetErrBaloon.UseVisualStyleBackColor = true;
            // 
            // rbComNetErrWindow
            // 
            this.rbComNetErrWindow.AutoSize = true;
            this.rbComNetErrWindow.Checked = true;
            this.rbComNetErrWindow.Location = new System.Drawing.Point(7, 20);
            this.rbComNetErrWindow.Name = "rbComNetErrWindow";
            this.rbComNetErrWindow.Size = new System.Drawing.Size(128, 17);
            this.rbComNetErrWindow.TabIndex = 0;
            this.rbComNetErrWindow.TabStop = true;
            this.rbComNetErrWindow.Text = "Окно с сообщением";
            this.rbComNetErrWindow.UseVisualStyleBackColor = true;
            // 
            // lblPanicInfo
            // 
            this.lblPanicInfo.AutoSize = true;
            this.lblPanicInfo.Location = new System.Drawing.Point(140, 348);
            this.lblPanicInfo.Name = "lblPanicInfo";
            this.lblPanicInfo.Size = new System.Drawing.Size(328, 13);
            this.lblPanicInfo.TabIndex = 19;
            this.lblPanicInfo.Text = "(выполняется при обнаружении стоп-страны в режиме паники)";
            // 
            // chkComNewIPMessage
            // 
            this.chkComNewIPMessage.AutoSize = true;
            this.chkComNewIPMessage.Location = new System.Drawing.Point(163, 364);
            this.chkComNewIPMessage.Name = "chkComNewIPMessage";
            this.chkComNewIPMessage.Size = new System.Drawing.Size(141, 17);
            this.chkComNewIPMessage.TabIndex = 20;
            this.chkComNewIPMessage.Text = "Оповещать о смене IP";
            this.chkComNewIPMessage.UseVisualStyleBackColor = true;
            // 
            // btnEmbedSound
            // 
            this.btnEmbedSound.Enabled = false;
            this.btnEmbedSound.Location = new System.Drawing.Point(312, 292);
            this.btnEmbedSound.Name = "btnEmbedSound";
            this.btnEmbedSound.Size = new System.Drawing.Size(105, 27);
            this.btnEmbedSound.TabIndex = 21;
            this.btnEmbedSound.Text = "Встроенный звук";
            this.btnEmbedSound.UseVisualStyleBackColor = true;
            this.btnEmbedSound.Click += new System.EventHandler(this.btnEmbedSound_Click);
            // 
            // btnUptateSxGeo
            // 
            this.btnUptateSxGeo.Location = new System.Drawing.Point(268, 385);
            this.btnUptateSxGeo.Name = "btnUptateSxGeo";
            this.btnUptateSxGeo.Size = new System.Drawing.Size(124, 37);
            this.btnUptateSxGeo.TabIndex = 30;
            this.btnUptateSxGeo.Text = "Обновить БД SxGeo";
            this.btnUptateSxGeo.UseVisualStyleBackColor = true;
            this.btnUptateSxGeo.Click += new System.EventHandler(this.btnUptateSxGeo_Click);
            // 
            // dlgOpenSxG
            // 
            this.dlgOpenSxG.Description = "Выберите папку, содержащую файлы SxGeo.dat, SxGeoSity.dat или оба этих файла.";
            this.dlgOpenSxG.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlgOpenSxG.ShowNewFolderButton = false;
            // 
            // btnScripts
            // 
            this.btnScripts.Location = new System.Drawing.Point(7, 54);
            this.btnScripts.Name = "btnScripts";
            this.btnScripts.Size = new System.Drawing.Size(446, 22);
            this.btnScripts.TabIndex = 31;
            this.btnScripts.Text = "Список скриптов для получения IP-адреса";
            this.btnScripts.UseVisualStyleBackColor = true;
            this.btnScripts.Click += new System.EventHandler(this.btnScripts_Click);
            // 
            // grpScripts
            // 
            this.grpScripts.Controls.Add(this.rbComScriptChangeChangeIfError);
            this.grpScripts.Controls.Add(this.rbComScriptChangeOnlyFirst);
            this.grpScripts.Controls.Add(this.btnScripts);
            this.grpScripts.Location = new System.Drawing.Point(4, 177);
            this.grpScripts.Name = "grpScripts";
            this.grpScripts.Size = new System.Drawing.Size(464, 82);
            this.grpScripts.TabIndex = 32;
            this.grpScripts.TabStop = false;
            this.grpScripts.Text = "Настройки скриптов получения IP:";
            // 
            // rbComScriptChangeChangeIfError
            // 
            this.rbComScriptChangeChangeIfError.AutoSize = true;
            this.rbComScriptChangeChangeIfError.Location = new System.Drawing.Point(233, 20);
            this.rbComScriptChangeChangeIfError.Name = "rbComScriptChangeChangeIfError";
            this.rbComScriptChangeChangeIfError.Size = new System.Drawing.Size(226, 17);
            this.rbComScriptChangeChangeIfError.TabIndex = 33;
            this.rbComScriptChangeChangeIfError.Text = "При ошибке задействовать следующий";
            this.rbComScriptChangeChangeIfError.UseVisualStyleBackColor = true;
            // 
            // rbComScriptChangeOnlyFirst
            // 
            this.rbComScriptChangeOnlyFirst.AutoSize = true;
            this.rbComScriptChangeOnlyFirst.Checked = true;
            this.rbComScriptChangeOnlyFirst.Location = new System.Drawing.Point(9, 20);
            this.rbComScriptChangeOnlyFirst.Name = "rbComScriptChangeOnlyFirst";
            this.rbComScriptChangeOnlyFirst.Size = new System.Drawing.Size(225, 17);
            this.rbComScriptChangeOnlyFirst.TabIndex = 32;
            this.rbComScriptChangeOnlyFirst.TabStop = true;
            this.rbComScriptChangeOnlyFirst.Text = "Использовать только первый в списке";
            this.rbComScriptChangeOnlyFirst.UseVisualStyleBackColor = true;
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Location = new System.Drawing.Point(398, 385);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(70, 37);
            this.btnResetSettings.TabIndex = 33;
            this.btnResetSettings.Text = "Сброс настроек";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // frmCommonSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 454);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.grpScripts);
            this.Controls.Add(this.btnUptateSxGeo);
            this.Controls.Add(this.btnEmbedSound);
            this.Controls.Add(this.chkComNewIPMessage);
            this.Controls.Add(this.lblPanicInfo);
            this.Controls.Add(this.grpNetErr);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.chkComCheckExit);
            this.Controls.Add(this.lblRun);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAutostart);
            this.Controls.Add(this.btnStopCountry);
            this.Controls.Add(this.txtComRunCommand);
            this.Controls.Add(this.btnSoundPlay);
            this.Controls.Add(this.btnSoundFile);
            this.Controls.Add(this.txtComAlarmSoundPath);
            this.Controls.Add(this.chkComAlarmSound);
            this.Controls.Add(this.grpSignal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommonSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Общие настройки";
            this.Load += new System.EventHandler(this.frmCommonSettings_Load);
            this.grpSignal.ResumeLayout(false);
            this.grpSignal.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.grpNetErr.ResumeLayout(false);
            this.grpNetErr.PerformLayout();
            this.grpScripts.ResumeLayout(false);
            this.grpScripts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSignal;
        private System.Windows.Forms.RadioButton rbComAlarmLevelHTTP_HEADERS;
        private System.Windows.Forms.RadioButton rbComAlarmLevelREMOTE_ADDR;
        private System.Windows.Forms.RadioButton rbComAlarmLevelAll;
        private System.Windows.Forms.CheckBox chkComAlarmSound;
        private System.Windows.Forms.TextBox txtComAlarmSoundPath;
        private System.Windows.Forms.Button btnSoundFile;
        private System.Windows.Forms.Button btnSoundPlay;
        private System.Windows.Forms.TextBox txtComRunCommand;
        private System.Windows.Forms.Button btnStopCountry;
        private System.Windows.Forms.Button btnAutostart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.CheckBox chkComCheckExit;
        private System.Windows.Forms.OpenFileDialog dlgOpenSound;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.RadioButton rbComTimeSecounds;
        private System.Windows.Forms.TextBox txtComTimeInterval;
        private System.Windows.Forms.RadioButton rbComTimeMinutes;
        private System.Windows.Forms.GroupBox grpNetErr;
        private System.Windows.Forms.RadioButton rbComNetErrWindow;
        private System.Windows.Forms.RadioButton rbComNetErrBaloon;
        private System.Windows.Forms.RadioButton rbComAlarmLevelNone;
        private System.Windows.Forms.RadioButton rbComAlarmLevelOnlyWarning;
        private System.Windows.Forms.Label lblPanicInfo;
        private System.Windows.Forms.CheckBox chkComNewIPMessage;
        private System.Windows.Forms.Button btnEmbedSound;
        private System.Windows.Forms.Button btnUptateSxGeo;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenSxG;
        private System.Windows.Forms.Button btnScripts;
        private System.Windows.Forms.GroupBox grpScripts;
        private System.Windows.Forms.RadioButton rbComScriptChangeChangeIfError;
        private System.Windows.Forms.RadioButton rbComScriptChangeOnlyFirst;
        private System.Windows.Forms.Button btnResetSettings;
    }
}