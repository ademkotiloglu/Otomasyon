using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;

namespace DXApplication2.Modul_Banka
{
    public partial class frmBankaİslem : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool edit = false;
        int BankaID = -1;
        int IslemID = -1;
    
        
       
        public frmBankaİslem()
        {
            InitializeComponent();
        }

        void temizle()
    {
        txtTarih.Text = DateTime.Now.ToLongDateString();
        txtAciklama.Text = "";
        txtBelgeNo.Text = "";
        txtHesapNo.Text = "";
        txtHesapTuru.Text = "";
        txtTutar.Text = "0";
        edit = false;
        BankaID = -1;
        IslemID = -1;
            
        AnaForm.aktarma = -1;

    }
        private void frmBankaİslem_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToLongDateString();
            if (BankaID<0)  
            txtBelgeNo.Text = Numaralar.bankaislem('B');
            
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_BANKAHAREKETLERI Hareket = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
                Hareket.ACIKLAMA = txtAciklama.Text;
                Hareket.BELGENO = txtBelgeNo.Text;
                Hareket.EVRAKTURU = "Banka İslem";
                if (rbtncikis.Checked) Hareket.GCKODU = "C";
                if (rbtngiris.Checked) Hareket.GCKODU = "G";
                Hareket.BANKAID = BankaID;
                Hareket.TARIH = DateTime.Parse(txtTarih.Text);
                Hareket.TUTAR = decimal.Parse(txtTutar.Text);
                Hareket.SAVEDATE = DateTime.Now;
                Hareket.SAVEUSER = AnaForm.UserID;
                db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(Hareket);
                db.SubmitChanges();
                Mesajlar.yenikayit("Banka İşlem kaydı Yapılmıştır.");
                temizle();
                frmBankaİslem_Load(null, null);
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
                Fonksiyonlar.TBL_BANKAHAREKETLERI Hareket = db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID);
                Hareket.ACIKLAMA = txtAciklama.Text;
                Hareket.BELGENO = txtBelgeNo.Text;
                Hareket.EVRAKTURU = "Banka İslem";
                if (rbtncikis.Checked) Hareket.GCKODU = "C";
                if (rbtngiris.Checked) Hareket.GCKODU = "G";
                Hareket.BANKAID = BankaID;
                Hareket.TARIH = DateTime.Parse(txtTarih.Text);
                Hareket.TUTAR = decimal.Parse(txtTutar.Text);
                Hareket.EDITDATE = DateTime.Now;
                Hareket.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                temizle();

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
                db.TBL_BANKAHAREKETLERIs.DeleteOnSubmit(db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID));
                temizle();
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

        public void ac(int ID)
        {
            try
            {
                edit = true;
                IslemID = ID;
                Fonksiyonlar.TBL_BANKAHAREKETLERI Hareket = db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID);
                BankaAc(Hareket.BANKAID.Value);
                txtAciklama.Text = Hareket.ACIKLAMA;
                txtBelgeNo.Text = Hareket.BELGENO;
                txtTarih.Text = Hareket.TARIH.Value.ToShortDateString();
                txtTutar.Text = Hareket.TUTAR.ToString();
                if (Hareket.GCKODU == "G") rbtngiris.Checked = true;
                if (Hareket.GCKODU == "C") rbtncikis.Checked = true;
            }
            catch (Exception e)
            {
                temizle();
                Mesajlar.Hata(e);
            }
        }
       
        void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                txtHesapTuru.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPADI;
                txtHesapNo.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPNO;
            }
            catch (Exception)
            {
                BankaID = -1;
            }
        }
        private void txtHesapTuru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int Id = Formlar.BankaListesi(true);
            if (Id > 0) BankaAc(Id);
            AnaForm.aktarma = -1;
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

        private void frmBankaİslem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}