using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Modul_Ayar
{
    public partial class frmSirketBilgileri : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();
        Fonksiyonlar.Resimleme Resimleme = new Fonksiyonlar.Resimleme();
        Fonksiyonlar.Islemler islemler = new Fonksiyonlar.Islemler();

        OpenFileDialog Dosya = new OpenFileDialog();
        bool Resim = false;
        public frmSirketBilgileri()
        {
            InitializeComponent();
        }

        private void frmSirketBilgileri_Load(object sender, EventArgs e)
        {
            listele();
        }

        public void listele()
        {
            var komisyon = db.TBL_AYARLAR.FirstOrDefault();
            if (komisyon != null) 
            txtadres.Text = komisyon.Adres;
            txtadsoyad.Text = komisyon.AdSoyad;
            txteposta.Text = komisyon.Eposta;
            txtkurulus.Text = komisyon.Kurulus;
            txtnot.Text = komisyon.Note;
            if (komisyon.Logo != null)
            {
                txtresimkutusu.Image = Resimleme.ResimGetirme(komisyon.Logo.ToArray());
            }
            if (komisyon.Logo == null)
            {
                txtresimkutusu.Image = null;
            }
            txttelefon.Text = komisyon.Telefon;
            txtunvan.Text = komisyon.Unvan;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
                using (var db = new DatabaseDataContext())
                {
                islemler.sabitvarsayilan();
                    var sirket = db.TBL_AYARLAR.FirstOrDefault();
                    sirket.AdSoyad = txtadsoyad.Text;
                    sirket.Adres = txtadres.Text;
                    sirket.Unvan = txtunvan.Text;
                    sirket.Kurulus = txtkurulus.Text;
                    sirket.Eposta = txteposta.Text;
                    sirket.Note = txtnot.Text;
                    sirket.Telefon = txttelefon.Text;
                if (Resim) sirket.Logo = new System.Data.Linq.Binary(Resimleme.ResimYukleme(txtresimkutusu.Image));

                db.SubmitChanges();
                    Mesajlar.yenikayit("Şirket Bilgileri Güncel ..!");
                
            }
        }

        private void txtresimekle_Click(object sender, EventArgs e)
        {
            resimsec();
        }
        void resimsec()

        {
            Dosya.Filter = "jpg(*.jpg)|*.jpg|jpeg(*.jpeg)|*.jpeg";
            if (Dosya.ShowDialog() == DialogResult.OK)
            {
                txtresimkutusu.ImageLocation = Dosya.FileName;
                Resim = true;
            }
        }
    }
}