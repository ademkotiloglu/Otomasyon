using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.CodeParser;

namespace DXApplication2.Modul_Kasa
{
    public partial class frmKasaHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();

        int HareketID = -1;
        int Hareket1ID = -1;
        int KasaID = -1;
        int EvrakID = -1;
        string EvrakTURU;
        public frmKasaHareketleri()
        {
            InitializeComponent();
        }

        public void Ac(int ID)
        {
            try
            {
                KasaID = ID;
                txtKasaKodu.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAKODU;
                txtKasaAdi.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAADI;
                DurumGetir();
                listele();
            }
                catch (Exception e)
            {
                Mesajlar.Hata(e);
                }
        }

        void listele()
        {

            var lst = from s in db.VW_KASAHAREKETLERIs
                      where s.KASAID == KasaID
                      select s;
            Liste.DataSource = lst;
            Liste.Enabled = true;
        }
        
        void DurumGetir()
        {
            Fonksiyonlar.VW_KASADURUM Kasa = db.VW_KASADURUM.First(s => s.ID == KasaID);
            txtGiris.Text = Kasa.GIRIS.Value.ToString();
            txtCikis.Text = Kasa.CIKIS.Value.ToString();
            txtBakiye.Text = Kasa.BAKIYE.Value.ToString();
        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.KasaListesi(true);
            if (ID > 0)
            {
                Ac(ID);
                AnaForm.aktarma = -1;
            }
        }

        void sec()
        {
            try
            {

                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("KASAID").ToString());
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
        private void SagTik_Opening(object sender, CancelEventArgs e)
        {
           sec();
            if (EvrakTURU == "Kasa Devir Kartı")
            {
                DevirKartiDuzenle.Enabled =true;
                TahsilatOdemeDuzenle.Enabled =false;

            }
            else if (EvrakTURU == "Kasa Tahsilat" || EvrakTURU == "Kasa Ödeme")
            {
                DevirKartiDuzenle.Enabled = false;
                TahsilatOdemeDuzenle.Enabled = true;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void DevirKartiDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.KasaDevir(true, HareketID);
            
        }

        private void TahsilatOdemeDuzenle_Click(object sender, EventArgs e)
        {
            Formlar.KasaTahsilat(true, HareketID);
            
        }

        private void frmKasaHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            DurumGetir();
        }

        private void frmKasaHareketleri_Load(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

            sec();
            if (EvrakTURU == "Satış Faturası" || EvrakTURU == "Alış Faturası" || EvrakTURU =="Satış İade Faturası" || EvrakTURU =="Alış İade Faturası") 
            {
                Mesajlar.hata123("Evrak Türü Fatura Olan Kayıtlar Fatura Listesi Bölümünden Düzenlenebilir ..");
            }
        }
    }
}