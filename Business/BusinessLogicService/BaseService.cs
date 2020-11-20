using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.BusinessLogicService
{
    public class BaseService<T>
    {
        public SqlCommand _sqlCommand;
        public SqlDataReader _sqlDataReader;
        public int _returnInt;
        public object _returnObject;
        public List<T> _liste;
        public T _data;
    }
}
