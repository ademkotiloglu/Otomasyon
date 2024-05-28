using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Unicode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Modul_Ayar
{
    public partial class frmKasaSeçimi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool Edit = false;
        int SecimID = -1;
        double VAL = 0;
        string ID1 = "KS";
        int kasaID = -1;
        public frmKasaSeçimi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            var lst = from s in db.TBL_KASALARs
                      select s;
            Liste.DataSource = lst;


        }

        private void frmKasaSeçimi_Load(object sender, EventArgs e)
        {
            Listele();
            var firstRecord = db.TBL_VARSAYILANKASA.FirstOrDefault();
            if(firstRecord != null)
            textBox1.Text = firstRecord.KASA.ToString();
            if (firstRecord == null)
                textBox1.Text = "Varsayılan Kasa Seçiniz ..";
            if (firstRecord == null)
                btnkaydet.Enabled = true;
            if (firstRecord != null)
                btnkaydet.Enabled = false;
        }

        void sec()
        {

            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                kasaID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                textBox1.Text = gridView1.GetFocusedRowCellValue("KASAADI").ToString();
             
            }
            catch (Exception e)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
        }
        void YeniKaydet()
        {

            try
            {
                Fonksiyonlar.TBL_VARSAYILANKASA Kasa = new Fonksiyonlar.TBL_VARSAYILANKASA();
                Kasa.KASA = textBox1.Text;
                Kasa.KASAID = kasaID;
                db.TBL_VARSAYILANKASA.InsertOnSubmit(Kasa);
                db.SubmitChanges();
                Mesajlar.yenikayit("Varsayılan Kasa Seçildi .");
                btnkaydet.Enabled=false;
                btnsil.Enabled = true;
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
                var firstRecord = db.TBL_VARSAYILANKASA.FirstOrDefault();
                firstRecord.KASA = textBox1.Text;
                
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                Listele();

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            
            YeniKaydet();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();
            db.SubmitChanges();
            Mesajlar.yenikayit("Varsayılan Kasa Temizlendi .");
            textBox1.Text = "";
            btnkaydet.Enabled = true;
            btnsil.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        void sil()
        {
            db.TBL_VARSAYILANKASA.DeleteOnSubmit(db.TBL_VARSAYILANKASA.FirstOrDefault());
        }
    }
}