using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Stok
{
    public partial class frmStokDuzenList : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        public bool secim = true;
        int secimID = -1;
        int HareketID = -1;
        public frmStokDuzenList()
        {
            InitializeComponent();
        }

        private void frmStokDuzenList_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            var lst = from s in DB.VW_STOKLISTESI
                      where s.STOKADI.Contains(txtparcaadi.Text) && s.STOKKODU.Contains(txtparcakodu.Text) 
                      select s;
            Liste.DataSource = lst;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtbarkod.Text = "";
            txtparcaadi.Text = "";
            txtparcakodu.Text = "";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        void sec()
        {
            try
            {
                secimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {
                secimID = -1;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            Formlar.StokKartiDuzen(true, HareketID);

        }

        private void frmStokDuzenList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Acrobat Reader|*.pdf";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Liste.ExportToPdf(sf.FileName);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel|*.xls";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Liste.ExportToXls(sf.FileName);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Formlar.StokKarti();
        }
    }
}