using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database
{
    public class BaseDAL
    {
        public BaseDAL()
        {
            _sqlConnection = StaticsClass.StaticsMethods._sqlBaglanti;
        }
        public SqlConnection _sqlConnection;
        public SqlCommand _sqlCommand;
        public SqlDataReader _SqlDataReader;
        public int returnInt;
        public object returnObject;
        private void connectionState()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open) _sqlConnection.Close();
            else _sqlConnection.Open();
        }
        public void tryCatchConnection(Action action)
        {
            //loglama kısmı için yazılan metot. 
            try
            {
                connectionState();
                action.Invoke();
            }
            catch (Exception exception)
            {
                //loglama işini logger projesi içerisindeki tryCatch metodunu kullanarak yapıyoruz.
                Logger.LogTryCatch.TryCatch(exception,"Database Logical Layer");
              
            }
            finally
            {
                connectionState();
            }
        }
        public int AddUpdateDelete(SqlCommand cmd)
        {
            returnInt = 0;
            cmd.Connection = _sqlConnection;
            tryCatchConnection(() =>
            {
                returnInt = cmd.ExecuteNonQuery();
            });
            return returnInt;
        }
        public SqlDataReader GetAll(SqlCommand cmd)
        {
            cmd.Connection = _sqlConnection;
            _sqlConnection.Open();
            return cmd.ExecuteReader();
            //baglantı businessServise tarafında kapatılacak.
        }
        public object Get(SqlCommand cmd)
        {
            returnObject = null;
            cmd.Connection = _sqlConnection;
            tryCatchConnection(() =>
            {
                returnObject = cmd.ExecuteScalar();
            });
            return returnObject;
        }
    }
}
