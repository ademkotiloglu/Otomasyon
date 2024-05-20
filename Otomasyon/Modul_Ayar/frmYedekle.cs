using DXApplication2.Fonksiyonlar;
using System;
using System.IO;
using System.Windows.Forms;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using DevExpress.XtraBars.Docking2010.Views.Widget;

namespace DXApplication2.Modul_Ayar
{
    public partial class frmYedekle : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        public frmYedekle()
        {
            InitializeComponent();
        }

        private void btnyedekle_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        
                if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection();
                if (radioButton1.Checked)//radiobuton1 seçildiyse yani kullanıcı adı varsa   //baglantıcumlemuz soyle olacak
                    con = new SqlConnection("Data Source=" + textBox2.Text + ";Initial Catalog=" + textBox1.Text + ";Persist Security Info=True; User ID =" + textBox3.Text + "; Password=" + textBox4.Text + "");
                else if (radioButton2.Checked)//yani kullanıcı adı ve şifre kullanmadan işlem yapıalcaksa.
                    con = new SqlConnection("Server=" + textBox2.Text + "; Database=" + textBox1.Text + ";Trusted_Connection=True;"); // bu veritabanına erişmemiz için şifreisz yöntem. Client sunucular için kullanılabilir.
                else
                    MessageBox.Show("Lütfen seçim yapın !");
                //Şimdi yine biz sunucu ve veritabanı verileri girilmemişse hata verdirelim kontrol amaçlı. önemli iki alan bu
                string Komutcumle = "BACKUP DATABASE " + textBox1.Text + " TO DISK = '" + txtPath.Text + "\\" + DateTime.Now.ToString("yyyyMMdd") + "Otomasyon_Yedek" + ".bak'";
                //üstte ilk parametre veritabanı adı ikinici parametre programın calıstıgı yolu alıyor ve gunun tarihi ile .bak uzantılı dosya olusturyyor.
                //bu dosyayı veritabanında restore database diyerek içeri alabiliriz.
                SqlCommand komut = new SqlCommand(Komutcumle, con);
                con.Open();
                komut.ExecuteNonQuery();
                con.Close();
                Mesajlar.Uyari();

            }
        }

        private void frmYedekle_Load(object sender, EventArgs e)
        {
            string sunucu = Properties.Settings.Default.cs_Sunucu;
            string user = Properties.Settings.Default.cs_UserID;
            string pass = Properties.Settings.Default.cs_Password;
            string database = Properties.Settings.Default.cs_Database;
            textBox1.Text =  database.Substring(0,(database.Length-1));
            textBox2.Text = sunucu.Substring(0, (sunucu.Length - 1));
            textBox3.Text = user.Substring(0, (user.Length - 1));
            textBox4.Text = pass.Substring(0, (pass.Length - 1));
            radioButton2.Select();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text = dlg.SelectedPath;
            }
        }
    }
}