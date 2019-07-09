using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmScripts : Form
    {
        public bool Changed = false;
        public List<string> Scripts = null;

        public frmScripts()
        {
            InitializeComponent();
        }

        private void frmScripts_Load(object sender, EventArgs e)
        {
            foreach (string s in Scripts)
            {
                lstScripts.Items.Add(s);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Scripts.Clear();
            foreach (object o in lstScripts.Items)
            {
                Scripts.Add(o.ToString());
            }
            Changed = true;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((!lstScripts.Items.Contains(txtScriptURL.Text.Trim()))
                && (txtScriptURL.Text.Trim() != string.Empty))
            {
                lstScripts.Items.Add(txtScriptURL.Text.Trim());
            }
        }

        private void lstScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstScripts.SelectedItem != null)
            {
                txtScriptURL.Text = lstScripts.SelectedItem.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lstScripts.SelectedIndex == -1) return;

            if ((!lstScripts.Items.Contains(txtScriptURL.Text.Trim()))
                && (txtScriptURL.Text.Trim() != string.Empty))
            {
                lstScripts.Items[lstScripts.SelectedIndex] 
                    = txtScriptURL.Text.Trim();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstScripts.SelectedIndex == -1) return;

            DialogResult Ans = MessageBox.Show("Удалить " +
                lstScripts.Items[lstScripts.SelectedIndex].ToString() + "?",
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (Ans == DialogResult.Yes)
            {
                int OldIdx = lstScripts.SelectedIndex;
                lstScripts.Items.RemoveAt(lstScripts.SelectedIndex);
                if (OldIdx < lstScripts.Items.Count)
                {
                    lstScripts.SelectedIndex = OldIdx;
                }
                else
                {
                    if (lstScripts.Items.Count > 0)
                    {
                        lstScripts.SelectedIndex = lstScripts.Items.Count - 1;
                    }
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lstScripts.SelectedIndex > 0)
            {
                object o = lstScripts.Items[lstScripts.SelectedIndex];
                lstScripts.Items[lstScripts.SelectedIndex] =
                    lstScripts.Items[lstScripts.SelectedIndex - 1];
                lstScripts.Items[lstScripts.SelectedIndex - 1] = o;
                lstScripts.SelectedIndex--;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lstScripts.SelectedIndex < lstScripts.Items.Count - 1)
            {
                object o = lstScripts.Items[lstScripts.SelectedIndex];
                lstScripts.Items[lstScripts.SelectedIndex] =
                    lstScripts.Items[lstScripts.SelectedIndex + 1];
                lstScripts.Items[lstScripts.SelectedIndex + 1] = o;
                lstScripts.SelectedIndex++;
            }
        }
        
    }
}
