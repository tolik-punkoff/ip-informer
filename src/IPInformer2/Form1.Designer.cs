namespace IPInformer2
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMyIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOthIP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStopWatching = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNetworkSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTechinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdate,
            this.mnuMyIP,
            this.mnuOthIP,
            this.toolStripSeparator3,
            this.mnuStopWatching,
            this.toolStripSeparator1,
            this.mnuSettings,
            this.mnuNetworkSettings,
            this.mnuTechinfo,
            this.toolStripSeparator2,
            this.mnuHelp,
            this.mnuAbout,
            this.mnuExit});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(217, 264);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(216, 22);
            this.mnuUpdate.Text = "Обновить";
            this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
            // 
            // mnuMyIP
            // 
            this.mnuMyIP.Name = "mnuMyIP";
            this.mnuMyIP.Size = new System.Drawing.Size(216, 22);
            this.mnuMyIP.Text = "Мой IP...";
            this.mnuMyIP.Click += new System.EventHandler(this.mnuMyIP_Click);
            // 
            // mnuOthIP
            // 
            this.mnuOthIP.Name = "mnuOthIP";
            this.mnuOthIP.Size = new System.Drawing.Size(216, 22);
            this.mnuOthIP.Text = "Другой IP...";
            this.mnuOthIP.Click += new System.EventHandler(this.mnuOthIP_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // mnuStopWatching
            // 
            this.mnuStopWatching.Name = "mnuStopWatching";
            this.mnuStopWatching.Size = new System.Drawing.Size(216, 22);
            this.mnuStopWatching.Text = "Остановить";
            this.mnuStopWatching.Click += new System.EventHandler(this.mnuStopWatching_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(216, 22);
            this.mnuSettings.Text = "Настройки...";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuNetworkSettings
            // 
            this.mnuNetworkSettings.Name = "mnuNetworkSettings";
            this.mnuNetworkSettings.Size = new System.Drawing.Size(216, 22);
            this.mnuNetworkSettings.Text = "Настройки сети...";
            this.mnuNetworkSettings.Click += new System.EventHandler(this.mnuNetworkSettings_Click);
            // 
            // mnuTechinfo
            // 
            this.mnuTechinfo.Name = "mnuTechinfo";
            this.mnuTechinfo.Size = new System.Drawing.Size(216, 22);
            this.mnuTechinfo.Text = "Техническая информация...";
            this.mnuTechinfo.Click += new System.EventHandler(this.mnuTechinfo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(216, 22);
            this.mnuAbout.Text = "О программе...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(216, 22);
            this.mnuExit.Text = "Выход";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.mnuMain;
            this.niMain.Text = "IP Informer";
            this.niMain.Visible = true;
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(216, 22);
            this.mnuHelp.Text = "Помощь";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPInformer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuMyIP;
        private System.Windows.Forms.ToolStripMenuItem mnuOthIP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuStopWatching;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuNetworkSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ToolStripMenuItem mnuTechinfo;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    }
}

