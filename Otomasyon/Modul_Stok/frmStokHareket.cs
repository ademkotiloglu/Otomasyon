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

namespace DXApplication2.Modul_Stok
{
    public partial class frmStokHareket : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool secim = true;
        int HareketID = -1;
        int Hareket1ID = -1;
        int FaturaID = -1;
        int EvrakID = -1;
        string EvrakTURU = "";
        public frmStokHareket()
        {
            InitializeComponent();
        }

        private void frmStokHareket_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            var lst = from s in db.VW_STOKHAREKETLERI
                      where s.ID == FaturaID
                      select s;
            Liste.DataSource = lst;
        }
        public void Ac(int ID)
        {
            try
            {
                FaturaID = ID;
                txtKasaKodu.Text = db.TBL_STOKLARs.First(s => s.ID == ID).STOKKODU;
                txtKasaAdi.Text = db.TBL_STOKLARs.First(s => s.ID == ID).STOKADI;
                DurumGetir();
                listele();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.StokListesi(true);
            if (ID > 0)
            {
                Ac(ID);
                AnaForm.aktarma = -1;
            }
        }
        void DurumGetir()
        {
            Fonksiyonlar.VW_STOKDURUM stok = db.VW_STOKDURUMs.First(s => s.ID == FaturaID);
            txtGiris.Text = stok.GIRIS.Value.ToString();
            txtCikis.Text = stok.CIKIS.Value.ToString();
            txtBakiye.Text = stok.BAKIYE.Value.ToString();
        }

        void sec()
        {
            try
            {
                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("FATURAID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("FATURANO").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTURU = gridView1.GetFocusedRowCellValue("TIPI").ToString();
            }
            catch (Exception)
            {
                HareketID = -1;
                EvrakTURU = "";
                EvrakID = -1;
            }
        }

       
        private void FaturaDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.Fatura(true, HareketID);
            listele();
        }

        private void StokDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.aFatura(true, HareketID);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = int.Parse(gridView1.GetFocusedRowCellValue("FATURAID").ToString());
            int ID3 = int.Parse(gridView1.GetFocusedRowCellValue("IRSALIYEID").ToString());

            sec();
            if (EvrakTURU == "Satış Faturası")
            {
                Formlar.Fatura(true, ID, false);
            }
            else if (EvrakTURU == "Alış Faturası")
            {
                Formlar.aFatura(true, ID, false);
            }
            else if (EvrakTURU == "Alış İade Faturası")
            {
                Formlar.aiFatura(true, ID, false);
            }
            else if (EvrakTURU == "Satış İade Faturası")
            {
                Formlar.iFatura(true, ID, false);
            }
            else if (EvrakTURU == "Alış İrsaliyesi")
            {
                Formlar.alisirsaliye(true, ID3, false);
            }
            else if (EvrakTURU == "Satış İrsaliyesi")
            {
                Formlar.satisIrsaliye(true, ID3, false);
            }
            else if (EvrakTURU == "Sıcak Satış")
            {
                Mesajlar.sicaksatis();
            }
         
        }

        private void frmStokHareket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}