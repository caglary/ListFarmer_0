using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
   public class Fks
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
        [DisplayName("İşletme No")]
        public string isletmeNo { get; set; }
        [DisplayName("Dilekçe No")]
        public string dilekceNo { get; set; }
        [DisplayName("İşletme Adı")]
        public string isletmeAdi { get; set; }
        [DisplayName("Baba Adı")]
        public string babaAdi { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime dogumTarihi { get; set; }
        [DisplayName(@"Desteklenen Alan\da")]
        public Decimal desteklenenAlan { get; set; }
        [DisplayName(@"Destekleme Miktarı \ TL")]
        public Decimal desteklemeMiktari { get; set; }
    }
}
