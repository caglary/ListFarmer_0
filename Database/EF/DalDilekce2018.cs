using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interface;
using Entities.EF;
namespace Database.EF
{
   public class DalDilekce2018 : Repository.RepositoryBase<Entities.EF.DILEKCE2018>, Interface.IEfCrud<Entities.EF.DILEKCE2018>
    {
        public int Delete(DILEKCE2018 Entity)
        {
            throw new NotImplementedException();
        }
        public DILEKCE2018 Get(string EntityTc)
        {
            throw new NotImplementedException();
        }
        public int Save(DILEKCE2018 Entity)
        {
            throw new NotImplementedException();
        }
        public int Update(DILEKCE2018 Entity)
        {
            throw new NotImplementedException();
        }
        List<DILEKCE2018> IEfCrud<DILEKCE2018>.GetAll()
        {
            throw new NotImplementedException();
        }
        public  void RestoreFks2018(DILEKCE2018 item)
        {
            using (Context context = new Context())
            {
                var ciftci = context.DILEKCE2018.Where(I => I.tc == item.tc).FirstOrDefault();
                if (ciftci != null)
                {
                    //database içerisinde kayıt varsa update işlemi yapılacak.
                    ciftci.isim = item.isim;
                    ciftci.kayitdurumu = item.kayitdurumu;
                    ciftci.mahalle = item.mahalle;
                    ciftci.soyisim = item.soyisim;
                    ciftci.tarih = item.tarih;
                    ciftci.telefon = item.telefon;
                    ciftci.aciklama = item.aciklama;
                    ciftci.dilekceno = item.dilekceno;
                    context.SaveChanges();
                }
                else
                {
                    context.DILEKCE2018.Add(item);
                    context.SaveChanges();
                }
            }
        }
        public DILEKCE2018 GetByDilekceNo(int EntityDilekceNo)
        {
            using (Database.EF.Context context = new Context())
            {
                return context.DILEKCE2018.Where(c => c.dilekceno == EntityDilekceNo).FirstOrDefault();
            }
        }
    }
}
