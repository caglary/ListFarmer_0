namespace Entities.EF
{
    using System;
    public class FKS2018
    {
        public int ID { get; set; }
        public int SIRA_NO { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string MAHALLE_KOY { get; set; }
        public string ISLETME_NO { get; set; }
        public string DILEKCE_NO { get; set; }
        public string ISLETME_ADI { get; set; }
        public string BABA_ADI { get; set; }
        public DateTime DOGUM_TARIHI { get; set; }
        public decimal DESTEKLENEN_ALAN { get; set; }
        public decimal DESTEKLEME_MIKTARI { get; set; }
    }
}
