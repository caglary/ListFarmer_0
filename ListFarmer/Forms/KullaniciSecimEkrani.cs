using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ListFarmer
{
    public partial class KullaniciSecimEkrani : Form
    {
        Business.BLLKullaniciSQL bll;
        SqlConnection _baglanti;
        public KullaniciSecimEkrani(SqlConnection baglanti )
        {
            
            InitializeComponent();
            string datasource=baglanti.DataSource;
            lblDataSource.Text =datasource +"\nbağlantılı database içerisinde bulunuyorsunuz.";
            
            bll = new Business.BLLKullaniciSQL(baglanti);
            _baglanti = baglanti;
            
        }
      
        private void KullaniciSecimEkranı_Load(object sender, EventArgs e)
        {
            cmbKullaniciAdi.DataSource = bll.GetAll();
            this.AcceptButton = btnGiris;
        }
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            Entities.Kullanici kullanici = cmbKullaniciAdi.SelectedItem as Entities.Kullanici;
            StaticsClass.StaticsMethods._kullanici = kullanici;
            if (kullanici.isim!="misafir")
            {
                if (kullanici.parola == txtParola.Text)
                {
                    Form1 frm = new Form1(kullanici);
                    frm.Show();
                  
                    this.Close();
                }
            }
            else
            {
                Form1 frm = new Form1(kullanici);
                frm.Show();
            
                this.Close();
            }
          
        }
        private void BtnGeriDon_Click(object sender, EventArgs e)
        {
            SelectConnectionString frm = new SelectConnectionString();
            frm.Show();
            this.Close();
        }
        private void LblParolaDegistir_MouseHover(object sender, EventArgs e)
        {
            lblParolaDegistir.Font = new Font("Thoma", 8, FontStyle.Regular);
            lblParolaDegistir.Text = "Tıklayınız.";
        }
        private void LblParolaDegistir_MouseLeave(object sender, EventArgs e)
        {
            
            lblParolaDegistir.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
            lblParolaDegistir.Text = "Parola değiştir.";
        }
        private void LblParolaDegistir_Click(object sender, EventArgs e)
        {
            Entities.Kullanici kullanici= cmbKullaniciAdi.SelectedItem as Entities.Kullanici;
            if (txtParola.Text==kullanici.parola)
            {
                ParolaDegistir frm = new ParolaDegistir(kullanici,_baglanti);
                frm.ShowDialog();
            }
            else MessageBox.Show("Parolanızı doğru giriniz. Parola girişi yapılmadan şifre değiştirme işlemi gerçekleşemez.");
        }
    }
}
