using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplication2.Modul_Cek;

namespace DXApplication2.Modul_Banka
{
    public partial class frmBankaHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext db = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        int islemID = -1;
        int BankaID = -1;
        int HareketID = -1;
        int EvrakID = -1;
        string EvrakTURU;
        public frmBankaHareketleri()
        {
            InitializeComponent();
        }

        public void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                txtHesapTuru.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).BANKAADI;
                txtHesapNo.Text = db.TBL_BANKALARs.First(s => s.ID == BankaID).HESAPNO;
                DurumGetir();
                listele();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void DurumGetir()
        {
            Fonksiyonlar.VW_BANKADURUM Banka = db.VW_BANKADURUMs.First(s => s.ID == BankaID);
            txtGiris.Text = Banka.GIRIS.Value.ToString();
            txtCikis.Text = Banka.CIKIS.Value.ToString();
            txtBakiye.Text = Banka.BAKIYE.Value.ToString();
         
        }

        void listele()
        {
            var lst = from s in db.VW_BANKAHAREKETLERI
                      where s.BANKAID == BankaID
                      select s;
            Liste.DataSource = lst;
          
        }

     

       
            void sec()
            {
                try
                {
                    islemID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    EvrakTURU = gridView1.GetFocusedRowCellValue("EVRAKTURU").ToString();
                }
                catch (Exception)
                {
                    islemID = -1;
                    EvrakTURU = "";
                }
            
        }
        private void frmBankaHareketleri_Load(object sender, EventArgs e)
        {

        }

        private void SagTik_Opening(object sender, CancelEventArgs e)
        {

            sec();
            if (EvrakTURU == "Banka İslem")
            {
                BankaIslemi.Enabled = true;
                TransferIslem.Enabled = false;
                banka.Enabled = false;

            }
            if (EvrakTURU == "Banka Havale" || EvrakTURU == "Banka EFT")
            {
                BankaIslemi.Enabled = false;
                TransferIslem.Enabled = true;
                banka.Enabled = false;
            }
            if (EvrakTURU == "Bankaya Çek")
            {
                BankaIslemi.Enabled = false;
                TransferIslem.Enabled = false;
                banka.Enabled = true;

            }
            if (EvrakTURU == "Kendi Çekimiz")
            {
                BankaIslemi.Enabled = false;
                TransferIslem.Enabled = false;
                banka.Enabled = false;

            }


        }

      

        private void TransferIslem_Click(object sender, EventArgs e)
        {
            Formlar.BankaParaTransferi(true, islemID);
            listele();
        }

        private void txtHesapTuru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.BankaListesi(true);
            if (ID > 0)
            {
                BankaAc(ID);
                AnaForm.aktarma = -1;
            }
        }

        private void frmBankaHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DurumGetir();
        }

        private void banka_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(gridView1.GetFocusedRowCellValue("EVRAKID").ToString());

            Formlar.BankaCek1(true, ID);
            listele();
        }

        private void BankaIslemi_Click(object sender, EventArgs e)
        {
            
            Formlar.Bankaİslem(true, islemID);
            listele();
        }
    }
}