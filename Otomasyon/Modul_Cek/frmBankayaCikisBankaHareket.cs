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
    public partial class frmBankayaCikisBankaHareket : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        int BankaID = -1;
        int CekID = -1;
        bool edit = false;
        Fonksiyonlar.TBL_CEKLER cek;

        public frmBankayaCikisBankaHareket()
        {
            InitializeComponent();
        }

       void temizle()
        {
            txtBanka.Text = "";
            txtBankaAdi.Text = "";
            txtBelgeNo.Text = "";
            txtCekNo.Text = "";
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "";
            CekID = -1;
            BankaID = -1;
            AnaForm.aktarma = -1;
 ;

        }

        void cekgetir(int ID)
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
                
                if (cek.VERILENBANKAID != null)
                {
                    if (cek.VERILENBANKAID.Value > 0)
                    {
                        bankagetir(cek.VERILENBANKAID.Value);
                        txtBelgeNo.Text = cek.VERILENBANKA_BELGENO;
                        txtTarih.Text = cek.VERILENBANKA_TARIHI.Value.ToShortDateString();
                    }
                }

            }
            catch (Exception ex)
           {
               Mesajlar.Hata(ex);
           }
       }


        void bankagetir(int ID)
        {
            try
            {
                BankaID = ID;
                Fonksiyonlar.TBL_BANKALAR Banka = db.TBL_BANKALARs.First(s => s.ID == BankaID);
                txtHesapNo.Text= Banka.HESAPNO;
                txtBankaAdi.Text = Banka.HESAPADI;
                
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_BANKAHAREKETLERI bankahareket = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
                bankahareket.ACIKLAMA = txtBelgeNo.Text + "Belge Numaralı ve " + txtCekNo.Text + "Numaralı Çekin Bankaya Çıkışı";
                bankahareket.BANKAID = BankaID;
                bankahareket.BELGENO = txtBelgeNo.Text;
                bankahareket.EVRAKID = CekID;
                bankahareket.EVRAKTURU = "Bankaya Çek";
                bankahareket.GCKODU = "G";
                bankahareket.TARIH = DateTime.Parse(txtTarih.Text);
                bankahareket.TUTAR = decimal.Parse(txtTutar.Text);
                bankahareket.SAVEDATE = DateTime.Now;
                bankahareket.SAVEUSER = AnaForm.UserID;
                db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(bankahareket);
                db.SubmitChanges();

                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);

                cek.VERILENBANKA_BELGENO = txtBelgeNo.Text;
                cek.VERILENBANKA_TARIHI = DateTime.Parse(txtTarih.Text);
                cek.VERILENBANKAID = BankaID;
                cek.DURUMU = "Bankada";
                db.SubmitChanges();
                Mesajlar.yenikayit("Bankaya Çek Çıkışı İşleminin Hareket Kayıtı ve Çek Kayıtı Güncellemesi Yapılmıştır .");
                temizle();
               
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
                Fonksiyonlar.TBL_BANKAHAREKETLERI bankahareket = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
                bankahareket.ACIKLAMA = txtBelgeNo.Text + "Belge Numaralı ve " + txtCekNo.Text + "Numaralı Çekin Bankaya Çıkışı";
                bankahareket.BANKAID = BankaID;
                bankahareket.BELGENO = txtBelgeNo.Text;
                bankahareket.EVRAKID = CekID;
                bankahareket.EVRAKTURU = "Bankaya Çek";
                bankahareket.GCKODU = "G";
                bankahareket.TARIH = DateTime.Parse(txtTarih.Text);
                bankahareket.TUTAR = decimal.Parse(txtTutar.Text);
                bankahareket.SAVEDATE = DateTime.Now;
                bankahareket.SAVEUSER = AnaForm.UserID;
                db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(bankahareket);
                db.SubmitChanges();

                Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);

                cek.VERILENBANKA_BELGENO = txtBelgeNo.Text;
                cek.VERILENBANKA_TARIHI = DateTime.Parse(txtTarih.Text);
                cek.VERILENBANKAID = BankaID;
                cek.DURUMU = "Bankada";
                
                cek.EDITDATE = DateTime.Now;
                cek.EDITUSER = AnaForm.UserID;
                Mesajlar.yenikayit("Bankaya Çek Çıkışı İşleminin Hareket Kayıtı ve Çek Kayıtı Güncellemesi Yapılmıştır .");

                db.SubmitChanges();
                temizle();
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        private void frmBankayaCikisBankaHareket_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtVadeTarihi.Text = DateTime.Now.ToShortDateString();
            
        }

        private void txtHesapNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = Formlar.BankaListesi(true);
            if (id > 0)
            {
                bankagetir(id);
                            }
            AnaForm.aktarma = -1;
        }

        private void txtCekNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = Formlar.ceklistesiduzen(true);
            if (id > 0) cekgetir(id);
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
    if ( edit && Mesajlar.Sil() == DialogResult.Yes && BankaID > 0 && CekID > 0)
    {
        db.TBL_BANKAHAREKETLERIs.DeleteOnSubmit(db.TBL_BANKAHAREKETLERIs.First(s => s.EVRAKTURU == "Bankaya Çek" && s.EVRAKID == CekID ));
        Fonksiyonlar.TBL_CEKLER cek = db.TBL_CEKLERs.First(s => s.ID == CekID);
        cek.VERILENBANKA_BELGENO = "";
        cek.VERILENBANKAID = -1;
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

        private void frmBankayaCikisBankaHareket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
        private void txtBelgeNo_Click(object sender, EventArgs e)
        {
           
        }
        public void ac(int CekinIDsi)
        {
            try
            {
                CekID = CekinIDsi;

                cekgetir(CekID);

                edit = true;
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
                temizle();
            }
        }
    }
}