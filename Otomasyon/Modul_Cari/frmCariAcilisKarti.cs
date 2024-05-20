using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Data.SqlClient;

namespace DXApplication2.Modul_Cari
{
    public partial class frmCariAcilisKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        

        bool Edit = false;

        bool Resim = false;
        OpenFileDialog Dosya = new OpenFileDialog();
        int GrupID = -1;
        int CariID = -1;
        double VAL = 0;
        string ID1 = "CR";
       
        public frmCariAcilisKarti()
        {
            InitializeComponent();
        }

   
        void temizle()
        {
            txtCariKodu.Text = Numaralar.CariKodNumarasi('C');
            txtAdres.Text = "";
            txtCariAdi.Text = "";
            txtCariGrupKodu.Text = "";
            txtCariKodu.Text = "";
            txtFax1.Text = "";
            txtFax2.Text = "";
            txtGrupAdi.Text = "";
            txtIlce.Text = "";
            txtMail.Text = "";
            txtMailInfo.Text = "";
            txtSehir.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtUlke.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtWeb.Text = "";
            txtYetkili1.Text = "";
            txtYetkili2.Text = "";
            txtYetkiliEmail.Text = "";
            Edit = false;
            GrupID = -1;
            CariID = -1;
            AnaForm.aktarma = -1;

        }
        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CARILER cari = new Fonksiyonlar.TBL_CARILER();
                cari.ADRES = txtAdres.Text;
                cari.GRUPID = GrupID;
                cari.CARIADI = txtCariAdi.Text;
                cari.CARIKODU = txtCariKodu.Text;
                cari.FAX1 = txtFax1.Text;
                cari.FAX2 = txtFax2.Text;
                cari.ILCE = txtIlce.Text;
                cari.MAILINFO = txtMailInfo.Text;
                cari.SEHIR = txtSehir.Text;
                cari.TELEFON1 = txtTelefon1.Text;
                cari.TELEFON2 = txtTelefon2.Text;
                cari.ULKE = txtUlke.Text;
                cari.VERGIDAIRESI = txtVergiDairesi.Text;
                cari.VERGINO = txtVergiNo.Text;
                cari.WEBADRES = txtWeb.Text;
                cari.YETKILI1 = txtYetkili1.Text;
                cari.YETKILI2 = txtYetkili2.Text;
                cari.YETKILIMAIL1 = txtMail.Text;
                cari.YETKILIMAIL2 = txtYetkiliEmail.Text;
                cari.SAVEDATE = DateTime.Now;
                cari.SAVEUSER = AnaForm.UserID;
                DB.TBL_CARILERs.InsertOnSubmit(cari);
                DB.SubmitChanges();
                Mesajlar.yenikayit("Yeni Cari Kaydı Oluşturuldu.");
                temizle();
                frmCariAcilisKarti_Load(null, null);


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
                Fonksiyonlar.TBL_CARILER cari = DB.TBL_CARILERs.First(s => s.ID == CariID);
                cari.ADRES = txtAdres.Text;
                cari.GRUPID = GrupID;
                cari.CARIADI = txtCariAdi.Text;
                cari.CARIKODU = txtCariKodu.Text;
                cari.FAX1 = txtFax1.Text;
                cari.FAX2 = txtFax2.Text;
                cari.ILCE = txtIlce.Text;
                cari.MAILINFO = txtMailInfo.Text;
                cari.SEHIR = txtSehir.Text;
                cari.TELEFON1 = txtTelefon1.Text;
                cari.TELEFON2 = txtTelefon2.Text;
                cari.ULKE = txtUlke.Text;
                cari.VERGIDAIRESI = txtVergiDairesi.Text;
                cari.VERGINO = txtVergiNo.Text;
                cari.WEBADRES = txtWeb.Text;
                cari.YETKILI1 = txtYetkili1.Text;
                cari.YETKILI2 = txtYetkili2.Text;
                cari.YETKILIMAIL1 = txtMail.Text;
                cari.YETKILIMAIL2 = txtYetkiliEmail.Text;
                cari.EDITDATE = DateTime.Now;
                cari.EDITUSER = AnaForm.UserID;
                DB.SubmitChanges();
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
                DB.TBL_CARILERs.DeleteOnSubmit(DB.TBL_CARILERs.First(s => s.ID == CariID));
                DB.SubmitChanges();
                temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }

        }

        void grupac(int ID)
        {
            
            GrupID = ID;
            Fonksiyonlar.TBL_CARIGRUPLARI grup = DB.TBL_CARIGRUPLARIs.First(s => s.ID == GrupID);
            txtGrupAdi.Text = grup.GRUPADI;
            txtCariGrupKodu.Text = grup.GRUPKODU;
        
        }

        public void ac(int ID)
        {
            Edit = true;
            CariID = ID;
            Fonksiyonlar.TBL_CARILER cari = DB.TBL_CARILERs.First(s => s.ID == CariID);
            grupac(cari.GRUPID.Value);
            txtAdres.Text = cari.ADRES;
            txtCariAdi.Text = cari.CARIADI;
            txtCariKodu.Text = cari.CARIKODU;
            txtFax1.Text = cari.FAX1;
            txtFax2.Text = cari.FAX2;
            txtIlce.Text = cari.ILCE;
            txtMail.Text = cari.YETKILIMAIL2;
            txtMailInfo.Text = cari.MAILINFO;
            txtSehir.Text = cari.SEHIR;
            txtTelefon1.Text = cari.TELEFON1;
            txtTelefon2.Text = cari.TELEFON2;
            txtUlke.Text = cari.ULKE;
            txtVergiDairesi.Text = cari.VERGIDAIRESI;
            txtVergiNo.Text = cari.VERGINO;
            txtWeb.Text = cari.WEBADRES;
            txtYetkili1.Text = cari.YETKILI1;
            txtYetkili2.Text = cari.YETKILI2;
            txtYetkiliEmail.Text = cari.YETKILIMAIL1;
            

        }

     
        
        private void frmCariAcilisKarti_Load(object sender, EventArgs e)
        {
            txtCariKodu.Text = Numaralar.CariKodNumarasi('C');
           

        }

        private void txtCariKodu_Click(object sender, EventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0)
            {
                ac(ID);
                AnaForm.aktarma = -1;
            }
        }

        private void txtCariGrupKodu_Click(object sender, EventArgs e)
        {
            int ID = Formlar.CariGruplari(true);
            if (ID > 0)
            {
                grupac(ID);
                AnaForm.aktarma = -1;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            var stok = DB.TBL_CARILERs.Where(x => x.ID == CariID).FirstOrDefault();

            if (stok == null)
                return;

            var stokHareketCount = DB.TBL_CARIHAREKETLERIs.Where(x => x.CARIID == stok.ID).Count();

            if (stokHareketCount > 0)
                Mesajlar.HataCari();
            else if (Mesajlar.Sil() == DialogResult.Yes)
                sil();
            
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtCariGrupKodu.Text != "") 
            { 
            if (Edit && CariID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
            else yenikaydet();
                
            } 
            else
                MessageBox.Show("Cari Kodu Seçilmelidir .", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
           
        }
       
  

        private void frmCariAcilisKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}