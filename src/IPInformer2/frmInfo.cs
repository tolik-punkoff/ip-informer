using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SxGeoSharp;

namespace IPInformer2
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        public SxGeoHeader Header;
        public string DBPath = "";
        public string CurrentScript = "";
        
        private void frmInfo_Load(object sender, EventArgs e)
        {
            txtCurrentScript.Text = CurrentScript;
            
            SxGeoDB tmpDB = new SxGeoDB(DBPath);
            if (!tmpDB.OpenDB())
            {
                CommonFunctions.ErrMessage(tmpDB.ErrorMessage);
                return;
            }

            Header = tmpDB.GetHeader();

            tmpDB.CloseDB();
        }
        
        private void frmInfo_Shown(object sender, EventArgs e)
        {
            string[] LabelText = new string[] {"Имя файла:",
            "Путь:",
            "Версия: ",
            "Время создания: ",
            "Тип БД: ",
            "Кодировка: ",
            "Элементов в индексе первых байт: ",
            "Элементов в основном индексе: ",
            "Блоков в одном элементе индекса: ",
            "Количество диапазонов: ",
            "Размер ID-блока в байтах (1 для стран, 3 для городов): ",
            "Максимальный размер записи региона: ",
            "Максимальный размер записи города: ",
            "Размер справочника регионов: ",
            "Размер справочника городов: ",
            "Максимальный размер записи страны: ",
            "Размер справочника стран: ",
            "Размер описания формата упаковки города/региона/страны: ",
            "Описание формата упаковки (RAW): ",
            //"---",
            "Начало индекса первых байт: ",
            "Начало основного индекса: ",
            "Начало диапазонов: ",
            "Начало справочника регионов: ",
            "Начало справочника городов: ",
            "Начало справочника стран: "};

            grdInfo.Columns.Add("Info", "Info");
            grdInfo.Columns.Add("Data", "Data");
            
            List<string> ldata = new List<string>();
            FileInfo fi;
            try
            {
                fi = new FileInfo(DBPath);
            }
            catch
            {
                return;
            }

            ldata.Add(fi.Name);
            ldata.Add(fi.DirectoryName);
            ldata.Add(Header.Version);
            ldata.Add(Header.Timestamp.ToString());
            ldata.Add(Header.DBType.ToString());
            ldata.Add(Header.DBEncoding.ToString());
            ldata.Add(Header.fbIndexLen.ToString());
            ldata.Add(Header.mIndexLen.ToString());
            ldata.Add(Header.Range.ToString());
            ldata.Add(Header.DiapCount.ToString());
            ldata.Add(Header.IdLen.ToString());
            ldata.Add(Header.MaxRegion.ToString());
            ldata.Add(Header.MaxCity.ToString());
            ldata.Add(Header.RegionSize.ToString());
            ldata.Add(Header.CitySize.ToString());
            ldata.Add(Header.MaxCountry.ToString());
            ldata.Add(Header.CountrySize.ToString());
            ldata.Add(Header.PackSize.ToString());
            ldata.Add(Header.PackFormat.ToString().Replace('\0', '\n'));

            //смещения частей БД
            ldata.Add(Header.fb_begin.ToString());
            ldata.Add(Header.midx_begin.ToString());
            ldata.Add(Header.db_begin.ToString());
            ldata.Add(Header.regions_begin.ToString());
            ldata.Add(Header.cites_begin.ToString());
            ldata.Add(Header.countries_begin.ToString());

            int i = 0;
            foreach (string txt in LabelText)
            {
                grdInfo.Rows.Add(txt, ldata[i]);
                i++;
            }

            
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
