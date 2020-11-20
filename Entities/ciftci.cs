using System;
namespace Entities
{
    public class Ciftci : Abstract.ciftciBase
    {
       
        public override string ToString()
        {
            return string.Format($"Dilekce No : {dilekceno}\nTc No: {tc}\nisim : {isim}\nsoyisim : {soyisim}\n");
        }
        public string KayitMesaj()
        {
            string mesaj=$" Dilekçe No : {dilekceno}\n İsim : {isim}\n Soyisim : {soyisim}\n TC : {tc}\n Mahalle : {mahalle}\n Açıklama : {aciklama}\n Telefon : {telefon}\n Tarih : {DateTime.Now.ToShortDateString()}  {DateTime.Now.ToShortTimeString()} "; 
            return mesaj;
        }
    }
}
