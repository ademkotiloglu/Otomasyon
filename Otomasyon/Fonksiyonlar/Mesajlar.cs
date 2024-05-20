using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2.Fonksiyonlar
{
    class Mesajlar
    {
        AnaForm MesajForm = new AnaForm();
        public void yenikayit(string Mesaj)
        {
            MesajForm.Mesaj("Yeni Kayıt Girişi", Mesaj);
            

        }
        public void deneme(string Mesaj)
        {
            MesajForm.Mesaj("Uyarı", Mesaj);


        }

        public DialogResult Guncelle()
        {
            
            return MessageBox.Show("Seçili Kayıt Kalıcı Olarak Güncellenecektir\n Güncelleme İşlemini Onaylıyormusunuz )", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Sil()
        { 
        return MessageBox.Show("Seçili Olan Kayıt Kalıcı Olarak Silinecektir.\n Silme İşlemini Onaylıyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        public DialogResult HataStok()
        {
            return MessageBox.Show("Stok hareketi olan stok silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult HataCari()
        {
            return MessageBox.Show("Cari hareketi olan Cari silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult hatacek()
        {
            return MessageBox.Show("Bu Kayıt Çek Listesi Üzerinden Düzenlenmelidir !", "Düzenleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Guncelle(bool Guncelleme)
        {
            MesajForm.Mesaj("Kayıt Güncelleme", "Kayıt Güncellenmiştir.");
            
    }

        public void Hata(Exception Hata)
        {
            MesajForm.Mesaj("Hata Oluştu", Hata.Message);
           
        }
        public DialogResult HataGrupStok()
        {
            return MessageBox.Show("Stok kayıdı olan grup silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult sicaksatis()
        {
            return MessageBox.Show("Hızlı Satış İşlemi . Lütfen İade Giriniz !", "Düzenleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult HataCariGrup()
        {
            return MessageBox.Show("Cari kayıdı olan grup silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult HataBanka()
        {
            return MessageBox.Show("İşlem Yapılan Banka Kayıtı silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult HataKasa()
        {
            return MessageBox.Show("İşlem Yapılan Kasa Kayıtı silinemez!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult hatacekduzen()
        {
            return MessageBox.Show("Durumu Caride Olan Çek Önce Cari Hareket Kartından Düzenlenmeli!", "Düzenleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult hatacekduzen1()
        {
            return MessageBox.Show("Durumu Bankada Olan Çek Önce Banka Hareket Kartından Düzenlenmeli!", "Düzenleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult hatamukerrerkayit()
        {
            return MessageBox.Show("Bu Çek Zaten Tediye Edilmiş.", "Düzenleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult Uyari()
        {
            return MessageBox.Show("Yedekleme Tamamlandı ..", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult Uyari1()
        {
            return MessageBox.Show("Geri Yükleme Tamamlandı ..", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
