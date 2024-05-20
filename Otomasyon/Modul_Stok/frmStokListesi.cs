using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;

namespace DXApplication2.Modul_Stok
{
    public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        public bool secim = true;
        int secimID = -1;
        int HareketID = -1;

        public frmStokListesi()
        {
            InitializeComponent();
        }

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        
        public void Listele()
        {
            var lst = from s in DB.VW_STOKLISTESI
                      where s.STOKADI.Contains(txtparcaadi.Text) && s.STOKKODU.Contains(txtparcakodu.Text) && s.STOKBARKOD.Contains(txtbarkod.Text)
                      select s;
            Liste.DataSource = lst;
        }
        

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtbarkod.Text = "";
            txtparcaadi.Text = "";
            txtparcakodu.Text = "";
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

     

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
             sec();
            if (secim && secimID > 0)
            {
                AnaForm.aktarma = secimID;
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

        private void Liste_Click(object sender, EventArgs e)
        {

        }

        private void frmStokListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Formlar.StokKartiDuzen();
        }
    }
}
