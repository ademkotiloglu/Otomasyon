using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Kasa
{
    public partial class frmKasaDevir : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool edit = false;
        int KasaID = -1;
        int IslemID = -1;
        public frmKasaDevir()
        {
            InitializeComponent();
        }

        private void frmKasaDevir_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToLongDateString();
            if (IslemID < 0)
                txtBelgeNo.Text = Numaralar.kasahareket('H');
        }

        void Temizle ()
        {
            txtTarih.Text = DateTime.Now.ToLongDateString();
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
            txtTutar.Text = "0";
            edit = false;
            KasaID = -1;
            IslemID = -1;
            AnaForm.aktarma = -1;
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_KASAHAREKETLERI Hareket = new Fonksiyonlar.TBL_KASAHAREKETLERI();
                Hareket.ACIKLAMA = txtAciklama.Text;
                Hareket.BELGENO = txtBelgeNo.Text;
                Hareket.EVRAKTURU = "Kasa Devir Kartı";
                if (rdbtncikis.Checked) Hareket.GCKODU = "C";
                if (rdbtngiris.Checked) Hareket.GCKODU = "G";
                Hareket.KASAID = KasaID;
                Hareket.TARIH = DateTime.Parse(txtTarih.Text);
                Hareket.TUTAR = decimal.Parse(txtTutar.Text);
                Hareket.SAVEDATE = DateTime.Now;
                Hareket.SAVEUSER = AnaForm.UserID;
                db.TBL_KASAHAREKETLERIs.InsertOnSubmit(Hareket);
                db.SubmitChanges();
                Mesajlar.yenikayit("Devir Kartı Hareket Kaydı İşlenmiştir.");
                Temizle();
                frmKasaDevir_Load(null, null);
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }

        }

        void guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_KASAHAREKETLERI Hareket = db.TBL_KASAHAREKETLERIs.First(s => s.ID == IslemID);
                Hareket.ACIKLAMA = txtAciklama.Text;
                Hareket.BELGENO = txtBelgeNo.Text;
                Hareket.EVRAKTURU = "Kasa Devir Kartı";
                if (rdbtncikis.Checked) Hareket.GCKODU = "C";
                if (rdbtngiris.Checked) Hareket.GCKODU = "G";
                Hareket.KASAID = KasaID;
                Hareket.TARIH = DateTime.Parse(txtTarih.Text);
                Hareket.TUTAR = decimal.Parse(txtTutar.Text);
                Hareket.EDITDATE = DateTime.Now;
                Hareket.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void sil()
        {

            try
            {
                db.TBL_KASAHAREKETLERIs.DeleteOnSubmit(db.TBL_KASAHAREKETLERIs.First(s => s.ID == IslemID));
                db.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void KasaAc(int ID)
        {
            try
            {
                KasaID = ID;
                txtKasaAdi.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAADI;
                txtKasaKodu.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAKODU;
            }
            catch (Exception)
            {
                KasaID = -1;
            }
        }

        public void Ac(int HareketID)
        {

            try
            {
                edit = true;
                IslemID = HareketID;               
                Fonksiyonlar.TBL_KASAHAREKETLERI hareket = db.TBL_KASAHAREKETLERIs.First(s => s.ID == IslemID);
                txtAciklama.Text = hareket.ACIKLAMA;
                txtBelgeNo.Text = hareket.BELGENO;                
                txtTarih.Text = hareket.TARIH.Value.ToShortTimeString();
                txtTutar.Text = hareket.TUTAR.Value.ToString();
                if (hareket.GCKODU == "G") rdbtngiris.Checked = true;
                if (hareket.GCKODU == "C") rdbtncikis.Checked = true;
                KasaAc(hareket.KASAID.Value);

            }
            catch (Exception e)
            {
                Temizle();
                Mesajlar.Hata(e);
            }
        }
        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (edit && IslemID > 0 && Mesajlar.Sil() == DialogResult.Yes) sil();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (edit && IslemID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
            else yenikaydet();
        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            int Id = Formlar.KasaListesi(true);
            if (Id > 0)
            {
                KasaAc(Id);
                AnaForm.aktarma = -1;
            }
        }

        private void frmKasaDevir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}