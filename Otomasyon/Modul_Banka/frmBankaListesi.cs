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

namespace DXApplication2.Modul_Banka
{
    public partial class frmBankaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool Secim = false;
        int SecimID = -1;
        public frmBankaListesi()
        {
            InitializeComponent();
        }

        private void frmBankaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
    
   public void Listele()
        {
            var lst = from s in db.VW_BANKALISTE
                      where s.HESAPADI.Contains(txtHesapTuru.Text) && s.HESAPNO.Contains(txtHesapNo.Text) && s.IBAN.Contains(txtIBAN.Text)
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

  

   private void btnAra_Click(object sender, EventArgs e)
   {
       Listele();
   }

   private void btnSil_Click(object sender, EventArgs e)
   {
       txtHesapNo.Text = "";
       txtHesapTuru.Text = "";
       txtIBAN.Text = "";
   }

   private void gridView1_DoubleClick(object sender, EventArgs e)
   {
       sec();
       if (Secim && SecimID > 0)
       {
           AnaForm.aktarma = SecimID;
           this.Close();
       }
   }

   private void frmBankaListesi_KeyDown(object sender, KeyEventArgs e)
   {
       if (e.KeyCode == Keys.Escape)
       {
           this.Close();
       }
   }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Formlar.BankaAcilisDuzen();
        }
    }
}