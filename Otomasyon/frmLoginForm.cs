using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.IO.Compression;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Lisans;
using DXApplication2.Fonksiyonlar;

namespace DXApplication2
{
    public partial class frmLoginForm : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public int v = 1;
        public frmLoginForm()
        {

            InitializeComponent();
            txtkullanici.Focus();
            Inıt_Data();
            
        }
        static async Task Main()
        {
            var updated = await CheckNewVersionAsync();
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            Kontrol kontrol = new Kontrol();
            if(kontrol.KontrolYap())
            try
            {
                Fonksiyonlar.TBL_KULLANICILAR kullanici = db.TBL_KULLANICILARs.First(s => s.KULLANICI == txtkullanici.Text.Trim() && s.SIFRE == txtsifre.Text.Trim());
                kullanici.LASTLOGIN = DateTime.Now;
                db.SubmitChanges();
                this.Hide();
                save_data();
                AnaForm frm = new AnaForm(kullanici);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş Yapılamadı . Kullanıc Adı veya Şifreyi Kontrol Ediniz ..");
                return;
            }
        }

        private void btnbaglanti_Click(object sender, EventArgs e)
        {
            frmAyar frm = new frmAyar();
            frm.ShowDialog();
        }

        private const string sunucuVersiyonDosyaURL = "http://ademkotiloglu.com/versiyon/test.php";
        private const string uygulamaIndirmeURL = "http://ademkotiloglu.com/versiyon/Setup.msi";

        private static async Task<bool> CheckNewVersionAsync()
        {
            try
            {
                string sunucuVersiyonHtml = await new HttpClient().GetStringAsync(sunucuVersiyonDosyaURL);
                string pattern = @"<p>(.*?)<\/p>";
                string sunucuVersiyon = Regex.Match(sunucuVersiyonHtml, pattern).Groups[1].Value;
                string mevcutVersiyon = Application.ProductVersion;

              

                if (new Version(sunucuVersiyon) > new Version(mevcutVersiyon))
                {
                    MessageBox.Show("Yeni Bir Güncelleme Bulunuyor. İndiriliyor...");
                    var httpClient = new HttpClient();
                    var downloaded = await httpClient.GetStreamAsync(uygulamaIndirmeURL);

                    if (File.Exists("Yeni_Guncelleme.msi"))
                    {
                        File.Delete("Yeni_Guncelleme.msi");
                    }
                    using (var reader = new FileStream("Yeni_Guncelleme.msi", FileMode.CreateNew))
                    {
                        downloaded.CopyTo(reader);
                    }
                    try
                    {
                        Process.Start("Yeni_Guncelleme.msi");
                    }
                    catch (Exception excpt)
                    {
                        MessageBox.Show(excpt.Message);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Uygulama Güncel...");
                    return false;
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show(excpt.Message);
                return true;
            }
        }

    

    private void frmLoginForm_Load(object sender, EventArgs e)
        {



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v == 1) 
            {
            }
            else
            {
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckNewVersionAsync();
        }

        private void Inıt_Data()
        {
            if (Properties.Settings.Default.Username!=string.Empty)
            {
                if (Properties.Settings.Default.Remember==true)
                {
                    txtkullanici.Text = Properties.Settings.Default.Username;
                    txtsifre.Text = Properties.Settings.Default.Password;
                    checkBox1.Checked = true;
                }
                else
                {
                    txtkullanici.Text = Properties.Settings.Default.Username;
                }
            }
        }

        private void save_data()
        {
            if(checkBox1.Checked)
            {
                Properties.Settings.Default.Username = txtkullanici.Text;
                Properties.Settings.Default.Password = txtsifre.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void txtkullanici_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Lic lic = new Lic();
            label1.Text = lic.CpuNo() + "\n" + lic.CpuKarakterToplam().ToString();
        }
    }
}