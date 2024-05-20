using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;

using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.CodeParser;
using System.Runtime.CompilerServices;
using DevExpress.Pdf.Native;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraPrinting;
using DXApplication2.Fonksiyonlar;

namespace DXApplication2.Modul_Stok
{
    public partial class frmStokGruplari : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        public bool secim = false;
        int secimID = -1;
        bool edit = false;
        int grupId = -1;

        public frmStokGruplari()
        {
            InitializeComponent();
        }

        private void frmStokGruplari_Load(object sender, EventArgs e)
        {
            txtgrupkodu.Text = Numaralar.StokGrupNo('G');
            listele();
        }
        void listele()
        {
            var lst = from s in db.TBL_STOKGRUPLARIs
                      select s;
            Liste.DataSource = lst;
        }

        void temizle()
        {
            txtgrupkodu.Text = "";
            txtgrupadi.Text = "";

            edit = false;
            listele();
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_STOKGRUPLARI grup = new Fonksiyonlar.TBL_STOKGRUPLARI();
                grup.GRUPADI = txtgrupadi.Text;
                grup.GRUPKODU = txtgrupkodu.Text;
                grup.GRUPSAVEDATE = DateTime.Now;
                grup.GRUPSAVEUSER = AnaForm.UserID;

                db.TBL_STOKGRUPLARIs.InsertOnSubmit(grup);
                db.SubmitChanges();
                Mesaj.yenikayit("Yeni Grup Kaydı Oluşturuldu.");
                temizle();
                frmStokGruplari_Load(null, null);
            }
            catch (Exception e)
            {
                Mesaj.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_STOKGRUPLARI Grup = db.TBL_STOKGRUPLARIs.First(s => s.ID == secimID);
                Grup.GRUPKODU = txtgrupkodu.Text;
                Grup.GRUPADI = txtgrupadi.Text;

                Grup.GRUPEDITUSER = AnaForm.UserID;
                Grup.GRUPEDITDATE = DateTime.Now;
                db.SubmitChanges();
                Mesaj.Guncelle(true);
            }
            catch (Exception e)
            {
                Mesaj.Hata(e);
            }
        }

        void sil()
        {
            try
            {
               
                db.TBL_STOKGRUPLARIs.DeleteOnSubmit(db.TBL_STOKGRUPLARIs.First(s => s.ID == secimID));
                db.SubmitChanges();
                temizle();

            }
            catch (Exception e)
            {
                Mesaj.Hata(e);
            }
        }


        void sec()
        {
            try
            {
                edit = true;
                grupId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                secimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtgrupadi.Text = gridView1.GetFocusedRowCellValue("GRUPADI").ToString();
                txtgrupkodu.Text = gridView1.GetFocusedRowCellValue("GRUPKODU").ToString();
               

            }
            catch (Exception)
            {
                edit = false;
                secimID = -1;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmStokGruplari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            var stockCount = db.TBL_STOKLARs.Where(x => x.STOKGRUPID == grupId).Count();

            if (edit && stockCount > 0)
                Mesaj.HataGrupStok();
            if (edit && stockCount <=0 && Mesaj.Sil() == DialogResult.Yes) sil();


        }

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            if (edit && secimID > 0 && Mesaj.Guncelle() == DialogResult.Yes) Guncelle();
            else yenikaydet();
        }

        private void btnkapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void Liste_DoubleClick_1(object sender, EventArgs e)
        {
            sec();
            if (secim && secimID > 0)
            {
                AnaForm.aktarma = secimID;
                this.Close();
            }
        }
    }
}