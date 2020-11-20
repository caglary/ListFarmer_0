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
    public partial class ParolaDegistir : Form
    {
        Business.BLLKullaniciSQL _bll;
        Entities.Kullanici _kullanici;
        public ParolaDegistir(Entities.Kullanici kullanici,SqlConnection _baglanti)
        {
            InitializeComponent();
            
            _bll = new Business.BLLKullaniciSQL(_baglanti);
            //SqlConnection baglanti = _bll.baglantiNedir();
            _kullanici = kullanici;
        }
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            Form kullaniciSecimEkrani = Application.OpenForms["KullaniciSecimEkrani"];
            kullaniciSecimEkrani.Show();
            this.Close();
        }
        private void BtnDevam_Click(object sender, EventArgs e)
        {
            //guncelleme işlemi
            updateOperation();
            Form kullaniciSecimEkrani = Application.OpenForms["KullaniciSecimEkrani"];
            kullaniciSecimEkrani.Show();
            this.Close();
        }
        private void updateOperation()
        {
           
            Entities.Kullanici updatedKullanici = new Entities.Kullanici();
            string yenisifre = txtYeniSifre.Text;
            string yenisifretekrar = txtYeniSifreTekrar.Text;
           
            if (!string.IsNullOrEmpty(yenisifre) && !string.IsNullOrEmpty(yenisifretekrar) && yenisifre == yenisifretekrar)
            {
                _kullanici.parola = yenisifre;
                _bll.Update(_kullanici);
            }
        }
        private void ParolaDegistir_Load(object sender, EventArgs e)
        {
            txtEskiSifre.Text = _kullanici.parola;
            txtEskiSifre.Enabled = false;
        }
    }
}
