namespace Entities.EF
{
    using System;
    public class kullanicilar
    {
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string email { get; set; }
        public string kullaniciadi { get; set; }
        public string parola { get; set; }
        public DateTime kayittarihi { get; set; }
        public DateTime ensongiristarih { get; set; }
        public string tc { get; set; }
        public string tbssifre { get; set; }
    }
}
