namespace ListFarmer
{
    partial class ParolaDegistir
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEskiSifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.btnDevam = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eski Şifre";
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.Location = new System.Drawing.Point(143, 11);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Size = new System.Drawing.Size(177, 22);
            this.txtEskiSifre.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Yeni Şifre";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(143, 39);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(177, 22);
            this.txtYeniSifre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yeni Şifre (Tekrar)";
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(143, 67);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(177, 22);
            this.txtYeniSifreTekrar.TabIndex = 2;
            // 
            // btnDevam
            // 
            this.btnDevam.Location = new System.Drawing.Point(143, 111);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(83, 33);
            this.btnDevam.TabIndex = 3;
            this.btnDevam.Text = "Devam";
            this.btnDevam.UseVisualStyleBackColor = true;
            this.btnDevam.Click += new System.EventHandler(this.BtnDevam_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(245, 111);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 33);
            this.btnVazgec.TabIndex = 4;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.BtnVazgec_Click);
            // 
            // ParolaDegistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(343, 159);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnDevam);
            this.Controls.Add(this.txtYeniSifreTekrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParolaDegistir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParolaDegistir";
            this.Load += new System.EventHandler(this.ParolaDegistir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEskiSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Button btnDevam;
        private System.Windows.Forms.Button btnVazgec;
    }
}