using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Cek
{
    public partial class frmMusteriCeki : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        int CariID = -1;
        int CekID = -1;
        bool edit = false;
        public frmMusteriCeki()
        {
            InitializeComponent();
        }

        private void frmMusteriCeki_Load(object sender, EventArgs e)
        {
            if (CekID < 0)
            txtBelgeNo.Text = Numaralar.cek('C');
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
        void temizle()
        {
            txtAciklama.Text = "";
            txtBanka.Text = "";
            txtBelgeNo.Text = "";
            txtBorclu.Text = "";
            txtCariadi.Text = "";
            txtCariKodu.Text = "";
            txtCekNo.Text = "";
            txtCekTuru.SelectedIndex = 0;
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtTarih.Text = "";
            txtTutar.Text = "";
            CariID = -1;
            CekID = -1;
            AnaForm.aktarma = -1;
            edit = false;

        }

        void yenikaydet()
        {
           try 
	{	        
		 Fonksiyonlar.TBL_CEKLER cek = new Fonksiyonlar.TBL_CEKLER();
            cek.ACIKLAMA = txtAciklama.Text;
            if (txtCekTuru.SelectedIndex == 0) cek.ACKODU = "A";
            if (txtCekTuru.SelectedIndex == 1) cek.ACKODU = "C";
            cek.ALINANCARIID = CariID;
            cek.BANKA = txtBanka.Text;
            cek.BELGENO = txtBelgeNo.Text;
            cek.CEKNO = txtCekNo.Text;
            cek.DURUMU = "Portföy";
            cek.HESAPNO = txtHesapNo.Text;
            cek.SUBE = txtSube.Text;
            cek.ASILBORCLU = txtBorclu.Text;
            cek.TAHSIL = "Hayır";
            cek.VADETARIHI = DateTime.Parse(txtTarih.Text);
            cek.TUTAR = decimal.Parse(txtTutar.Text);
            cek.TIPI = "Müşteri Çeki";
            cek.SAVEDATE = DateTime.Now;
            cek.SAVEUSER = AnaForm.UserID;
            db.TBL_CEKLERs.InsertOnSubmit(cek);
            db.SubmitChanges();
            Mesajlar.yenikayit(txtCekNo.Text + "No lu Çek Kayıtı Gerçekleştirilmişitir");
            Fonksiyonlar.TBL_CARIHAREKETLERI cari = new Fonksiyonlar.TBL_CARIHAREKETLERI();
            cari.ACIKLAMA = txtBelgeNo.Text + "Belge Numaralı ve" + txtCekNo.Text + " Çek Numaralı Müşteri Çeki";
            cari.CARIID = CariID;
            cari.EVRAKID = cek.ID;
            cari.EVRAKTURU = "Müşteri Çeki";
            cari.TARIH = DateTime.Now;
            cari.TIPI = "MÇ";
            cari.SAVEDATE = DateTime.Now;
            cari.SAVEUSER = AnaForm.UserID;
            db.TBL_CARIHAREKETLERIs.InsertOnSubmit(cari);
            db.SubmitChanges();
            Mesajlar.yenikayit(txtCekNo.Text + "No'lu Müşteri Çeki Kaydı Gerçekleştirilmiştir.");
            temizle();
                frmMusteriCeki_Load(null, null);
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
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                cek.ACIKLAMA = txtAciklama.Text;
                if (txtCekTuru.SelectedIndex == 0) cek.ACKODU = "A";
                if (txtCekTuru.SelectedIndex == 1) cek.ACKODU = "C";
                cek.ALINANCARIID = CariID;
                cek.BANKA = txtBanka.Text;
                cek.ASILBORCLU = txtBorclu.Text;
                cek.BELGENO = txtBelgeNo.Text;
                cek.CEKNO = txtCekNo.Text;
                cek.DURUMU = "Portföy";
                cek.HESAPNO = txtHesapNo.Text;
                cek.SUBE = txtSube.Text;
                cek.TAHSIL = "Hayır";
                cek.VADETARIHI = DateTime.Parse(txtTarih.Text);
                cek.TUTAR = decimal.Parse(txtTutar.Text);
                cek.TIPI = "Müşteri Çeki";
                cek.EDITDATE = DateTime.Now;
                cek.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI cari = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKID == CekID && s.EVRAKTURU == "Müşteri Çeki" && s.TIPI == "MÇ");
                cari.ACIKLAMA = txtBelgeNo.Text + "Belge Numaralı ve" + txtCekNo.Text + " Çek Numaralı Müşteri Çeki";
                cari.CARIID = CariID;
                cari.EVRAKID = cek.ID;
                cari.EVRAKTURU = "Müşteri Çeki";
                cari.TARIH = DateTime.Now;
                cari.TIPI = "MÇ";
                cari.EDITDATE = DateTime.Now;
                cari.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle();
                Mesajlar.deneme("Kayıt Güncellendi.");
                
                
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }

        }

        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                txtCariadi.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIADI;
                txtCariKodu.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIKODU;
            }
            catch (Exception)
            {
                CariID = -1;
            }
        }

        public void ac(int ID)
        {
            try
            {
                CekID = ID;
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                txtAciklama.Text = cek.ACIKLAMA;
                if (cek.ACKODU == "A") txtCekTuru.SelectedIndex = 0;
                if (cek.ACKODU == "C") txtCekTuru.SelectedIndex = 1;
                txtBorclu.Text = cek.ASILBORCLU;
                txtBanka.Text = cek.BANKA;
                txtBelgeNo.Text = cek.BELGENO;
                txtCekNo.Text = cek.CEKNO;
                txtHesapNo.Text = cek.HESAPNO;
                txtSube.Text = cek.SUBE;
                txtTutar.Text = cek.TUTAR.Value.ToString();
                txtTarih.Text = cek.VADETARIHI.Value.ToShortDateString();
                CariAc(cek.ALINANCARIID.Value);
                edit = true;

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
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

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (edit) guncelle();
            else yenikaydet();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (edit & CekID > 0 & Mesajlar.Sil() == DialogResult.Yes);
            {
                db.TBL_CEKLERs.DeleteOnSubmit(db.TBL_CEKLERs.First(s => s.ID == CekID));
                db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKID == CekID && s.EVRAKTURU == "Müşteri Çeki"));
                db.SubmitChanges();
                this.Close();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMusteriCeki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}