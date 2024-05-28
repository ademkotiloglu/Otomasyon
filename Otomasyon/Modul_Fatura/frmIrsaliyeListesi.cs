using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Fatura
{
    public partial class frmIrsaliyeListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool secim = true;
        int HareketID = -1;
        int EvrakID = -1;
        string EvrakTURU = "";
        public frmIrsaliyeListesi()
        {
            InitializeComponent();
            secim = secim;
        }

        private void frmIrsaliyeListesi_Load(object sender, EventArgs e)
        {
            listeletumu1();
        }

        void listele()

        {
            DateTime baslangic = DateTime.Parse(dbaslangic.Value.ToShortDateString());
            var lst = from s in db.TBL_IRSALIYELERs
                      where s.IRSALIYESERI.Contains(txtFaturaTuru.Text) && s.IRSALIYENO.Contains(txtFaturaNo.Text) && s.TARIHI==baslangic
                      select s;
            Liste.DataSource = lst;
        }
        void listeletumu()
        {
            DateTime baslangic = DateTime.Parse(dbaslangic.Value.ToShortDateString());
            var lst = from s in db.TBL_IRSALIYELERs
                      where s.TARIHI == baslangic
                      select s;
            Liste.DataSource = lst;
        }
        void listeletumu1()
        {
            
            var lst = from s in db.TBL_IRSALIYELERs
                  
                      select s;
            Liste.DataSource = lst;
        }
        private void txtFaturaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFaturaTuru.Text == "Tümü") 
                listeletumu();
                if (txtFaturaTuru.Text == "Satış İrsaliyesi")
                    listele();
                if (txtFaturaTuru.Text == "Alış İrsaliyesi")
                    listele();
            }
            catch
            {
                listele();
            }
        }

        void sec()
        {
            try
            {
                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("IRSALIYENO").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTURU = gridView1.GetFocusedRowCellValue("IRSALIYESERI").ToString();
            }
            catch (Exception)
            {
                HareketID = -1;
                EvrakTURU = "";
                EvrakID = -1;
            }
        }

        private void SagTik_Opening(object sender, CancelEventArgs e)
        {
            sec();
            if (EvrakTURU == "Satış İrsaliyesi")
            {
                SagTikYenile.Enabled = true;
                alisduzenle.Enabled = false;

            }
            else if (EvrakTURU == "Alış İrsaliyesi")
            {
                SagTikYenile.Enabled = false;
                alisduzenle.Enabled = true;
            }
        }

        private void SagTikYenile_Click(object sender, EventArgs e)
        {
            Formlar.satisIrsaliye(true, HareketID);
            listele();
        }

        private void alisduzenle_Click(object sender, EventArgs e)
        {
            Formlar.alisirsaliye(true, HareketID);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            sec();
            if (EvrakTURU == "Satış İrsaliyesi")
            {
                Formlar.satisIrsaliye(true, ID, false);
            }
            else if (EvrakTURU == "Alış İrsaliyesi")
            {
                Formlar.alisirsaliye(true, ID, false);
            }
        }

        private void frmIrsaliyeListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       
    }
}