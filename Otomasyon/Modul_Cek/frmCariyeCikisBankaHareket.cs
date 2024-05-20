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
    public partial class frmCariyeCikisBankaHareket : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        int CariID = -1;
        int CekID = -1;
        bool edit = false;
        Fonksiyonlar.TBL_CEKLER cek;
        string EvrakTURU = "";
        public frmCariyeCikisBankaHareket()
        {
            InitializeComponent();
        }

        private void frmCariyeCikisBankaHareket_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtVadeTarihi.Text = DateTime.Now.ToShortDateString();
            
        }
        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.TBL_CARILER Cari = db.TBL_CARILERs.First(s => s.ID == CariID);
                txtCariKodu.Text = Cari.CARIADI;
                txtCariAdi.Text = Cari.CARIADI;
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);  
              
            }
        }

        void CekGetir(int ID)
        {
            try
            {
                CekID = ID;
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                txtBanka.Text = cek.BANKA;
                txtCekNo.Text = cek.CEKNO;
                txtSube.Text = cek.SUBE;
                txtVadeTarihi.Text = cek.VADETARIHI.Value.ToShortDateString();
                txtTutar.Text = cek.TUTAR.Value.ToString();
                if (cek.VERILENCARIID != null)
                {
                    if (cek.VERILENCARIID.Value > 0)
                    {
                        CariAc(cek.VERILENCARIID.Value);
                        txtBelgeNo.Text = cek.VERILENCARI_BELGENO;
                        txtTarih.Text = cek.VERILENCARI_TARIHI.Value.ToShortDateString();
                    }
                }
            }
            catch (Exception ex)
            {

                Mesajlar.Hata(ex);
            }
        }

        public void ac(int CekinIDsi)
        {
            try
            {
                CekID = CekinIDsi;
                
                CekGetir(CekID);
                
                    edit = true;
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
                temizle();
            }
        }

        void temizle()
        {
            txtBanka.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtCekNo.Text = "";
            txtSube.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "";
            txtVadeTarihi.Text = DateTime.Now.ToShortDateString();
            CariID = -1;
            CekID = -1;
            edit = false;
            AnaForm.aktarma = -1;
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                cek.VERILENCARIID = CariID;
                cek.VERILENCARI_TARIHI = DateTime.Parse(txtTarih.Text);
                cek.VERILENCARI_BELGENO = txtBelgeNo.Text;
                cek.DURUMU = "Caride";
                cek.EDITDATE = DateTime.Now;
                cek.EDITUSER = AnaForm.UserID;
                
                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI cari = new Fonksiyonlar.TBL_CARIHAREKETLERI();
                cari.ACIKLAMA = txtCekNo.Text + " Çek Numaralı ve" + txtBelgeNo.Text + "Belge Numaralı Çek";
                cari.ALACAK = decimal.Parse(txtTutar.Text);
                cari.CARIID = CariID;
                cari.EVRAKID = CekID;
                cari.EVRAKTURU = "Cariye Çek";
                cari.TARIH = DateTime.Now;
                cari.TIPI = "Çek İşlemi";
                cari.SAVEDATE = DateTime.Now;
                cari.SAVEUSER = AnaForm.UserID;
                db.TBL_CARIHAREKETLERIs.InsertOnSubmit(cari);
                db.SubmitChanges();
                Mesajlar.yenikayit("Cariye Çek Çıkışı İşleminin Hareket Kayıtı ve Çek Kayıtı Güncellemesi Yapılmıştır .");
             
            }
            catch (Exception ex)
            {

                Mesajlar.Hata(ex);
            }
        }

        void guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
                cek.VERILENCARIID = CariID;
                cek.VERILENCARI_TARIHI = DateTime.Parse(txtTarih.Text);
                cek.VERILENCARI_BELGENO = txtBelgeNo.Text;
                cek.DURUMU = "Caride";
                cek.EDITDATE = DateTime.Now;
                cek.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI cari = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == "Cariye Çek" && s.EVRAKID == CekID);
                cari.ACIKLAMA = txtCekNo.Text + " Çek Numaralı ve" + txtBelgeNo.Text + "Belge Numaralı Çek";
                cari.ALACAK = decimal.Parse(txtTutar.Text);
                cari.CARIID = CariID;
                cari.EVRAKID = CekID;
                cari.EVRAKTURU = "Cariye Çek";
                cari.TARIH = DateTime.Now;
                cari.TIPI = "Çek İşlemi";
                cari.EDITDATE = DateTime.Now;
                cari.EDITUSER = AnaForm.UserID;
                
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
            }
            catch (Exception ex)
            {

                Mesajlar.Hata(ex);
            }
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = Formlar.CariListesi(true);
            if (id > 0) CariAc(id);
            AnaForm.aktarma = -1;
        }

        private void txtCekNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = Formlar.ceklistesiduzen(true);
            if (id > 0)  CekGetir(id);
            AnaForm.aktarma = -1;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çek Hareketi Düzenlenemez .Yanlızca Silinebilir..");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            
            try
{
             
    if ( edit && Mesajlar.Sil() == DialogResult.Yes && CariID > 0 && CekID > 0)
    {
        db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == "Cariye Çek" && s.EVRAKID == CekID ));
        Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
        cek.VERILENCARI_BELGENO = "";
        cek.VERILENCARIID = -1;
                    cek.DURUMU = "Portföy";
                    
        db.SubmitChanges();
                    Mesajlar.deneme("Silme Başarılı .");
                    this.Close();
                }
}
            catch (Exception ex)
{
    Mesajlar.Hata(ex);
}
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCariyeCikisBankaHareket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtCekNo_Click(object sender, EventArgs e)
        {

        }
    }
}