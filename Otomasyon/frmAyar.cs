using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication2
{
    public partial class frmAyar : DevExpress.XtraEditors.XtraForm
    {
        public frmAyar()
        {
            InitializeComponent();
        }

        private void chckyenigiris_CheckedChanged(object sender, EventArgs e)
        {
            txtdatabase.Enabled = !txtdatabase.Enabled;
            txtpassword.Enabled = !txtpassword.Enabled;
            txtsunucu.Enabled = !txtsunucu.Enabled;
            txtuserid.Enabled = !txtuserid.Enabled;
            btnkaydet.Enabled = !btnkaydet.Enabled;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cs_Sunucu = txtsunucu.Text.Trim() + ";";
            Properties.Settings.Default.cs_Database = txtdatabase.Text.Trim() + ";";
            Properties.Settings.Default.cs_UserID = txtuserid.Text.Trim() + ";";
            Properties.Settings.Default.cs_Password = txtpassword.Text.Trim() + ";";
            Properties.Settings.Default.Database = txtdatabase.Text.Trim();
            Properties.Settings.Default.Save();


        }

        private void frmAyar_Load(object sender, EventArgs e)
        {
            labelControl2.Text = Properties.Settings.Default.cs1 + Properties.Settings.Default.cs_Sunucu + Properties.Settings.Default.cs2 +
                Properties.Settings.Default.cs_Database + Properties.Settings.Default.cs3 + Properties.Settings.Default.cs_UserID +
                Properties.Settings.Default.cs4 + Properties.Settings.Default.cs_Password;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}