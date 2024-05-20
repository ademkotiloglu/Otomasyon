using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509;
using DevExpress.Utils;

namespace DXApplication2.Fonksiyonlar
{
    class Islemler
    {
        DatabaseDataContext db = new DatabaseDataContext();
        Mesajlar Mesajlar = new Mesajlar();

        public  void sabitvarsayilan()
        {
            if (!db.TBL_AYARLAR.Any())
            {
                TBL_AYARLAR s = new TBL_AYARLAR();
                s.KartKomisyon = 0;
                s.Yazici = false;
                s.AdSoyad = "admin";
                s.Adres = "admin";
                s.Unvan = "admin";
                s.Telefon = "admin";
                s.Eposta ="admin";
                s.Kurulus = "admin";
                s.Note = "admin";
               
                db.TBL_AYARLAR.InsertOnSubmit(s);
                db.SubmitChanges();

            }
        }

        public static double DoubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger,NumberStyles.Currency,CultureInfo.CurrentCulture.NumberFormat, out sonuc);
            return sonuc;

        }

        public static void gridduzenle(DataGridView dgv)
        {
            if(dgv.Columns.Count>0)
            {
                for (int i=0; i< dgv.Columns.Count;i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "ID":
                            dgv.Columns[i].Visible = false; break;
                        case "ISLEMNO":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;
                        case "IslemNo":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;
                        case "ACIKLAMA":
                            dgv.Columns[i].Visible = false;break;
                        case "TARIH":
                            dgv.Columns[i].HeaderText = "Tarih";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].Width = 165;
                            break;
                        case "KULLANICI":
                            dgv.Columns[i].HeaderText = "KULLANICI"; break;
                        case "IADE":
                            dgv.Columns[i].HeaderText = "İade"; break;
                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Ürün Numarası"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Ürün Grubu"; break;
                        case "AlisFiyat":
                            dgv.Columns[i].HeaderText = "Alış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;

                        case "SatisFiyat":
                            dgv.Columns[i].HeaderText = "Satış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "KdvOrani":
                            dgv.Columns[i].HeaderText = "Kdv Oranı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "Birim":
                            
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "Miktar":

                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "ODEMESEKLI":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "ALISFOYATTOPLAM":
                            dgv.Columns[i].HeaderText = "Satır Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "KART":
                            dgv.Columns[i].HeaderText = "Kart";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "NAKIT":
                            dgv.Columns[i].HeaderText = "Nakit";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "GELIR":
                            dgv.Columns[i].HeaderText = "Gelir";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "GIDER":
                            dgv.Columns[i].HeaderText = "Gider";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "Toplam":
                            dgv.Columns[i].HeaderText = "Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;

                     

                    }
                }
            }
        }
        public static void gridduzenle1(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                       
                        case "STOKBARKOD":
                            dgv.Columns[i].HeaderText = "Barkodu"; break;
                        case "STOKADI":
                            dgv.Columns[i].HeaderText = "Stok Adı"; break;
                        case "STOKBIRIM":
                            dgv.Columns[i].HeaderText = "Birimi"; break;
                        case "STOKSATISFIYAT":
                            dgv.Columns[i].HeaderText = "Satış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "STOKSATISKDV":
                            dgv.Columns[i].HeaderText = "Kdv Oranı %";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "STOKKODU":
                            dgv.Columns[i].Visible = false; break;
                        case "ID":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKALISFIYAT":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKALISKDV":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKGRUPID":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKRESIM":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKSAVEUSER":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKSAVEDATE":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKEDITUSER":
                            dgv.Columns[i].Visible = false; break;
                        case "STOKEDITTIME":
                            dgv.Columns[i].Visible = false; break;


                    }
                }
            }
        }

    }
}
