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

namespace DXApplication2.Modul_HizliSatis
{
    public partial class frmGelirGider : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();

        public frmGelirGider()
        {
            InitializeComponent();
        }
        public string gelirgider { get; set; }  

        public string kullanici {  get; set; }

        private void frmGelirGider_Load(object sender, EventArgs e)
        {
            label1.Text = gelirgider + " İŞLEMİ YAPILIYOR";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text!="")
            {
                    if (textBox2.Text != "" && textBox1.Text != "" )
                {
                        TBL_HIZLISATISRAPOR io = new TBL_HIZLISATISRAPOR();
                        io.ISLEMNO = 0;
                        io.IADE = false;
                        io.ODEMESEKLI = comboBox1.Text;
                        io.NAKIT = Islemler.DoubleYap(textBox2.Text);
                        io.KART = Islemler.DoubleYap(textBox1.Text);
                        if (gelirgider == "GELİR")
                        {
                            io.GELIR = true;
                            io.GIDER = false;
                        }
                        else
                        {
                            io.GELIR = false;
                            io.GIDER = true;
                        }
                        io.ALISFOYATTOPLAM = 0;
                        io.ACIKLAMA = gelirgider + " - İşlemi " + richTextBox1.Text;
                        io.TARIH = dateTimePicker1.Value;
                    io.KULLANICI = AnaForm.UserID;
                    db.TBL_HIZLISATISRAPOR.InsertOnSubmit(io);
                    db.SubmitChanges();
                    MessageBox.Show(gelirgider + " İşlemi Kaydedildi ..");
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    richTextBox1.Clear();
                    comboBox1.Text = "";
                    HizliSatisRapor f = (HizliSatisRapor)Application.OpenForms["HizliSatisRapor"];
                    if (f!=null)
                    {
                        f.button1_Click(null, null);
                    }
                    this.Hide();

                }
            }
            else
            {
                MessageBox.Show("Lütfen Ödeme Türü Belirleyiniz !");
            }
        }
    }
}