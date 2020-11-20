using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class Kullanici
    {
        public int id { get; set; }
        public string Tc { get; set; }
        public string tbsSifre { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string email { get; set; }
        public string kullaniciadi { get; set; }
        public string parola { get; set; }
        public DateTime kayittarihi { get; set; }
        public DateTime ensongiristarih { get; set; }
        public override string ToString()
        {
            return kullaniciadi;
        }
    }
}
