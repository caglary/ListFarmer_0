using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Database
{
   
    public interface IBaseDLL<T>
    {
        void connectionState();
        List<T> GetAll();
        T Get(T Entity);
        int Save(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
    }
}
