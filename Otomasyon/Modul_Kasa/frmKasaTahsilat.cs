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
    public partial class frmKasaTahsilat : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool Edit = false;
        int IslemID = -1;
        string IslemTuru = "Kasa Tahsilat";
        int CariHareketID = -1;
        int KasaID = -1;
        int CariID = -1;
        public frmKasaTahsilat()
        {
            InitializeComponent();
        }

        private void frmKasaTahsilat_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToLongDateString();
            if (IslemID < 0)
                txtBelgeNo.Text = Numaralar.kasahareket('H');
        }

        private void txtIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            IslemTuru = txtIslemTuru.SelectedItem.ToString();
        }

        void temizle()
        {
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtIslemTuru.SelectedIndex = 0;
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            Edit = false;
            IslemID = -1;
            KasaID = -1;
            IslemID = -1;
            CariHareketID = -1;
            AnaForm.aktarma = -1;
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

        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                txtCariAdi.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIADI;
                txtCariKodu.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIKODU;
            }
            catch (Exception)
            {
                CariID = -1;
            }
        }
        
        public void ac(int HareketID)
        {
            try
            {
                Edit = true;
                IslemID = HareketID;
                Fonksiyonlar.TBL_KASAHAREKETLERI KasaHareketi = db.TBL_KASAHAREKETLERIs.First(s => s.ID == IslemID);
                CariHareketID = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == KasaHareketi.EVRAKTURU && s.EVRAKID == IslemID).ID;
                
                txtAciklama.Text = KasaHareketi.ACIKLAMA;
                txtBelgeNo.Text = KasaHareketi.BELGENO;
                if (KasaHareketi.EVRAKTURU == "Kasa Tahsilat") txtIslemTuru.SelectedIndex = 0;
                if (KasaHareketi.EVRAKTURU == "Kasa Ödeme") txtIslemTuru.SelectedIndex = 1;
                txtTarih.Text = KasaHareketi.TARIH.Value.ToShortDateString();
                txtTutar.Text = KasaHareketi.TUTAR.Value.ToString();
                KasaAc(KasaHareketi.KASAID.Value);
                CariAc(KasaHareketi.CARIID.Value);
             
            }
            catch (Exception e)
            {
                temizle();
                Mesajlar.Hata(e);
            }

        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_KASAHAREKETLERI KasaHareketi = new Fonksiyonlar.TBL_KASAHAREKETLERI();
                KasaHareketi.ACIKLAMA = txtAciklama.Text;
                KasaHareketi.BELGENO = txtBelgeNo.Text;
                KasaHareketi.CARIID = CariID;
                KasaHareketi.EVRAKTURU = txtIslemTuru.SelectedItem.ToString();
                if (txtIslemTuru.SelectedIndex == 0) KasaHareketi.GCKODU = "G";
                if (txtIslemTuru.SelectedIndex == 1) KasaHareketi.GCKODU = "C";
                KasaHareketi.KASAID = KasaID;
                KasaHareketi.SAVEDATE = DateTime.Now;
                KasaHareketi.SAVEUSER = AnaForm.UserID;
                KasaHareketi.TARIH = DateTime.Parse(txtTarih.Text);
                KasaHareketi.TUTAR = decimal.Parse(txtTutar.Text);
                db.TBL_KASAHAREKETLERIs.InsertOnSubmit(KasaHareketi);
                db.SubmitChanges();
                Mesajlar.yenikayit(txtIslemTuru.SelectedItem.ToString() + "Yeni Kasa Hareketi Olarak İşlenmiştir.");
                Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = new Fonksiyonlar.TBL_CARIHAREKETLERI();
                CariHareket.ACIKLAMA = txtBelgeNo.Text + "Belge Numarası" + txtIslemTuru.SelectedItem.ToString() + " İşlemi";
                if (txtIslemTuru.SelectedIndex == 0) CariHareket.BORC= decimal.Parse(txtTutar.Text);
                if (txtIslemTuru.SelectedIndex == 1) CariHareket.ALACAK = decimal.Parse(txtTutar.Text);
                CariHareket.CARIID = CariID;
                CariHareket.EVRAKID = KasaHareketi.ID;
                CariHareket.EVRAKTURU = txtIslemTuru.SelectedItem.ToString();
                CariHareket.TARIH = DateTime.Now;
                if (txtIslemTuru.SelectedIndex == 0) CariHareket.TIPI ="KT";
                if (txtIslemTuru.SelectedIndex == 1) CariHareket.TIPI = "KÖ";
                CariHareket.SAVEDATE = DateTime.Now;
                CariHareket.SAVEUSER = AnaForm.UserID;
                db.TBL_CARIHAREKETLERIs.InsertOnSubmit(CariHareket);
                db.SubmitChanges();
                Mesajlar.yenikayit(txtIslemTuru.SelectedItem.ToString() + "Yeni Cari Hareketi Olarak İşlenmiştir");
                frmKasaTahsilat_Load(null, null);
            }

            catch (Exception e)
            {
            Mesajlar.Hata(e);
            }

        }

        void guncelle()
        {
             try
            {
                Fonksiyonlar.TBL_KASAHAREKETLERI KasaHareketi = db.TBL_KASAHAREKETLERIs.First(s => s.ID == IslemID);
                KasaHareketi.ACIKLAMA = txtAciklama.Text;
                KasaHareketi.BELGENO = txtBelgeNo.Text;
                KasaHareketi.CARIID = CariID;
                KasaHareketi.EVRAKTURU = txtIslemTuru.SelectedItem.ToString();
                if (txtIslemTuru.SelectedIndex == 0) KasaHareketi.GCKODU = "G";
                if (txtIslemTuru.SelectedIndex == 1) KasaHareketi.GCKODU = "C";
                KasaHareketi.KASAID = KasaID;
                KasaHareketi.EDITDATE = DateTime.Now;
                KasaHareketi.EDITUSER = AnaForm.UserID;
                KasaHareketi.TARIH = DateTime.Parse(txtTarih.Text);
                KasaHareketi.TUTAR = decimal.Parse(txtTutar.Text);
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = db.TBL_CARIHAREKETLERIs.First(s => s.ID ==CariHareketID);
                CariHareket.ACIKLAMA = txtBelgeNo.Text + "Belge Numarası" + txtIslemTuru.SelectedItem.ToString() + " İşlemi";
                if (txtIslemTuru.SelectedIndex == 0) CariHareket.BORC= decimal.Parse(txtTutar.Text);
                if (txtIslemTuru.SelectedIndex == 0) CariHareket.ALACAK = 0;
                if (txtIslemTuru.SelectedIndex == 1) CariHareket.ALACAK= decimal.Parse(txtTutar.Text);
                if (txtIslemTuru.SelectedIndex == 1) CariHareket.BORC = 0;
                CariHareket.CARIID = CariID;
                CariHareket.EVRAKID = KasaHareketi.ID;
                CariHareket.EVRAKTURU = txtIslemTuru.SelectedItem.ToString();
                CariHareket.TARIH = DateTime.Now;
                if (txtIslemTuru.SelectedIndex == 0) CariHareket.TIPI ="KT";
                if (txtIslemTuru.SelectedIndex == 1) CariHareket.TIPI = "KÖ";
                CariHareket.EDITDATE = DateTime.Now;
                CariHareket.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();

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
                db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.ID == CariHareketID));
                db.SubmitChanges();
                temizle();
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && CariHareketID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
            else yenikaydet();
                 
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0  && CariHareketID > 0 && Mesajlar.Sil() == DialogResult.Yes) sil();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            int Id = Formlar.CariListesi(true);
            if (Id > 0)
            {
                CariAc(Id);
                AnaForm.aktarma = -1;
            }
        }

        private void frmKasaTahsilat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

      
    }
}