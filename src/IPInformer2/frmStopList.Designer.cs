namespace IPInformer2
{
    partial class frmStopList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStopList));
            this.dsCountries = new System.Data.DataSet();
            this.dvCountries = new System.Windows.Forms.DataGridView();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblSearchIn = new System.Windows.Forms.Label();
            this.lstStopList = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // dsCountries
            // 
            this.dsCountries.DataSetName = "NewDataSet";
            // 
            // dvCountries
            // 
            this.dvCountries.AllowUserToAddRows = false;
            this.dvCountries.AllowUserToDeleteRows = false;
            this.dvCountries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvCountries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCountries.Location = new System.Drawing.Point(2, 47);
            this.dvCountries.Name = "dvCountries";
            this.dvCountries.ReadOnly = true;
            this.dvCountries.Size = new System.Drawing.Size(363, 271);
            this.dvCountries.TabIndex = 0;
            this.dvCountries.CurrentCellChanged += new System.EventHandler(this.dvCountries_CurrentCellChanged);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(2, 21);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(363, 20);
            this.txtFind.TabIndex = 6;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lblSearchIn
            // 
            this.lblSearchIn.AutoSize = true;
            this.lblSearchIn.Location = new System.Drawing.Point(-1, 5);
            this.lblSearchIn.Name = "lblSearchIn";
            this.lblSearchIn.Size = new System.Drawing.Size(97, 13);
            this.lblSearchIn.TabIndex = 5;
            this.lblSearchIn.Text = "Поиск по столбцу";
            // 
            // lstStopList
            // 
            this.lstStopList.FormattingEnabled = true;
            this.lstStopList.Location = new System.Drawing.Point(414, 21);
            this.lstStopList.Name = "lstStopList";
            this.lstStopList.Size = new System.Drawing.Size(268, 251);
            this.lstStopList.TabIndex = 7;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::IPInformer2.Properties.Resources.arrow_full_left_32;
            this.btnRemove.Location = new System.Drawing.Point(371, 130);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(37, 40);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::IPInformer2.Properties.Resources.arrow_full_right_32;
            this.btnAdd.Location = new System.Drawing.Point(371, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(37, 40);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(414, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(601, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStopList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstStopList);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblSearchIn);
            this.Controls.Add(this.dvCountries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStopList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стоп-лист стран";
            this.Load += new System.EventHandler(this.frmStopList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvCountries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dsCountries;
        private System.Windows.Forms.DataGridView dvCountries;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblSearchIn;
        private System.Windows.Forms.ListBox lstStopList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}