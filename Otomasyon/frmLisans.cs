using DevExpress.XtraEditors;
using DXApplication2.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class frmLisans : DevExpress.XtraEditors.XtraForm
    {
        public frmLisans()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                Kontrol k = new Kontrol();
                k.Lisansla(textBox1.Text);
            }
        }
    }
}