using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database.Interface
{
   public interface IEfCrud<T>
    {
       
        List<T> GetAll();
        T Get(string EntityTc);
        int Save(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
    }
}
