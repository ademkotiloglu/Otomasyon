using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Lisans
{
    public class Lic
    {
        public string CpuNo()
        {
            string islemciid = "";
            ManagementObjectSearcher ara = new ManagementObjectSearcher("Select * From WIN32_Processor");
            ManagementObjectCollection obje = ara.Get();
            foreach (ManagementObject item in obje)
            {
                islemciid = item["ProcessorId"].ToString();
            }
            return islemciid;
        
        }
        public int CpuKarakterToplam()
        {
            int toplam = 0;
            foreach (char item in CpuNo().ToCharArray()) 
            {
                toplam += (int)item;
            }
            return toplam;
        }

        public string gunkarakter = "NCDNVCUJADBSVDNVIKDANVKCVJKDNVKDASBVJUDNVMKADSBNVKDASVNKJSDNVKUGE";
        public string aykarakter = "GBSDSHNVIBSDAVJDVBUDSVCNLSKDVBDUVNBVDSVU";
        public string yilkarakter = "EGUFWBDOJSHAWCVOASYGTGJDVBUDSVCNLSKDVVKD";

        public bool TarihKontrol(DateTime baslangic, DateTime bitis)
        {
            return baslangic < DateTime.Now && DateTime.Now < bitis;
        }
        public int GirilenLisansiKontrolEt(string girilenlisansbilgisi)
        {
            Cursor.Current = Cursors.WaitCursor;
            double girilen = Convert.ToDouble(girilenlisansbilgisi);
            bool demomu = girilen == CpuKarakterToplam() * TarihFonksiyon() * 3;
            bool yillikmi = girilen == CpuKarakterToplam() * TarihFonksiyon() * 13;
            int durum = 0;
            if (demomu)
            {
                durum = 1; //demo kurulum
            }
            if (yillikmi)
            {
                durum = 2; //yillik kurulum
            }
            else
            {
                durum = 0;
            }
            Cursor.Current = Cursors.Default;
            return durum;   
        }
        public DateTime TarihCoz(string sifrelitarih)
        {
            string strgun = sifrelitarih.Substring(0, 2);
            string stray = sifrelitarih.Substring(2, 2);
            string stryil = sifrelitarih.Substring(4, 2);
            int gun = gunler().Where(x => x.ad == strgun).FirstOrDefault().numara;
            int ay = aylar().Where(x => x.ad == stray).FirstOrDefault().numara;
            int yil = yillar().Where(x => x.ad == stryil).FirstOrDefault().numara;
            DateTime tarih = new DateTime(yil, ay, gun);
            return tarih;
        }
        public string TarihSifrele(DateTime tarih)
        {
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;
            string strgun = gunler().Where(x => x.numara == gun).FirstOrDefault().ad;
            string stray = aylar().Where(x => x.numara == ay).FirstOrDefault().ad;
            string stryil = yillar().Where(x => x.numara == yil).FirstOrDefault().ad;
            string olusansifrelitarih = strgun + stray + stryil;
            return olusansifrelitarih;
        }
        public List<Sablon> gunler()
        {
            List<Sablon> listgun = new List<Sablon>();
            for (int i=0; i <31;i++ )
            {
                listgun.Add(new Sablon { numara = i + 1, ad = gunkarakter.ToString().Substring(i * 2, 2)});
            }
            return listgun;
        }
        public List<Sablon> aylar()
        {
            List<Sablon> listay = new List<Sablon>();
            for (int i = 0; i < 12; i++)
            {
                listay.Add(new Sablon { numara = i + 1, ad = aykarakter.ToString().Substring(i * 2, 2)});
            }
            return listay;
        }
        public List<Sablon> yillar()
        {
            List<Sablon> listyil = new List<Sablon>();
            int karaktersayisi = 0;
            for (int i = 2023; i < 2033; i++)
            {
                listyil.Add(new Sablon { numara = i, ad = yilkarakter.ToString().Substring(karaktersayisi * 2, 2) });
                karaktersayisi += 2;
            }
            return listyil;
        }
        public class Sablon
        {
            public int numara { get; set; }  
            public string ad { get; set; }
        }

        public long EkrandaGoster()
        {
            long gosterilecekno = CpuKarakterToplam() * TarihFonksiyon();
            return gosterilecekno;
        }
        public long TarihFonksiyon()
        {
            return (DateTime.Now.Day + DateTime.Now.Month) * DateTime.Now.Year;
        }

        public DateTime DemoTarihOlustur()
        {
            DateTime tarih = DateTime.Now.AddDays(10);
            return tarih;
        }
        public DateTime YillikTarihOlustur()
        {
            DateTime tarih = DateTime.Now.AddYears(1);
            return tarih;
        }
                
    }
}
