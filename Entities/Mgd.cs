using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class Mgd
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Sıra No")]
        public int siraNo { get; set; }
        [DisplayName("İl")]
        public string il { get; set; }
        [DisplayName("İlçe")]
        public string ilce { get; set; }
        [DisplayName(@"Mahalle\Köy")]
        public string mahalleKoy { get; set; }
        [DisplayName("Dilekçe No")]
        public string dilekceNo { get; set; }
        [DisplayName("İşletme Adı")]
        public string isletmeAdi { get; set; }
        [DisplayName("Baba Adı")]
        public string babaAdi { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime dogumTarihi { get; set; }
        [DisplayName("TC")]
        public string tc { get; set; }
        [DisplayName(@"Mazot Destek Alanı\da")]
        public Decimal mazotAlani { get; set; }
        [DisplayName(@"Mazot Destekleme Ücreti\TL")]
        public Decimal mazotDesteklemeMiktari { get; set; }
        [DisplayName(@"Gübre Destek Alanı\da")]
        public Decimal gubreAlani { get; set; }
        [DisplayName(@"Gübre Destekleme Ücreti\TL")]
        public Decimal gubreDesteklemeMiktari { get; set; }
        [DisplayName(@"Toplam Destekleme Ücreti\TL")]
        public Decimal toplamDesteklemeMiktari { get; set; }
    }
}
