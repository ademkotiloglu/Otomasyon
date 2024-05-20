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

namespace DXApplication2.Modul_Cari
{
    public partial class frmCariGruplari : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        public bool secim = false;
        bool edit = false;
        int secimID = -1;
        int adem = -1;
        int grupId = -1;
        public frmCariGruplari()
        {
            InitializeComponent();
        }

   
        
        private void frmCariGruplari_Load(object sender, EventArgs e)
        {
            txtgrupkodu.Text = Numaralar.CariGrupNo('G');
            listele();
        }
        void listele()
        {
            var lst = from s in db.TBL_CARIGRUPLARIs
                      select s;
            Liste.DataSource = lst;
        }

        void temizle()
        {
            txtgrupkodu.Text = Numaralar.CariGrupNo('G');
            txtgrupadi.Text = "";

            edit = false;
            listele();
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_CARIGRUPLARI grup = new Fonksiyonlar.TBL_CARIGRUPLARI();
                grup.GRUPADI = txtgrupadi.Text;
                grup.GRUPKODU = txtgrupkodu.Text;
                grup.SAVEDATE = DateTime.Now;
                grup.SAVEUSER = AnaForm.UserID;

                db.TBL_CARIGRUPLARIs.InsertOnSubmit(grup);
                db.SubmitChanges();
                Mesajlar.yenikayit("Yeni Grup Kaydı Oluşturuldu.");
                temizle();
                frmCariGruplari_Load(null, null);
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.TBL_CARIGRUPLARI Grup = db.TBL_CARIGRUPLARIs.First(s => s.ID == secimID);
                Grup.GRUPKODU = txtgrupkodu.Text;
                Grup.GRUPADI = txtgrupadi.Text;

                Grup.EDITUSER = AnaForm.UserID;
                Grup.EDITDATE = DateTime.Now;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
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
                db.TBL_CARIGRUPLARIs.DeleteOnSubmit(db.TBL_CARIGRUPLARIs.First(s => s.ID == secimID));
                db.SubmitChanges();
                temizle();

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
                edit = true;
                secimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                grupId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtgrupadi.Text = gridView1.GetFocusedRowCellValue("GRUPADI").ToString();
                txtgrupkodu.Text = gridView1.GetFocusedRowCellValue("GRUPKODU").ToString();

            }
            catch (Exception)
            {
                edit = false;
                secimID = -1;
            }
        }

    

        

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            if (edit && secimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else yenikaydet();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
             var stockCount = db.TBL_CARILERs.Where(x => x.GRUPID == grupId).Count();

            if (edit && stockCount > 0)
                Mesajlar.HataGrupStok();
            if (edit && stockCount <=0 && Mesajlar.Sil() == DialogResult.Yes) sil();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sec();
            if (secim && secimID > 0)
            {
                AnaForm.aktarma = secimID;
                this.Close();
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
            if (secim && secimID > 0)
            {
                AnaForm.aktarma = secimID;
                this.Close();
            }
        }

        private void frmCariGruplari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
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








    
