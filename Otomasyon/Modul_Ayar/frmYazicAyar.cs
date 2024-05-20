using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Modul_Ayar
{
    public partial class frmYazicAyar : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.Islemler islemler = new Fonksiyonlar.Islemler();
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        public frmYazicAyar()
        {
            InitializeComponent();
        }

         public void doldur()
        {
            
            var yazici = db.TBL_AYARLAR.FirstOrDefault();
            if (yazici != null)
            if (yazici.Yazici.Value) checkBox1.Checked = true;
            else checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new DatabaseDataContext())
                if (checkBox1.Checked)
            {
               
                {
                    islemler.sabitvarsayilan();
                    var ayarla = db.TBL_AYARLAR.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SubmitChanges();
                    checkBox1.Text = "Yazıcı Durumu Aktif";
                    checkBox1.BackColor = Color.DarkOliveGreen;
                }
            }
            else
            {
                islemler.sabitvarsayilan();
                var ayarla = db.TBL_AYARLAR.FirstOrDefault();
                ayarla.Yazici = false;
                db.SubmitChanges();
                checkBox1.Text = "Yazıcı Durumu Pasif";
                    checkBox1.BackColor = Color.Tomato;       
                }
        }

        private void frmYazicAyar_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}