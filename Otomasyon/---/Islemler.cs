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


    }
}
