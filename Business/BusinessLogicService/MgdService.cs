using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.BusinessLogicService
{
   public class MgdService:BaseService<Mgd>
    {
        Database.MgdDAL dll;
        public MgdService()
        {
            dll = new Database.MgdDAL();
        }
        public List<Mgd> GetAll(string listeImi)
        {
            _liste = new List<Mgd>();
            string sql = "SELECT *  FROM [Db_Tarim].[dbo].[" + listeImi + "] order by SIRA_NO asc";
            _sqlCommand = new SqlCommand(sql);
            _sqlDataReader =dll.GetAll(_sqlCommand) ;
            while (_sqlDataReader.Read())
            {
                Mgd kayit = new Mgd();
                kayit.id = (int)_sqlDataReader[0];
                kayit.siraNo = (int)_sqlDataReader[1];
                kayit.il = _sqlDataReader[2].ToString();
                kayit.ilce = _sqlDataReader[3].ToString();
                kayit.mahalleKoy = _sqlDataReader[4].ToString();
                kayit.dilekceNo = _sqlDataReader[5].ToString();
                kayit.isletmeAdi = _sqlDataReader[6].ToString();
                kayit.babaAdi = _sqlDataReader[7].ToString();
                kayit.dogumTarihi = (DateTime)_sqlDataReader[8];
                kayit.tc = _sqlDataReader[9].ToString();
                kayit.mazotAlani = (Decimal)_sqlDataReader[10];
                kayit.mazotDesteklemeMiktari = (Decimal)_sqlDataReader[11];
                kayit.gubreAlani = (Decimal)_sqlDataReader[12];
                kayit.gubreDesteklemeMiktari = (Decimal)_sqlDataReader[13];
                kayit.toplamDesteklemeMiktari = (Decimal)_sqlDataReader[14];
                _liste.Add(kayit);
            }
            _sqlDataReader.Close();
            dll._sqlConnection.Close();
            return _liste;
        }
    }
}
