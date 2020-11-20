using Database.EF;
using Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.EF
{
    public class ListeManager
    {
        public static string whichConnectionString;
        Database.EF.Dal2019 dal2019;
        Database.EF.Dal2018 dal2018;
        Database.EF.DalDilekce2019 dalDilekce2019;
        Database.EF.DalDilekce2018 dalDilekce2018;
        public ListeManager()
        {
            Database.EF.Context.whichConnectionString = whichConnectionString;
            dal2019 = new Database.EF.Dal2019();
            dal2018 = new Database.EF.Dal2018();
            dalDilekce2019 = new DalDilekce2019();
            dalDilekce2018 = new DalDilekce2018();
        }
        public List<Entities.EF.liste2019> Notlar2019()
        {
            return dal2019.Notlar ();
        }
        public void Restore2019(Entities.EF.liste2019 item)
        {
            dal2019.Restore2019(item);
        }
        public List<Entities.EF.liste2018> Notlar2018()
        {
            return dal2018.Notlar2018();
        }
        public List<Entities.EF.DILEKCE2019> NotlarFks2019()
        {
            return dalDilekce2019.Notlar();
        }
        public int Fks2019EnSonNumara()
        {
            return dalDilekce2019.EnSonNumara();
        }
        internal void Restore2018(liste2018 ciftciListe2018)
        {
            dal2018.Restore2018(ciftciListe2018);
        }
        internal void RestoreFks2018(DILEKCE2018 ciftciFks2018)
        {
            dalDilekce2018.RestoreFks2018(ciftciFks2018);
        }
    }
}
