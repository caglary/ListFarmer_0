namespace Entities.EF
{
    using System;
    public class iletisimBilgileri
    {
        public string id { get; set; }
        public string tc { get; set; }
        public string isim { get; set; }
        public string soysim { get; set; }
        public string babaAdi { get; set; }
        public string anneAdi { get; set; }
        public DateTime? dogumTarihi { get; set; }
        public string cinsiyet { get; set; }
        public string medeniDurumu { get; set; }
        public string cepTelefonu { get; set; }
        public string evTelefonu { get; set; }
        public string email { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string koyMahalle { get; set; }
    }
}
