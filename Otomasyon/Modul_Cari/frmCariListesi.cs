using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Cari
{


    public partial class frmCariListesi : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool SEcim = true;
        int SecimID = -1;
        int HareketID = -1;

        public frmCariListesi()
        {
            InitializeComponent();
        }

        private void frmCariListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

     public void Listele()
        {
            var lst = from s in DB.TBL_CARILERs
                      where s.CARIADI.Contains(txtcarikodu.Text) && s.CARIKODU.Contains(txtcariadi.Text)
                      select s;
            Liste.DataSource = lst;

        }

     private void btnAra_Click(object sender, EventArgs e)
     {
         Listele();
     }

     private void btnSil_Click(object sender, EventArgs e)
     {
         txtcarikodu.Text = "";
         txtcariadi.Text = "";
         
     }

     void sec()
     {
         try
         {
             SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
         }
         catch (Exception)
         {
             SecimID = -1;
         }
     }

     private void gridView1_DoubleClick(object sender, EventArgs e)
     {
         sec();
         if (SEcim && SecimID > 0)
         {
             AnaForm.aktarma = SecimID;
             this.Close();

         }
     }

     private void frmCariListesi_KeyDown(object sender, KeyEventArgs e)
     {
         if (e.KeyCode == Keys.Escape)
         {
             this.Close();
         }
     }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Formlar.CariKarti();
        }
    }
}