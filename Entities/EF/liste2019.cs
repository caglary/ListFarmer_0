namespace Entities.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class liste2019
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
