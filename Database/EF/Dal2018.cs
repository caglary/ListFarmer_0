using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interface;
using Entities.EF;
namespace Database.EF
{
    public class Dal2018: Repository.RepositoryBase<Entities.EF.liste2018>,Interface.IEfCrud<Entities.EF.liste2018>
    {
        public int Delete(liste2018 Entity)
        {
             CUDOperation(Entity, System.Data.Entity.EntityState.Deleted);
             return SaveChange();
        }
        public liste2018 Get(string EntityTC)
        {
            return Get(EntityTC);
        }
        public List<Entities.EF.liste2018> Notlar2018()
        {
            return Where(I => I.aciklama != "").OrderByDescending(I => I.dilekceno).ToList();
        }
        public int Save(liste2018 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Added);
            return SaveChange();
        }
        public int Update(liste2018 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Modified);
            return SaveChange();
        }
        List<liste2018> IEfCrud<liste2018>.GetAll()
        {
            return GetAll().ToList();
        }
        public void Restore2018(liste2018 item)
        {
            using (Context context = new Context())
            {
                var ciftci = context.liste2018.Where(I => I.tc == item.tc).FirstOrDefault();
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
                    context.liste2018.Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
