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
    public partial class frmKullaniciYonetimi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        int secim = 0;
        
        
        public frmKullaniciYonetimi()
        {
            InitializeComponent();
            this.Shown += frmKullaniciYonetimi_Shown;
        }

        void frmKullaniciYonetimi_Shown(object sender, EventArgs e)
        {
            listele();
           
        }

        void listele()
        {
            var lst = from s in db.TBL_KULLANICILARs
                      select s;
            gridControl1.DataSource = lst;
        }
       

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Formlar.KullaniciPanel(true, secim);
            
          
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formlar.KullaniciPanel();
          

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (Mesajlar.Sil() == DialogResult.Yes)
            {
                db.TBL_KULLANICILARs.DeleteOnSubmit(db.TBL_KULLANICILARs.First(s => s.ID == secim));
                db.SubmitChanges();
                listele();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            secim = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

        }

        private void frmKullaniciYonetimi_Load(object sender, EventArgs e)
        {

        }

        private void frmKullaniciYonetimi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       
        

       
    }
}