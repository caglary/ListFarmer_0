using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Database
{
    public class KullanıcıDalSQL : IBaseDLL<Kullanici>
    {
        //Kullanici ile ilgili işlemler...
        SqlConnection _baglanti;
        SqlCommand _komut;
        SqlDataReader dr;
        int _returnValue;
        string nameOfClass = nameof(KullanıcıDalSQL);
        public KullanıcıDalSQL(SqlConnection connection)
        {
            _baglanti = connection;
        }
        public void baglantiAyarla()
        {
            if (_baglanti.State == System.Data.ConnectionState.Open) _baglanti.Close();
            else _baglanti.Open();
        }
        public void connectionState()
        {
            throw new NotImplementedException();
        }
        public int Delete(Kullanici Entity)
        {
            return 0;
        }
        public Kullanici Get(Kullanici Entity)
        {
            Kullanici kullanici = new Kullanici();
            Logger.LogTryCatch.TryCatch(() =>
            {
                baglantiAyarla();
                string sqlkomut = "select * from kullanicilar where id=@id";
                _komut = new SqlCommand(sqlkomut, _baglanti);
                _komut.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Entity.id;
                dr = _komut.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        kullanici.id = (int)dr["id"];
                        kullanici.isim = dr["isim"].ToString();
                        kullanici.soyisim = dr["soyisim"].ToString();
                        kullanici.kullaniciadi = dr["kullaniciadi"].ToString();
                        kullanici.parola = dr["parola"].ToString();
                        kullanici.kayittarihi = (DateTime)dr["kayittarihi"];
                        kullanici.email = dr["email"].ToString();
                        kullanici.ensongiristarih = (DateTime)dr["ensongiristarih"];
                        kullanici.tbsSifre = dr["tbssifre"].ToString();
                        kullanici.Tc = dr["tc"].ToString();
                    }
                    dr.Close();
                }
                baglantiAyarla();
            }, nameOfClass);
            return kullanici;
        }
        public List<Kullanici> GetAll()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            Logger.LogTryCatch.TryCatch(() =>
            {
                baglantiAyarla();
                string sqlkomut = "select * from kullanicilar order by id asc";
                _komut = new SqlCommand(sqlkomut, _baglanti);
                dr = _komut.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Kullanici kullanici = new Kullanici();
                        kullanici.id = (int)dr["id"];
                        kullanici.isim = dr["isim"].ToString();
                        kullanici.soyisim = dr["soyisim"].ToString();
                        kullanici.kullaniciadi = dr["kullaniciadi"].ToString();
                        kullanici.parola = dr["parola"].ToString();
                        kullanici.kayittarihi = (DateTime)dr["kayittarihi"];
                        kullanici.email = dr["email"].ToString();
                        kullanici.ensongiristarih = (DateTime)dr["ensongiristarih"];
                        kullanici.Tc = dr["Tc"].ToString();
                        kullanici.tbsSifre = dr["tbsSifre"].ToString();
                        kullanicilar.Add(kullanici);
                    }
                    dr.Close();
                }
                baglantiAyarla();
            }, nameOfClass);
            return kullanicilar;
        }
        public int Save(Kullanici Entity)
        {
            return 0;
        }
        public int Update(Kullanici Entity)
        {
            _returnValue = 0;
            Logger.LogTryCatch.TryCatch(() =>
            {
                baglantiAyarla();
                string sqlkomut = "update kullanicilar set parola=@parola where id=@id";
                _komut = new SqlCommand(sqlkomut, _baglanti);
                _komut.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Entity.id;
                _komut.Parameters.AddWithValue("@parola", SqlDbType.NVarChar).Value = Entity.parola;
                _returnValue = _komut.ExecuteNonQuery();
                baglantiAyarla();
            }, nameOfClass);
            return _returnValue;
        }
    }
}
