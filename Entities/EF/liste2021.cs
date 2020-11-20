using System;
namespace Entities.EF
{
    public class liste2021
    {
        public int id { get; set; }
        public int dilekceno { get; set; }
        public string tc { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string mahalle { get; set; }
        public DateTime tarih { get; set; }
        public string aciklama { get; set; }
        public string telefon { get; set; }
        public int? kayitdurumu { get; set; }
    }
}
