using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.Modul_HizliSatis
{
    public partial class HizliSatisRapor : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();
        private int rowIndex = 0;
        public HizliSatisRapor()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void HizliSatisRapor_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            button1_Click(null, null);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TBL_HIZLISATISRAPOR rapor = new TBL_HIZLISATISRAPOR();
            DateTime baslangic = DateTime.Parse(dbaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dbitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            {
                if (listBox1.SelectedIndex == 0)
                {
                    var liste = db.TBL_HIZLISATISRAPOR.ToList();
                    liste = db.TBL_HIZLISATISRAPOR.Where(x => x.TARIH >= baslangic && x.TARIH <= bitis).OrderByDescending(x => x.TARIH).ToList();
                    dataGridView1.DataSource = liste;

                    tsatisnakit.Text = Convert.ToDouble(liste.Where(x => x.IADE == false && x.GELIR == false && x.GIDER == false).Sum(x => x.NAKIT)).ToString("C2");
                    tsatiskart.Text = Convert.ToDouble(liste.Where(x => x.IADE == false && x.GELIR == false && x.GIDER == false).Sum(x => x.KART)).ToString("C2");

                    tiadenakit.Text = Convert.ToDouble(liste.Where(x => x.IADE == true).Sum(x => x.NAKIT)).ToString("C2");
                    tiadekart.Text = Convert.ToDouble(liste.Where(x => x.IADE == true).Sum(x => x.KART)).ToString("C2");

                    tgelirnakit.Text = Convert.ToDouble(liste.Where(x => x.GELIR == true).Sum(x => x.NAKIT)).ToString("C2");
                    tgelirkart.Text = Convert.ToDouble(liste.Where(x => x.GELIR == true).Sum(x => x.KART)).ToString("C2");

                    tgidernakit.Text = Convert.ToDouble(liste.Where(x => x.GIDER == true).Sum(x => x.NAKIT)).ToString("C2");
                    tgiderkart.Text = Convert.ToDouble(liste.Where(x => x.GIDER == true).Sum(x => x.KART)).ToString("C2");
                }
                else if (listBox1.SelectedIndex == 1)
                {
                    var liste = db.TBL_HIZLISATISRAPOR.ToList();
                    liste = db.TBL_HIZLISATISRAPOR.Where(x => x.TARIH >= baslangic && x.TARIH <= bitis && x.IADE == false && x.GELIR == false && x.GIDER == false).ToList();
                    dataGridView1.DataSource = liste;
                }
                else if (listBox1.SelectedIndex == 2)
                {
                    var liste = db.TBL_HIZLISATISRAPOR.ToList();
                    liste = db.TBL_HIZLISATISRAPOR.Where(x => x.TARIH >= baslangic && x.TARIH <= bitis && x.IADE == true).ToList();
                    dataGridView1.DataSource = liste;
                }
                else if (listBox1.SelectedIndex == 3)
                {
                    var liste = db.TBL_HIZLISATISRAPOR.ToList();
                    liste = db.TBL_HIZLISATISRAPOR.Where(x => x.TARIH >= baslangic && x.TARIH <= bitis && x.GELIR == true).ToList();
                    dataGridView1.DataSource = liste;
                }
                else if (listBox1.SelectedIndex == 4)
                {
                    var liste = db.TBL_HIZLISATISRAPOR.ToList();
                    liste = db.TBL_HIZLISATISRAPOR.Where(x => x.TARIH >= baslangic && x.TARIH <= bitis && x.GIDER == true).ToList();
                    dataGridView1.DataSource = liste;
                }
            }
            Islemler.gridduzenle(dataGridView1);
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied = true;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modul_HizliSatis.frmGelirGider f = new frmGelirGider();
            f.gelirgider = "GELİR";
            f.kullanici = lKullanici.Text;
            f.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modul_HizliSatis.frmGelirGider f = new frmGelirGider();
            f.gelirgider = "GİDER";
            f.kullanici = lKullanici.Text;
            f.ShowDialog();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int islemno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IslemNo"].Value.ToString());
                if (islemno != 0)
                {
                    frmDetayGoster f = new frmDetayGoster();
                    f.islemno = islemno;
                    f.ShowDialog();
                }
            }
        }

        private void HizliSatisRapor_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}