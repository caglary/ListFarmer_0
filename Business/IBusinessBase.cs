using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    interface IBusinessBase<T, Y>
    {
        List<T> GetAll(Y nameOfList);
        T Get(Y tcNo, Y nameOfList);
        void Save(T Entity, Y nameOfList);
        void Update(T Entity, Y nameOfList);
        void Delete(T Entity, Y nameOfList);
    }
    interface IBusinessBase<T>
    {
        List<T> GetAll();
        T Get(T Entity);
        void Save(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
