using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Modul_Banka
{
    public partial class frmBankaAcilisDuzen : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool Edit = false;
        int SecimID = -1;
        int bankaID = -1;
        public frmBankaAcilisDuzen()
        {
            InitializeComponent();
            if (AnaForm.Kullanici.KODU == "Misafir")
            {
                btnsil.Enabled = false;
            }
        }
       


        private void frmBankaAcilisDuzen_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            txtBankaAdi.Text = "";
            txtAdres.Text = "";
            txtBankaSube.Text = "";
            txtEmail.Text = "";
            txtHesapNo.Text = "";
            txtHesapTuru.Text = "";
            txtIBAN.Text = "";
            txtSubeTelefon.Text = "";
            txtTemsilci.Text = "";
            Edit = false;
            SecimID = -1;


        }

        void YeniKaydet()
        {

            try
            {
                Fonksiyonlar.TBL_BANKALAR Banka = new Fonksiyonlar.TBL_BANKALAR();
                Banka.ADRES = txtAdres.Text;
                Banka.BANKAADI = txtBankaAdi.Text;
                Banka.HESAPADI = txtHesapTuru.Text;
                Banka.HESAPNO = txtHesapNo.Text;
                Banka.IBAN = txtIBAN.Text;
                Banka.SUBE = txtBankaSube.Text;
                Banka.TEL = txtSubeTelefon.Text;
                Banka.TEMSILCI = txtTemsilci.Text;
                Banka.TEMSILCIEMAIL = txtEmail.Text;
                Banka.SAVEDATE = DateTime.Now;
                Banka.SAVEUSER = AnaForm.UserID;
                db.TBL_BANKALARs.InsertOnSubmit(Banka);
                db.SubmitChanges();
                Mesajlar.yenikayit("Yeni Kayıt Oluşturuldu .");
                Listele();
                frmBankaListesi frmAna = (frmBankaListesi)System.Windows.Forms.Application.OpenForms["frmBankaListesi"];

                frmAna.Listele();



            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        void Listele()
        {
            var lst = from s in db.VW_BANKALISTE
                      select s;
            Liste.DataSource = lst;

        }

        void guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_BANKALAR Banka = db.TBL_BANKALARs.First(s => s.ID == SecimID);
                Banka.ADRES = txtAdres.Text;
                Banka.BANKAADI = txtBankaAdi.Text;
                Banka.HESAPADI = txtHesapTuru.Text;
                Banka.HESAPNO = txtHesapNo.Text;
                Banka.IBAN = txtIBAN.Text;
                Banka.SUBE = txtBankaSube.Text;
                Banka.TEL = txtSubeTelefon.Text;
                Banka.TEMSILCI = txtTemsilci.Text;
                Banka.TEMSILCIEMAIL = txtEmail.Text;
                Banka.EDITDATE = DateTime.Now;
                Banka.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                Listele();
                frmBankaListesi frmAna = (frmBankaListesi)System.Windows.Forms.Application.OpenForms["frmBankaListesi"];

                frmAna.Listele();

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
                db.TBL_BANKALARs.DeleteOnSubmit(db.TBL_BANKALARs.First(s => s.ID == SecimID));
                db.SubmitChanges();
                Temizle();


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
                bankaID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

                txtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
                txtBankaAdi.Text = gridView1.GetFocusedRowCellValue("BANKAADI").ToString();
                txtBankaSube.Text = gridView1.GetFocusedRowCellValue("SUBE").ToString();
                txtEmail.Text = gridView1.GetFocusedRowCellValue("TEMSILCIEMAIL").ToString();
                txtHesapNo.Text = gridView1.GetFocusedRowCellValue("HESAPNO").ToString();
                txtHesapTuru.Text = gridView1.GetFocusedRowCellValue("HESAPADI").ToString();
                txtIBAN.Text = gridView1.GetFocusedRowCellValue("IBAN").ToString();
                txtSubeTelefon.Text = gridView1.GetFocusedRowCellValue("TEL").ToString();
                txtTemsilci.Text = gridView1.GetFocusedRowCellValue("TEMSILCI").ToString();



            }
            catch (Exception e)
            {
                Edit = false;
                SecimID = -1;
            }
        }

       
      


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sec();
        }

        private void frmBankaAcilisDuzen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnkapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            var stockCount = db.TBL_BANKAHAREKETLERIs.Where(x => x.BANKAID == bankaID).Count();

            if (Edit && stockCount > 0)
                Mesajlar.HataBanka();
            if (Edit && stockCount <= 0 && Mesajlar.Sil() == DialogResult.Yes) sil();

            Listele();
        }

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            if (txtBankaAdi.Text != "" && txtAdres.Text != "")
            {
                if (Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
                else YeniKaydet();
            }
            else MessageBox.Show("Banka Adı ve Adres Girilmesi Gereklidir.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
  