using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace DXApplication2.Fonksiyonlar
{
    class Resimleme
    {
        public byte[] ResimYukleme(System.Drawing.Image Resim)
        {
            using (MemoryStream ms = new MemoryStream())
            { 
            Resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ResimGetirme(byte[] GelenBytearray)
        {
            using (MemoryStream ms = new MemoryStream(GelenBytearray))
            {
                Image resim = Image.FromStream(ms);
                return resim;
            }
        }
        
     
        }
}
