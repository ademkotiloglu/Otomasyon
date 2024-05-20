using DevExpress.CodeParser;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Wizards.Templates;
using DXApplication2.Fonksiyonlar;
using Microsoft.SqlServer.Management.Sdk.Sfc;
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
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DXApplication2.Modul_HizliSatis
{
    public partial class HizliSatis : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();
        int FaturaID = -1;
        int IrsaliyeID = -1;
          
        public HizliSatis()
        {
            InitializeComponent();
          
        }
        private void hizlibutondoldur()
        {
            var hizliurun = db.TBL_HIZLIURUN.ToList();
            foreach (var item in hizliurun)
            {
                Button bh = this.Controls.Find("bh" + item.ID, true).FirstOrDefault() as Button;
                if (bh != null)
                {
                    double fiyat = Islemler.DoubleYap(item.STOKSATISFIYAT.ToString());
                    bh.Text = item.STOKADI + "\n" + fiyat.ToString("C2");
                }

            }
        }
        private void btnsil(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-")) ;
                {
                    int butonid = Convert.ToUInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += sil_click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void sil_click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelleme = db.TBL_HIZLIURUN.First(s => s.ID == butonid);
            guncelleme.STOKBARKOD = "-";
            guncelleme.STOKADI = "-";
            guncelleme.STOKSATISFIYAT = 0;
            db.SubmitChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("bh" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");
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
        private void hizlibutonclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
            if (b.Text.ToString().StartsWith("-"))
            {
                HizliButonEkle f = new HizliButonEkle();
                f.lbuttonno.Text = butonid.ToString();
                f.ShowDialog();
            }
            else
            {
                var urunbarkod = db.TBL_HIZLIURUN.Where(a => a.ID == butonid).Select(a => a.STOKBARKOD).FirstOrDefault();
                var urun = db.TBL_STOKLARs.Where(a => a.STOKBARKOD == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(txtmiktar.Text));
                GenelToplam();
            }
        }

        public void ilksatir()
        {
            if (!db.TBL_HIZLISATISYAP.Any())
            {
                TBL_HIZLISATISYAP s = new TBL_HIZLISATISYAP();
                s.Barkod = "1";
                s.KDVTutar = 1;
                s.Tarih = DateTime.Now;
                s.Toplam = 1;
                s.Birim = "1";
                s.Iade = false;
                s.IslemNo = 1;
                s.Kullanici = "admin";
                s.Miktar = 0;
                s.OdemeSekli = "0";
                s.AlisFiyat = 0;
                s.SatisFiyat = 0;
                s.UrunAd = "0";
                s.UrunGrup = "0";
                db.TBL_HIZLISATISYAP.InsertOnSubmit(s);
                db.SubmitChanges();

            }
        }

        private void HizliSatis_Load(object sender, EventArgs e)
        {
            
                label4.Text = Numaralar.FaturaNo('F');
            label9.Text = Numaralar.IrsaliyeNo('I');
           
            hizlibutondoldur();
            ilksatir();
            b5.Text = 5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
            timer1.Start();
            {
                var sabit = db.TBL_AYARLAR.FirstOrDefault();
                cyazdirma.Checked = Convert.ToBoolean(sabit.Yazici);
            }
        }

        private void GenelToplam()
        {
            double toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dataGridView1.Rows[i].Cells["Tutar"].Value);
            }
            txtgeneltoplam.Text = toplam.ToString("C2");
            txtmiktar.Text = "1";
            txtbarkodu.Clear();
            txtbarkodu.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void UrunGetirListeye(TBL_STOKLAR urun, string barkod, double miktar)
        {
            int satirsayisi = dataGridView1.Rows.Count;
            //double miktar = Convert.ToDouble(txtmiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        dataGridView1.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(dataGridView1.Rows[i].Cells["Miktar"].Value);
                        dataGridView1.Rows[i].Cells["Tutar"].Value = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells["Fiyat"].Value), 2);
                        eklenmismi = true;
                    }
                }
            }

            if (!eklenmismi)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                dataGridView1.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.STOKADI;
                dataGridView1.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.STOKGRUPID;
                dataGridView1.Rows[satirsayisi].Cells["Birim"].Value = urun.STOKBIRIM;
                dataGridView1.Rows[satirsayisi].Cells["Fiyat"].Value = urun.STOKSATISFIYAT;
                dataGridView1.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                dataGridView1.Rows[satirsayisi].Cells["Tutar"].Value = Math.Round(miktar * (double)urun.STOKSATISFIYAT, 2);
                dataGridView1.Rows[satirsayisi].Cells["AlisFiyat"].Value = urun.STOKALISFIYAT;
                dataGridView1.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.STOKSATISKDV;
                dataGridView1.Rows[satirsayisi].Cells["STOKKODU"].Value = urun.STOKKODU;
                dataGridView1.Rows[satirsayisi].Cells["KDVORAN"].Value = urun.STOKSATISKDV;
            
            }
        }
        private void txtbarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            string barkod = txtbarkodu.Text.Trim();
            if (e.KeyCode == Keys.Enter)

            {

                if (barkod.Length <= 2)
                {
                    txtmiktar.Text = barkod;
                    txtbarkodu.Clear();
                    txtbarkodu.Focus();
                }

                else
                {

                    if (db.TBL_STOKLARs.Any(a => a.STOKBARKOD == barkod))
                    {
                        var urun = db.TBL_STOKLARs.Where(a => a.STOKBARKOD == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod, Convert.ToDouble(txtmiktar.Text));
                    }
                    else
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (db.TBL_TERAZI.Any(a => a.TeraziOnEk == onek))

                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.TBL_STOKLARs.Any(a => a.STOKBARKOD == teraziurunno))

                            {
                                var urunterazi = db.TBL_STOKLARs.Where(a => a.STOKBARKOD == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetirListeye(urunterazi, teraziurunno, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("Kg Ürün Ekleme Sayfası");
                            }
                        }
                        else
                        {
                            Console.Beep(900, 2000);
                            MessageBox.Show("Normal Ürün Ekleme Sayfası");
                        }
                    }
                }

                dataGridView1.ClearSelection();
                GenelToplam();

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }
        private void badet_Click(object sender, EventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                txtmiktar.Text = txtnumarator.Text;
                txtbarkodu.Clear();
                txtbarkodu.Focus();
            }

        }
        private void button51_Click(object sender, EventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                double sonuc = Islemler.DoubleYap(txtnumarator.Text) - Islemler.DoubleYap(txtgeneltoplam.Text);
                txtparaustu.Text = sonuc.ToString("C2");
                txtnumarator.Clear();
                txtbarkodu.Focus();
            }
        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                if (db.TBL_STOKLARs.Any(a => a.STOKBARKOD == txtnumarator.Text))
                {
                    var urun = db.TBL_STOKLARs.Where(a => a.STOKBARKOD == txtnumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, txtnumarator.Text, Convert.ToDouble(txtmiktar.Text));
                    txtbarkodu.Focus();
                    GenelToplam();
                }
                else
                {
                    formlar.StokKarti();
                }
            }
        }

        private void paraustuhesapla(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = Islemler.DoubleYap(b.Text) - Islemler.DoubleYap(txtgeneltoplam.Text);
            txtodenen.Text = Islemler.DoubleYap(b.Text).ToString("C2");
            txtparaustu.Text = sonuc.ToString("C2");
        }

        private void btndigerurun_Click(object sender, EventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                int satirsayisi = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                dataGridView1.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                dataGridView1.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                dataGridView1.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                dataGridView1.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(txtnumarator.Text);
                dataGridView1.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                dataGridView1.Rows[satirsayisi].Cells["Tutar"].Value = Convert.ToDouble(txtnumarator.Text);
                dataGridView1.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                GenelToplam();
                txtnumarator.Text = "";
                txtbarkodu.Focus();
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                checkBox1.Text = "Satış Yapılıyor ..!";
                checkBox1.BackColor = Color.GreenYellow;
            }
            else
            {
                checkBox1.Checked = true;
                checkBox1.Text = "İade Yapılıyor ..!";
                checkBox1.BackColor = Color.Tomato;
            }
        }

        public void temizle()
        {
            txtmiktar.Text = "1";
            lblnakit.Text = "";
            lblkredi.Text = "";
            txtbarkodu.Clear();
            txtodenen.Clear();
            txtparaustu.Clear();
            txtgeneltoplam.Text = 0.ToString("C2");
            checkBox1.Checked = false;
            txtnumarator.Clear();
            dataGridView1.Rows.Clear();
            txtbarkodu.Clear();
            txtbarkodu.Focus();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                iadeyap("Nakit");
            }
            else
            {
                satisyap1("Nakit");
            }
            temizle();
            checkBox1.Checked =false;
            checkBox1.Text = "Satış Yapılıyor ..!";
            checkBox1.BackColor = Color.GreenYellow;
        }

        public void satisyap1(string odemesekli)
        {
          
            int satirsayisi = dataGridView1.Rows.Count;
            bool satisiade = checkBox1.Checked;
            double alisfiyattoplam = 0;
          
            if (satirsayisi > 0)
            {
                int? islemno = db.TBL_HIZLISATISYAP.First().IslemNo;
                Fonksiyonlar.TBL_HIZLISATISYAP[] stokhareket = new Fonksiyonlar.TBL_HIZLISATISYAP[dataGridView1.RowCount];

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    stokhareket[i] = new Fonksiyonlar.TBL_HIZLISATISYAP();
                    stokhareket[i].IslemNo = islemno;
                    stokhareket[i].UrunAd = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                    stokhareket[i].UrunGrup = dataGridView1.Rows[i].Cells["UrunGrup"].Value.ToString();
                    stokhareket[i].Barkod = dataGridView1.Rows[i].Cells["Barkod"].Value.ToString();
                    stokhareket[i].Birim = dataGridView1.Rows[i].Cells["Birim"].Value.ToString();
                    stokhareket[i].AlisFiyat = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    stokhareket[i].SatisFiyat = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Fiyat"].Value.ToString());
                    stokhareket[i].Miktar = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareket[i].Toplam = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Tutar"].Value.ToString());
                    stokhareket[i].KDVTutar = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["KDVTutari"].Value.ToString()) * Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareket[i].OdemeSekli = odemesekli;
                    stokhareket[i].Iade = satisiade;
                    stokhareket[i].Tarih = DateTime.Now;
                    stokhareket[i].Kullanici = "admin";
                    db.TBL_HIZLISATISYAP.InsertOnSubmit(stokhareket[i]);
                    db.SubmitChanges();
                    
                   

                };
                Fonksiyonlar.TBL_FATURALAR[] fatura = new Fonksiyonlar.TBL_FATURALAR[dataGridView1.RowCount];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    fatura[i] = new Fonksiyonlar.TBL_FATURALAR();
                    fatura[i].FATURATURU = "Sıcak Satış";
                    fatura[i].FATURANO = label4.Text;
                    fatura[i].CARIKODU = "Genel Müşteri";
                    fatura[i].TARIHI = DateTime.Now;
                    fatura[i].ACIKLAMA = islemno + "Numaralı Hızlı Satış İşlemi";
                    fatura[i].GENELTOPLAM = decimal.Parse(dataGridView1.Rows[i].Cells["Tutar"].Value.ToString());
                    fatura[i].SAVEUSER = AnaForm.UserID;
                    fatura[i].SAVEDATE = DateTime.Now;
                    fatura[i].IRSALIYEID = IrsaliyeID;
                    db.TBL_FATURALAR.InsertOnSubmit(fatura[i]);
                    db.SubmitChanges();
                    FaturaID = fatura[i].ID;
                };
                if (IrsaliyeID < 0)
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {

                        Fonksiyonlar.TBL_IRSALIYELER irsaliye = new Fonksiyonlar.TBL_IRSALIYELER();
                        irsaliye.FATURAID = fatura[i].ID;
                        irsaliye.IRSALIYENO = label9.Text;
                        irsaliye.CARIKODU = "Genel Müşteri";
                        irsaliye.TARIHI = DateTime.Now;
                        irsaliye.SAVEUSER = AnaForm.UserID;
                        irsaliye.SAVEDATE = DateTime.Now;
                        db.TBL_IRSALIYELERs.InsertOnSubmit(irsaliye);
                        db.SubmitChanges();
                        IrsaliyeID = irsaliye.ID;
                        fatura[i].IRSALIYEID = IrsaliyeID;

                    }

                Fonksiyonlar.TBL_STOKHAREKETLERI[] stokhareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[dataGridView1.RowCount];
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {

                        stokhareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                        stokhareketi[i].BIRIMFIYAT = decimal.Parse(dataGridView1.Rows[i].Cells["Fiyat"].Value.ToString());
                    stokhareketi[i].IRSALIYEID = IrsaliyeID;
                    stokhareketi[i].FATURAID = FaturaID;
                        stokhareketi[i].GCKODU = "C";
                        stokhareketi[i].KDV = decimal.Parse(dataGridView1.Rows[i].Cells["KDVTutari"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                        stokhareketi[i].MIKTAR = int.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                        stokhareketi[i].STOKKODU = dataGridView1.Rows[i].Cells["STOKKODU"].Value.ToString();
                        stokhareketi[i].TIPI = "Sıcak Satış";
                        stokhareketi[i].SAVEDATE = DateTime.Now;
                        stokhareketi[i].SAVEUSER = AnaForm.UserID;

                        db.TBL_STOKHAREKETLERIs.InsertOnSubmit(stokhareketi[i]);
                        db.SubmitChanges();


                    };
                

              
                    Fonksiyonlar.TBL_HIZLISATISRAPOR io = new TBL_HIZLISATISRAPOR();
                io.ISLEMNO = islemno;
                io.IADE = false;
                io.ALISFOYATTOPLAM = Islemler.DoubleYap(txtgeneltoplam.Text);
                io.GELIR = false;
                io.GIDER = false;
                io.ODEMESEKLI = odemesekli;
                io.KULLANICI = AnaForm.UserID;
                io.TARIH = DateTime.Now;
                switch (odemesekli)
                {
                    case "Nakit":
                        io.NAKIT = Islemler.DoubleYap(txtgeneltoplam.Text);
                        io.KART = 0; break;
                    case "Kart":
                        io.KART = Islemler.DoubleYap(txtgeneltoplam.Text);
                        io.NAKIT = 0; break;
                       
                    case "Kart-Nakit":
                        io.NAKIT = Islemler.DoubleYap(lblnakit.Text);
                        io.KART = Islemler.DoubleYap(lblkredi.Text); break;

                }
                db.TBL_HIZLISATISRAPOR.InsertOnSubmit(io);
                db.SubmitChanges();

                MessageBox.Show("Satış Tamamlandı ..!");
                var islemnoartir = db.TBL_HIZLISATISYAP.First();
                islemnoartir.IslemNo += 1;
                db.SubmitChanges();
                if (cyazdirma.Checked)
                {
                    Yazdir yazdir = new Yazdir(islemno);
                    yazdir.IslemNo = islemno;
                    yazdir.YazdirmayaBasla();

                }
                temizle();
            }
        }
        private void iadeyap(string odemesekli)
        {
            int satirsayisi = dataGridView1.Rows.Count;
            bool satisiade = checkBox1.Checked;
            double alisfiyattoplam = 0;
            if (satirsayisi > 0)
            {
                int? islemno = db.TBL_HIZLISATISYAP.First().IslemNo;
                Fonksiyonlar.TBL_HIZLISATISYAP[] stokhareket = new Fonksiyonlar.TBL_HIZLISATISYAP[dataGridView1.RowCount];

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    stokhareket[i] = new Fonksiyonlar.TBL_HIZLISATISYAP();
                    stokhareket[i].IslemNo = islemno;
                    stokhareket[i].UrunAd = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                    stokhareket[i].UrunGrup = dataGridView1.Rows[i].Cells["UrunGrup"].Value.ToString();
                    stokhareket[i].Barkod = dataGridView1.Rows[i].Cells["Barkod"].Value.ToString();
                    stokhareket[i].Birim = dataGridView1.Rows[i].Cells["Birim"].Value.ToString();
                    stokhareket[i].AlisFiyat = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    stokhareket[i].SatisFiyat = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Fiyat"].Value.ToString());
                    stokhareket[i].Miktar = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareket[i].Toplam = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Tutar"].Value.ToString());
                    stokhareket[i].KDVTutar = Islemler.DoubleYap(dataGridView1.Rows[i].Cells["KDVTutari"].Value.ToString()) * Islemler.DoubleYap(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareket[i].OdemeSekli = odemesekli;
                    stokhareket[i].Iade = satisiade;
                    stokhareket[i].Tarih = DateTime.Now;
                    stokhareket[i].Kullanici = "admin";
                    db.TBL_HIZLISATISYAP.InsertOnSubmit(stokhareket[i]);
                    db.SubmitChanges();

                }

                Fonksiyonlar.TBL_STOKHAREKETLERI[] stokhareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[dataGridView1.RowCount];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    stokhareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    stokhareketi[i].BIRIMFIYAT = decimal.Parse(dataGridView1.Rows[i].Cells["Fiyat"].Value.ToString());
                    stokhareketi[i].FATURAID = islemno;
                    stokhareketi[i].GCKODU = "G";
                    stokhareketi[i].KDV = decimal.Parse(dataGridView1.Rows[i].Cells["KDVTutari"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareketi[i].MIKTAR = int.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    stokhareketi[i].STOKKODU = dataGridView1.Rows[i].Cells["STOKKODU"].Value.ToString();
                    stokhareketi[i].TIPI = "Sıcak Satış";
                    stokhareketi[i].SAVEDATE = DateTime.Now;
                    stokhareketi[i].SAVEUSER = AnaForm.UserID;
                    db.TBL_STOKHAREKETLERIs.InsertOnSubmit(stokhareketi[i]);
                    db.SubmitChanges();
                };

                Fonksiyonlar.TBL_HIZLISATISRAPOR io = new TBL_HIZLISATISRAPOR();
                io.ISLEMNO = islemno;
                io.IADE = true;
                io.ALISFOYATTOPLAM = Islemler.DoubleYap(txtgeneltoplam.Text);
                io.GELIR = false;
                io.GIDER = false;
                io.ODEMESEKLI = odemesekli;
                io.KULLANICI = AnaForm.UserID;
                io.TARIH = DateTime.Now;
                switch (odemesekli)
                {
                    case "Nakit":
                        io.NAKIT = Islemler.DoubleYap(txtgeneltoplam.Text);
                        io.KART = 0; break;

                    case "Kart":
                        io.KART = Islemler.DoubleYap(txtgeneltoplam.Text);
                        io.NAKIT = 0; break;
                        
                    case "Kart-Nakit":
                        io.NAKIT = Islemler.DoubleYap(lblnakit.Text);
                        io.KART = Islemler.DoubleYap(lblkredi.Text); break;

                      
                }
                db.TBL_HIZLISATISRAPOR.InsertOnSubmit(io);
                db.SubmitChanges();

                MessageBox.Show("İade Tamamlandı ..!");
                var islemnoartir = db.TBL_HIZLISATISYAP.First();
                islemnoartir.IslemNo += 1;
                db.SubmitChanges();
                MessageBox.Show("Yazdırma İşlemi Yapınız..!");

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmNumarator f = new frmNumarator();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                iadeyap("Kart");
            }
            else
            {
                satisyap1("Kart");
            }
                temizle();
            checkBox1.Checked = false;
            checkBox1.Text = "Satış Yapılıyor ..!";
            checkBox1.BackColor = Color.GreenYellow;
        }

        private void btnislembeklet_Click(object sender, EventArgs e)
        {
            if (btnislembeklet.Text == "İşlem Beklet")
            {
                bekle();
                btnislembeklet.BackColor = System.Drawing.Color.GreenYellow;
                btnislembeklet.Text = "İşlem Bekliyor";
                dataGridView1.Rows.Clear();
            }
            else
            {
                beklekapat();
                btnislembeklet.BackColor = System.Drawing.Color.Goldenrod;
                btnislembeklet.Text = "İşlem Beklet";
                beklegrid.Rows.Clear();
            }
        }

        private void bekle()
        {
            int satir = dataGridView1.Rows.Count;
            int sutun = dataGridView1.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    beklegrid.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        beklegrid.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
            }
        }
        private void beklekapat()
        {
            int satir = beklegrid.Rows.Count;
            int sutun = beklegrid.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    dataGridView1.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = beklegrid.Rows[i].Cells[j].Value;
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == 9)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                dataGridView1.ClearSelection();
                GenelToplam();
                lblkredi.Text = "";
                lblnakit.Text = "";
                txtbarkodu.Focus();
            }
        }

        private void HizliSatis_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.F2)
               satisyap1("Nakit");
           
           if (e.KeyCode == Keys.F3)
               satisyap1("Kart");
           

        }
    }
}



  