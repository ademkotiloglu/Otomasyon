using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.CodeParser;
using DXApplication2.Fonksiyonlar;

namespace DXApplication2.Modul_Fatura
{
    public partial class frmFaturaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        public bool secim = true;
        int HareketID = -1;
        int EvrakID = -1;
        string EvrakTURU = "";
        public frmFaturaListesi()
        {
            InitializeComponent();


        }

        private void frmFaturaListesi_Load(object sender, EventArgs e)
        {
            listeletumu1();
        }

        void listele()
        {
            DateTime baslangic = DateTime.Parse(dbaslangic.Value.ToShortDateString());
            var lst = from s in db.TBL_FATURALAR
                      where s.FATURATURU.Contains(txtFaturaTuru.Text) && s.FATURANO.Contains(txtFaturaNo.Text) && s.TARIHI == baslangic
                      select s;
            Liste.DataSource = lst;

        }
        void listeletumu()
        {
            DateTime baslangic = DateTime.Parse(dbaslangic.Value.ToShortDateString());
            var lst = from s in db.TBL_FATURALAR
                      where s.TARIHI == baslangic
                      select s;
            Liste.DataSource = lst;
        }
        void listeletumu1()
        {

            var lst = from s in db.TBL_FATURALAR

                      select s;
            Liste.DataSource = lst;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtFaturaTuru.Text == "Satış İade Faturası") 
                listele();
                if (txtFaturaTuru.Text == "Alış İade Faturası") 
                listele();
                if (txtFaturaTuru.Text == "Satış Faturası") 
                listele();
                if (txtFaturaTuru.Text == "Alış Faturası") 
                listele();
                if (txtFaturaTuru.Text == "Sıcak Satış") 
                listele();
                if (txtFaturaTuru.Text == "Tümü") 
                listeletumu();
            }
            catch
            {
                listele();
            }

        }

        private void txtFaturaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

            sec();
            if (EvrakTURU == "Satış Faturası")
            {
                Formlar.Fatura(true, ID, false);
            }
            else if (EvrakTURU == "Alış Faturası")
            {
                Formlar.aFatura(true, ID, false);
            }
            else if (EvrakTURU == "Alış İade Faturası")
            {
                Formlar.aiFatura(true, ID, false);
            }
            else if (EvrakTURU == "Satış İade Faturası")
            {
                Formlar.iFatura(true, ID, false);
            }
            else if (EvrakTURU == "Sıcak Satış")
            {
                Mesajlar.hata123("Sıcak Satış Faturası Düzenlenemez !");
            }
        }
        void sec()
        {
            try
            {
                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("FATURANO").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTURU = gridView1.GetFocusedRowCellValue("FATURATURU").ToString();
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
            if (EvrakTURU == "Satış Faturası")
            {
                SagTikYenile.Enabled = true;
                alisduzenle.Enabled = false;

            }
            else if (EvrakTURU == "Alış Faturası")
            {
                SagTikYenile.Enabled = false;
                alisduzenle.Enabled = true;
            }
        }

        private void SagTikYenile_Click(object sender, EventArgs e)
        {
            Formlar.Fatura(true, HareketID);
            listele();
        }

        private void alisduzenle_Click(object sender, EventArgs e)
        {
            Formlar.aFatura(true, HareketID);
            listele();
        }

        private void frmFaturaListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}