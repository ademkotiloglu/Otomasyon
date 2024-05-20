namespace DXApplication2.Modul_Ayar
{
    partial class frmTeraziAyar
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
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TeraziOnEk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnkapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnsil = new DevExpress.XtraEditors.SimpleButton();
            this.btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtterazi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtdefaultkomisyon = new System.Windows.Forms.TextBox();
            this.txtkomisyon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(294, 268);
            this.tabPane1.SelectedPage = this.tabNavigationPage1;
            this.tabPane1.Size = new System.Drawing.Size(294, 268);
            this.tabPane1.TabIndex = 0;
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Terazi Ön Ek Ayarları";
            this.tabNavigationPage1.Controls.Add(this.groupControl3);
            this.tabNavigationPage1.Controls.Add(this.groupControl2);
            this.tabNavigationPage1.Controls.Add(this.groupControl1);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(294, 247);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.Liste);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 78);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(294, 111);
            this.groupControl3.TabIndex = 2;
            // 
            // Liste
            // 
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(2, 22);
            this.Liste.MainView = this.gridView1;
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(290, 87);
            this.Liste.TabIndex = 2;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Liste.Click += new System.EventHandler(this.gridView1_DoubleClick_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.TeraziOnEk});
            this.gridView1.GridControl = this.Liste;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick_1);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowFocus = false;
            this.ID.OptionsColumn.FixedWidth = true;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 20;
            // 
            // TeraziOnEk
            // 
            this.TeraziOnEk.Caption = "TERAZİ ÖN EKİ";
            this.TeraziOnEk.FieldName = "TeraziOnEk";
            this.TeraziOnEk.Name = "TeraziOnEk";
            this.TeraziOnEk.OptionsColumn.AllowEdit = false;
            this.TeraziOnEk.OptionsColumn.AllowFocus = false;
            this.TeraziOnEk.OptionsColumn.FixedWidth = true;
            this.TeraziOnEk.Visible = true;
            this.TeraziOnEk.VisibleIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnkapat);
            this.groupControl2.Controls.Add(this.btnsil);
            this.groupControl2.Controls.Add(this.btnkaydet);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 189);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(294, 58);
            this.groupControl2.TabIndex = 1;
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnkapat.ImageOptions.Image = global::DXApplication2.Properties.Resources.Kapat24x24;
            this.btnkapat.Location = new System.Drawing.Point(196, 22);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(93, 33);
            this.btnkapat.TabIndex = 8;
            this.btnkapat.Text = "Ana Form";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsil.ImageOptions.Image = global::DXApplication2.Properties.Resources.Sil24x24;
            this.btnsil.Location = new System.Drawing.Point(101, 22);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(93, 33);
            this.btnsil.TabIndex = 7;
            this.btnsil.Text = "Sil";
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnkaydet.ImageOptions.Image = global::DXApplication2.Properties.Resources.Kaydet24x24;
            this.btnkaydet.Location = new System.Drawing.Point(5, 22);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(93, 33);
            this.btnkaydet.TabIndex = 6;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtterazi);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(294, 78);
            this.groupControl1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 10);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bu Formda Güncelleme Yapılamaz . SadeceSilinebilir !";
            // 
            // txtterazi
            // 
            this.txtterazi.BackColor = System.Drawing.Color.Coral;
            this.txtterazi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtterazi.ForeColor = System.Drawing.SystemColors.Window;
            this.txtterazi.Location = new System.Drawing.Point(135, 32);
            this.txtterazi.Name = "txtterazi";
            this.txtterazi.Size = new System.Drawing.Size(147, 23);
            this.txtterazi.TabIndex = 1;
            this.txtterazi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Terazili Ürün İçin Ön Ek :";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Komisyon Ayarları";
            this.tabNavigationPage2.Controls.Add(this.label1);
            this.tabNavigationPage2.Controls.Add(this.simpleButton2);
            this.tabNavigationPage2.Controls.Add(this.simpleButton1);
            this.tabNavigationPage2.Controls.Add(this.txtdefaultkomisyon);
            this.tabNavigationPage2.Controls.Add(this.txtkomisyon);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(294, 247);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = "Komisyon \r\nOranı";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = global::DXApplication2.Properties.Resources.Kapat24x24;
            this.simpleButton2.Location = new System.Drawing.Point(146, 163);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(136, 72);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Ana Form\r\n";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::DXApplication2.Properties.Resources.Banka_Havale32x32;
            this.simpleButton1.Location = new System.Drawing.Point(12, 163);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(128, 72);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Komisyon \r\nOranı \r\nEkle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtdefaultkomisyon
            // 
            this.txtdefaultkomisyon.BackColor = System.Drawing.Color.Coral;
            this.txtdefaultkomisyon.Enabled = false;
            this.txtdefaultkomisyon.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtdefaultkomisyon.ForeColor = System.Drawing.SystemColors.Window;
            this.txtdefaultkomisyon.Location = new System.Drawing.Point(201, 12);
            this.txtdefaultkomisyon.Name = "txtdefaultkomisyon";
            this.txtdefaultkomisyon.Size = new System.Drawing.Size(81, 65);
            this.txtdefaultkomisyon.TabIndex = 0;
            this.txtdefaultkomisyon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtkomisyon
            // 
            this.txtkomisyon.BackColor = System.Drawing.Color.Coral;
            this.txtkomisyon.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkomisyon.ForeColor = System.Drawing.SystemColors.Window;
            this.txtkomisyon.Location = new System.Drawing.Point(12, 92);
            this.txtkomisyon.Name = "txtkomisyon";
            this.txtkomisyon.Size = new System.Drawing.Size(270, 65);
            this.txtkomisyon.TabIndex = 0;
            this.txtkomisyon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTeraziAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 268);
            this.Controls.Add(this.tabPane1);
            this.IconOptions.Image = global::DXApplication2.Properties.Resources.scales;
            this.Name = "frmTeraziAyar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terazi / Komisyon Ayarları";
            this.Load += new System.EventHandler(this.frmTeraziAyar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.tabNavigationPage2.ResumeLayout(false);
            this.tabNavigationPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private System.Windows.Forms.TextBox txtkomisyon;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtterazi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnkapat;
        private DevExpress.XtraEditors.SimpleButton btnsil;
        private DevExpress.XtraEditors.SimpleButton btnkaydet;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox txtdefaultkomisyon;
        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TeraziOnEk;
        private System.Windows.Forms.Label label3;
    }
}