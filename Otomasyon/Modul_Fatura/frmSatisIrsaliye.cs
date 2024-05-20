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
    public partial class frmSatisIrsaliye : DevExpress.XtraEditors.XtraForm
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
        string ID1 = "SF";
        double VAL1 = 0;
        string ID2 = "SI";

        

        public frmSatisIrsaliye(bool Ac, int ID, bool Irsaliye)
        {
            InitializeComponent();
            edit = Ac;
            IrsaliyeID = ID;
           
            IrsaliyeAc = Irsaliye;
            this.Shown += frmSatisIrsaliye_Shown;
        }

        void frmSatisIrsaliye_Shown(object sender, EventArgs e)
        {
            if (edit) FaturaGetir();
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

        void FaturaGetir()
        {
            try
            {
                Fonksiyonlar.TBL_IRSALIYELER Fatura = db.TBL_IRSALIYELERs.First(s => s.ID == IrsaliyeID);
                
                txtİrsaliyeNo.Text = db.TBL_IRSALIYELERs.First(s => s.ID == Fatura.ID).IRSALIYENO;
                txtIrsaliyeTarih.EditValue = db.TBL_IRSALIYELERs.First(s => s.ID == Fatura.ID).TARIHI.Value.ToShortDateString();
                txtCariAdi.Text = db.TBL_CARILERs.First(s => s.CARIKODU == Fatura.CARIKODU).CARIADI;
                txtCariKodu.Text = Fatura.CARIKODU;
                
                var srg = from s in db.VW_KALEMLERs
                          where s.IRSALIYEID == IrsaliyeID
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

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

       

      
        void yenikaydet()
        {
            try
            {
                Fonksiyonlar.TBL_FATURALAR fatura = new Fonksiyonlar.TBL_FATURALAR();
                
                
                if (IrsaliyeID < 0)
                {
                    Fonksiyonlar.TBL_IRSALIYELER irsaliye = new Fonksiyonlar.TBL_IRSALIYELER();
                    IrsaliyeID = irsaliye.ID;
                    irsaliye.ACIKLAMA = txtAciklama.Text;
                    irsaliye.CARIKODU = txtCariKodu.Text;
                    irsaliye.IRSALIYEID = IrsaliyeID;
                    irsaliye.IRSALIYENO = txtİrsaliyeNo.Text;
                    irsaliye.IRSALIYESERI = "Satış İrsaliyesi";
                    irsaliye.TARIHI = DateTime.Parse(txtIrsaliyeTarih.Text);
                    irsaliye.SAVEUSER = AnaForm.UserID;
                    irsaliye.SAVEDATE = DateTime.Now;
                    db.TBL_IRSALIYELERs.InsertOnSubmit(irsaliye);
                    db.SubmitChanges();
                    IrsaliyeID = irsaliye.ID;
                  
                }
                Fonksiyonlar.TBL_STOKHAREKETLERI[] stokhareket = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    stokhareket[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                    stokhareket[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    stokhareket[i].FATURAID = fatura.ID;
                    stokhareket[i].GCKODU = "C";
                    stokhareket[i].IRSALIYEID = IrsaliyeID;
                    stokhareket[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    stokhareket[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    stokhareket[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    stokhareket[i].TIPI = "Satış İrsaliyesi";
                    stokhareket[i].SAVEDATE = DateTime.Now;
                    stokhareket[i].SAVEUSER = AnaForm.UserID;
                    db.TBL_STOKHAREKETLERIs.InsertOnSubmit(stokhareket[i]);
                }
                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI carihareket = new Fonksiyonlar.TBL_CARIHAREKETLERI();

              
                    carihareket.ALACAK = 0;
                    carihareket.BORC = decimal.Parse(txtGenelToplam.Text);
                
                
                carihareket.CARIID = CariID;
                carihareket.TARIH = DateTime.Now;
                carihareket.TIPI = "SI";
                carihareket.EVRAKTURU = "Satış İrsaliyesi";
                carihareket.EVRAKID = IrsaliyeID;
                carihareket.SAVEDATE = DateTime.Now;
                carihareket.SAVEUSER = AnaForm.UserID;
                db.TBL_CARIHAREKETLERIs.InsertOnSubmit(carihareket);
                db.SubmitChanges();
                Mesajlar.yenikayit("Yeni İrsaliye Başarıyla Kayıt Edildi");
                temizle();
            }
            catch (Exception ex)
            {
                Mesajlar.Hata(ex);
            }
            frmSatisIrsaliye_Load(null, null); 
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
           
            txtGenelToplam.Text = "0.00";
            
            txtİrsaliyeNo.Text = "";
            txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();
          
            txtKDV.Text = "0.00";
           
            AnaForm.aktarma = -1;
            for (int i = gridView1.RowCount; i > -1; i--)
            {
                gridView1.DeleteRow(0);
            }
        }

       

      

        void guncelle()
        {
            try
            {
              
                Fonksiyonlar.TBL_IRSALIYELER irsaliye = db.TBL_IRSALIYELERs.First(s => s.ID == IrsaliyeID);
                irsaliye.IRSALIYENO = txtİrsaliyeNo.Text;
                irsaliye.TARIHI = DateTime.Parse(txtIrsaliyeTarih.Text);
                irsaliye.EDITDATE = DateTime.Now;
                irsaliye.EDITUSER = AnaForm.UserID;
                db.TBL_STOKHAREKETLERIs.DeleteAllOnSubmit(db.TBL_STOKHAREKETLERIs.Where(s => s.IRSALIYEID == IrsaliyeID));
                db.SubmitChanges();
                Fonksiyonlar.TBL_STOKHAREKETLERI[] StokHareketi = new Fonksiyonlar.TBL_STOKHAREKETLERI[gridView1.RowCount];
                for (int i =0; i < gridView1.RowCount; i++)
                {
                    StokHareketi[i] = new Fonksiyonlar.TBL_STOKHAREKETLERI();
                
                    StokHareketi[i].BIRIMFIYAT = decimal.Parse(gridView1.GetRowCellValue(i, "BIRIMFIYAT").ToString());
                    StokHareketi[i].GCKODU = "C";
                    StokHareketi[i].IRSALIYEID = IrsaliyeID;
                    StokHareketi[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    StokHareketi[i].MIKTAR = int.Parse(gridView1.GetRowCellValue(i, "MIKTAR").ToString());
                    StokHareketi[i].STOKKODU = gridView1.GetRowCellValue(i, "STOKKODU").ToString();
                    StokHareketi[i].TIPI = "Satış İrsaliyesi";
                    StokHareketi[i].SAVEDATE = DateTime.Now;
                    StokHareketi[i].SAVEUSER = AnaForm.UserID;
                    db.TBL_STOKHAREKETLERIs.InsertOnSubmit(StokHareketi[i]);

                }

                db.SubmitChanges();
                Fonksiyonlar.TBL_CARIHAREKETLERI carihareket = db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKTURU == "Satış İrsaliyesi" && s.EVRAKID == IrsaliyeID);
                carihareket.BORC = decimal.Parse(txtGenelToplam.Text);
                carihareket.ALACAK = 0;
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
                db.TBL_CARIHAREKETLERIs.DeleteOnSubmit(db.TBL_CARIHAREKETLERIs.First(s => s.EVRAKID == IrsaliyeID));
                db.TBL_IRSALIYELERs.DeleteOnSubmit(db.TBL_IRSALIYELERs.First(s => s.ID == IrsaliyeID));
                
                db.TBL_STOKHAREKETLERIs.DeleteAllOnSubmit(db.TBL_STOKHAREKETLERIs.Where(s => s.IRSALIYEID == IrsaliyeID));

                db.SubmitChanges();
                temizle();
            }
            catch (Exception e)
            {

                Mesajlar.Hata(e);
            }
        }

          
          

             private void btnkapat_Click(object sender, EventArgs e)
             {
                 this.Close();
             }

             private void btnsil_Click(object sender, EventArgs e)
             {
                 if (edit && IrsaliyeID > 0 && Mesajlar.Sil() == DialogResult.Yes) sil();
             }

             private void btnkaydet_Click(object sender, EventArgs e)
             {
                 if (edit && IrsaliyeID > 0) guncelle();
                 else yenikaydet();
                
                 
             }

             private void frmSatisIrsaliye_Load(object sender, EventArgs e)
             {

                 if (IrsaliyeID<0)
                 txtİrsaliyeNo.Text = Numaralar.IrsaliyeNo('I');
                  
                 txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();
                
                 
             }

             private void groupControl1_Paint(object sender, PaintEventArgs e)
             {

             }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (IrsaliyeID > 0)
            {
                var srg = db.VW_IRSALIYELERs.Where(s => s.IRSALIYENO == txtİrsaliyeNo.Text);

                DataSet ds = new DataSet();
                ds.Tables.Add(LINQToDataTable(srg));

                rprSatisFaturasi rpr = new rprSatisFaturasi();
                rpr.DataSource = ds;
                rpr.ShowPreview();
            }
            if (FaturaID < 0)
                Mesajlar.deneme("Öncelikle Kaydetmelisiniz ");
        }

            private void satirsil_Closed(object sender, ToolStripDropDownClosedEventArgs e)
             {
                 if (MessageBox.Show("Satır Silinecek . Eminmisiniz ? ", "Satır Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {

                     gridView1.DeleteSelectedRows();

                 }
             }

             private void frmSatisIrsaliye_KeyDown(object sender, KeyEventArgs e)
             {
                 if (e.KeyCode == Keys.Escape)
                 {
                     this.Close();
                 }
             }

          

             

           
          

        

       
      
    
    }
}
    
