using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;

namespace DXApplication2.Modul_Stok
{
    public partial class frmStokKartDuzen : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Resimleme Resimleme = new Fonksiyonlar.Resimleme();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();



        bool Edit = false;

        bool Resim = false;
        OpenFileDialog Dosya = new OpenFileDialog();
        int GrupID = -1;
        int StokID = -1;
        double VAL = 0;
        string ID1 = "ST";

        public frmStokKartDuzen()
        {
            InitializeComponent();
        }
        void temizle()
        {
            txtParcaKodu.Text = Numaralar.StokKodNumarasi('S');
            txtAlisFiyat.Text = "0";
            txtAlisKdv.Text = "0";
            txtresimkutusu.Image = null;
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            txtParcaAdi.Text = "";
            txtParcaKodu.Text = "";
            txtSatisFiyat.Text = "0";
            txtSatisKdv.Text = "0";
            txtStokBirim.SelectedIndex = 0;
            txtStokBarkod.Text = "";
            Edit = false;
            GrupID = -1;
            StokID = -1;
            AnaForm.aktarma = -1;

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

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_STOKLAR Stok = new Fonksiyonlar.TBL_STOKLAR();
                Stok.STOKADI = txtParcaAdi.Text;
                Stok.STOKALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                Stok.STOKALISKDV = decimal.Parse(txtAlisKdv.Text);
                Stok.STOKBARKOD = txtStokBarkod.Text;
                Stok.STOKBIRIM = txtStokBirim.Text;
                Stok.STOKGRUPID = GrupID;
                Stok.STOKKODU = txtParcaKodu.Text;
                if (Resim) Stok.STOKRESIM = new System.Data.Linq.Binary(Resimleme.ResimYukleme(txtresimkutusu.Image));
                Stok.STOKSATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                Stok.STOKSATISKDV = decimal.Parse(txtSatisKdv.Text);
                Stok.STOKSAVEDATE = DateTime.Now;
                Stok.STOKSAVEUSER = AnaForm.UserID;
                DB.TBL_STOKLARs.InsertOnSubmit(Stok);
                DB.SubmitChanges();
                Mesajlar.yenikayit("Yeni Stok Kaydı Oluşturuldu.");
                temizle();

                frmStokKartDuzen_Load(null, null);


                frmStokListesi frmAna = (frmStokListesi)System.Windows.Forms.Application.OpenForms["frmStokListesi"];

                frmAna.Listele();

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
                Fonksiyonlar.TBL_STOKLAR stok = DB.TBL_STOKLARs.First(s => s.ID == StokID);
                stok.STOKADI = txtParcaAdi.Text;
                stok.STOKALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                stok.STOKALISKDV = decimal.Parse(txtAlisKdv.Text);
                stok.STOKBARKOD = txtStokBarkod.Text;
                stok.STOKBIRIM = txtStokBirim.Text;
                stok.STOKGRUPID = GrupID;
                stok.STOKKODU = txtParcaKodu.Text;
                if (Resim) stok.STOKRESIM = new System.Data.Linq.Binary(Resimleme.ResimYukleme(txtresimkutusu.Image));
                stok.STOKSATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                stok.STOKSATISKDV = decimal.Parse(txtSatisKdv.Text);
                stok.STOKEDITTIME = DateTime.Now;
                stok.STOKEDITUSER = AnaForm.UserID;

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
                DB.TBL_STOKLARs.DeleteOnSubmit(DB.TBL_STOKLARs.First(s => s.ID == StokID));
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
            Fonksiyonlar.TBL_STOKGRUPLARI grup = DB.TBL_STOKGRUPLARIs.First(s => s.ID == GrupID);
            txtGrupAdi.Text = grup.GRUPADI;
            txtGrupKodu.Text = grup.GRUPKODU;
        }

        public void ac(int ID)
        {
            Edit = true;
            StokID = ID;
            Fonksiyonlar.TBL_STOKLAR stok = DB.TBL_STOKLARs.First(s => s.ID == StokID);
            grupac(stok.STOKGRUPID.Value);
            if (stok.STOKRESIM != null)
            {
                txtresimkutusu.Image = Resimleme.ResimGetirme(stok.STOKRESIM.ToArray());

            }
            if (stok.STOKRESIM == null)
            {
                txtresimkutusu.Image = null;
            }
            txtAlisFiyat.Text = stok.STOKALISFIYAT.ToString();
            txtAlisKdv.Text = stok.STOKALISKDV.ToString();
            txtStokBarkod.Text = stok.STOKBARKOD;
            txtStokBirim.Text = stok.STOKBIRIM;
            txtSatisFiyat.Text = stok.STOKSATISFIYAT.ToString();
            txtSatisKdv.Text = stok.STOKSATISKDV.ToString();
            txtParcaAdi.Text = stok.STOKADI;
            txtParcaKodu.Text = stok.STOKKODU;

        }




       
        private void frmStokKartDuzen_Load(object sender, EventArgs e)
        {
           if(StokID<0)
            txtParcaKodu.Text = Numaralar.StokKodNumarasi('S');
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (Edit && StokID > 0 && Mesajlar.Guncelle() == DialogResult.Yes)
            {
                guncelle();

            }
            else
            {
                yenikaydet();


            }
        }

        private void btnresimekle_Click(object sender, EventArgs e)
        {
            resimsec();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            var stok = DB.TBL_STOKLARs.Where(x => x.ID == StokID).FirstOrDefault();

            if (stok == null)
                return;

            var stokHareketCount = DB.TBL_STOKHAREKETLERIs.Where(x => x.STOKKODU == stok.STOKKODU).Count();

            if (stokHareketCount > 0)
                Mesajlar.HataStok();
            else if (Mesajlar.Sil() == DialogResult.Yes)
                sil();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtParcaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void txtParcaKodu_Click(object sender, EventArgs e)
        {
            int ID = Formlar.StokListesi(true);
            if (ID > 0)
            {
                ac(ID);
                AnaForm.aktarma = -1;
            }
        }

        private void txtGrupKodu_Click(object sender, EventArgs e)
        {
            int ID = Formlar.StokGruplari(true);
            if (ID > 0)
            {
                grupac(ID);
                AnaForm.aktarma = -1;
            }
        }

        private void frmStokKartDuzen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var barkodno = DB.TBL_OTOBARKOD.First();
            int karakter = barkodno.Barkod.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.Barkod.ToString();
            txtStokBarkod.Text = olusanbarkod;
            txtParcaAdi.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}