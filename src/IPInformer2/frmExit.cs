using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmExit : Form
    {
        public bool ComCheckExit = false;
        public frmExit()
        {
            InitializeComponent();            
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ComCheckExit=!chkStopQuestion.Checked;
            this.DialogResult = DialogResult.Yes;
            this.Close();            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        
    }
}
