namespace Entities.EF
{
    using System;
    public class MGD2018
    {
        public int ID { get; set; }
        public int SIRA_NO { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string MAHALLE_KOY { get; set; }
        public string DILEKCE_NO { get; set; }
        public string ISLETME_ADI { get; set; }
        public string BABA_ADI { get; set; }
        public DateTime DOGUM_TARIHI { get; set; }
        public string TC { get; set; }
        public decimal MAZOT_ALANI { get; set; }
        public decimal MAZOT_DESTEKLEME_MIKTARI { get; set; }
        public decimal GUBRE_ALANI { get; set; }
        public decimal GUBRE_DESTEKLEME_MIKTARI { get; set; }
        public decimal TOPLAM_DESTEKLEME_MIKTARI { get; set; }
    }
}
