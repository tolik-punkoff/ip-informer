namespace IPInformer2
{
    partial class frmPanic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanic));
            this.lblWrn = new System.Windows.Forms.Label();
            this.lblVash = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPren = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCmdMessage = new System.Windows.Forms.Label();
            this.btnEndTracking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWrn
            // 
            this.lblWrn.AutoSize = true;
            this.lblWrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWrn.ForeColor = System.Drawing.Color.White;
            this.lblWrn.Location = new System.Drawing.Point(155, 9);
            this.lblWrn.Name = "lblWrn";
            this.lblWrn.Size = new System.Drawing.Size(534, 108);
            this.lblWrn.TabIndex = 0;
            this.lblWrn.Text = "Внимание!";
            // 
            // lblVash
            // 
            this.lblVash.AutoSize = true;
            this.lblVash.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVash.ForeColor = System.Drawing.Color.White;
            this.lblVash.Location = new System.Drawing.Point(215, 117);
            this.lblVash.Name = "lblVash";
            this.lblVash.Size = new System.Drawing.Size(134, 39);
            this.lblVash.TabIndex = 1;
            this.lblVash.Text = "Ваш IP";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.Location = new System.Drawing.Point(346, 117);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(290, 39);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "255.255.255.255";
            // 
            // lblPren
            // 
            this.lblPren.AutoSize = true;
            this.lblPren.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPren.ForeColor = System.Drawing.Color.White;
            this.lblPren.Location = new System.Drawing.Point(102, 168);
            this.lblPren.Name = "lblPren";
            this.lblPren.Size = new System.Drawing.Size(645, 39);
            this.lblPren.TabIndex = 3;
            this.lblPren.Text = "принадлежит нежелательной стране";
            // 
            // lblCountry
            // 
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountry.ForeColor = System.Drawing.Color.White;
            this.lblCountry.Location = new System.Drawing.Point(96, 207);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(666, 128);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "$STRANA$";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(15, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(300, 79);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCmdMessage
            // 
            this.lblCmdMessage.AutoSize = true;
            this.lblCmdMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCmdMessage.ForeColor = System.Drawing.Color.White;
            this.lblCmdMessage.Location = new System.Drawing.Point(12, 361);
            this.lblCmdMessage.Name = "lblCmdMessage";
            this.lblCmdMessage.Size = new System.Drawing.Size(40, 18);
            this.lblCmdMessage.TabIndex = 6;
            this.lblCmdMessage.Text = "cmd";
            // 
            // btnEndTracking
            // 
            this.btnEndTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEndTracking.Location = new System.Drawing.Point(494, 401);
            this.btnEndTracking.Name = "btnEndTracking";
            this.btnEndTracking.Size = new System.Drawing.Size(300, 79);
            this.btnEndTracking.TabIndex = 7;
            this.btnEndTracking.Text = "Прекратить отслеживать IP";
            this.btnEndTracking.UseVisualStyleBackColor = true;
            this.btnEndTracking.Click += new System.EventHandler(this.btnEndTracking_Click);
            // 
            // frmPanic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(806, 492);
            this.Controls.Add(this.btnEndTracking);
            this.Controls.Add(this.lblCmdMessage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblPren);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblVash);
            this.Controls.Add(this.lblWrn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPanic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нежелательная страна";
            this.Load += new System.EventHandler(this.frmPanic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWrn;
        private System.Windows.Forms.Label lblVash;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPren;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCmdMessage;
        private System.Windows.Forms.Button btnEndTracking;
    }
}