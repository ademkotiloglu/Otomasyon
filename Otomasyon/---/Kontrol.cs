using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.IO;
using Lisans;
using DevExpress.Data.Helpers;
using DevExpress.CodeParser;
using System.Windows.Forms;

namespace DXApplication2.Fonksiyonlar
{
    public class Kontrol
    {
        DatabaseDataContext db = new DatabaseDataContext();
        Lic lic =new Lic();
        TBL_LISASNS guvenlik = new TBL_LISASNS();
        public bool KontrolYap()
        {
            bool durum = false;
            if (db.TBL_LISASNS.Count() == 0)
            {
                LisansFormuAc();
            }
            else
            {
                Lic lic = new Lic();
                var guvenlik = db.TBL_LISASNS.First();
                if(lic.TarihCoz(guvenlik.BASLANGIC)<DateTime.Now)
                {
                    guvenlik.BASLANGIC = lic.TarihSifrele(DateTime.Now);
                    db.SubmitChanges();
                    durum = true;
                }
                if (lic.TarihKontrol(lic.TarihCoz(guvenlik.BASLANGIC),lic.TarihCoz(guvenlik.BITIS)))
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                    LisansFormuAc();
                }
            }
            return durum;
        }
        public void LisansFormuAc()
        {
            Lic lic = new Lic();
            frmLisans f= new frmLisans();
            f.label2.Text = lic.EkrandaGoster().ToString();
            f.Show();
        }

        private int guvenlikeklimi()
        {
            return db.TBL_LISASNS.Count();
        }
        private void guvenlikekle(string baslangic, string bitis)
        {
            guvenlik.BASLANGIC = baslangic;
            guvenlik.BITIS = bitis;
            DateTime baslangictarihi = lic.TarihCoz(guvenlik.BASLANGIC);
            DateTime bitistarihi = lic.TarihCoz(guvenlik.BITIS);
            TimeSpan kalan = bitistarihi - baslangictarihi;
            int kalan1 = kalan.Days;
            if (kalan1 < 11)
            {
                guvenlik.DURUMU = "DEMO";
            }
            if (kalan1 > 11)
            {
                guvenlik.DURUMU = "LISANSLI KURULUM";
            }
            db.TBL_LISASNS.InsertOnSubmit(guvenlik);
            db.SubmitChanges();
        }

        private void guvenlikguncelle(string baslangic, string bitis)
        {
            var guvenlikguncelle = db.TBL_LISASNS.First();
            guvenlikguncelle.BASLANGIC = baslangic;
            guvenlikguncelle.BITIS = bitis;
            db.SubmitChanges();
        }
        private void demoolustur()
        {
            try
            {
  if (guvenlikeklimi()==0)
            {
                guvenlikekle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.DemoTarihOlustur()));
            }
            else 
            {
                guvenlikguncelle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.DemoTarihOlustur()));
            }
                System.Windows.Forms.MessageBox.Show("Program 10 Günlük Demo Lisansı Oluşturulmuştur ..!");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata Oluştu ..!");
            }
          
        }
        private void yillikolustur()
        {
            try
            {
                if (guvenlikeklimi() == 0)
                {
                    guvenlikekle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.YillikTarihOlustur()));
                }
                else
                {
                    guvenlikguncelle(lic.TarihSifrele(DateTime.Now), lic.TarihSifrele(lic.YillikTarihOlustur()));
                }
                    System.Windows.Forms.MessageBox.Show("Program 1 Yıllık Lisansı Oluşturulmuştur ..!");
                }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata Oluştu ..!");
            }

        }
        public void Lisansla(string girilenkod)
        {
            int durum = lic.GirilenLisansiKontrolEt(girilenkod);
            switch (durum)
            {
                case 0: //geçersiz lisans kodu
                    demoolustur();
                    break;
                case 1:
                    System.Windows.Forms.MessageBox.Show("Girilen Lisans Numarası Hatalı ..!");

                    break;
                case 2:
                    yillikolustur();
                    break;
                default:
                    break;

            }
        }
    }
    
}
