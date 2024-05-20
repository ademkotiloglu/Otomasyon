using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.CodeParser;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DXApplication2.Modul_HizliSatis;

namespace DXApplication2.Fonksiyonlar
{
    class Formlar
    {
        #region Ayarlar
        public void geriyukle()
        {
            Modul_Ayar.frmGeriYukle frm = new Modul_Ayar.frmGeriYukle();
            frm.ShowDialog();
        }
        public void yedekle()
        {
            Modul_Ayar.frmYedekle frm = new Modul_Ayar.frmYedekle();
            frm.ShowDialog();
        }
        public void printerayar()
        {
            Modul_Ayar.frmYazicAyar frm = new Modul_Ayar.frmYazicAyar();
            frm.ShowDialog();
        }
        public void teraziayar()
        {
            Modul_Ayar.frmTeraziAyar frm = new Modul_Ayar.frmTeraziAyar();
            frm.ShowDialog();
        }
        public void sirketayar()
        {
            Modul_Ayar.frmSirketBilgileri frm = new Modul_Ayar.frmSirketBilgileri();
            frm.ShowDialog();
        }
        #endregion



        #region StokFormları

        public void hizli()
        {
            HizliSatis frm = new HizliSatis();
           
            frm.Show();
        }
        public void logo()
        {
            frmLogo frm = new frmLogo();
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();
        }
        public int StokListesi(bool secim = false)
        {
            Modul_Stok.frmStokListesi frm = new Modul_Stok.frmStokListesi();
            if (secim)
            {
                frm.secim = secim;
                frm.ShowDialog();

            }
            else
            {

                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;

        }
        public int StokListesiDuzen(bool secim = false)
        {
            Modul_Stok.frmStokDuzenList frm = new Modul_Stok.frmStokDuzenList();
            if (secim)
            {
                frm.secim = secim;
                frm.ShowDialog();

            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Stok Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;

        }
        public int StokGruplari(bool secim = false)
        {
            Modul_Stok.frmStokGruplari frm = new Modul_Stok.frmStokGruplari();
            if (secim) frm.secim = secim;
            frm.ShowDialog();
            return AnaForm.aktarma;
        }
        public int StokHareketleri(bool secim = false)
        {
            Modul_Stok.frmStokHareket frm = new Modul_Stok.frmStokHareket();
            if (secim)
            {
                frm.secim = secim;
                frm.ShowDialog();

            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Stok Hareketleri")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }
        public void StokKarti(bool ac = false, int ID = -1)
        {
            Modul_Stok.frmStokKarti frm = new Modul_Stok.frmStokKarti();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }

        public void StokKartiDuzen(bool ac = false, int ID = -1)
        {
            Modul_Stok.frmStokKartDuzen frm = new Modul_Stok.frmStokKartDuzen();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        #endregion

        #region CariFormları
        public void CariKarti(bool ac = false, int ID = -1)
        {
            Modul_Cari.frmCariAcilisKarti frm = new Modul_Cari.frmCariAcilisKarti();
            if (ac) frm.ac(ID);
            frm.ShowDialog();

        }
        public int CariListesi(bool secim = false)
        {
            Modul_Cari.frmCariListesi frm = new Modul_Cari.frmCariListesi();
            if (secim)
            {
                frm.SEcim = secim;
                frm.ShowDialog();

            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Cari Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }

        public void CariKartiDuzen(bool ac = false, int ID = -1)
        {
            Modul_Cari.frmCariKartDuzen frm = new Modul_Cari.frmCariKartDuzen();
            if (ac) frm.ac(ID);
            frm.ShowDialog();

        }
        public int CariListesiDuzen(bool secim = false)
        {
            Modul_Cari.frmCariDuzenList frm = new Modul_Cari.frmCariDuzenList();
            if (secim)
            {
                frm.SEcim = secim;
                frm.ShowDialog();

            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Cari Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }
        public int CariGruplari(bool secim = false)
        {
            Modul_Cari.frmCariGruplari frm = new Modul_Cari.frmCariGruplari();

            if (secim) frm.secim = secim;
            frm.ShowDialog();
            return AnaForm.aktarma;

        }
        public int CariHareketleri(bool secim = false)
        {
            Modul_Cari.frmCariHareketleri frm = new Modul_Cari.frmCariHareketleri();
            if (secim)
            {
                frm.secim = secim;
                frm.ShowDialog();

            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Cari Hareketleri")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }
        #endregion

        #region BankaFormları
        public void BankaAcilisi(bool ac = false)
        {
            Modul_Banka.frmBankaAcilisKarti frm = new Modul_Banka.frmBankaAcilisKarti();
            frm.ShowDialog();
        }
        public int BankaHareketleri(bool ac = false, int ID = -1)
        {
            Modul_Banka.frmBankaHareketleri frm = new Modul_Banka.frmBankaHareketleri();

            if (ac)
            {
                frm.BankaAc(ID);
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Banka Hareketleri")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }
        public void Bankaİslem(bool ac = false, int ID = -1)
        {
            Modul_Banka.frmBankaİslem frm = new Modul_Banka.frmBankaİslem();
            if (ac) frm.ac(ID);
            frm.ShowDialog();

        }
        public void BankaParaTransferi(bool ac = false, int ID = -1)
        {
            Modul_Banka.frmParaTransferi frm = new Modul_Banka.frmParaTransferi();
            if (ac) frm.ac(ID);
            frm.ShowDialog();

        }
        public int BankaListesi(bool secim = false)
        {
            Modul_Banka.frmBankaListesi frm = new Modul_Banka.frmBankaListesi();
            if (secim)
            {
                frm.Secim = secim;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Banka Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.aktarma;
        }
        #endregion

        #region KasaFormları
        public void ParaTransferi(bool ac = false)
        {
            Modul_Banka.frmParaTransferi frm = new Modul_Banka.frmParaTransferi();
            frm.ShowDialog();
        }
        public int KasaListesi(bool secim = false)
        {
            Modul_Kasa.frmKasaListesi frm = new Modul_Kasa.frmKasaListesi();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Kasa Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;

        }
        public void KasaAcilis(bool ac = false)
        {
            Modul_Kasa.frmKasaAcilis frm = new Modul_Kasa.frmKasaAcilis();
            frm.ShowDialog();
        }
        public void KasaTahsilat(bool ac = false, int ID = -1)
        {
            Modul_Kasa.frmKasaTahsilat frm = new Modul_Kasa.frmKasaTahsilat();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public void KasaDevir(bool ac = false, int IslemID = -1)
        {
            Modul_Kasa.frmKasaDevir frm = new Modul_Kasa.frmKasaDevir();

            if (ac) frm.Ac(IslemID);
            frm.ShowDialog();
        }
        public int KasaHareketleri(bool ac = false, int ID = -1)
        {
            Modul_Kasa.frmKasaHareketleri frm = new Modul_Kasa.frmKasaHareketleri();

            if (ac)
            { frm.Ac(ID);
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Kasa Hareketleri")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();

            }
            return AnaForm.aktarma;
        }
        #endregion

        #region CekFormları
        public void KendiCek(bool ac = false,int ID=-1)
        {
            Modul_Cek.frmKendiCekim frm = new Modul_Cek.frmKendiCekim();
            if (ac) frm.Ac(ID);
            frm.ShowDialog();
        }
        public void MusteriCek(bool ac = false, int ID=-1)
        {
            Modul_Cek.frmMusteriCeki frm = new Modul_Cek.frmMusteriCeki();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public void CariCek(bool ac = false, int ID = -1)
        {
            Modul_Cek.frmCariyeCikis frm = new Modul_Cek.frmCariyeCikis();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public void BankaCek1(bool ac = false,int ID=-1)
        {
            Modul_Cek.frmBankayaCikisBankaHareket frm = new Modul_Cek.frmBankayaCikisBankaHareket();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public void CariCek1(bool ac = false, int ID = -1)
        {
            Modul_Cek.frmCariyeCikisBankaHareket frm = new Modul_Cek.frmCariyeCikisBankaHareket();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public void BankaCek(bool ac = false, int ID = -1)
        {
            Modul_Cek.frmBankayaCikis frm = new Modul_Cek.frmBankayaCikis();
            if (ac) frm.ac(ID);
            frm.ShowDialog();
        }
        public int ceklistesi(bool secim = false)
        {
            Modul_Cek.frmCekListesi frm = new Modul_Cek.frmCekListesi();
            if (secim)
            {
                frm.secim = true;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Çek Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.aktarma;
        }
        public int ceklistesiduzen(bool secim = false)
        {
            Modul_Cek.frmDuzenList frm = new Modul_Cek.frmDuzenList();
            if (secim)
            {
                frm.secim = true;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Çek Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.aktarma;
        }
        #endregion

        #region FaturaFormları

        public int FaturaListesi(bool secim = false)
        {
            Modul_Fatura.frmFaturaListesi frm = new Modul_Fatura.frmFaturaListesi();
            if (secim)

            {
                frm.secim = true;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "Fatura Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.aktarma;
        }

        public int IrsaliyeListesi(bool secim = false)
        {
            Modul_Fatura.frmIrsaliyeListesi frm = new Modul_Fatura.frmIrsaliyeListesi();
            if (secim)

            {
                frm.secim = true;
                frm.ShowDialog();
            }
            else
            {
                foreach (DevExpress.XtraEditors.XtraForm K in AnaForm.ActiveForm.MdiChildren)
                {
                    if (K.Text == "İrsaliye Listesi")
                    {
                        K.BringToFront();
                        return AnaForm.aktarma;
                    }
                }
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.aktarma;
        }

        public void Fatura(bool Ac = false, int ID = -1, bool Irsalıye=false)
        {
            Modul_Fatura.frmSatisFaturasi frm = new Modul_Fatura.frmSatisFaturasi(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();
            
        }
        public void aFatura(bool Ac = false, int ID = -1, bool Irsalıye = false)
        {
            Modul_Fatura.frmAlisFaturasi frm = new Modul_Fatura.frmAlisFaturasi(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

        }

        public void aiFatura(bool Ac = false, int ID = -1, bool Irsalıye = false)
        {
            Modul_Fatura.frmAlisIade frm = new Modul_Fatura.frmAlisIade(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

        }

        public void iFatura(bool Ac = false, int ID = -1, bool Irsalıye = false)
        {
            Modul_Fatura.frmSatisIade frm = new Modul_Fatura.frmSatisIade(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

        }
        
        #endregion

        #region Kullanici
        public void KullaniciYonetimi()
        {
            Modul_Kullanici.frmKullaniciYonetimi frm = new Modul_Kullanici.frmKullaniciYonetimi();
            frm.ShowDialog();
        }

        public void KullaniciPanel(bool ac = false, int ID = -1)
        {
            Modul_Kullanici.frmKullaniciPanel frm = new Modul_Kullanici.frmKullaniciPanel(ID, ac);
            frm.ShowDialog();
        }
        #endregion

        #region İrsaliye
 

        public void satisIrsaliye(bool Ac = false, int ID = -1, bool Irsalıye = false)
        {
            Modul_Fatura.frmSatisIrsaliye frm = new Modul_Fatura.frmSatisIrsaliye(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

        }

        public void alisirsaliye(bool Ac = false, int ID = -1, bool Irsalıye = false)
        {
            Modul_Fatura.frmAlisIrsaliye frm = new Modul_Fatura.frmAlisIrsaliye(Ac, ID, Irsalıye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

        }
        #endregion


        public void HizliSatisRapor(bool ac = false)
        {
            Modul_HizliSatis.HizliSatisRapor frm = new Modul_HizliSatis.HizliSatisRapor();
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();
        }
    }

}
