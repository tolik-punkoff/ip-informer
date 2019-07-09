namespace IPInformer2
{
    partial class frmIPInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIPInfo));
            this.dvIPInfo = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.dsIPInfo = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dvIPInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIPInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dvIPInfo
            // 
            this.dvIPInfo.AllowUserToAddRows = false;
            this.dvIPInfo.AllowUserToDeleteRows = false;
            this.dvIPInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvIPInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvIPInfo.Location = new System.Drawing.Point(1, 1);
            this.dvIPInfo.Name = "dvIPInfo";
            this.dvIPInfo.ReadOnly = true;
            this.dvIPInfo.Size = new System.Drawing.Size(363, 356);
            this.dvIPInfo.TabIndex = 1;
            this.dvIPInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dvIPInfo_CellFormatting);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(139, 363);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dsIPInfo
            // 
            this.dsIPInfo.DataSetName = "NewDataSet";
            // 
            // frmIPInfo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 392);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dvIPInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIPInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об IP-адресе";
            this.Load += new System.EventHandler(this.frmIPInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvIPInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIPInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvIPInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Data.DataSet dsIPInfo;
    }
}