namespace IPInformer2
{
    partial class frmPanicNet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanicNet));
            this.lblScript = new System.Windows.Forms.Label();
            this.lblWrn = new System.Windows.Forms.Label();
            this.lblVragi = new System.Windows.Forms.Label();
            this.btnEndTracking = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblErrData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScript
            // 
            this.lblScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScript.ForeColor = System.Drawing.Color.Black;
            this.lblScript.Location = new System.Drawing.Point(27, 127);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(767, 89);
            this.lblScript.TabIndex = 6;
            this.lblScript.Text = "Отсутствует соединение с сетью, или недоступен скрипт!";
            this.lblScript.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWrn
            // 
            this.lblWrn.AutoSize = true;
            this.lblWrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWrn.ForeColor = System.Drawing.Color.Black;
            this.lblWrn.Location = new System.Drawing.Point(130, 19);
            this.lblWrn.Name = "lblWrn";
            this.lblWrn.Size = new System.Drawing.Size(534, 108);
            this.lblWrn.TabIndex = 5;
            this.lblWrn.Text = "Внимание!";
            // 
            // lblVragi
            // 
            this.lblVragi.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVragi.ForeColor = System.Drawing.Color.Black;
            this.lblVragi.Location = new System.Drawing.Point(12, 216);
            this.lblVragi.Name = "lblVragi";
            this.lblVragi.Size = new System.Drawing.Size(767, 89);
            this.lblVragi.TabIndex = 7;
            this.lblVragi.Text = "Это может быть как обычным сбоем, так и происками врагов!";
            this.lblVragi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEndTracking
            // 
            this.btnEndTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEndTracking.Location = new System.Drawing.Point(494, 401);
            this.btnEndTracking.Name = "btnEndTracking";
            this.btnEndTracking.Size = new System.Drawing.Size(300, 79);
            this.btnEndTracking.TabIndex = 10;
            this.btnEndTracking.Text = "Прекратить отслеживать IP";
            this.btnEndTracking.UseVisualStyleBackColor = true;
            this.btnEndTracking.Click += new System.EventHandler(this.btnEndTracking_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(15, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(300, 79);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblErrData
            // 
            this.lblErrData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrData.ForeColor = System.Drawing.Color.Black;
            this.lblErrData.Location = new System.Drawing.Point(12, 305);
            this.lblErrData.Name = "lblErrData";
            this.lblErrData.Size = new System.Drawing.Size(767, 89);
            this.lblErrData.TabIndex = 8;
            this.lblErrData.Text = "Ниже идут данные о сбое:";
            this.lblErrData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPanicNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 492);
            this.Controls.Add(this.btnEndTracking);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblErrData);
            this.Controls.Add(this.lblVragi);
            this.Controls.Add(this.lblScript);
            this.Controls.Add(this.lblWrn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPanicNet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ошибка сети";
            this.Load += new System.EventHandler(this.frmPanicNet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Label lblWrn;
        private System.Windows.Forms.Label lblVragi;
        private System.Windows.Forms.Button btnEndTracking;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblErrData;
    }
}