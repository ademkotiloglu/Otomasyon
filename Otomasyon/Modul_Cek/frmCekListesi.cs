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

namespace DXApplication2.Modul_Cek
{
    public partial class frmCekListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        int SecilenID = -1;
        int EvrakID = -1;
        string EvrakTURU = "";
        string durumu = "";
        int HareketID = -1;

        public bool secim = true;

        public frmCekListesi()
        {
            InitializeComponent();
        }

        private void frmCekListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            var lst = from s in db.TBL_CEKLERs
                      where s.TIPI.Contains(txtcekturu.Text) && s.BANKA.Contains(txtbanka.Text) && s.CEKNO.Contains(txtcekno.Text)
                      select s;
            Liste.DataSource = lst;
        }

        void sec()
        {
            try
            {
                SecilenID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    EvrakID = int.Parse(gridView1.GetFocusedRowCellValue("BELGENO").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTURU = gridView1.GetFocusedRowCellValue("TIPI").ToString();
            }
            catch (Exception)
            {
                SecilenID = -1;
                EvrakTURU = "";
                EvrakID = -1;
            }
        }

        

        private void btnAra_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void frmCekListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
            int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            durumu = gridView1.GetFocusedRowCellValue("DURUMU").ToString();

            
                if (EvrakTURU == "Kendi Çekimiz" && durumu == "Portföy")
                {
                    Formlar.KendiCek(true, ID);
                }

                if (EvrakTURU == "Müşteri Çeki" && durumu == "Portföy")
                {
                    Formlar.MusteriCek(true, ID);
                }

            if (EvrakTURU == "Kendi Çekimiz" && durumu == "Bankada")
            {
                Mesajlar.hatacekduzen1();
            }

            if (EvrakTURU == "Müşteri Çeki" && durumu == "Bankada")
            {
                Mesajlar.hatacekduzen1();
            }
            if (EvrakTURU == "Kendi Çekimiz" && durumu == "Caride")
            {
                Mesajlar.hatacekduzen();
            }

            if (EvrakTURU == "Müşteri Çeki" && durumu == "Caride")
            {
                Mesajlar.hatacekduzen();
            }

        }
    }
}