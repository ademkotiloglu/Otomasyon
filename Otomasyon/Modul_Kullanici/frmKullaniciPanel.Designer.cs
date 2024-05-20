namespace DXApplication2.Modul_Kullanici
{
    partial class frmKullaniciPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIsim = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoyisim = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.rdbtnAktif = new System.Windows.Forms.RadioButton();
            this.rdbtnPasif = new System.Windows.Forms.RadioButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuru = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuru.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(78, 6);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(108, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Şifre :";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(78, 32);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(108, 20);
            this.txtSifre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Şifre (Tekrar) :";
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.Location = new System.Drawing.Point(78, 58);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.Size = new System.Drawing.Size(108, 20);
            this.txtSifreTekrar.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "İsim :";
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(78, 84);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(108, 20);
            this.txtIsim.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Soyisim :";
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(78, 110);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Size = new System.Drawing.Size(108, 20);
            this.txtSoyisim.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Kullanıcı Türü :";
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = global::DXApplication2.Properties.Resources.Kaydet24x24;
            this.btnKaydet.Location = new System.Drawing.Point(192, 9);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(80, 31);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.ImageOptions.Image = global::DXApplication2.Properties.Resources.Sil32x32;
            this.btnTemizle.Location = new System.Drawing.Point(192, 43);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 31);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // rdbtnAktif
            // 
            this.rdbtnAktif.AutoSize = true;
            this.rdbtnAktif.Location = new System.Drawing.Point(193, 116);
            this.rdbtnAktif.Name = "rdbtnAktif";
            this.rdbtnAktif.Size = new System.Drawing.Size(47, 17);
            this.rdbtnAktif.TabIndex = 3;
            this.rdbtnAktif.TabStop = true;
            this.rdbtnAktif.Text = "Aktif";
            this.rdbtnAktif.UseVisualStyleBackColor = true;
            // 
            // rdbtnPasif
            // 
            this.rdbtnPasif.AutoSize = true;
            this.rdbtnPasif.Location = new System.Drawing.Point(193, 137);
            this.rdbtnPasif.Name = "rdbtnPasif";
            this.rdbtnPasif.Size = new System.Drawing.Size(48, 17);
            this.rdbtnPasif.TabIndex = 3;
            this.rdbtnPasif.TabStop = true;
            this.rdbtnPasif.Text = "Pasif";
            this.rdbtnPasif.UseVisualStyleBackColor = true;
            // 
            // btnKapat
            // 
            this.btnKapat.ImageOptions.Image = global::DXApplication2.Properties.Resources.Kapat24x24;
            this.btnKapat.Location = new System.Drawing.Point(192, 78);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(80, 31);
            this.btnKapat.TabIndex = 8;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // txtTuru
            // 
            this.txtTuru.Location = new System.Drawing.Point(78, 136);
            this.txtTuru.Name = "txtTuru";
            this.txtTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuru.Properties.Items.AddRange(new object[] {
            "Yönetici",
            "Misafir"});
            this.txtTuru.Size = new System.Drawing.Size(108, 20);
            this.txtTuru.TabIndex = 5;
            // 
            // frmKullaniciPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 166);
            this.Controls.Add(this.rdbtnPasif);
            this.Controls.Add(this.rdbtnAktif);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoyisim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIsim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSifreTekrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuru);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKullaniciPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Düzenle";
            this.Load += new System.EventHandler(this.frmKullaniciPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKullaniciPanel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyisim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuru.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtSifreTekrar;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtIsim;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtSoyisim;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.RadioButton rdbtnAktif;
        private System.Windows.Forms.RadioButton rdbtnPasif;
        private DevExpress.XtraEditors.ComboBoxEdit txtTuru;
    }
}