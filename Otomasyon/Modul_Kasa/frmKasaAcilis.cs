using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Kasa
{
    public partial class frmKasaAcilis : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();


        bool Edit = false;
        int SecimID = -1;
        double VAL = 0;
        string ID1 = "KS";
        int kasaID = -1;
        public frmKasaAcilis()
        {
            InitializeComponent();
        }

        private void frmKasaAcilis_Load(object sender, EventArgs e)
        {
            txtKasaKodu.Text = Numaralar.KasaKodNumarasi('K');
            Listele();
        }

        void Temizle()
        {
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = Numaralar.KasaKodNumarasi('K');
            txtAciklama.Text = "";
            Edit = false;
            SecimID = -1;
            AnaForm.aktarma = -1;


        }

        void YeniKaydet()
        {

            try
            {
                Fonksiyonlar.TBL_KASALAR Kasa = new Fonksiyonlar.TBL_KASALAR();
                Kasa.ACIKLAMA = txtAciklama.Text;
                Kasa.KASAADI = txtKasaAdi.Text;
                Kasa.KASAKODU = txtKasaKodu.Text;
                Kasa.SAVEDATE = DateTime.Now;
                Kasa.SAVEUSER = AnaForm.UserID;
                db.TBL_KASALARs.InsertOnSubmit(Kasa);
                db.SubmitChanges();
                Mesajlar.yenikayit("Yeni Kayıt Oluşturuldu .");
                Temizle();
                Listele();
               
                
                

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
                Fonksiyonlar.TBL_KASALAR Kasa = db.TBL_KASALARs.First(s => s.ID == SecimID);
                Kasa.ACIKLAMA = txtAciklama.Text;
                Kasa.KASAADI = txtKasaAdi.Text;
                Kasa.KASAKODU = txtKasaKodu.Text;
                Kasa.EDITDATE = DateTime.Now;
                Kasa.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                Listele();

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
                db.TBL_KASALARs.DeleteOnSubmit(db.TBL_KASALARs.First(s => s.ID == SecimID));
                db.SubmitChanges();

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void sec()
        {

            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                kasaID= int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtKasaKodu.Text = gridView1.GetFocusedRowCellValue("KASAKODU").ToString();
                txtKasaAdi.Text = gridView1.GetFocusedRowCellValue("KASAADI").ToString();
                txtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
            }
            catch (Exception e)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        void Listele()
        {
            var lst = from s in db.TBL_KASALARs
                      select s;
            Liste.DataSource = lst;
            

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sec();   
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtKasaAdi.Text != "" && txtAciklama.Text != "")
            {
                if (Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
                else YeniKaydet();
            }
            else MessageBox.Show("Kasa Adı ve Açıklama Girilmesi Gereklidir.", "İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            var stockCount = db.TBL_KASAHAREKETLERIs.Where(x => x.KASAID == kasaID).Count();

            if (Edit && stockCount > 0)
                Mesajlar.HataKasa();
            if (Edit && stockCount <= 0 && Mesajlar.Sil() == DialogResult.Yes) sil();

            Listele();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKasaAcilis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
      

    }
}