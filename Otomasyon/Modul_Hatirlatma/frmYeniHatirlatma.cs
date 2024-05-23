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

namespace DXApplication2.Modul_Hatirlatma
{
    public partial class frmYeniHatirlatma : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        int HatirlatmaID = -1;
        public frmYeniHatirlatma()
        {
            InitializeComponent();
        }
        void yenikaydet()
        {
            Fonksiyonlar.TBL_HATIRLATMA yeni = new Fonksiyonlar.TBL_HATIRLATMA();
            yeni.ID = HatirlatmaID;
            yeni.NOTUNUZ = richTextBox1.Text;
            yeni.TARIH = DateTime.Now;
            yeni.GELECEKTARIH = DateTime.Parse(dbaslangic.Text);
            if (listBox1.SelectedIndex == 0)
            {
                yeni.ONEM = "Normal";
            }
            if (listBox1.SelectedIndex == 1)
            {
                yeni.ONEM = "Önemli";
            }
            if (listBox1.SelectedIndex == 2)
            {
                yeni.ONEM = "Çok Önemli";
            }
            db.TBL_HATIRLATMA.InsertOnSubmit(yeni);
            db.SubmitChanges();
            Mesajlar.yenikayit("Yeni Hatırlatma Eklendi ..");
        }
     void temizle()
        {
            richTextBox1.Text = "";
            listBox1.SelectedIndex = 0;
            dbaslangic.Text = DateTime.Now.ToShortDateString();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            yenikaydet();
            temizle();
        }

        private void frmYeniHatirlatma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}