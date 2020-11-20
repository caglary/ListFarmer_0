using Entities;
using OpenQA.Selenium;
using System;
using System.IO;
using wordeAktar = Microsoft.Office.Interop.Word;
namespace Selenium
{
    public class Tbs
    {
        public Tbs()
        {
            //parola adlı database içerisine geçiş yapan bağlantıyı oluşturuyoruz. 
            //baglanti = StaticsClass.StaticsMethods.changeinitialCatalog("parola", "sa", "1");
        }
        public void TbsGiris(IWebDriver driver, Entities.Kullanici kullanici)
        {
        basadon:
            try
            {
                driver.Navigate().Refresh();
                driver.Url = "https://tbs.tarbil.gov.tr/Authentication.aspx";
                driver.FindElement(By.Id("username")).SendKeys(kullanici.Tc);
                driver.FindElement(By.Id("password")).SendKeys(kullanici.tbsSifre);
                driver.FindElement(By.Id("btnSubmit")).Click();
               
            }
            catch (Exception)
            {
                goto basadon;
            }
        }
        public void TcNoGiris(IWebDriver driver, Ciftci c)
        {
            IWebElement txtTC = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_HoldingSearchControlUC_RadPanelBar1_i0_edtIdNo11"));
            txtTC.Click();
            txtTC.SendKeys(c.tc);
            ClickGercekKisiAra(driver, c);
        }
        public void ClickGercekKisiAra(IWebDriver driver, Ciftci c)
        {
            bekle();
            IWebElement btnGercekKisiAra =
                driver.FindElement(By.Name("ctl00$ctl00$bodyCPH$ContentPlaceHolder1$HoldingSearchControlUC$RadPanelBar1$i0$btnSearch11"));
            btnGercekKisiAra.Click();
            bekle();
            IWebElement btnDetay = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_grdList_ctl00_ctl04_EditButton"));
            btnDetay.Click();
        }
        public Ciftci IsletmeBilgileri(IWebDriver driver, Ciftci c, Entities.Kullanici kullanici, bool formAcılsınmı)
        {
            //parolayı parola database içinden değil de kullanıcı database içerisinden alıyoruz. 
            //because of that those cods are canceled.
            //string[] gelenler = listeyebak("tbs");
            //string kullaniciadi = gelenler[0];
            //string parola = gelenler[1];
            TbsGiris(driver, kullanici);
            driver.Url = "http://tbsapp1.tarim.gov.tr/Modules/TBSSystem/PersonSearch.aspx";
            IWebElement TcNo = driver.FindElement(By.Id("ctl00_ctl00_bodyCPH_ContentPlaceHolder1_edtIdNo"));
            TcNo.Click();
            TcNo.SendKeys(c.tc);
            IWebElement Click = driver.FindElement(By.Name("ctl00$ctl00$bodyCPH$ContentPlaceHolder1$btnMernis"));
            Click.Click();
        TcKontrol:
            IWebElement Isim = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtName"));
            if (Isim.Text == "")
            {
                goto TcKontrol;
            }
            IWebElement Soyisim = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtSurname"));
            IWebElement Mahalle = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_lblCiltAdi"));
            IWebElement Cinsiyet = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_txtGender"));
            IWebElement BabaAdi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtFatherName"));
            IWebElement AnneAdi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtMotherName"));
            IWebElement DogumTarihi = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtBirthdate"));
            IWebElement DogumYeri = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_edtDogumYeri"));
            IWebElement MedeniDurum = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_txtMaritalStatus"));
            IWebElement Il = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_lblIl"));
            IWebElement Ilce = driver.FindElement(By.Id("bodyCPH_ContentPlaceHolder1_lblIlce"));
            Ciftci ciftci = new Ciftci();
            if (!string.IsNullOrEmpty(Isim.Text) && !string.IsNullOrEmpty(Soyisim.Text))
            {
                string _isim, _soyisim, _mahalle, _cinsiyet, _babaAdi, _anneAdi, _dogumTarihi, _dogumYeri, _medeniDurumu, _il, _ilce;
                _isim = Isim.Text;
                _soyisim = Soyisim.Text;
                _mahalle = Mahalle.Text;
                _cinsiyet = Cinsiyet.Text;
                _babaAdi = BabaAdi.Text;
                _anneAdi = AnneAdi.Text;
                _dogumTarihi = DogumTarihi.Text;
                _dogumYeri = DogumYeri.Text;
                _medeniDurumu = MedeniDurum.Text;
                _il = Il.Text;
                _ilce = Ilce.Text;
                ciftci.isim = _isim;
                ciftci.soyisim = _soyisim;
                ciftci.mahalle = _mahalle;
                if (formAcılsınmı)
                {
                    KayitFormuDoldur(c, _isim, _soyisim, _mahalle, _cinsiyet, _babaAdi, _anneAdi, _dogumTarihi, _il, _ilce);
                    BilgiPaylasimDoldur(_isim, _soyisim, _mahalle);
                    ZiraiDilekceDoldur(_isim, _soyisim, _mahalle, c.tc);
                }
            }
            else
            {
                bekle();
                
            }
            return ciftci;
        }
        private void ZiraiDilekceDoldur(string isim, string soyisim, string mahalle, string tc)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            string fullName = directoryInfo.FullName;
            string kayitFormuPath = fullName + "\\word\\ZiraiDilekce.docx";
            if (File.Exists(kayitFormuPath))
            {
                wordeAktar.Application wordapp = new wordeAktar.Application();
                wordapp.Visible = true;
                wordeAktar.Document worddoc;
                object missing = System.Reflection.Missing.Value;
                object readOnly = false;
                object fileName = kayitFormuPath;
                worddoc = wordapp.Documents.Open(ref fileName, ref missing, ref readOnly, ref readOnly, ref missing, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                worddoc.Activate();
                object bmIsim = "Isim";
                worddoc.Bookmarks.get_Item(ref bmIsim).Range.Text = isim + " " + soyisim;
                object bmMahalle = "mahalle";
                worddoc.Bookmarks.get_Item(ref bmMahalle).Range.Text = mahalle;
                object bmTarih = "tarih";
                worddoc.Bookmarks.get_Item(ref bmTarih).Range.Text = DateTime.Now.ToShortDateString().ToString();
                object bmTc = "tc";
                worddoc.Bookmarks.get_Item(ref bmTc).Range.Text = tc;
            }
        }
        private static void KayitFormuDoldur(Ciftci c, string _isim, string _soyisim, string _mahalle, string _cinsiyet, string _babaAdi, string _anneAdi, string _dogumTarihi, string _il, string _ilce)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            string fullName = directoryInfo.FullName;
            string kayitFormuPath = fullName + "\\word\\ÇKF-(A-Kişisel Bilgiler).docx";
            if (File.Exists(kayitFormuPath))
            {
                wordeAktar.Application wordapp = new wordeAktar.Application();
                wordapp.Visible = true;
                wordeAktar.Document worddoc;
                object missing = System.Reflection.Missing.Value;
                object readOnly = false;
                object fileName = kayitFormuPath;
                worddoc = wordapp.Documents.Open(ref fileName, ref missing, ref readOnly, ref readOnly, ref missing, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                worddoc.Activate();
                object bmMahalle = "Mahalle";
                worddoc.Bookmarks.get_Item(ref bmMahalle).Range.Text = _mahalle;
                object bmAdSoyad = "AdSoyad";
                worddoc.Bookmarks.get_Item(ref bmAdSoyad).Range.Text = _isim + " " + _soyisim;
                object bmAnneAdi = "AnaAdi";
                worddoc.Bookmarks.get_Item(ref bmAnneAdi).Range.Text = _anneAdi;
                object bmBabaAdi = "BabaAdi";
                worddoc.Bookmarks.get_Item(ref bmBabaAdi).Range.Text = _babaAdi;
                object bmBasvuruTarihi = "BasvuruTarihi";
                worddoc.Bookmarks.get_Item(ref bmBasvuruTarihi).Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
                object bmCinsiyet = "Cinsiyeti";
                worddoc.Bookmarks.get_Item(ref bmCinsiyet).Range.Text = _cinsiyet;
                object bmDogumTarihi = "DogumTarihi";
                worddoc.Bookmarks.get_Item(ref bmDogumTarihi).Range.Text = _dogumTarihi;
             
               
                object bmTcKimlikNo = "Tc";
                worddoc.Bookmarks.get_Item(ref bmTcKimlikNo).Range.Text = c.tc;
                object bmIl = "Ili";
                worddoc.Bookmarks.get_Item(ref bmIl).Range.Text = _il.ToUpper();
                object bmIlce = "Ilce";
                worddoc.Bookmarks.get_Item(ref bmIlce).Range.Text = _ilce.ToUpper();
              
            }
            else
            {
                // loglanacak ...
                // belirtilen yolda dosya yok..
            }
        }
        private static void BilgiPaylasimDoldur(string _isim, string _soyisim, string _mahalle)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            string fullName = directoryInfo.FullName;
            string kayitFormuPath = fullName + "\\word\\bilgiPaylasim.docx";
            if (File.Exists(kayitFormuPath))
            {
                wordeAktar.Application wordapp = new wordeAktar.Application();
                wordapp.Visible = true;
                wordeAktar.Document worddoc;
                object missing = System.Reflection.Missing.Value;
                object readOnly = false;
                object fileName = kayitFormuPath;
                worddoc = wordapp.Documents.Open(ref fileName, ref missing, ref readOnly, ref readOnly, ref missing, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                worddoc.Activate();
                object bmAdiSoyadi = "AdiSoyadi";
                worddoc.Bookmarks.get_Item(ref bmAdiSoyadi).Range.Text = _isim.ToUpper() + " " + _soyisim.ToUpper();
                object bmAdres = "Adres";
                worddoc.Bookmarks.get_Item(ref bmAdres).Range.Text = _mahalle + " MAH.";
            }
            else
            {
                // loglanacak ...
                // belirtilen yolda dosya yok..
            }
        }
        private void bekle(int saniye = 2000)
        {
            System.Threading.Thread.Sleep(saniye);
        }
    }
}
