using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.BusinessLogicService
{
    public class FksService:BaseService<Fks>
    {
        Database.FksDAL dll;
        public FksService()
        {
            dll = new Database.FksDAL();
        }
        public List<Fks> GetAll(string listeIsmi)
        {
            List<Fks> Fksliste = new List<Fks>();
            string sql = "SELECT *  FROM [Db_Tarim].[dbo].[" + listeIsmi + "] order by SIRA_NO asc";
            _sqlCommand = new System.Data.SqlClient.SqlCommand(sql);
           _sqlDataReader= dll.GetAll(_sqlCommand);
            while (_sqlDataReader.Read())
            {
                Fks kayit = new Fks();
                kayit.id = (int)_sqlDataReader[0];
                kayit.siraNo = (int)_sqlDataReader[1];
                kayit.il = _sqlDataReader[2].ToString();
                kayit.ilce = _sqlDataReader[3].ToString();
                kayit.mahalleKoy = _sqlDataReader[4].ToString();
                kayit.isletmeNo = _sqlDataReader[5].ToString();
                kayit.dilekceNo = _sqlDataReader[6].ToString();
                kayit.isletmeAdi = _sqlDataReader[7].ToString();
                kayit.babaAdi = _sqlDataReader[8].ToString();
                kayit.dogumTarihi = (DateTime)_sqlDataReader[9];
                kayit.desteklenenAlan = (Decimal)_sqlDataReader[10];
                kayit.desteklemeMiktari = (Decimal)_sqlDataReader[11];
                Fksliste.Add(kayit);
            }
            _sqlDataReader.Close();
            dll._sqlConnection.Close();
            return Fksliste;
        }
    }
}
