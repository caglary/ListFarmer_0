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
using Entities;
using System.Configuration;
namespace ListFarmer
{
   
    public partial class SelectConnectionString : Form
    {
       
        Business.BLLKullaniciSQL _bllKullaniciSQL;
        Entities.Kullanici _kullanici;
        public SelectConnectionString()
        {
            InitializeComponent();
           
        }
        #region iptal edilen kısım
        /*
         *  private void BtnLenovo_Click(object sender, EventArgs e)
        {
            Business.EF.ListeManager.whichConnectionString = "name=LenovoEF";
            string connectionstring = ConfigurationManager.ConnectionStrings["Lenovo"].ConnectionString;
            SqlConnection baglanti = StaticsClass.StaticsMethods.sqlBaglanti(connectionstring);
            _bllKullaniciSQL = new Business.BLLKullaniciSQL(baglanti);
            Kullanici caglar = _bllKullaniciSQL.Get(new Entities.Kullanici
            {
                id = 1//1 numaralı kullanici olan cagların bilgilerini getirecek.
            });
            StaticsClass.StaticsMethods.kullaniciKim(caglar);
            if (baglanti!=null)
            {
                //_bllKullaniciSQL = new Business.KullaniciManagerSQL(baglanti);
                _kullanici = _bllKullaniciSQL.Get(new Entities.Kullanici { id = 1 });//id=1 caglar kullanıcısı
                Form1 frm = new Form1(_kullanici);
                frm.Show();
                notfyIconGoster(@"Lenovo Bilgisayara Hoşgeldin!");
                this.Hide();
               
            }
            else
            {
                MessageBox.Show(@"(LocalDB)\MSSQLLocalDB üzerinden database bağlantısı sağlanamadı.", "SQL Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         */
        #endregion
        private void BtnWork_Click(object sender, EventArgs e)
        {
            Business.EF.ListeManager.whichConnectionString = "IlceTarimEF";
            string connectionstring = ConfigurationManager.ConnectionStrings["IlceTarim"].ConnectionString;
            SqlConnection baglanti = StaticsClass.StaticsMethods.sqlBaglanti(connectionstring);
            if (baglanti != null)
            {
                KullaniciSecimEkrani frm = new KullaniciSecimEkrani(baglanti);
                frm.Show();
                this.Hide();
                string kullaniciBilgisi = "Merhaba, İlçe Tarıma Hoşgeldiniz.\n" + baglanti.DataSource;
                notfyIconGoster(kullaniciBilgisi);
            }
            else
            {
                MessageBox.Show(@"Data Source=192.168.1.116,1433; üzerinden bağlantı sağlanamadı.", "SQL Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void notfyIconGoster(string kullaniciBilgisi)
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.BalloonTipTitle = "Çiftçi Kayıt Programı";
            notifyIcon.BalloonTipText = kullaniciBilgisi;
            notifyIcon.Visible = true;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.ShowBalloonTip(5000);
        }
    }
}
