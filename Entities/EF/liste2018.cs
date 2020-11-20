namespace Entities.EF
{
    using System;
    public class liste2018
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
