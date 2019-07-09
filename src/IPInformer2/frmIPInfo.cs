using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmIPInfo : Form
    {
        public object TableDataSource = null;
        Dictionary<string, string> Fields = new Dictionary<string, string>();
        public frmIPInfo()
        {
            InitializeComponent();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIPInfo_Load(object sender, EventArgs e)
        {
            dvIPInfo.DataSource = TableDataSource;

            string[] Buf = Properties.Resources.datastructure.Replace("\r","")
                .Split('\n');

            foreach (string s in Buf)
            {
                string[] Buf2 = s.Split('|');
                Fields.Add(Buf2[0], Buf2[1]);
            }            
        }

        private void dvIPInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string v = dvIPInfo.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (Fields.ContainsKey(v))
                {
                    e.Value = Fields[v];
                }
            }
        }                
    }
}
