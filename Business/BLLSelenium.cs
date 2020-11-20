using Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Business
{
    public class BLLSelenium
    {
        Selenium.Tbs selenium;
        public static IWebDriver driver;// bu özellikle browser açık kapalı kontrolu yapılacak.
        public static IWebDriver driverNvi;// bu özellikle browser açık kapalı kontrolu yapılacak.
        string nameofproject;
      
        public BLLSelenium()
        {
            selenium = new Selenium.Tbs();
            nameofproject = nameof(BLLSelenium);
        }
        public static void webBrowserKapat()
        {
            if (driver != null) driver.Quit();
            if (driverNvi != null) driverNvi.Quit();
        }
        public void ClickTbs(Entities.Ciftci ciftci)
        {
            if (!string.IsNullOrEmpty(ciftci.tc))
            {
                Logger.LogTryCatch.TryCatch(() =>
                {
                    driver = new ChromeDriver();
                    Kullanici kullanici = StaticsClass.StaticsMethods._kullanici;
                    selenium.TbsGiris(driver, kullanici);
                    selenium.TcNoGiris(driver, ciftci);
                    selenium.ClickGercekKisiAra(driver, ciftci);
                    //driver.Manage().Window.Maximize();
                }, nameofproject);
            }
        }
        public Ciftci IsletmeBilgileriGetir(Ciftci ciftci, Entities.Kullanici kullanici)
        {
            Ciftci c = new Ciftci();
            if (!string.IsNullOrEmpty(ciftci.tc))
            {
                DialogResult soru= MessageBox.Show("Bilgileri forma kaydetmek ister misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                bool formAcilsinmi = soru == DialogResult.Yes ? true : false;
                driverNvi = new ChromeDriver();
                c = selenium.IsletmeBilgileri(driverNvi, ciftci, kullanici,formAcilsinmi);
                driverNvi.Quit();
            }
            else
            {
                MessageBox.Show("Tc numarası giriniz.");
            }
            return c;
        }
    }
}
