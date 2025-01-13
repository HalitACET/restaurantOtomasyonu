namespace restaurantOtomasyonu
{
    partial class frmMasaRezervasyon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasaRezervasyon));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtRezerveID = new DevExpress.XtraEditors.TextEdit();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnRezerveEt = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioDolu = new System.Windows.Forms.RadioButton();
            this.radioBos = new System.Windows.Forms.RadioButton();
            this.txtMasaID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMasaAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtRezerveAdSoyad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRezerveZaman = new DevExpress.XtraEditors.DateEdit();
            this.btnRezerveGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnRezerveSil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveAdSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveZaman.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveZaman.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(342, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(660, 426);
            this.gridControl1.TabIndex = 34;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(117, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 16);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "ID:";
            // 
            // txtRezerveID
            // 
            this.txtRezerveID.Location = new System.Drawing.Point(142, 42);
            this.txtRezerveID.Name = "txtRezerveID";
            this.txtRezerveID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRezerveID.Properties.Appearance.Options.UseFont = true;
            this.txtRezerveID.Size = new System.Drawing.Size(177, 22);
            this.txtRezerveID.TabIndex = 44;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTemizle.ImageOptions.Image")));
            this.btnTemizle.Location = new System.Drawing.Point(142, 331);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(167, 35);
            this.btnTemizle.TabIndex = 43;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnRezerveEt
            // 
            this.btnRezerveEt.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezerveEt.Appearance.Options.UseFont = true;
            this.btnRezerveEt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRezerveEt.ImageOptions.Image")));
            this.btnRezerveEt.Location = new System.Drawing.Point(142, 208);
            this.btnRezerveEt.Name = "btnRezerveEt";
            this.btnRezerveEt.Size = new System.Drawing.Size(167, 35);
            this.btnRezerveEt.TabIndex = 41;
            this.btnRezerveEt.Text = "Rezerve Et";
            this.btnRezerveEt.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(123, 184);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 16);
            this.labelControl2.TabIndex = 39;
            this.labelControl2.Text = "Durum:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(79, 73);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 16);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "Masa ID:";
            // 
            // radioDolu
            // 
            this.radioDolu.AutoSize = true;
            this.radioDolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioDolu.Location = new System.Drawing.Point(235, 182);
            this.radioDolu.Name = "radioDolu";
            this.radioDolu.Size = new System.Drawing.Size(84, 20);
            this.radioDolu.TabIndex = 37;
            this.radioDolu.Text = "Rezerve";
            this.radioDolu.UseVisualStyleBackColor = true;
            // 
            // radioBos
            // 
            this.radioBos.AutoSize = true;
            this.radioBos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioBos.Location = new System.Drawing.Point(176, 182);
            this.radioBos.Name = "radioBos";
            this.radioBos.Size = new System.Drawing.Size(53, 20);
            this.radioBos.TabIndex = 36;
            this.radioBos.Text = "Boş";
            this.radioBos.UseVisualStyleBackColor = true;
            // 
            // txtMasaID
            // 
            this.txtMasaID.Location = new System.Drawing.Point(142, 70);
            this.txtMasaID.Name = "txtMasaID";
            this.txtMasaID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMasaID.Properties.Appearance.Options.UseFont = true;
            this.txtMasaID.Size = new System.Drawing.Size(177, 22);
            this.txtMasaID.TabIndex = 35;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(72, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 16);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Masa Adı:";
            // 
            // txtMasaAdi
            // 
            this.txtMasaAdi.Location = new System.Drawing.Point(142, 98);
            this.txtMasaAdi.Name = "txtMasaAdi";
            this.txtMasaAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMasaAdi.Properties.Appearance.Options.UseFont = true;
            this.txtMasaAdi.Size = new System.Drawing.Size(177, 22);
            this.txtMasaAdi.TabIndex = 48;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(11, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(125, 16);
            this.labelControl5.TabIndex = 47;
            this.labelControl5.Text = "Rezerve Ad Soyad:";
            // 
            // txtRezerveAdSoyad
            // 
            this.txtRezerveAdSoyad.Location = new System.Drawing.Point(142, 126);
            this.txtRezerveAdSoyad.Name = "txtRezerveAdSoyad";
            this.txtRezerveAdSoyad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRezerveAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtRezerveAdSoyad.Size = new System.Drawing.Size(177, 22);
            this.txtRezerveAdSoyad.TabIndex = 46;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(28, 157);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(108, 16);
            this.labelControl6.TabIndex = 51;
            this.labelControl6.Text = "Rezerve Zamanı:";
            // 
            // txtRezerveZaman
            // 
            this.txtRezerveZaman.EditValue = "";
            this.txtRezerveZaman.Location = new System.Drawing.Point(142, 154);
            this.txtRezerveZaman.Name = "txtRezerveZaman";
            this.txtRezerveZaman.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRezerveZaman.Properties.Appearance.Options.UseFont = true;
            this.txtRezerveZaman.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRezerveZaman.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRezerveZaman.Properties.DisplayFormat.FormatString = "";
            this.txtRezerveZaman.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRezerveZaman.Properties.EditFormat.FormatString = "";
            this.txtRezerveZaman.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRezerveZaman.Properties.Mask.EditMask = "";
            this.txtRezerveZaman.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtRezerveZaman.Size = new System.Drawing.Size(177, 22);
            this.txtRezerveZaman.TabIndex = 50;
            // 
            // btnRezerveGuncelle
            // 
            this.btnRezerveGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezerveGuncelle.Appearance.Options.UseFont = true;
            this.btnRezerveGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRezerveGuncelle.ImageOptions.Image")));
            this.btnRezerveGuncelle.Location = new System.Drawing.Point(142, 249);
            this.btnRezerveGuncelle.Name = "btnRezerveGuncelle";
            this.btnRezerveGuncelle.Size = new System.Drawing.Size(167, 35);
            this.btnRezerveGuncelle.TabIndex = 52;
            this.btnRezerveGuncelle.Text = "Rezerve Güncelle";
            this.btnRezerveGuncelle.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnRezerveSil
            // 
            this.btnRezerveSil.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezerveSil.Appearance.Options.UseFont = true;
            this.btnRezerveSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRezerveSil.ImageOptions.Image")));
            this.btnRezerveSil.Location = new System.Drawing.Point(142, 290);
            this.btnRezerveSil.Name = "btnRezerveSil";
            this.btnRezerveSil.Size = new System.Drawing.Size(167, 35);
            this.btnRezerveSil.TabIndex = 53;
            this.btnRezerveSil.Text = "RezerveSil";
            this.btnRezerveSil.Click += new System.EventHandler(this.btnRezerveSil_Click);
            // 
            // frmMasaRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 450);
            this.Controls.Add(this.btnRezerveSil);
            this.Controls.Add(this.btnRezerveGuncelle);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtMasaAdi);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtRezerveAdSoyad);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtRezerveID);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnRezerveEt);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioDolu);
            this.Controls.Add(this.radioBos);
            this.Controls.Add(this.txtMasaID);
            this.Controls.Add(this.txtRezerveZaman);
            this.Name = "frmMasaRezervasyon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMasaDurumu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMasaDurumu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveAdSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveZaman.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRezerveZaman.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtRezerveID;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnRezerveEt;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton radioDolu;
        private System.Windows.Forms.RadioButton radioBos;
        private DevExpress.XtraEditors.TextEdit txtMasaID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtMasaAdi;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtRezerveAdSoyad;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit txtRezerveZaman;
        private DevExpress.XtraEditors.SimpleButton btnRezerveGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnRezerveSil;
    }
}