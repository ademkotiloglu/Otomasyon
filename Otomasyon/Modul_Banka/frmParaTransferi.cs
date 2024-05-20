using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2.Modul_Banka
{
    public partial class frmParaTransferi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool edit = false;
        int BankaID = -1;
        int CariID = -1;
        int IslemID = -1;

        string IslemTuru = "Banka Havale";
        public frmParaTransferi()
        {
            InitializeComponent();
        }

        private void txtTransferTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTransferTuru.SelectedIndex == 0)
            {

                rbtnGelen.Text = "Gelen Havale";
                rbtnGiden.Text = "Giden Havale";
                IslemTuru = "Banka Havale";
            }
            else if (txtTransferTuru.SelectedIndex ==0)
            {
                rbtnGelen.Text = "Gelen EFT";
                rbtnGiden.Text = "Giden EFT";
                IslemTuru = "Banka Havale";
            }
        }

        private void txtTarih_EditValueChanged(object sender, EventArgs e)
        {
            
        }

    void temizle()
        {
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtHesapNo.Text = "";
            txtHesapTuru.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            edit = false;
            IslemID = -1;
            BankaID = -1;
            CariID = -1;
            AnaForm.aktarma = -1;
        }

    void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                txtHesapTuru.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPADI;
                txtHesapNo.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPNO;
            }
            catch (Exception)
            {
                BankaID = -1;
            }
            }

    void CariAc(int ID)
    {
        try
        {
            CariID = ID;
            txtCariAdi.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIADI;
            txtCariKodu.Text = db.TBL_CARILERs.First(s => s.ID == CariID).CARIKODU;
        }
        catch (Exception)
        {
            CariID = -1;
        }
    }

    void yenikaydet()
    {
        try
        {
            Fonksiyonlar.TBL_BANKAHAREKETLERI Banka = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
            Banka.ACIKLAMA = txtAciklama.Text;
            Banka.BELGENO = txtBelgeNo.Text;
            Banka.CARIID = CariID;
            Banka.BANKAID = BankaID;
            Banka.EVRAKTURU = txtTransferTuru.SelectedItem.ToString();
            if (rbtnGelen.Checked) Banka.GCKODU = "G";
            if (rbtnGiden.Checked) Banka.GCKODU = "C";
            Banka.SAVEDATE = DateTime.Now;
            Banka.SAVEUSER = AnaForm.UserID;
            Banka.TARIH = DateTime.Parse(txtTarih.Text);
            Banka.TUTAR = decimal.Parse(txtTutar.Text);
            db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(Banka);
            db.SubmitChanges();
            Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = new Fonksiyonlar.TBL_CARIHAREKETLERI();
            CariHareket.ACIKLAMA = txtAciklama.Text;
            if (rbtnGelen.Checked) CariHareket.ALACAK = decimal.Parse(txtTutar.Text);
            if (rbtnGiden.Checked) CariHareket.ALACAK = decimal.Parse(txtTutar.Text);
            CariHareket.CARIID = CariID;
            CariHareket.EVRAKID = Banka.ID;
            CariHareket.EVRAKTURU = txtTransferTuru.SelectedItem.ToString();
            CariHareket.TARIH = DateTime.Now;
            if (txtTransferTuru.SelectedIndex == 0) CariHareket.TIPI = "BH";
            if (txtTransferTuru.SelectedIndex == 1) CariHareket.TIPI = "EFT";
            CariHareket.SAVEDATE = DateTime.Now;
            CariHareket.SAVEUSER = AnaForm.UserID;
            db.TBL_CARIHAREKETLERIs.InsertOnSubmit(CariHareket);
            db.SubmitChanges();
            Mesajlar.yenikayit("Para Transfer Kaydı İşlendi.");
            temizle();
                frmParaTransferi_Load(null, null);

        }

        catch (Exception e)
        {
            Mesajlar.Hata(e);
        }

    }

    void guncelle()
    {
        try
        {
            Fonksiyonlar.TBL_BANKAHAREKETLERI Banka = db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID);
            Banka.ACIKLAMA = txtAciklama.Text;
            Banka.BELGENO = txtBelgeNo.Text;
            Banka.CARIID = CariID;
            Banka.BANKAID = BankaID;
            Banka.EVRAKTURU = txtTransferTuru.SelectedItem.ToString();
            if (rbtnGelen.Checked) Banka.GCKODU = "G";
            if (rbtnGiden.Checked) Banka.GCKODU = "C";
            Banka.EDITDATE = DateTime.Now;
            Banka.EDITUSER = AnaForm.UserID;
            Banka.TARIH = DateTime.Parse(txtTarih.Text);
            Banka.TUTAR = decimal.Parse(txtTutar.Text);
            db.SubmitChanges();
            Mesajlar.Guncelle(true);
            Fonksiyonlar.TBL_CARIHAREKETLERI CariHareket = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == txtTransferTuru.SelectedItem.ToString() && s.EVRAKID == IslemID);
            CariHareket.ACIKLAMA = txtAciklama.Text;
            if (rbtnGelen.Checked) CariHareket.ALACAK = decimal.Parse(txtTutar.Text);
            if (rbtnGiden.Checked) CariHareket.ALACAK = decimal.Parse(txtTutar.Text);
            CariHareket.CARIID = CariID;
            CariHareket.EVRAKID = Banka.ID;
            CariHareket.EVRAKTURU = txtTransferTuru.SelectedItem.ToString();
            CariHareket.TARIH = DateTime.Now;
            if (txtTransferTuru.SelectedIndex == 0) CariHareket.TIPI = "BH";
            if (txtTransferTuru.SelectedIndex == 1) CariHareket.TIPI = "EFT";
            CariHareket.EDITDATE = DateTime.Now;
            CariHareket.EDITUSER = AnaForm.UserID;
            db.SubmitChanges();
            Mesajlar.Guncelle(true);
            temizle();

        }

        catch (Exception e)
        {
            Mesajlar.Hata(e);
        }
    }

    void sil()

    {
        try
        {
            db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == txtTransferTuru.SelectedItem.ToString() && s.EVRAKID == IslemID));
            db.TBL_BANKAHAREKETLERIs.DeleteOnSubmit(db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID));
            db.SubmitChanges();
            temizle();
        }
        catch (Exception e)
        {
            Mesajlar.Hata(e);
        }
    }

        public void ac(int HareketID)
    {
            try
            {
                edit = true;
                IslemID = HareketID;
                Fonksiyonlar.TBL_BANKAHAREKETLERI Banka = db.TBL_BANKAHAREKETLERIs.First(s => s.ID == IslemID);
                BankaAc(Banka.BANKAID.Value);
                CariAc(Banka.CARIID.Value);
                txtAciklama.Text = Banka.ACIKLAMA;
                txtBelgeNo.Text = Banka.BELGENO;
                txtTarih.Text = Banka.TARIH.Value.ToShortDateString();
                txtTransferTuru.Text = Banka.EVRAKTURU;
                txtTutar.Text = Banka.TUTAR.ToString();
                if (Banka.GCKODU == "G") rbtnGelen.Checked = true;
                if (Banka.GCKODU == "C") rbtnGiden.Checked = true;
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
    }

        private void txtHesapTuru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int Id = Formlar.BankaListesi(true);
            if (Id > 0)
            {
                BankaAc(Id);
                AnaForm.aktarma = -1;
            }
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int Id = Formlar.CariListesi(true);
            if (Id > 0)
            {
                CariAc(Id);
                AnaForm.aktarma = -1;
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (edit && IslemID > 0 && BankaID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) guncelle();
            else yenikaydet();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (edit && IslemID > 0 && BankaID > 0 && Mesajlar.Sil() == DialogResult.Yes) sil();

        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParaTransferi_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
            if (BankaID<0)
            txtBelgeNo.Text = Numaralar.paratransfer('P');
        }

        private void frmParaTransferi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}