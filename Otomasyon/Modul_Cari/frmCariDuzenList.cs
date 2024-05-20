using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;

namespace DXApplication2.Modul_Cari
{
    public partial class frmCariDuzenList : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool SEcim = false;
        int SecimID = -1;
        int HareketID = -1;
        public frmCariDuzenList()
        {
            InitializeComponent();
        }

        private void frmCariDuzenList_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            var lst = from s in DB.VW_CARILER
                      where s.CARIADI.Contains(txtcarikodu.Text) && s.CARIKODU.Contains(txtcariadi.Text)
                      select s;
            Liste.DataSource = lst;

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

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtcarikodu.Text = "";
            txtcariadi.Text = "";

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            Formlar.CariKartiDuzen(true, HareketID);
            

        }

        private void frmCariDuzenList_KeyDown(object sender, KeyEventArgs e)
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

        private void frmCariDuzenList_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            

        }
     
    }
     
}