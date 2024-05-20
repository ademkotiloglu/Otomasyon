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
    public partial class frmKendiCekim : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        int CariID = -1;
        int CekID = -1;
        int BankaID = -1;
        bool edit = false;
        public frmKendiCekim()
        {
            InitializeComponent();
        }

        private void frmKendiCekim_Load(object sender, EventArgs e)
        {
            if (CekID <0)
            txtBelgeNo.Text = Numaralar.cek('C');
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        void temizle()
        {
            txtAciklama.Text = "";
            txtBanka.Text = "";
            txtBelgeNo.Text = "";
            txtCekNo.Text = "";
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtTarih.Text = "";
            txtTutar.Text = "";
            CekID = -1;
            CariID = -1;
            AnaForm.aktarma = -1;
            edit = false;

        }

        void yenikaydet()
        {
            try
            {
                
                Fonksiyonlar.TBL_CEKLER cek = new Fonksiyonlar.TBL_CEKLER();
                cek.ACIKLAMA = txtAciklama.Text;
                cek.ACKODU = "A";
                cek.BANKA = txtBanka.Text;
                cek.BELGENO = txtBelgeNo.Text;
                cek.CEKNO = txtCekNo.Text;
                cek.DURUMU = "Portföy";
                cek.HESAPNO = txtHesapNo.Text;
                cek.SUBE = txtSube.Text;
                cek.TAHSIL = "Hayır";
                cek.TARIH = DateTime.Now;
                cek.TIPI = "Kendi Çekimiz";
                cek.TUTAR = decimal.Parse(txtTutar.Text);
                cek.VADETARIHI = DateTime.Parse(txtTarih.Text);
                cek.SAVEDATE = DateTime.Now;
                cek.SAVEUSER = AnaForm.UserID;
                db.TBL_CEKLERs.InsertOnSubmit(cek);
                db.SubmitChanges();
                Mesajlar.yenikayit(txtCekNo.Text + "Numaralı Çek Kayıtı Gerçekleştirilmişitir");
                Fonksiyonlar.TBL_BANKAHAREKETLERI banka = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
                banka.ACIKLAMA = txtCekNo.Text + "Numaralı ve " + txtTarih.Text + "Vadeli Kendi Çekimiz";
                banka.BANKAID = BankaID;
                banka.BELGENO = txtBelgeNo.Text;
                banka.EVRAKID = cek.ID;
                banka.EVRAKTURU = "Kendi Çekimiz";
                banka.GCKODU = "C";
                banka.TARIH = DateTime.Now;
                banka.TUTAR = decimal.Parse(txtTutar.Text);
                banka.SAVEDATE = DateTime.Now;
                banka.SAVEUSER = AnaForm.UserID;
                db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(banka);
                db.SubmitChanges();
                Mesajlar.yenikayit(txtCekNo.Text + "Numaralı Kendi Çekinizin Banka Kayıtı yapılmıştır");
                temizle();
                frmKendiCekim_Load(null, null);
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

        void guncelle()


        {
            {
                try
                {
                    Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                    cek.ACIKLAMA = txtAciklama.Text;
                    cek.ACKODU = "A";
                    cek.BANKA = txtBanka.Text;
                    cek.BELGENO = txtBelgeNo.Text;
                    cek.CEKNO = txtCekNo.Text;
                    cek.DURUMU = "Portföy";
                    cek.HESAPNO = txtHesapNo.Text;
                    cek.SUBE = txtSube.Text;
                    cek.TAHSIL = "Hayır";
                    cek.TARIH = DateTime.Now;
                    cek.TIPI = "Kendi Çekimiz";
                    cek.TUTAR = decimal.Parse(txtTutar.Text);
                    cek.VADETARIHI = DateTime.Parse(txtTarih.Text);
                    cek.EDITDATE = DateTime.Now;
                    cek.EDITUSER = AnaForm.UserID;
                    db.SubmitChanges();
                    Fonksiyonlar.TBL_BANKAHAREKETLERI banka = db.TBL_BANKAHAREKETLERIs.First(s => s.EVRAKID == CekID && s.EVRAKTURU == "Kendi Cekimiz");
                    banka.ACIKLAMA = txtCekNo.Text + "Numaralı ve " + txtTarih.Text + "Vadeli Kendi Çekimiz";
                    banka.BANKAID = BankaID;
                    banka.BELGENO = txtBelgeNo.Text;
                    banka.EVRAKID = cek.ID;
                    banka.EVRAKTURU = "Kendi Çekimiz";
                    banka.GCKODU = "C";
                    banka.TARIH = DateTime.Now;
                    banka.TUTAR = decimal.Parse(txtTutar.Text);
                    banka.EDITDATE = DateTime.Now;
                    banka.EDITUSER = AnaForm.UserID;
                    db.SubmitChanges();
                    Mesajlar.Guncelle();
                    Mesajlar.deneme("Kayıt Güncellendi.");

                }
                catch (Exception e)
                {

                   
                }
            }
        }

        void sil()
        {
            try
            {
                db.TBL_CEKLERs.DeleteOnSubmit(db.TBL_CEKLERs.First(s => s.ID == CekID));
                db.TBL_BANKAHAREKETLERIs.DeleteOnSubmit(db.TBL_BANKAHAREKETLERIs.First(s => s.EVRAKID == CekID && s.EVRAKTURU == "Kendi Çekimiz"));
                
                
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        public void BankaAc(int BankaIDs)
        {
            try
            {
                BankaID = BankaIDs;
                Fonksiyonlar.TBL_BANKALAR banka = db.TBL_BANKALARs.First(s => s.ID == BankaID);
                txtBanka.Text = banka.BANKAADI;
                txtHesapNo.Text = banka.HESAPNO;
                txtSube.Text = banka.SUBE;
              

            }
            catch (Exception)
            {
                BankaID = -1;
            }
        }

        public void Ac(int cekID)
        {
            try
            {
                CekID = cekID;
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                BankaAc(db.TBL_BANKALARs.First(s => s.BANKAADI == cek.BANKA && s.HESAPNO == cek.HESAPNO).ID);
                txtAciklama.Text = cek.ACIKLAMA;
                txtBelgeNo.Text = cek.BELGENO;
                txtCekNo.Text = cek.CEKNO;
                txtTutar.Text = cek.TUTAR.Value.ToString();
                txtTarih.Text = cek.TARIH.Value.ToShortDateString();
                
                edit = true;
              

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
                temizle();
            }
        }
        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (edit & CekID > 0 & Mesajlar.Sil() == DialogResult.Yes) ;
            {
                db.TBL_CEKLERs.DeleteOnSubmit(db.TBL_CEKLERs.First(s => s.ID == CekID));
                db.TBL_BANKAHAREKETLERIs.DeleteOnSubmit(db.TBL_BANKAHAREKETLERIs.First(s => s.EVRAKID == CekID && s.EVRAKTURU == "Kendi Çekimiz"));
                db.SubmitChanges();
                Mesajlar.deneme("Silme Başarılı .");
                this.Close();
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (edit && CekID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
            else yenikaydet();
        }

        private void txtHesapNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int Id = Formlar.BankaListesi(true);
            if (Id > 0)
            {
                BankaAc(Id);
                AnaForm.aktarma = -1;
            }
        }

        private void frmKendiCekim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}