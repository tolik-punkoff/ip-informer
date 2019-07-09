using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmPanicNet : Form
    {
        public delegate void OnFormPanicNetClosed(bool StopTracking);
        public event OnFormPanicNetClosed FormPanicNetClosed;
        
        public string ErrorMessage = "";        
        public frmPanicNet()
        {
            InitializeComponent();
        }

        private void frmPanicNet_Load(object sender, EventArgs e)
        {
            lblErrData.Text = "Данные о сбое: " + ErrorMessage;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (FormPanicNetClosed != null) FormPanicNetClosed(false);
            this.Close();
        }

        private void btnEndTracking_Click(object sender, EventArgs e)
        {
            if (FormPanicNetClosed != null) FormPanicNetClosed(true);
            this.Close();
        }
    }
}
