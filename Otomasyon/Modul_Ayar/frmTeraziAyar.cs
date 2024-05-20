using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using DevExpress.XtraRichEdit.API.Native;
using DXApplication2.Fonksiyonlar;
using DXApplication2.Modul_Cari;
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
    public partial class frmTeraziAyar : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db =new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool Edit = false;
        int SecimID = -1;
        public bool secim = false;
        public frmTeraziAyar()
        {
            InitializeComponent();
        }

        void temizle ()
        {
            txtterazi.Text = "";
            Edit = false;
            SecimID = -1;
            AnaForm.aktarma = -1;
        }

        void yenikaydet()
        {
            Fonksiyonlar.TBL_TERAZI terazi = new Fonksiyonlar.TBL_TERAZI();
            terazi.TeraziOnEk = int.Parse(txtterazi.Text);   
            db.TBL_TERAZI.InsertOnSubmit(terazi);
            db.SubmitChanges();
            Mesajlar.yenikayit("Yeni Kayıt Oluşturuldu .");
            temizle();
            txtterazi.Focus();
            listele();



        }
        private void frmTeraziAyar_Load(object sender, EventArgs e)
        {
            listele();
            listelekomisyon();
           
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void listele()
        {
            var lst = from s in db.TBL_TERAZI
                      select s;
            Liste.DataSource = lst;
        }
        public void listelekomisyon()
        {
            var komisyon = db.TBL_AYARLAR.FirstOrDefault();
            txtdefaultkomisyon.Text = komisyon.KartKomisyon.ToString();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            yenikaydet();
        }
        void sec()
        {
            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    txtterazi.Text = gridView1.GetFocusedRowCellValue("TeraziOnEk").ToString();

            }
            catch (Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            sec();
            if (secim && SecimID > 0)
            {
                AnaForm.aktarma = SecimID;
                this.Close();
            }
            
        }
        void sil()
        {
            db.TBL_TERAZI.DeleteOnSubmit(db.TBL_TERAZI.First(s => s.ID == SecimID));
            db.SubmitChanges();
            temizle();
            listele();
            txtterazi.Focus();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();  
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtkomisyon.Text !="")
            {
                using (var db = new DatabaseDataContext())
                {
                    var ayar = db.TBL_AYARLAR.FirstOrDefault();
                    ayar.KartKomisyon = Convert.ToInt16(txtkomisyon.Text);
                    db.SubmitChanges();
                    Mesajlar.yenikayit("Komisyon Ayarı Yapıldı ..");
                    txtkomisyon.Focus();
                    txtdefaultkomisyon.Clear();
                    txtdefaultkomisyon.Text = ayar.KartKomisyon.ToString();

                }
            }
            else
            {
                MessageBox.Show("Komisyon Bilgisi Girmediniz ..!");
            }
        }
    }
}