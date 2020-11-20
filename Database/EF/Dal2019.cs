using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interface;
using Entities.EF;
namespace Database.EF
{
    public class Dal2019 : Repository.RepositoryBase<Entities.EF.liste2019>, Interface.IEfCrud<Entities.EF.liste2019>
    {
        public List<Entities.EF.liste2019> Notlar()
        {
            List<liste2019> liste = new List<liste2019>();
            using (Database.EF.Context context=new Context())
            {
                liste = context.liste2019.Where(I => I.aciklama != "").OrderByDescending(I => I.dilekceno).ToList();
            }
            return liste;
            //var donenDeger = Where(I => I.aciklama != "").OrderByDescending(I => I.dilekceno).ToList();
            //return donenDeger;
            
        }
        public void Restore2019(Entities.EF.liste2019 item)
        {
            using (Context context = new Context())
            {
                var ciftci = context.liste2019.Where(I => I.tc == item.tc).FirstOrDefault();
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
                    context.liste2019.Add(item);
                    context.SaveChanges();
                }
            }
        }
        public int EnSonNumara()
        {
            int dilekceNo = Context.liste2019.Last().dilekceno;
            return dilekceNo + 1;
        }
        List<liste2019> IEfCrud<liste2019>.GetAll()
        {
            return GetAll().ToList();
        }
        public liste2019 Get(string EntityTc)
        {
            return Get(EntityTc);
        }
        public int Save(liste2019 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Added);
            return SaveChange();
        }
        public int Update(liste2019 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Modified);
            return SaveChange();
        }
        public int Delete(liste2019 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Deleted);
            return SaveChange();
        }
    }
}
