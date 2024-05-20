using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DXApplication2.Fonksiyonlar
{
    class Numara
    {

        DatabaseDataContext db = new DatabaseDataContext();
        Mesajlar Mesajlar = new Mesajlar();

        public string StokKodNumarasi(char c)
        {
            var sonKayit = (from s in db.TBL_STOKLARs
                            where s.STOKKODU.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.STOKKODU;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string StokGrupNo(char c)
        {
            var sonKayit = (from s in db.TBL_STOKGRUPLARIs
                            where s.GRUPKODU.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.GRUPKODU;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string CariGrupNo(char c)
        {
            var sonKayit = (from s in db.TBL_CARIGRUPLARIs
                            where s.GRUPKODU.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.GRUPKODU;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string CariKodNumarasi(char c)
        {

            var sonKayit = (from s in db.TBL_CARILERs
                            where s.CARIKODU.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonCariNo = sonKayit.CARIKODU;

            var numeric = Convert.ToInt32(sonCariNo.Substring(1, sonCariNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }

        public string KasaKodNumarasi(char c)
        {
            var sonKayit = (from s in db.TBL_KASALARs
                            where s.KASAKODU.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonCariNo = sonKayit.KASAKODU;

            var numeric = Convert.ToInt32(sonCariNo.Substring(1, sonCariNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string FaturaNo(char c)
        {
            var sonKayit = (from s in db.TBL_FATURALAR
                            where s.FATURANO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonCariNo = sonKayit.FATURANO;

            var numeric = Convert.ToInt32(sonCariNo.Substring(1, sonCariNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }

          public string IrsaliyeNo(char c)
        {
            var sonKayit = (from s in db.TBL_IRSALIYELERs
                            where s.IRSALIYENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonCariNo = sonKayit.IRSALIYENO;

            var numeric = Convert.ToInt32(sonCariNo.Substring(1, sonCariNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string paratransfer(char c)
        {
            var sonKayit = (from s in db.TBL_BANKAHAREKETLERIs
                            where s.BELGENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.BELGENO;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string bankaislem(char c)
        {
            var sonKayit = (from s in db.TBL_BANKAHAREKETLERIs
                            where s.BELGENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.BELGENO;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string cek(char c)
        {
            var sonKayit = (from s in db.TBL_CEKLERs
                            where s.BELGENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.BELGENO;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string cek1(char c)
        {
            var sonKayit = (from s in db.TBL_CEKLERs
                            where s.VERILENBANKA_BELGENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.VERILENBANKA_BELGENO;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
        public string kasahareket(char c)
        {
            var sonKayit = (from s in db.TBL_KASAHAREKETLERIs
                            where s.BELGENO.Substring(0, 1) == c.ToString()
                            orderby s.ID descending
                            select s).FirstOrDefault();

            if (sonKayit == null)
            {
                return c.ToString() + "000001";
            }

            var sonStokNo = sonKayit.BELGENO;

            var numeric = Convert.ToInt32(sonStokNo.Substring(1, sonStokNo.Length - 1));

            numeric++;

            string Num = c.ToString() + numeric.ToString().PadLeft(6, '0');

            return Num;
        }
    }
    }

      


