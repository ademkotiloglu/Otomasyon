using DevExpress.XtraRichEdit.Model.History;
using DXApplication2.Fonksiyonlar;
using Lisans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();
        public static Fonksiyonlar.TBL_KULLANICILAR Kullanici;
        public static int UserID = -1;
        public static int aktarma = -1;

        public AnaForm()
        {
            InitializeComponent();
           
        }

        public AnaForm(Fonksiyonlar.TBL_KULLANICILAR GelenKullanici)
        {
            InitializeComponent();
            Kullanici = GelenKullanici;
            UserID = Kullanici.ID;
            txtaltkullanici.Caption = Kullanici.KULLANICI;
            txtsaat.Caption = DateTime.Now.ToLongDateString();
            txttarih.Caption = DateTime.Now.ToLongTimeString();
            if (Kullanici.KODU == "Misafir")
            {
                BtnKullanici.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

        }

        #region StokButon
        private void barBtnStokListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.StokListesiDuzen();
        }

        private void barBtnStokKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.StokKarti();
        }

        private void barBtnStokGrup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.StokGruplari();
        }

        private void barBtnStokHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.StokHareketleri();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokKarti();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokListesiDuzen();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokGruplari();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokHareketleri();
        }
        #endregion

        #region CariButon
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            formlar.CariKarti();

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.CariGruplari();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            formlar.CariListesiDuzen();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.CariHareketleri();
        }
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariKarti();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariGruplari();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariListesiDuzen();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariHareketleri();
        }
        #endregion

        #region BankaButon
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.BankaAcilisi();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.BankaHareketleri();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.Bankaİslem();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.BankaListesi();
        }
        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaAcilisi();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.ParaTransferi();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaListesi();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.Bankaİslem();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaHareketleri();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaAcilis();
        }

        #endregion

        #region KasaButon
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.ParaTransferi();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KasaAcilis();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KasaListesi();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KasaDevir();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KasaHareketleri();
        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KasaTahsilat();
        }
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaListesi();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaDevir();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaTahsilat();
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaHareketleri();
        }

        #endregion

        #region FaturaButon
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.Fatura();
        }


        #endregion

        #region CekButon
        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KendiCek();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.MusteriCek();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.BankaCek();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.CariCek();
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.MusteriCek();
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KendiCek();
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaCek();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariCek();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.ceklistesi();
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.ceklistesi();
        }
        #endregion

        #region GenelButon
        public void Mesaj(string Baslik, string Mesaj)
        {

            ALC.Show(this, Baslik, Mesaj);
        }



        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
        #endregion

        private void BtnKullanici_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KullaniciYonetimi();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.FaturaListesi();
        }

        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.FaturaListesi();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.Fatura();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.aFatura();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.aFatura();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.iFatura();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.iFatura();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.aiFatura();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.aiFatura();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.satisIrsaliye();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.alisirsaliye();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.alisirsaliye();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.satisIrsaliye();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.IrsaliyeListesi();
        }

        private void navBarItem31_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.IrsaliyeListesi();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void AnaForm_Load(object sender, EventArgs e)
        {
            formlar.logo();
            Lic lic = new Lic();
            var lisans = db.TBL_LISASNS.FirstOrDefault();
            txtlisansdurum.Caption = lisans.DURUMU;
            txtlisansdurumu1.Caption = lic.TarihCoz(lisans.BITIS).ToString();
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Hakkimizda f2 = new Hakkimizda();
            f2.ShowDialog();
        }

        private void barButtonItem34_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.hizli();
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.yedekle();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.geriyukle();
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.sirketayar();
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.printerayar();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.teraziayar();
        }

        private void barButtonItem35_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.KullaniciYonetimi();
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.HizliSatisRapor();
        }
    }
    }

