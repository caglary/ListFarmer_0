using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Business.BusinessLogicService
{
    public class BackupServise
    {
        SqlCommand _sqlCommand;
       
        int _returnInt;
       
        Database.BaseDAL dll;
        BusinessLogicService.CiftciService ciftciService;
        public BackupServise()
        {
            dll = new Database.BaseDAL();
            ciftciService = new CiftciService();
        }
       
        public void RestoreDBFromSQL()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            DialogResult dr = OFD.ShowDialog();
            string KaynakYolu = OFD.FileName;
            if (!string.IsNullOrEmpty(KaynakYolu) && dr == DialogResult.OK)
            {
                string restoreCommand = @"USE master ALTER DATABASE Db_Tarim SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE Db_Tarim FROM DISK = '" + KaynakYolu + "'";// --This rolls back all uncommitted transactions in the db.
                _sqlCommand = new SqlCommand(restoreCommand);
                _returnInt = dll.AddUpdateDelete(_sqlCommand);
                if (_returnInt > 0)
                {
                    MesajKutusu.information("Restore işlemi başarıyla gerçekleşti");
                }
            }
        }
        public void RestoreDbFromJson(string listeIsmi)
        {
            //gelen json verilerini Sql tarafına kayıt işlemi yapıyorum. 
            List<Ciftci> ciftciler = null;
            bool kontrol = false;
            OpenFileDialog OFD = new OpenFileDialog();
            DialogResult dr = OFD.ShowDialog();
            string KaynakYolu = OFD.FileName;
            string[] parça = KaynakYolu.Split('\\');
            foreach (var item in parça) kontrol = item.Contains(listeIsmi);//liste ismi seçilen dosyanın adıyla aynı olup olmadığını kontrol ediyoruz. kaynakyolu seçilen dosya ile aynı olmalı. farklı listeleri birbirinin üzerine yazdırmamak için.
            if (kontrol && dr == DialogResult.OK)
            {
                //json kodları buraya yazılacak. Restore işlemi için
                string JsonOkunanData = File.ReadAllText(KaynakYolu);
                ciftciler = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ciftci>>(JsonOkunanData);
                if (ciftciler != null && listeIsmi=="liste2019")
                {
                    Business.EF.ListeManager liste = new EF.ListeManager();
                    foreach (var item in ciftciler)
                    {
                        
                        Entities.EF.liste2019 ciftci = new Entities.EF.liste2019()
                        {
                            aciklama = item.aciklama,
                            dilekceno = item.dilekceno,
                            isim = item.isim,
                            kayitdurumu = item.KayitDurumu,
                            mahalle = item.mahalle,
                            soyisim = item.soyisim,
                            tarih = item.tarih,
                            tc = item.tc,
                            telefon = item.telefon
                        };
                        liste.Restore2019(ciftci);
                    }
                    string mesaj = "Restore is finished";
                    Business.MesajKutusu.information(mesaj);
                }
                else if (ciftciler != null && listeIsmi == "liste2018")
                {
                    Business.EF.ListeManager listeManager = new EF.ListeManager();
                 
                    foreach (var item in ciftciler)
                    {
                        Entities.EF.liste2018 ciftciListe2018 = new Entities.EF.liste2018()
                        {
                            aciklama = item.aciklama,
                            dilekceno = item.dilekceno,
                            isim = item.isim,
                            kayitdurumu = item.KayitDurumu,
                            mahalle = item.mahalle,
                            soyisim = item.soyisim,
                            tarih = item.tarih,
                            tc = item.tc,
                            telefon = item.telefon
                        };
                        listeManager.Restore2018(ciftciListe2018);
                    }
                    string mesaj = "Restore is finished";
                    Business.MesajKutusu.information(mesaj);
                }
                else if (ciftciler != null && listeIsmi == "DILEKCE2018")
                {
                    Business.EF.ListeManager listeManager = new EF.ListeManager();
                    foreach (var item in ciftciler)
                    {
                        Entities.EF.DILEKCE2018 ciftciFks2018 = new Entities.EF.DILEKCE2018()
                        {
                            aciklama = item.aciklama,
                            dilekceno = item.dilekceno,
                            isim = item.isim,
                            kayitdurumu = item.KayitDurumu,
                            mahalle = item.mahalle,
                            soyisim = item.soyisim,
                            tarih = item.tarih,
                            tc = item.tc,
                            telefon = item.telefon
                        };
                        listeManager.RestoreFks2018(ciftciFks2018);
                    }
                    string mesaj = "Restore is finished";
                    Business.MesajKutusu.information(mesaj);
                }
                else
                {
                   
                    string mesaj = "Üzgünüz, Restore işlemi şu an bu liste için yapılamıyor.";
                    Business.MesajKutusu.warning(mesaj);
                }
            }
            else
            {
                MessageBox.Show("Yanlış liste seçimi yaptınız.");
            }
        }
        public bool BackupDbJsonFormat(FolderBrowserDialog _folder)
        {
            bool returnValue = false;
            
                string[] listeIsmi = new string[] { "liste2018", "liste2019", "DILEKCE2018", "liste2020", "DILEKCE2019" };
                foreach (var liste in listeIsmi)
                {
                    string _folderPath = _folder.SelectedPath;
                    List<Ciftci> ciftciler = ciftciService.GetAll(liste);
                    string jsonCiftciler = Newtonsoft.Json.JsonConvert.SerializeObject(ciftciler);
                    string SavePath = _folderPath + "\\" + "" + liste + ".json";
                    File.WriteAllText(SavePath, jsonCiftciler);
                    try
                    {
                        StaticsClass.StaticsMethods.emailGonder("caglar.yurdakul60@gmail.com", $"{liste} yedek", "json formatında yedek alınmıştır.", SavePath);
                    }
                    catch (Exception)
                    {
                        returnValue = false;
                    }
                }
                returnValue = true;
            return returnValue;
        }
    }
}
