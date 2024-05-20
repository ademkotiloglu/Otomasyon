using DevExpress.Utils.Extensions;
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
using System.Data.Entity;
using System.IO;
using System.Data.SqlTypes;
using DXApplication2.Fonksiyonlar;
using System.Data.Linq;
using Microsoft.EntityFrameworkCore;

namespace DXApplication2.Modul_HizliSatis
{
    public partial class HizliButonEkle : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        public HizliButonEkle()
        {
            InitializeComponent();
        }

        private void txtbarkod_TextChanged(object sender, EventArgs e)
        {
            if (txtbarkod.Text != "") ;
            {
                string urunad = txtbarkod.Text;
                var urunler = db.TBL_STOKLARs.Where(a => a.STOKADI.Contains(urunad)).ToList();
                dataGridView1.DataSource = urunler;

            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                    {
                dataGridView1.DataSource = db.TBL_STOKLARs.ToList();
                Islemler.gridduzenle1(dataGridView1);
            }
            else
            {
                dataGridView1.DataSource = null;
            }

        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string barkod = dataGridView1.CurrentRow.Cells["STOKBARKOD"].Value.ToString();
                string urunad = dataGridView1.CurrentRow.Cells["STOKADI"].Value.ToString();
                double fiyat = Convert.ToDouble(dataGridView1.CurrentRow.Cells["STOKSATISFIYAT"].Value.ToString());
                int id = Convert.ToInt16(lbuttonno.Text);
                var guncelleme = db.TBL_HIZLIURUN.First(s => s.ID == id);
                guncelleme.STOKBARKOD = barkod;
                guncelleme.STOKADI = urunad;
                guncelleme.STOKSATISFIYAT = fiyat;
                db.SubmitChanges();
                MessageBox.Show("Hızlı Ürün Tanımlanmıştır ..!");
                HizliSatis f = (HizliSatis)Application.OpenForms["HizliSatis"];
                if (f != null)
                {
                    Button b = f.Controls.Find("bh" + id, true).FirstOrDefault() as Button;
                    b.Text = urunad + "\n" + fiyat.ToString("C2");
                }
                this.Close();
            }
        }

        private void HizliButonEkle_Load(object sender, EventArgs e)
        {

        }
    }
}