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

namespace DXApplication2.Modul_HizliSatis
{
    public partial class frmKasaSec : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;
        double VAL = 0;
        string ID1 = "KS";
        int kasaID = -1;
        public frmKasaSec()
        {
            InitializeComponent();
        }

        private void frmKasaSec_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            var lst = from s in db.TBL_KASALARs
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
        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
            
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

    }
}