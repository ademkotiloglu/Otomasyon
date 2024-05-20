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
    public partial class frmGeriYukle : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        private SqlConnection con;
        private SqlCommand komut;
        string connectionstring = "";
        string sql = "";
        public frmGeriYukle()
        {
            InitializeComponent();
        }

       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Yedekleme Dosyası(*.bak) |*bak|Tüm Dosyalar (*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text= dlg.FileName;
            }
        }

        private void frmGeriYukle_Load(object sender, EventArgs e)
        {
            string sunucu = Properties.Settings.Default.cs_Sunucu;
            string user = Properties.Settings.Default.cs_UserID;
            string pass = Properties.Settings.Default.cs_Password;
            string database = Properties.Settings.Default.cs_Database;
            textBox1.Text = database.Substring(0, (database.Length - 1));
            textBox2.Text = sunucu.Substring(0, (sunucu.Length - 1));
            textBox3.Text = user.Substring(0, (user.Length - 1));
            textBox4.Text = pass.Substring(0, (pass.Length - 1));
            radioButton2.Select();
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

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("VeritabanıSeçimi Zorunludur ..!");
                    return;
                }
               
                
                SqlConnection con = new SqlConnection("Data Source=" + textBox2.Text + ";Initial Catalog=" + textBox1.Text + ";Persist Security Info=True; User ID =" + textBox3.Text + "; Password=" + textBox4.Text + "");
                string str = "USE MASTER ";
                string sql = "ALTER DATABASE " + textBox1.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                string sql1 = "RESTORE DATABASE " + textBox1.Text + " FROM Disk ='" + txtPath.Text + "' WITH REPLACE;";
                SqlCommand komut = new SqlCommand(sql, con);
                SqlCommand komut1 = new SqlCommand(sql1, con);
                SqlCommand komut2 = new SqlCommand(str, con);
                con.Open();
                komut2.ExecuteNonQuery();
                komut.ExecuteNonQuery();
                komut1.ExecuteNonQuery();
                
                con.Close();
                con.Dispose();
                Mesajlar.Uyari1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}