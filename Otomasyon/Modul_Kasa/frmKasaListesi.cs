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

namespace DXApplication2.Modul_Kasa
{
    public partial class frmKasaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        int SecimID = -1;
        public frmKasaListesi()
        {
            InitializeComponent();
        }

        private void frmKasaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            var lst = from s in db.VW_KASALISTESI
                      where s.KASAKODU.Contains(txtKasaKodu.Text) && s.KASAADI.Contains(txtKasaAdi.Text)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sec();
            if (Secim && SecimID >0)
            {
                AnaForm.aktarma = SecimID;
                this.Close();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
                
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
           
        }

        private void frmKasaListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Formlar.KasaAcilisDuzen();
        }
    }
}