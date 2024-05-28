using DevExpress.CodeParser;
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
    public partial class frmCariSec : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;
        double VAL = 0;
        string ID1 = "KS";
        int kasaID = -1;
        public frmCariSec()
        {
            InitializeComponent();
        }

        private void frmCariSec_Load(object sender, EventArgs e)
        {
            Lİstele();
        }
        void Lİstele()
        {
            var lst = from s in DB.TBL_CARILERs
                      
                      select s;
            Liste.DataSource = lst;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var lst = from s in DB.TBL_CARILERs
                      where  s.CARIADI.Contains(textBox1.Text)
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

        private void gridView1_Click(object sender, EventArgs e)
        {
            sec();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            sec();
            if (Secim && SecimID > 0)
            {
                AnaForm.aktarma = SecimID;
                this.Close();
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            sec();
        }
    }
}