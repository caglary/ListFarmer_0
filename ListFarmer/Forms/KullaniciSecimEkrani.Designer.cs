namespace ListFarmer
{
    partial class KullaniciSecimEkrani
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciSecimEkrani));
            this.lblDataSource = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKullaniciAdi = new System.Windows.Forms.ComboBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.lblParolaDegistir = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(15, 11);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(53, 20);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parola";
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(332, 109);
            this.txtParola.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParola.Name = "txtParola";
            this.txtParola.PasswordChar = '*';
            this.txtParola.Size = new System.Drawing.Size(238, 27);
            this.txtParola.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // cmbKullaniciAdi
            // 
            this.cmbKullaniciAdi.Font = new System.Drawing.Font("Miriam Libre", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKullaniciAdi.FormattingEnabled = true;
            this.cmbKullaniciAdi.Location = new System.Drawing.Point(332, 71);
            this.cmbKullaniciAdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbKullaniciAdi.Name = "cmbKullaniciAdi";
            this.cmbKullaniciAdi.Size = new System.Drawing.Size(238, 34);
            this.cmbKullaniciAdi.TabIndex = 0;
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(332, 190);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(101, 45);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Location = new System.Drawing.Point(470, 190);
            this.btnGeriDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(101, 45);
            this.btnGeriDon.TabIndex = 3;
            this.btnGeriDon.Text = "Geri dön";
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.BtnGeriDon_Click);
            // 
            // lblParolaDegistir
            // 
            this.lblParolaDegistir.AutoSize = true;
            this.lblParolaDegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParolaDegistir.Location = new System.Drawing.Point(442, 150);
            this.lblParolaDegistir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParolaDegistir.Name = "lblParolaDegistir";
            this.lblParolaDegistir.Size = new System.Drawing.Size(103, 17);
            this.lblParolaDegistir.TabIndex = 5;
            this.lblParolaDegistir.Text = "Parola değiştir.";
            this.lblParolaDegistir.Click += new System.EventHandler(this.LblParolaDegistir_Click);
            this.lblParolaDegistir.MouseLeave += new System.EventHandler(this.LblParolaDegistir_MouseLeave);
            this.lblParolaDegistir.MouseHover += new System.EventHandler(this.LblParolaDegistir_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // KullaniciSecimEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 245);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblParolaDegistir);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.cmbKullaniciAdi);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDataSource);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KullaniciSecimEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KullaniciSecimEkrani";
            this.Load += new System.EventHandler(this.KullaniciSecimEkranı_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKullaniciAdi;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Label lblParolaDegistir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}