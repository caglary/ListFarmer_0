using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interface;
using Entities.EF;
namespace Database.EF
{
    public class DalDilekce2019 : Repository.RepositoryBase<Entities.EF.DILEKCE2019>,Interface.IEfCrud<Entities.EF.DILEKCE2019>
    {
        public int Delete(DILEKCE2019 Entity)
        {
            throw new NotImplementedException();
        }
        public int EnSonNumara()
        {
            int sonNumara = -10;
            Entities.EF.DILEKCE2019 gelenDeger= Context.DILEKCE2019.ToList().LastOrDefault();
            sonNumara =( gelenDeger==null) ?  1 :  gelenDeger.dilekceno + 1;
            return sonNumara;
           
        }
        public DILEKCE2019 Get(string EntityTc)
        {
            throw new NotImplementedException();
        }
        public DILEKCE2019 GetByDilekceNo(int EntityDilekceNo)
        {
            using (Database.EF.Context context=new Context())
            {
               return context.DILEKCE2019.Where(c => c.dilekceno == EntityDilekceNo).FirstOrDefault();
            }
        }
        public List<Entities.EF.DILEKCE2019> Notlar()
        {
            return Where(I => I.aciklama != "").OrderByDescending(I => I.dilekceno).ToList();
        }
        public int Save(DILEKCE2019 Entity)
        {
            CUDOperation(Entity, System.Data.Entity.EntityState.Added);
            return SaveChange();
        }
        public int Update(DILEKCE2019 Entity)
        {
            throw new NotImplementedException();
        }
       List<DILEKCE2019> IEfCrud<DILEKCE2019>.GetAll()
        {
            return GetAll().ToList();
        }
      
    }
}
