using System;
using System.ComponentModel;
namespace Entities.Abstract
{
    public abstract class ciftciBase
    {
       
        [DisplayName("Dilekce Numarası")]
        public int dilekceno { get; set; }
        [DisplayName("TC Kimlik No")]
        public string tc { get; set; }
        [DisplayName("İsim")]
        public string isim { get; set; }
        [DisplayName("Soyisim")]
        public string soyisim { get; set; }
        [DisplayName(@"Mahalle\Köy")]
        public string mahalle { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime tarih { get; set; }
        [DisplayName(@"Not\Aciklama")]
        public string aciklama { get; set; }
        [DisplayName("Telefon No")]
        public string telefon { get; set; }
        [DisplayName("Kayıt Durumu")]
        public int KayitDurumu { get; set; }
        public string tamAd()
        {
            return isim + " " + soyisim;
        }
        
    }
}
