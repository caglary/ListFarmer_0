namespace ListFarmer
{
    partial class Sorgular
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
            this.grpbxDataGridView = new System.Windows.Forms.GroupBox();
            this.dgwListe = new System.Windows.Forms.DataGridView();
            this.grpbxListeler = new System.Windows.Forms.GroupBox();
            this.BtnMgd2017 = new System.Windows.Forms.Button();
            this.BtnFks2017 = new System.Windows.Forms.Button();
            this.BtnMgd2018 = new System.Windows.Forms.Button();
            this.BtnFks2018 = new System.Windows.Forms.Button();
            this.grpbxArama = new System.Windows.Forms.GroupBox();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToplamKayitSayisi = new System.Windows.Forms.Label();
            this.lblListeIsmi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).BeginInit();
            this.grpbxListeler.SuspendLayout();
            this.grpbxArama.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxDataGridView
            // 
            this.grpbxDataGridView.Controls.Add(this.dgwListe);
            this.grpbxDataGridView.Location = new System.Drawing.Point(12, 118);
            this.grpbxDataGridView.Name = "grpbxDataGridView";
            this.grpbxDataGridView.Size = new System.Drawing.Size(1018, 399);
            this.grpbxDataGridView.TabIndex = 0;
            this.grpbxDataGridView.TabStop = false;
            this.grpbxDataGridView.Text = "Liste";
            // 
            // dgwListe
            // 
            this.dgwListe.AllowUserToAddRows = false;
            this.dgwListe.AllowUserToDeleteRows = false;
            this.dgwListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListe.Location = new System.Drawing.Point(3, 18);
            this.dgwListe.Name = "dgwListe";
            this.dgwListe.ReadOnly = true;
            this.dgwListe.RowHeadersWidth = 51;
            this.dgwListe.RowTemplate.Height = 24;
            this.dgwListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwListe.Size = new System.Drawing.Size(1012, 378);
            this.dgwListe.TabIndex = 0;
            this.dgwListe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwListe_CellDoubleClick);
            // 
            // grpbxListeler
            // 
            this.grpbxListeler.Controls.Add(this.BtnMgd2017);
            this.grpbxListeler.Controls.Add(this.BtnFks2017);
            this.grpbxListeler.Controls.Add(this.BtnMgd2018);
            this.grpbxListeler.Controls.Add(this.BtnFks2018);
            this.grpbxListeler.Location = new System.Drawing.Point(12, 12);
            this.grpbxListeler.Name = "grpbxListeler";
            this.grpbxListeler.Size = new System.Drawing.Size(1015, 100);
            this.grpbxListeler.TabIndex = 1;
            this.grpbxListeler.TabStop = false;
            this.grpbxListeler.Text = "Liste Seçiniz.";
            // 
            // BtnMgd2017
            // 
            this.BtnMgd2017.Location = new System.Drawing.Point(320, 31);
            this.BtnMgd2017.Name = "BtnMgd2017";
            this.BtnMgd2017.Size = new System.Drawing.Size(95, 44);
            this.BtnMgd2017.TabIndex = 0;
            this.BtnMgd2017.Text = "MGD 2017";
            this.BtnMgd2017.UseVisualStyleBackColor = true;
            this.BtnMgd2017.Click += new System.EventHandler(this.BtnMgd2017_Click);
            // 
            // BtnFks2017
            // 
            this.BtnFks2017.Location = new System.Drawing.Point(219, 31);
            this.BtnFks2017.Name = "BtnFks2017";
            this.BtnFks2017.Size = new System.Drawing.Size(95, 44);
            this.BtnFks2017.TabIndex = 0;
            this.BtnFks2017.Text = "FKS 2017";
            this.BtnFks2017.UseVisualStyleBackColor = true;
            this.BtnFks2017.Click += new System.EventHandler(this.BtnFks2017_Click);
            // 
            // BtnMgd2018
            // 
            this.BtnMgd2018.Location = new System.Drawing.Point(118, 31);
            this.BtnMgd2018.Name = "BtnMgd2018";
            this.BtnMgd2018.Size = new System.Drawing.Size(95, 44);
            this.BtnMgd2018.TabIndex = 0;
            this.BtnMgd2018.Text = "MGD 2018";
            this.BtnMgd2018.UseVisualStyleBackColor = true;
            this.BtnMgd2018.Click += new System.EventHandler(this.BtnMgd2018_Click);
            // 
            // BtnFks2018
            // 
            this.BtnFks2018.Location = new System.Drawing.Point(17, 31);
            this.BtnFks2018.Name = "BtnFks2018";
            this.BtnFks2018.Size = new System.Drawing.Size(95, 44);
            this.BtnFks2018.TabIndex = 0;
            this.BtnFks2018.Text = "FKS 2018";
            this.BtnFks2018.UseVisualStyleBackColor = true;
            this.BtnFks2018.Click += new System.EventHandler(this.BtnFks2018_Click);
            // 
            // grpbxArama
            // 
            this.grpbxArama.Controls.Add(this.txtIsim);
            this.grpbxArama.Controls.Add(this.txtTc);
            this.grpbxArama.Controls.Add(this.label2);
            this.grpbxArama.Controls.Add(this.lblToplamKayitSayisi);
            this.grpbxArama.Controls.Add(this.lblListeIsmi);
            this.grpbxArama.Controls.Add(this.label5);
            this.grpbxArama.Controls.Add(this.label3);
            this.grpbxArama.Controls.Add(this.label1);
            this.grpbxArama.Location = new System.Drawing.Point(15, 523);
            this.grpbxArama.Name = "grpbxArama";
            this.grpbxArama.Size = new System.Drawing.Size(1012, 195);
            this.grpbxArama.TabIndex = 2;
            this.grpbxArama.TabStop = false;
            this.grpbxArama.Text = "Aşağıdaki seçeneklere göre arama yapınız.";
            // 
            // txtIsim
            // 
            this.txtIsim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsim.Location = new System.Drawing.Point(68, 143);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(315, 30);
            this.txtIsim.TabIndex = 1;
            this.txtIsim.TextChanged += new System.EventHandler(this.TxtIsim_TextChanged);
            // 
            // txtTc
            // 
            this.txtTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTc.Location = new System.Drawing.Point(68, 100);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(315, 30);
            this.txtTc.TabIndex = 0;
            this.txtTc.TextChanged += new System.EventHandler(this.TxtTc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "İsim :";
            // 
            // lblToplamKayitSayisi
            // 
            this.lblToplamKayitSayisi.AutoSize = true;
            this.lblToplamKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamKayitSayisi.Location = new System.Drawing.Point(717, 81);
            this.lblToplamKayitSayisi.Name = "lblToplamKayitSayisi";
            this.lblToplamKayitSayisi.Size = new System.Drawing.Size(89, 38);
            this.lblToplamKayitSayisi.TabIndex = 0;
            this.lblToplamKayitSayisi.Text = "____";
            // 
            // lblListeIsmi
            // 
            this.lblListeIsmi.AutoSize = true;
            this.lblListeIsmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListeIsmi.Location = new System.Drawing.Point(576, 83);
            this.lblListeIsmi.Name = "lblListeIsmi";
            this.lblListeIsmi.Size = new System.Drawing.Size(66, 17);
            this.lblListeIsmi.TabIndex = 0;
            this.lblListeIsmi.Text = "Liste ismi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(576, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Toplam Kayıt Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(368, 51);
            this.label3.TabIndex = 0;
            this.label3.Text = "Arama yapmak istediğiniz bilgileri giriniz.\r\n-Tc alanından Tc numaralarına göre a" +
    "rama yapabilirsiniz.\r\n-İsim alanından İsme göre arama yapabilirsiniz.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tc :";
            // 
            // Sorgular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1042, 730);
            this.Controls.Add(this.grpbxArama);
            this.Controls.Add(this.grpbxListeler);
            this.Controls.Add(this.grpbxDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Sorgular";
            this.Text = "Sorgular";
            this.Load += new System.EventHandler(this.Sorgular_Load);
            this.grpbxDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).EndInit();
            this.grpbxListeler.ResumeLayout(false);
            this.grpbxArama.ResumeLayout(false);
            this.grpbxArama.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.GroupBox grpbxDataGridView;
        private System.Windows.Forms.DataGridView dgwListe;
        private System.Windows.Forms.GroupBox grpbxListeler;
        private System.Windows.Forms.Button BtnMgd2017;
        private System.Windows.Forms.Button BtnFks2017;
        private System.Windows.Forms.Button BtnMgd2018;
        private System.Windows.Forms.Button BtnFks2018;
        private System.Windows.Forms.GroupBox grpbxArama;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblToplamKayitSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblListeIsmi;
    }
}