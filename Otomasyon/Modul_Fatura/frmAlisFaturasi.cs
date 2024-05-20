using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace DXApplication2.Modul_Fatura
{
    public partial class frmAlisFaturasi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara Numaralar = new Fonksiyonlar.Numara();

        bool edit = false;
        int CariID = -1;
        int OdemeID = -1;
        int FaturaID = -1;
        int IrsaliyeID = -1;
        string OdemeYeri = "";
        bool IrsaliyeAc = false;
        double VAL = 0;
        string ID1 = "AF";
        double VAL1 = 0;
        string ID2 = "AI";
        int BankaID = -1;
        int KasaID = -1;


        private void frmAlisFaturasi_Load(object sender, EventArgs e)
        {
            txtFaturaTarihi.Text = DateTime.Now.ToShortDateString();
            txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();
            if (FaturaID < 0 && IrsaliyeID < 0)
                txtFaturaNo.Text = Numaralar.FaturaNo('F');
            txtİrsaliyeNo.Text = Numaralar.IrsaliyeNo('I');
        }

              public frmAlisFaturasi(bool Ac, int ID, bool Irsaliye)
        {
            InitializeComponent();
            edit = Ac;
            if (Irsaliye) IrsaliyeID = ID;
            else FaturaID = ID;
            IrsaliyeAc = Irsaliye;
            this.Shown += frmAlisFaturasi_Shown;
        }

        void frmAlisFaturasi_Shown(object sender, EventArgs e)
        {
            if (edit) FaturaGetir();
        }

        
        void FaturaGetir()
        {
            try
            {
                Fonksiyonlar.TBL_FATURALAR Fatura = db.TBL_FATURALAR.First(s => s.ID == FaturaID);
                
                IrsaliyeID = Fatura.IRSALIYEID.Value;
                txtAciklama.Text = Fatura.ACIKLAMA;
                txtFaturaNo.Text = Fatura.FATURANO;
                if (Fatura.ODEMEYERIID > 0)
                {
                    txtFaturaTuru.SelectedIndex = 1;
                    if (Fatura.ODEMEYERI == "Kasa")
                    {
                        txtOdemeYeri.SelectedIndex = 0;
                        OdemeYeri = Fatura.ODEMEYERI;
                        txtKasaAdi.Text = db.TBL_KASALARs.First(s => s.ID == Fatura.ODEMEYERIID.Value).KASAADI;
                        txtKasaKodu.Text = db.TBL_KASALARs.First(s => s.ID == Fatura.ODEMEYERIID.Value).KASAKODU;
                    }
                    else if (Fatura.ODEMEYERI == "Banka")
                    {
                        txtOdemeYeri.SelectedIndex = 1;
                        OdemeYeri = Fatura.ODEMEYERI;
                        txtHesapAdi.Text = db.TBL_BANKALARs.First(s => s.ID == Fatura.ODEMEYERIID.Value).HESAPADI;
                        txtHesapNo.Text = db.TBL_BANKALARs.First(s => s.ID == Fatura.ODEMEYERIID.Value).HESAPNO;
                    }
                    OdemeID = Fatura.ODEMEYERIID.Value;
                }
                else if (Fatura.ODEMEYERIID < 1) txtFaturaTuru.SelectedIndex = 0;
                txtİrsaliyeNo.Text = db.TBL_IRSALIYELERs.First(s => s.ID == Fatura.IRSALIYEID.Value).IRSALIYENO;
                txtIrsaliyeTarih.EditValue = db.TBL_IRSALIYELERs.First(s => s.ID == Fatura.IRSALIYEID.Value).TARIHI.Value.ToShortDateString();
                txtCariAdi.Text = db.TBL_CARILERs.First(s => s.CARIKODU == Fatura.CARIKODU).CARIADI;
                txtCariKodu.Text = Fatura.CARIKODU;
                txtFaturaTarihi.EditValue = Fatura.TARIHI.Value.ToShortDateString();

                var srg = from s in db.VW_KALEMLERs
                          where s.FATURAID == FaturaID
                          select s;
                foreach (Fonksiyonlar.VW_KALEMLER k in srg)
                {
                    gridView1.AddNewRow();
                    gridView1.SetFocusedRowCellValue("MIKTAR", k.MIKTAR);
                    gridView1.SetFocusedRowCellValue("BIRIMFIYAT", k.BIRIMFIYAT);
                    gridView1.SetFocusedRowCellValue("KDV", k.KDV);
                    gridView1.SetFocusedRowCellValue("BARKOD", k.STOKBARKOD);
                    gridView1.SetFocusedRowCellValue("STOKKODU", k.STOKKODU);
                    gridView1.SetFocusedRowCellValue("STOKADI", k.STOKADI);
                    gridView1.SetFocusedRowCellValue("BIRIM", k.STOKBIRIM);
                    gridView1.UpdateCurrentRow();
                }


            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

    
      

        private void txtCariKodu_Click(object sender, EventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0) CariSec(ID);
            AnaForm.aktarma = -1;
        }
        void CariSec(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.TBL_CARILER cari = db.TBL_CARILERs.First(s => s.ID == CariID);
                txtCariKodu.Text = cari.CARIKODU;
                txtCariAdi.Text = cari.CARIADI;


            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        void StokGetir(int StokID)
        {
            try
            {
                Fonksiyonlar.TBL_STOKLAR stok = db.TBL_STOKLARs.First(s => s.ID == StokID);
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("MIKTAR", 0);
                gridView1.SetFocusedRowCellValue("BARKOD", stok.STOKBARKOD);
                gridView1.SetFocusedRowCellValue("STOKKODU", stok.STOKKODU);
                gridView1.SetFocusedRowCellValue("STOKADI", stok.STOKADI);
                gridView1.SetFocusedRowCellValue("BIRIM", stok.STOKBIRIM);
                gridView1.SetFocusedRowCellValue("BIRIMFIYAT", stok.STOKSATISFIYAT);
                gridView1.SetFocusedRowCellValue("KDV", stok.STOKSATISKDV);
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            hesapla();
        }

        void hesapla()
        {
            try
            {
                decimal BirimFiyat = 0, Miktar = 0, AraToplam = 0, GenelToplam = 0, KDV = 0, Indırım = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    Miktar = decimal.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString()) / 100 + 1;
                    AraToplam += Miktar * BirimFiyat;
                    GenelToplam += decimal.Parse(gridView1.GetRowCellValue(i, "TOPLAM").ToString()) * KDV;
                }
                txtAraToplam.Text = AraToplam.ToString("0.00");
                txtKDV.Text = (GenelToplam - AraToplam).ToString("0.00");
                txtGenelToplam.Text = GenelToplam.ToString("0.00");
                txtİndirim.Text = Indırım.ToString("0.00");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFaturaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFaturaTuru.SelectedIndex == 0) txtFaturaTuru.Enabled = false;
            if (txtFaturaTuru.SelectedIndex == 1) txtFaturaTuru.Enabled = true;
        }

        private void txtOdemeYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                panelControl4.Enabled = true;
                txtHesapAdi.Enabled = false;
                txtHesapNo.Enabled = false;
                txtKasaAdi.Enabled = false;
                txtKasaKodu.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = false;
                OdemeYeri = txtOdemeYeri.Text;

            }
            if (txtOdemeYeri.SelectedIndex == 1)
            {
                panelControl4.Enabled = true;
                txtHesapAdi.Enabled = true;
                txtHesapNo.Enabled = false;
                txtKasaAdi.Enabled = false;
                txtKasaKodu.Enabled = false;
                OdemeYeri = txtOdemeYeri.Text;
                checkBox1.Enabled = false;
                checkBox2.Enabled = true;
            }
        }

       

        void temizle()
        {
            CariID = -1;
            OdemeID = -1;
            FaturaID = -1;
            IrsaliyeID = -1;
            OdemeYeri = "";
            IrsaliyeAc = false;
            edit = false;
            txtAciklama.Text = "";
            txtAraToplam.Text = "0.00";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtFaturaNo.Text = "";
            txtFaturaTarihi.Text = DateTime.Now.ToShortDateString();
            txtFaturaTuru.SelectedIndex = 0;
            txtGenelToplam.Text = "0.00";
            txtHesapAdi.Text = "";
            txtHesapNo.Text = "";
            txtİrsaliyeNo.Text = "";
            txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
            txtKDV.Text = "0.00";
            txtOdemeYeri.SelectedIndex = 0;
            AnaForm.aktarma = -1;
            for (int i = gridView1.RowCount; i > -1; i--)
            {
                gridView1.DeleteRow(0);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal Miktar = 0, BirimFiyat = 0, Toplam = 0;
                if (e.Column.Name != "colTOPLAM")
                {
                    Miktar = decimal.Parse(gridView1.GetFocusedRowCellValue("MIKTAR").ToString());
                    if (gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString() != "") BirimFiyat = decimal.Parse
                         (gridView1.GetFocusedRowCellValue("BIRIMFIYAT").ToString());
                    Toplam = Miktar * BirimFiyat;
                    gridView1.SetFocusedRowCellValue("TOPLAM", Toplam);
                    hesapla();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnStokSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int StokID = Formlar.StokListesi(true);
            if (StokID > 0)
            {
                StokGetir(StokID);
            }
            AnaForm.aktarma = -1;
        }

      

        private void txtOdemeYeri_EnabledChanged(object sender, EventArgs e)
        {
            if (txtOdemeYeri.Enabled)
            {
                OdemeYeri = txtOdemeYeri.Text;
            }
            else if (!txtOdemeYeri.Enabled)
            {
                OdemeYeri = "";
            }
        }

        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_FATURALAR fatura = new Fonksiyonlar.TBL_FATURALAR();
                fatura.ACIKLAMA = txtAciklama.Text;
                fatura.CARIKODU = txtCariKodu.Text;
                fatura.FATURANO = txtFaturaNo.Text;
                fatura.FATURATURU = "Alış Faturası";
                fatura.GENELTOPLAM = decimal.Parse(txtGenelToplam.Text);
                fatura.IRSALIYEID = IrsaliyeID;
                fatura.ODEMEYERI = OdemeYeri;
                fatura.ODEMEYERIID = OdemeID;
                fatura.TARIHI = DateTime.Parse(txtFaturaTarihi.Text);
                fatura.SAVEUSER = AnaForm.UserID;
                fatura.SAVEDATE = DateTime.Now;
                db.TBL_FATURALAR.InsertOnSubmit(fatura);
                db.SubmitChanges();
                FaturaID = fatura.ID;
                if (IrsaliyeID < 0)
                {
                    Fonksiyonlar.TBL_IRSALIYELER irsaliye = new Fonksiyonlar.TBL_IRSALIYELER();
                    irsaliye.ACIKLAMA = txtAciklama.Text;
                    irsaliye.CARIKODU = txtCariKodu.Text;
                    irsaliye.FATURAID = fatura.ID;
                    irsaliye.IRSALIYESERI = "Alış İrsaliyesi";
                    irsaliye.IRSALIYENO = txtİrsaliyeNo.Text;
                    irsaliye.TARIHI = DateTime.Parse(txtIrsaliyeTarih.Text);
                    irsaliye.SAVEUSER = AnaForm.UserID;
                    irsaliye.SAVEDATE = DateTime.Now;
                    db.TBL_IRSALIYELERs.InsertOnSubmit(irsaliye);
                    db.SubmitChanges();
                    IrsaliyeID = irsaliye.ID;
                    fatura.IRSALIYEID = IrsaliyeID;
                }
                Fonksiyonlar.TBL_STOKHAREKETLERI[] stokhareket = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    stokhareket[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    stokhareket[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    stokhareket[i].FATURAID = fatura.ID;
                    stokhareket[i].GCKODU = "G";
                    stokhareket[i].IRSALIYEID = IrsaliyeID;
                    stokhareket[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    stokhareket[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    stokhareket[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    stokhareket[i].TIPI = "Alış Faturası";
                    stokhareket[i].SAVEDATE = DateTime.Now;
                    stokhareket[i].SAVEUSER = AnaForm.UserID;
                    db.TBL_STOKHAREKETLERIs.InsertOnSubmit(stokhareket[i]);
                }
                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI carihareket = new Fonksiyonlar.TBL_CARIHAREKETLERI();
                carihareket.ACIKLAMA = txtFaturaNo.Text + "No ' lu Alış Faturası";
                if (txtFaturaTuru.SelectedIndex == 0)
                {
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                    carihareket.BORC = 0;
                }
                else if (txtFaturaTuru.SelectedIndex == 1)
                {
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                }
                carihareket.CARIID = CariID;
                carihareket.TARIH = DateTime.Now;
                carihareket.TIPI = "AF";
                carihareket.EVRAKTURU = "Alış Faturası";
                carihareket.EVRAKID = fatura.ID;
                carihareket.SAVEDATE = DateTime.Now;
                carihareket.SAVEUSER = AnaForm.UserID;
                db.TBL_CARIHAREKETLERIs.InsertOnSubmit(carihareket);
                db.SubmitChanges();
                Mesajlar.yenikayit("Yeni Fatura Başarıyla Kayıt Edildi");
                if (checkBox1.Checked)
                {
                    Fonksiyonlar.TBL_KASAHAREKETLERI kasahareket = new Fonksiyonlar.TBL_KASAHAREKETLERI();
                    kasahareket.KASAID = KasaID;
                    kasahareket.BELGENO = txtFaturaNo.Text;
                    kasahareket.TARIH = DateTime.Parse(txtFaturaTarihi.Text); ;
                    kasahareket.EVRAKTURU = "Alış Faturası";
                    kasahareket.EVRAKID = fatura.ID;
                    kasahareket.GCKODU = "G";
                    kasahareket.TUTAR = decimal.Parse(txtGenelToplam.Text);
                    kasahareket.CARIID = carihareket.CARIID;
                    kasahareket.ACIKLAMA = txtFaturaNo.Text + "No ' lu Fatura";
                    kasahareket.SAVEDATE = DateTime.Now;
                    kasahareket.SAVEUSER = AnaForm.UserID;
                    db.TBL_KASAHAREKETLERIs.InsertOnSubmit(kasahareket);
                    db.SubmitChanges();

                }
                if (checkBox2.Checked)
                {
                    Fonksiyonlar.TBL_BANKAHAREKETLERI bankahareket = new Fonksiyonlar.TBL_BANKAHAREKETLERI();
                    bankahareket.BANKAID = BankaID;
                    bankahareket.CARIID = carihareket.CARIID;
                    bankahareket.BELGENO = txtFaturaNo.Text;
                    bankahareket.TARIH = DateTime.Parse(txtFaturaTarihi.Text);
                    bankahareket.EVRAKTURU = "Satış Faturası";
                    bankahareket.EVRAKID = fatura.ID;
                    bankahareket.GCKODU = "C";
                    bankahareket.TUTAR = decimal.Parse(txtGenelToplam.Text);
                    bankahareket.ACIKLAMA = txtFaturaNo.Text + "No ' lu Fatura";
                    bankahareket.SAVEDATE = DateTime.Now;
                    bankahareket.SAVEUSER = AnaForm.UserID;
                    db.TBL_BANKAHAREKETLERIs.InsertOnSubmit(bankahareket);
                    db.SubmitChanges();
                }
                temizle();
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
            frmAlisFaturasi_Load(null, null); 
        }

        void guncelle()

        {
            try
            {
                Fonksiyonlar.TBL_FATURALAR fatura = db.TBL_FATURALAR.First(s => s.ID == FaturaID);
                fatura.FATURANO = txtFaturaNo.Text;
                fatura.ACIKLAMA = txtAciklama.Text;
                fatura.CARIKODU = txtCariKodu.Text;
                fatura.GENELTOPLAM = decimal.Parse(txtGenelToplam.Text);
                fatura.ODEMEYERI = OdemeYeri;
                fatura.ODEMEYERIID = OdemeID;
                fatura.EDITDATE = DateTime.Now;
                fatura.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Fonksiyonlar.TBL_IRSALIYELER irsaliye = db.TBL_IRSALIYELERs.First(s => s.ID == IrsaliyeID);
                irsaliye.IRSALIYENO = txtİrsaliyeNo.Text;
                irsaliye.TARIHI = DateTime.Parse(txtIrsaliyeTarih.Text);
                irsaliye.EDITDATE = DateTime.Now;
                irsaliye.EDITUSER = AnaForm.UserID;
                db.TBL_STOKHAREKETLERIs.DeleteAllOnSubmit(db.TBL_STOKHAREKETLERIs.Where(s => s.FATURAID == FaturaID));
                db.SubmitChanges();
                Fonksiyonlar.TBL_STOKHAREKETLERI[] StokHareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    StokHareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    StokHareketi[i].FATURAID = FaturaID;
                    StokHareketi[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    StokHareketi[i].GCKODU = "G";
                    StokHareketi[i].IRSALIYEID = IrsaliyeID;
                    StokHareketi[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    StokHareketi[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    StokHareketi[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    StokHareketi[i].TIPI = "Alış Faturası";
                    StokHareketi[i].SAVEDATE = DateTime.Now;
                    StokHareketi[i].SAVEUSER = AnaForm.UserID;
                    db.TBL_STOKHAREKETLERIs.InsertOnSubmit(StokHareketi[i]);

                }

                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI carihareket = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == "Alış Faturası" && s.EVRAKID == FaturaID);
                if (txtFaturaTuru.SelectedIndex == 0)
                {
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                    carihareket.BORC = 0;
                }
                else if (txtFaturaTuru.SelectedIndex == 1)
                {
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                    carihareket.ALACAK = decimal.Parse(txtGenelToplam.Text);
                }
                carihareket.EDITDATE = DateTime.Now;
                carihareket.EDITUSER = AnaForm.UserID;
                db.SubmitChanges();
                Mesajlar.Guncelle(true);
                temizle();
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
        }

  

        public DataTable LINQToDataTable<T>(IEnumerable<T> Lnqlst)
        {
            DataTable dt = new DataTable();


            PropertyInfo[] columns = null;

            if (Lnqlst == null) return dt;

            foreach (T Record in Lnqlst)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }



     

     

        void sil()
        {
            try
            {
                db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKID == FaturaID));
                db.TBL_IRSALIYELERs.DeleteOnSubmit(db.TBL_IRSALIYELERs.First(s => s.ID == IrsaliyeID));
                db.TBL_FATURALAR.DeleteOnSubmit(db.TBL_FATURALAR.First(s => s.ID == FaturaID));
                db.TBL_STOKHAREKETLERIs.DeleteAllOnSubmit(db.TBL_STOKHAREKETLERIs.Where(s => s.FATURAID == FaturaID));
                db.SubmitChanges();
                temizle();
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (FaturaID > 0)
            {
                var srg = db.VW_FATURALARs.Where(s => s.FATURANO == txtFaturaNo.Text);

            DataSet ds = new DataSet();
            ds.Tables.Add(LINQToDataTable(srg));

            rprSatisFaturasi rpr = new rprSatisFaturasi();
            rpr.DataSource = ds;
            rpr.ShowPreview();
        }
          if (FaturaID< 0)
                Mesajlar.deneme("Öncelikle Kaydetmelisiniz ");

        }

    private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (edit && FaturaID > 0 && Mesajlar.Sil() == DialogResult.Yes) sil();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (edit && FaturaID > 0) guncelle();
            else yenikaydet();
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void satirsil_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (MessageBox.Show("Satır Silinecek . Eminmisiniz ? ", "Satır Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                gridView1.DeleteSelectedRows();

            }
        }

        private void frmAlisFaturasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                txtHesapAdi.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPADI;
                txtHesapNo.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPNO;
            }
            catch (Exception)
            {
                BankaID = -1;
            }
        }


        void KasaAc(int ID)
        {
            try
            {
                KasaID = ID;
                txtKasaAdi.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAADI;
                txtKasaKodu.Text = db.TBL_KASALARs.First(s => s.ID == KasaID).KASAKODU;
            }
            catch (Exception)
            {
                KasaID = -1;
            }
        }

        private void txtHesapAdi_Click(object sender, EventArgs e)
        {
            int Id = Formlar.BankaListesi(true);
            if (Id > 0) BankaAc(Id);
            AnaForm.aktarma = -1;
        }

        private void txtKasaKodu_Click(object sender, EventArgs e)
        {
            int Id = Formlar.KasaListesi(true);
            if (Id > 0)
            {
                KasaAc(Id);
                AnaForm.aktarma = -1;
            }
        }
    }
}