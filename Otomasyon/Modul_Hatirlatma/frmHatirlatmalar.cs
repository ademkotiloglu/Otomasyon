using DevExpress.CodeParser;
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

namespace DXApplication2.Modul_Hatirlatma
{
    public partial class frmHatirlatmalar : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        int HatirlatmaID = -1;
        bool edit = false;
        int SecimID = -1;   
        public frmHatirlatmalar()
        {
            InitializeComponent();
        }

        void listele()
        {
            var lst = from s in db.TBL_HATIRLATMA
                      select s;
            Liste.DataSource = lst;
        }
        void listele1()
        {

            var lst = from s in db.TBL_HATIRLATMA
                      where s.ONEM == "Önemli" 
                      select s;
            Liste.DataSource = lst;
        }
        void listele2()
        {

            var lst = from s in db.TBL_HATIRLATMA
                      where s.ONEM == "Normal"
                      select s;
            Liste.DataSource = lst;
        }
        void listele3()
        {

            var lst = from s in db.TBL_HATIRLATMA
                      where s.ONEM == "Çok Önemli"
                      select s;
            Liste.DataSource = lst;
        }

        void listele4()
        {

            var lst = from s in db.TBL_HATIRLATMA
                      where s.ONEM == "Tamamlandı"
                      select s;
            Liste.DataSource = lst;
        }
        private void frmHatirlatmalar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listele3();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listele1();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listele2();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listele4();
        }

        void sec()
        {
            try
            {
                edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
               

            }
            catch (Exception)
            {
                edit = false;
                SecimID = -1;
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Fonksiyonlar.TBL_HATIRLATMA guncel = db.TBL_HATIRLATMA.First(s => s.ID == SecimID);
                guncel.ONEM = "Tamamlandı";
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            sec();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            db.TBL_HATIRLATMA.DeleteOnSubmit(db.TBL_HATIRLATMA.First(s => s.ID == SecimID));
            db.SubmitChanges();
            listele();
        }

        private void frmHatirlatmalar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}