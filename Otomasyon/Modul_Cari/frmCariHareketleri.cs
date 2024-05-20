using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Cari
{
    public partial class frmCariHareketleri : DevExpress.XtraEditors.XtraForm
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
        public frmCariHareketleri()
        {
            InitializeComponent();
        }

        private void frmCariHareketleri_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            var lst = from s in db.TBL_CARIHAREKETLERIs
                      where s.CARIID == FaturaID
                      select s;
            Liste.DataSource = lst;
        }
        public void Ac(int ID)
        {
            try
            {
                FaturaID = ID;
                txtKasaKodu.Text = db.TBL_CARILERs.First(s => s.ID == ID).CARIKODU;
                txtKasaAdi.Text = db.TBL_CARILERs.First(s => s.ID == ID).CARIADI;
                DurumGetir();
                listele();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        void DurumGetir()
        {
            Fonksiyonlar.VW_CARIHAREKET cari = db.VW_CARIHAREKETs.First(s => s.CARIID == FaturaID);
            txtGiris.Text = cari.ALACAK.Value.ToString();
            txtCikis.Text = cari.BORC.Value.ToString();
            txtBakiye.Text = cari.BAKIYE.Value.ToString();
        }

        void sec()
        {
            try
            {
                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("EVRAKID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("CARIID").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTURU = gridView1.GetFocusedRowCellValue("EVRAKTURU").ToString();
            }
            catch (Exception)
            {
                HareketID = -1;
                EvrakTURU = "";
                EvrakID = -1;
            }

        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0)
            {
                Ac(ID);
                AnaForm.aktarma = -1;
            }

        }
  
        private void gridView1_Click(object sender, EventArgs e)
        {

        }


        private void SagTik_Opening_1(object sender, CancelEventArgs e)
        {
            sec();
            if (EvrakTURU == "Kasa Tahsilat")
            {
                DevirKartiDuzenle.Enabled = false;
                TahsilatOdemeDuzenle.Enabled = true;

            }
            else if (EvrakTURU == "Satış Faturası" || EvrakTURU == "Alış Faturası")
            {
                DevirKartiDuzenle.Enabled = true;
                TahsilatOdemeDuzenle.Enabled = false;
            }
        }

        private void DevirKartiDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.Fatura(true, HareketID);
            listele();
        }

        private void TahsilatOdemeDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.KasaTahsilat(true, HareketID);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = int.Parse(gridView1.GetFocusedRowCellValue("EVRAKID").ToString());

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
                Formlar.alisirsaliye(true, ID, false);
            }
            else if (EvrakTURU == "Satış İrsaliyesi")
            {
                Formlar.satisIrsaliye(true, ID, false);
            }
            else if (EvrakTURU == "Kasa Tahsilat")
            {
                Formlar.KasaTahsilat(true, ID);
            }
            else if (EvrakTURU == "Kasa Ödeme")
            {
                Formlar.KasaTahsilat(true, ID);
            }
            else if (EvrakTURU == "Banka Havale")
            {
                Formlar.BankaParaTransferi(true, ID);
            }
            else if (EvrakTURU == "Banka EFT")
            {
                Formlar.BankaParaTransferi(true, ID);
            }
            else if (EvrakTURU == "Müşteri Çeki")
            {
                Mesajlar.hatacek();
            }
            else if (EvrakTURU == "Cariye Çek")
            {
                Formlar.CariCek1(true, ID);
            }
        }

        private void frmCariHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            listele();
            DurumGetir();
        }
    }
}