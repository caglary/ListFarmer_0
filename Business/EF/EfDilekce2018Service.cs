using Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.EF
{
    public class EfDilekce2018Service
    {
        Database.EF.DalDilekce2018 _dalDilekce2018;
        public EfDilekce2018Service()
        {
            _dalDilekce2018 = new Database.EF.DalDilekce2018();
        }
        public DILEKCE2018 GetByDilekceNo(int EntityDilekceNo)
        {
            return _dalDilekce2018.GetByDilekceNo(EntityDilekceNo);
        }
    }
}
