using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPInformer2
{
    public partial class frmStopList : Form
    {        
        public bool Chanded = false;
        int iCurrCol = -1; //текущая колонка
        bool bRenaming = false; //если не переименовано - false, переименовано - true, 
                                //чтоб не было атерфактов в поиске
        //внутренний список стоп-стран (сохраняется во время работы формы)
        //если не нажата отмена - синхронизируется с главным
        //KEY - код ISO
        //VALUE - название страны
        public Dictionary<string, string> StopList = null;
        public frmStopList()
        {
            InitializeComponent();
        }

        private void frmStopList_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ip_icon_form;

            if (!DataLoader.LoadCSV(CommonFunctions.SettingsPath + "iso.csv", ';',
                dsCountries, "Countries", "Country;ISO"))
            {
                if (!DataLoader.LoadCSVString(Properties.Resources.iso, ';',
                dsCountries, "Countries", "Country;ISO"))
                {
                    CommonFunctions.ErrMessage(DataLoader.ErrorMessage);
                    this.Close();
                    return;
                }
                else
                {
                    this.Text = this.Text + " [INTERNAL BASE]";
                }
            }
            else
            {
                this.Text = this.Text + " [\\data\\iso.csv]";
            }
            dvCountries.DataSource = dsCountries.Tables["Countries"].DefaultView;
            dvCountries.Columns[1].HeaderText = "Код ISO";
            dvCountries.Columns[0].HeaderText = "Страна";
            bRenaming = true;
            dvCountries.CurrentCell= dvCountries.Rows[dvCountries.Rows.Count - 1].Cells[0];
            dvCountries.CurrentCell = dvCountries.Rows[0].Cells[0];            

            //добавляем стоп-страны в внутренний список и listbox             

            foreach (KeyValuePair<string,string> country in StopList)
            {                
                lstStopList.Items.Add(country.Value + " (" + country.Key + ")");                 
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            //поиск по любому полю в таблице
            for (int i = 0; i < dvCountries.RowCount; i++)
            {
                dvCountries.Rows[i].Selected = false;
                if (dvCountries.Rows[i].Cells[iCurrCol].Value != null)
                    if (dvCountries.Rows[i].Cells[iCurrCol].Value.ToString().StartsWith(txtFind.Text, true, null))
                    {
                        dvCountries.CurrentCell = dvCountries.Rows[i].Cells[iCurrCol];
                        dvCountries.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
        }

        private void dvCountries_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((dvCountries.CurrentCell != null)&&(bRenaming))
            {
                lblSearchIn.Text = "Поиск по столбцу [" + dvCountries.Columns[dvCountries.CurrentCell.ColumnIndex].HeaderText + "]:";
                iCurrCol = dvCountries.CurrentCell.ColumnIndex;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dvCountries.CurrentCell != null)
            {
                string data = dvCountries.CurrentRow.Cells[0].Value.ToString() + " (" +
                            dvCountries.CurrentRow.Cells[1].Value.ToString() + ")";
                int idx=lstStopList.Items.IndexOf(data);
                if (idx == -1)
                {
                    lstStopList.Items.Add(data);
                    StopList.Add(dvCountries.CurrentRow.Cells["ISO"].Value.ToString(), dvCountries.CurrentRow.Cells["Country"].Value.ToString());
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //удаление
            int idx = lstStopList.SelectedIndex;
            if (idx != -1)
            {
                //получим ключ для удаления из внутреннего списка
                string tempkey=lstStopList.Items[idx].ToString();
                int start=tempkey.IndexOf('(')+1;
                int length = tempkey.IndexOf(')')-start;
                tempkey=tempkey.Substring(start,length);                
                //удалим элемент из listbox
                lstStopList.Items.RemoveAt(idx);
                //и внутреннего списка
                StopList.Remove(tempkey);
            }
            if (idx < lstStopList.Items.Count)
            {
                lstStopList.SelectedIndex = idx;
            }
            else
            {
                lstStopList.SelectedIndex = lstStopList.Items.Count - 1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            Chanded = true;
            this.Close();
        }

        
    }
}
