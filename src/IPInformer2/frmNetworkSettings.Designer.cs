namespace IPInformer2
{
    partial class frmNetworkSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNetworkSettings));
            this.grpProxySwitch = new System.Windows.Forms.GroupBox();
            this.btnSystemProxy = new System.Windows.Forms.Button();
            this.rbConnectionTypeManualProxy = new System.Windows.Forms.RadioButton();
            this.rbConnectionTypeSystemProxy = new System.Windows.Forms.RadioButton();
            this.rbConnectionTypeNoProxy = new System.Windows.Forms.RadioButton();
            this.grpProxy = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.chkShowChars = new System.Windows.Forms.CheckBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtProxyAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtConnectionTimeout = new System.Windows.Forms.TextBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblTimeoutInfo = new System.Windows.Forms.Label();
            this.grpProxySwitch.SuspendLayout();
            this.grpProxy.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProxySwitch
            // 
            this.grpProxySwitch.Controls.Add(this.btnSystemProxy);
            this.grpProxySwitch.Controls.Add(this.rbConnectionTypeManualProxy);
            this.grpProxySwitch.Controls.Add(this.rbConnectionTypeSystemProxy);
            this.grpProxySwitch.Controls.Add(this.rbConnectionTypeNoProxy);
            this.grpProxySwitch.Location = new System.Drawing.Point(3, 3);
            this.grpProxySwitch.Name = "grpProxySwitch";
            this.grpProxySwitch.Size = new System.Drawing.Size(404, 97);
            this.grpProxySwitch.TabIndex = 0;
            this.grpProxySwitch.TabStop = false;
            this.grpProxySwitch.Text = "Настройки соединения";
            // 
            // btnSystemProxy
            // 
            this.btnSystemProxy.Enabled = false;
            this.btnSystemProxy.Location = new System.Drawing.Point(194, 42);
            this.btnSystemProxy.Name = "btnSystemProxy";
            this.btnSystemProxy.Size = new System.Drawing.Size(204, 21);
            this.btnSystemProxy.TabIndex = 3;
            this.btnSystemProxy.Text = "Открыть \"Свойства обозревателя\"";
            this.btnSystemProxy.UseVisualStyleBackColor = true;
            this.btnSystemProxy.Click += new System.EventHandler(this.btnSystemProxy_Click);
            // 
            // rbConnectionTypeManualProxy
            // 
            this.rbConnectionTypeManualProxy.AutoSize = true;
            this.rbConnectionTypeManualProxy.Location = new System.Drawing.Point(10, 68);
            this.rbConnectionTypeManualProxy.Name = "rbConnectionTypeManualProxy";
            this.rbConnectionTypeManualProxy.Size = new System.Drawing.Size(162, 17);
            this.rbConnectionTypeManualProxy.TabIndex = 2;
            this.rbConnectionTypeManualProxy.Text = "Настроить прокси вручную";
            this.rbConnectionTypeManualProxy.UseVisualStyleBackColor = true;
            this.rbConnectionTypeManualProxy.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbConnectionTypeSystemProxy
            // 
            this.rbConnectionTypeSystemProxy.AutoSize = true;
            this.rbConnectionTypeSystemProxy.Location = new System.Drawing.Point(10, 44);
            this.rbConnectionTypeSystemProxy.Name = "rbConnectionTypeSystemProxy";
            this.rbConnectionTypeSystemProxy.Size = new System.Drawing.Size(178, 17);
            this.rbConnectionTypeSystemProxy.TabIndex = 1;
            this.rbConnectionTypeSystemProxy.TabStop = true;
            this.rbConnectionTypeSystemProxy.Text = "Системные настройки прокси";
            this.rbConnectionTypeSystemProxy.UseVisualStyleBackColor = true;
            this.rbConnectionTypeSystemProxy.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbConnectionTypeNoProxy
            // 
            this.rbConnectionTypeNoProxy.AutoSize = true;
            this.rbConnectionTypeNoProxy.Checked = true;
            this.rbConnectionTypeNoProxy.Location = new System.Drawing.Point(10, 20);
            this.rbConnectionTypeNoProxy.Name = "rbConnectionTypeNoProxy";
            this.rbConnectionTypeNoProxy.Size = new System.Drawing.Size(145, 17);
            this.rbConnectionTypeNoProxy.TabIndex = 0;
            this.rbConnectionTypeNoProxy.TabStop = true;
            this.rbConnectionTypeNoProxy.Text = "Соединяться напрямую";
            this.rbConnectionTypeNoProxy.UseVisualStyleBackColor = true;
            this.rbConnectionTypeNoProxy.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // grpProxy
            // 
            this.grpProxy.Controls.Add(this.chkShowChars);
            this.grpProxy.Controls.Add(this.chkSavePassword);
            this.grpProxy.Controls.Add(this.txtProxyPassword);
            this.grpProxy.Controls.Add(this.lblPassword);
            this.grpProxy.Controls.Add(this.txtProxyUser);
            this.grpProxy.Controls.Add(this.lblUser);
            this.grpProxy.Controls.Add(this.txtProxyPort);
            this.grpProxy.Controls.Add(this.lblPort);
            this.grpProxy.Controls.Add(this.txtProxyAddress);
            this.grpProxy.Controls.Add(this.lblAddress);
            this.grpProxy.Enabled = false;
            this.grpProxy.Location = new System.Drawing.Point(3, 107);
            this.grpProxy.Name = "grpProxy";
            this.grpProxy.Size = new System.Drawing.Size(404, 143);
            this.grpProxy.TabIndex = 1;
            this.grpProxy.TabStop = false;
            this.grpProxy.Text = "Настройки прокси";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(3, 253);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(404, 23);
            this.lblErrorMessage.TabIndex = 10;
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkShowChars
            // 
            this.chkShowChars.AutoSize = true;
            this.chkShowChars.Location = new System.Drawing.Point(220, 97);
            this.chkShowChars.Name = "chkShowChars";
            this.chkShowChars.Size = new System.Drawing.Size(124, 17);
            this.chkShowChars.TabIndex = 9;
            this.chkShowChars.Text = "Показать символы";
            this.chkShowChars.UseVisualStyleBackColor = true;
            this.chkShowChars.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Location = new System.Drawing.Point(96, 97);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(118, 17);
            this.chkSavePassword.TabIndex = 8;
            this.chkSavePassword.Text = "Сохранять пароль";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(96, 71);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(298, 20);
            this.txtProxyPassword.TabIndex = 7;
            this.txtProxyPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Location = new System.Drawing.Point(96, 46);
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.Size = new System.Drawing.Size(298, 20);
            this.txtProxyUser.TabIndex = 5;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(9, 49);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(83, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Пользователь:";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(344, 20);
            this.txtProxyPort.MaxLength = 5;
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(50, 20);
            this.txtProxyPort.TabIndex = 3;
            this.txtProxyPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(303, 23);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Порт:";
            // 
            // txtProxyAddress
            // 
            this.txtProxyAddress.Location = new System.Drawing.Point(56, 20);
            this.txtProxyAddress.Name = "txtProxyAddress";
            this.txtProxyAddress.Size = new System.Drawing.Size(241, 20);
            this.txtProxyAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(10, 23);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(41, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Адрес:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3, 307);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(341, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtConnectionTimeout
            // 
            this.txtConnectionTimeout.Location = new System.Drawing.Point(125, 283);
            this.txtConnectionTimeout.MaxLength = 5;
            this.txtConnectionTimeout.Name = "txtConnectionTimeout";
            this.txtConnectionTimeout.Size = new System.Drawing.Size(100, 20);
            this.txtConnectionTimeout.TabIndex = 4;
            this.txtConnectionTimeout.Text = "0";
            this.txtConnectionTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeout_KeyPress);
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(3, 286);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(116, 13);
            this.lblTimeout.TabIndex = 5;
            this.lblTimeout.Text = "Таймаут соединения:";
            // 
            // lblTimeoutInfo
            // 
            this.lblTimeoutInfo.AutoSize = true;
            this.lblTimeoutInfo.Location = new System.Drawing.Point(232, 287);
            this.lblTimeoutInfo.Name = "lblTimeoutInfo";
            this.lblTimeoutInfo.Size = new System.Drawing.Size(166, 13);
            this.lblTimeoutInfo.TabIndex = 6;
            this.lblTimeoutInfo.Text = " миллисекунд 0 - по умолчанию";
            // 
            // frmNetworkSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 332);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblTimeoutInfo);
            this.Controls.Add(this.lblTimeout);
            this.Controls.Add(this.txtConnectionTimeout);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpProxy);
            this.Controls.Add(this.grpProxySwitch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNetworkSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки сети";
            this.Load += new System.EventHandler(this.frmNetworkSettings_Load);
            this.grpProxySwitch.ResumeLayout(false);
            this.grpProxySwitch.PerformLayout();
            this.grpProxy.ResumeLayout(false);
            this.grpProxy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProxySwitch;
        private System.Windows.Forms.RadioButton rbConnectionTypeManualProxy;
        private System.Windows.Forms.RadioButton rbConnectionTypeSystemProxy;
        private System.Windows.Forms.RadioButton rbConnectionTypeNoProxy;
        private System.Windows.Forms.GroupBox grpProxy;
        private System.Windows.Forms.TextBox txtProxyAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.CheckBox chkShowChars;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSystemProxy;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TextBox txtConnectionTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblTimeoutInfo;
    }
}