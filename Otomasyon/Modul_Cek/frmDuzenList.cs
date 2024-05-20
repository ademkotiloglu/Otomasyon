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

namespace DXApplication2.Modul_Cek
{
    public partial class frmDuzenList : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        int SecilenID = -1;
        public bool secim = true;
        string durumu = "";
        public frmDuzenList()
        {
            InitializeComponent();
        }

        private void frmDuzenList_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
            durumu = gridView1.GetFocusedRowCellValue("DURUMU").ToString();
            
                if (secim && SecilenID > 0 && durumu == "Portföy")

                {
                    AnaForm.aktarma = SecilenID;
                    this.Close();
                }
            if (secim && SecilenID > 0 && durumu == "Caride")
            {
                Mesajlar.hatamukerrerkayit();
            }
            if (secim && SecilenID > 0 && durumu == "Bankada")
            {
                Mesajlar.hatamukerrerkayit();
            }

        }
    }
}