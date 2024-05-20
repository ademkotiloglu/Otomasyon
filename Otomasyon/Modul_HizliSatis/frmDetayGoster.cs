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
    public partial class frmDetayGoster : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();
        public frmDetayGoster()
        {
            InitializeComponent();
        }
        public int islemno { get; set; }
        private void frmDetayGoster_Load(object sender, EventArgs e)
        {
            lblislemno.Text = islemno.ToString();


            dataGridView1.DataSource = db.TBL_HIZLISATISYAP.Select(s=> new {s.IslemNo,s.UrunAd,s.Miktar,s.Toplam}).Where(x => x.IslemNo == islemno).ToList();
            Islemler.gridduzenle(dataGridView1);
        }
    }
}