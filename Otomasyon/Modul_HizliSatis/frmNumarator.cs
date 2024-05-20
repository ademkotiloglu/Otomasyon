using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DXApplication2.Fonksiyonlar;
using DXApplication2.Modul_Fatura;
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
    public partial class frmNumarator : DevExpress.XtraEditors.XtraForm
    {
        public frmNumarator()
        {
            InitializeComponent();
        }

        private void bnx_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = txtnumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    txtnumarator.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (txtnumarator.Text.Length > 0)
                {
                    txtnumarator.Text = txtnumarator.Text.Substring(0, txtnumarator.Text.Length - 1);
                }
            }
            else
            {
                txtnumarator.Text += b.Text;
            }
        }
        void hesapla()
        {
            if (txtnumarator.Text != "")
            {
                
                    Modul_HizliSatis.HizliSatis f = (Modul_HizliSatis.HizliSatis)Application.OpenForms["HizliSatis"];
                    double nakit = Islemler.DoubleYap(txtnumarator.Text);
                    double geneltoplam = Islemler.DoubleYap(f.txtgeneltoplam.Text);
                    double kart = geneltoplam - nakit;
                    f.lblnakit.Text = nakit.ToString("C2");
                    f.lblkredi.Text = kart.ToString("C2");
                     f.satisyap1("Kart-Nakit");
                    this.Hide();
                   
                
            }
        }
        private void txtnumarator_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                if(e.KeyCode== Keys.Enter)
                {
                    Modul_HizliSatis.HizliSatis f = (Modul_HizliSatis.HizliSatis)Application.OpenForms["HizliSatis"];
                    double nakit = Islemler.DoubleYap(txtnumarator.Text);
                    double geneltoplam = Islemler.DoubleYap(f.txtgeneltoplam.Text);
                    double kart = geneltoplam - nakit;
                    f.lblnakit.Text = nakit.ToString("C2");
                    f.lblkredi.Text = kart.ToString("C2");
                    this.Hide();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hesapla();
        }
    }
}