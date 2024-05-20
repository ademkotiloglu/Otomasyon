using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Kullanici
{
    public partial class frmKullaniciPanel : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        bool Ac = false;
        int KullaniciID = -1;
        bool edit = false; 
        public frmKullaniciPanel(int ID , bool Acc)
        {
            InitializeComponent();
            Ac = Acc;
            KullaniciID = ID;
            if (Ac)
            {
                KullaniciGetir(ID);
                txtKullaniciAdi.Enabled = false;
            }
        }

        void temizle()
        {
            txtIsim.Text = "";
            txtKullaniciAdi.Text = "";
            txtTuru.SelectedIndex = 1;
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            rdbtnPasif.Checked = true;
            Ac = false;
            KullaniciID = -1;
        }

       

        void KullaniciGetir(int ID)
        {
            KullaniciID = ID;
            try
            {
                Fonksiyonlar.TBL_KULLANICILAR Kullanici = db.TBL_KULLANICILARs.First(s => s.ID == KullaniciID);
                txtIsim.Text = Kullanici.ISIM;
                txtSoyisim.Text = Kullanici.SOYISIM;
                txtKullaniciAdi.Text = Kullanici.KULLANICI;
                txtSifre.Text = Kullanici.SIFRE;
                txtSifreTekrar.Text = Kullanici.SIFRE;
                if (Kullanici.KODU == "Misafir") txtTuru.SelectedIndex = 1;
                if (Kullanici.KODU == "Yönetici") txtTuru.SelectedIndex = 0;
                if (Kullanici.AKTIF.Value) rdbtnAktif.Checked = true;
                if (!Kullanici.AKTIF.Value) rdbtnPasif.Checked = true;

            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }
        private void frmKullaniciPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
             yenikaydet();
       
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void yenikaydet()
        {
            if (txtSifre.Text.Trim() == txtSifreTekrar.Text.Trim())
            {
                if (txtIsim.Text =="")
                {
                    MessageBox.Show("İsim Girişi Yapmak Zorunludur");
                        return;
                }
                else if (txtSoyisim.Text == "")
                {
                MessageBox.Show("Soyisim Girişi Yapmak Zorunludur");
                    return;
                }
                else if (txtKullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı Girişi Zorunludur");
                        return;
                }
                else if (txtSifre.Text == "")
                {
                    MessageBox.Show("Şifre Girişi Yapmak Zorundasınız");
                        return;
                }
                DialogResult DR = MessageBox.Show(txtTuru.Text + "Türünde Bir Kullanıcı Açmak Üzeresiniz . Eminmisiniz? ", "Kullanıcı Kayıt Tamamlama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!Ac)
                        { 
                        if (db.TBL_KULLANICILARs.Where(s => s.KULLANICI == txtKullaniciAdi.Text).Count()>0)
                        {
                            MessageBox.Show("Kullanıcı Adı Mevcut . Farklı Bir Kullanıcı Adı Yazmalısınız ..");
                            return;
                        }

                    }
                       Fonksiyonlar.TBL_KULLANICILAR Kullanici;
                       if (!Ac) Kullanici = new Fonksiyonlar.TBL_KULLANICILAR();
                       else Kullanici = db.TBL_KULLANICILARs.First(s => s.ID == KullaniciID);
                       if (rdbtnAktif.Checked) Kullanici.AKTIF = true;
                       if (rdbtnPasif.Checked) Kullanici.AKTIF = false;
                       Kullanici.ISIM = txtIsim.Text;
                       Kullanici.SOYISIM = txtSoyisim.Text;
                       Kullanici.KULLANICI = txtKullaniciAdi.Text;
                       Kullanici.KODU = txtTuru.Text;
                       if (Ac) Kullanici.EDITDATE = DateTime.Now;
                       else Kullanici.SAVEDATE = DateTime.Now;
                       Kullanici.SIFRE = txtSifre.Text;
                       if (!Ac) db.TBL_KULLANICILARs.InsertOnSubmit(Kullanici);
                       db.SubmitChanges();
                       if (Ac) Mesajlar.Guncelle(true);
                       else Mesajlar.yenikayit(txtKullaniciAdi.Text + "Kullanıcı Kayıtı Açılmıştır");
                       this.Close();
                       Formlar.KullaniciYonetimi();
                     
                        
                       
                       
                    }
                    catch (Exception ex)
                    {
                        Mesajlar.Hata(ex);
                    }
                }
                else MessageBox.Show("Şifreler Aynı Değil");
            }
        }

        private void frmKullaniciPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}