using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Business.BusinessLogicService
{
    public class CiftciService : BaseService<Ciftci>, IBusinessBase<Ciftci, string>
    {
        Database.CiftciDAL dll;
        ValidationRules.FluentValidation.CiftciValidator ciftciValidator;
        public CiftciService()
        {
            dll = new Database.CiftciDAL();
            ciftciValidator = new ValidationRules.FluentValidation.CiftciValidator();
        }
        public void Delete(Ciftci Entity, string nameOfList)
        {
            DialogResult dr = MesajKutusu.Question($"{Entity.dilekceno} dilekce numaralı kaydı {nameOfList} listesinden silmek istiyor musunuz?");
            if (dr == DialogResult.Yes)
            {
                string sql = "delete from " + nameOfList + " where dilekceno=@dilekceno";
                _sqlCommand = new SqlCommand(sql);
                _sqlCommand.Parameters.AddWithValue("@dilekceno", SqlDbType.Int).Value = Entity.dilekceno;
                dll.AddUpdateDelete(_sqlCommand);
            }
        }
        public Ciftci Get(string tcNumarasi, string nameOfList)
        {
            Ciftci ciftci = new Ciftci();
            string sql = "select * from " + nameOfList + " where tc=@tc";
            _sqlCommand = new SqlCommand(sql);
            _sqlCommand.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = tcNumarasi;
            _sqlDataReader = dll.GetAll(_sqlCommand);
            while (_sqlDataReader.Read())
            {
                ciftci.dilekceno = (int)_sqlDataReader["dilekceno"];
                ciftci.tc = _sqlDataReader["tc"].ToString();
                ciftci.isim = _sqlDataReader["isim"].ToString();
                ciftci.soyisim = _sqlDataReader["soyisim"].ToString();
                ciftci.mahalle = _sqlDataReader["mahalle"].ToString();
                ciftci.tarih = (DateTime)_sqlDataReader["tarih"];
                ciftci.aciklama = _sqlDataReader["aciklama"].ToString();
                ciftci.telefon = _sqlDataReader["telefon"].ToString();
                ciftci.KayitDurumu = _sqlDataReader.IsDBNull(9) ? 0 : (int)_sqlDataReader["kayitdurumu"];
            }
            _sqlDataReader.Close();
            dll._sqlConnection.Close();
            return ciftci;
        }
        public Ciftci Get(int dilekceNo, string nameOfList)
        {
            Ciftci ciftci = new Ciftci();
            string sql = "select * from " + nameOfList + " where dilekceno=@dilekceno";
            _sqlCommand = new SqlCommand(sql);
            _sqlCommand.Parameters.AddWithValue("@dilekceno", SqlDbType.Int).Value = dilekceNo;
            _sqlDataReader = dll.GetAll(_sqlCommand);
            while (_sqlDataReader.Read())
            {
                ciftci.dilekceno = (int)_sqlDataReader["dilekceno"];
                ciftci.tc = _sqlDataReader["tc"].ToString();
                ciftci.isim = _sqlDataReader["isim"].ToString();
                ciftci.soyisim = _sqlDataReader["soyisim"].ToString();
                ciftci.mahalle = _sqlDataReader["mahalle"].ToString();
                ciftci.tarih = (DateTime)_sqlDataReader["tarih"];
                ciftci.aciklama = _sqlDataReader["aciklama"].ToString();
                ciftci.telefon = _sqlDataReader["telefon"].ToString();
                ciftci.KayitDurumu = _sqlDataReader.IsDBNull(9) ? 0 : (int)_sqlDataReader["kayitdurumu"];
            }
            _sqlDataReader.Close();
            dll._sqlConnection.Close();
            return ciftci;
        }
        public List<Ciftci> GetAll(string nameOfList)
        {
            _liste = new List<Ciftci>();
            string sql = "";
            if (nameOfList != "DILEKCE2018" && nameOfList != "DILEKCE2019")
            {
                sql = "select * from " + nameOfList + " order by dilekceno desc";
            }
            else
            {
                sql = "select * from " + nameOfList + " order by tarih desc";
            }
            _sqlCommand = new SqlCommand(sql);
            _sqlDataReader = dll.GetAll(_sqlCommand);
            while (_sqlDataReader.Read())
            {
                Ciftci ciftci = new Ciftci();
                ciftci.dilekceno = (int)_sqlDataReader["dilekceno"];
                ciftci.tc = _sqlDataReader["tc"].ToString();
                ciftci.isim = _sqlDataReader["isim"].ToString();
                ciftci.soyisim = _sqlDataReader["soyisim"].ToString();
                ciftci.mahalle = _sqlDataReader["mahalle"].ToString();
                ciftci.tarih = (DateTime)_sqlDataReader["tarih"];
                ciftci.aciklama = _sqlDataReader["aciklama"].ToString();
                ciftci.telefon = _sqlDataReader["telefon"].ToString();
                ciftci.KayitDurumu = _sqlDataReader.IsDBNull(9) ? 0 : (int)_sqlDataReader["kayitdurumu"];
                _liste.Add(ciftci);
            }
            _sqlDataReader.Close();
            dll._sqlConnection.Close();
            return _liste;
            ////if (nameOfList=="liste2018")
            ////{
            ////    Database.EF.Dal2018 dal = new Database.EF.Dal2018();
            ////    List<Entities.EF.liste2018> gelenListe = dal.GetAll().ToList();
            ////    List<Ciftci> ciftciler = new List<Ciftci>();
            ////    foreach (var item in gelenListe)
            ////    {
            ////        Ciftci c = new Ciftci();
            ////        c.aciklama = item.aciklama;
            ////        c.dilekceno = item.dilekceno;
            ////        c.isim = item.isim;
            ////        c.KayitDurumu =Convert.ToInt16( item.kayitdurumu);
            ////        c.mahalle = item.mahalle;
            ////        c.tarih = item.tarih;
            ////        c.tc = item.tc;
            ////        c.telefon = item.telefon;
            ////        c.soyisim = item.soyisim;
            ////        ciftciler.Add(c);
            ////    }
            ////    return ciftciler;
            ////}
            ////else
            ////{
            ////    return null;
            ////}
        }
        public List<Entities.EF.DILEKCE2019> GetAllFks2019(string EFListeSec)
        {
            List<Entities.EF.DILEKCE2019> liste = null;
            if (EFListeSec=="Dilekce2019")
            {
                Database.EF.DalDilekce2019 dal = new Database.EF.DalDilekce2019();
                liste= dal.GetAll().OrderByDescending(I=>I.dilekceno).ToList();
            }
           
            return liste;
        }
        public void Save(Ciftci ciftci, string nameOfList)
        {
            Validation(ciftci, () =>
            {
                //oncelikle gelen ciftci daha önce kayıt olmuş mu kontrolü yapılmalı.
                _data = Get(ciftci.tc, nameOfList);
                if (_data.tc == null)
                {
                    _returnInt = 0;
                    string sql = "insert into " + nameOfList + " (dilekceno,tc,isim,soyisim,mahalle,tarih,aciklama,telefon,kayitdurumu) values (@dilekceno,@tc,@isim,@soyisim,@mahalle,@tarih,@aciklama,@telefon,@kayitdurumu)";
                    string sql2 = "select max(dilekceno) from " + nameOfList + "";
                    _sqlCommand = new SqlCommand(sql2);
                    _returnObject = dll.Get(_sqlCommand);
                    int dilekceNumarasi = 0;
                    if (_returnObject != null) dilekceNumarasi = (int)_returnObject;
                    if (dilekceNumarasi >= 0)
                    {
                        _sqlCommand = new SqlCommand(sql);
                        if (nameOfList != "DILEKCE2018" && nameOfList != "DILEKCE2019")
                        {
                            ciftci.dilekceno = dilekceNumarasi + 1;
                            _sqlCommand.Parameters.AddWithValue("@dilekceno", SqlDbType.Int).Value = ciftci.dilekceno;
                        }
                        else
                        {
                            _sqlCommand.Parameters.AddWithValue("@dilekceno", SqlDbType.Int).Value = ciftci.dilekceno;
                        }
                        _sqlCommand.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = ciftci.tc;
                        _sqlCommand.Parameters.AddWithValue("@isim", SqlDbType.NVarChar).Value = ciftci.isim;
                        _sqlCommand.Parameters.AddWithValue("@soyisim", SqlDbType.NVarChar).Value = ciftci.soyisim;
                        _sqlCommand.Parameters.AddWithValue("@mahalle", SqlDbType.NVarChar).Value = ciftci.mahalle;
                        _sqlCommand.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = DateTime.Now;
                        _sqlCommand.Parameters.AddWithValue("@aciklama", SqlDbType.NVarChar).Value = ciftci.aciklama.ToLower();
                        _sqlCommand.Parameters.AddWithValue("@telefon", SqlDbType.NVarChar).Value = ciftci.telefon;
                        _sqlCommand.Parameters.AddWithValue("@kayitdurumu", SqlDbType.SmallInt).Value = ciftci.KayitDurumu;
                        _returnInt = dll.AddUpdateDelete(_sqlCommand);
                    }
                    if (_returnInt > 0)
                    {
                        MesajKutusu.information($"Kayıt işleminiz başarılı.\n{nameOfList} Dilekçe Numarasi : {ciftci.dilekceno}");
                    }
                }
                else
                {
                    MesajKutusu.error("Aynı Tc Numarası ile kayıt mevcuttur.");
                }
            });
        }
        public void Save2019(Ciftci ciftci)
        {
            Validation(ciftci, () =>
            {
                Database.EF.Dal2019 n = new Database.EF.Dal2019();
                Entities.EF.liste2019 kayit = n.Where(I => I.tc == ciftci.tc).FirstOrDefault();
                Entities.EF.liste2019 Sonkayit = n.GetAll().OrderByDescending(I => I.dilekceno).FirstOrDefault();
                if (kayit == null)
                {
                    n.CUDOperation(new Entities.EF.liste2019()
                    {
                        aciklama = ciftci.aciklama,
                        dilekceno = Sonkayit.dilekceno + 1,
                        isim = ciftci.isim,
                        kayitdurumu = ciftci.KayitDurumu,
                        mahalle = ciftci.mahalle,
                        soyisim = ciftci.soyisim,
                        tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                        tc = ciftci.tc,
                        telefon = ciftci.telefon
                    }, System.Data.Entity.EntityState.Added);
                    int ReturnValue = n.SaveChange();
                    if (ReturnValue == 1)
                    {
                        MesajKutusu.information($"Kayıt işleminiz başarılı.\n2019 ÇKS Dilekçe Numarasi : {Sonkayit.dilekceno + 1}");
                    }
                }
                else
                {
                    MesajKutusu.error("Aynı Tc Numarası ile kayıt mevcuttur.");
                }
            });
        }
        public void SaveFks2019(Ciftci ciftci)
        {
            Validation(ciftci, () =>
            {
                Database.EF.DalDilekce2019 dal = new Database.EF.DalDilekce2019();
                dal.CUDOperation(new Entities.EF.DILEKCE2019()
                {
                    aciklama = ciftci.aciklama,
                    dilekceno = ciftci.dilekceno,
                    isim = ciftci.isim,
                    kayitdurumu = ciftci.KayitDurumu,
                    mahalle = ciftci.mahalle,
                    soyisim = ciftci.soyisim,
                    tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    tc = ciftci.tc,
                    telefon = ciftci.telefon
                }, System.Data.Entity.EntityState.Added);
                dal.SaveChange();
            });
        }
        private void Validation(Ciftci ciftci, Action action)
        {
            try
            {
                var result = ciftciValidator.Validate(ciftci);
                if (result.Errors.Count > 0)
                {
                    throw new ValidationException(result.ToString());
                }
                action.Invoke();
            }
            catch (Exception exception)
            {
                Logger.LogTryCatch.TryCatch(exception, "CiftciService-Save Method");
                MesajKutusu.warning(exception.Message);
            }
        }
        public void Update(Ciftci ciftci, string nameOfList)
        {
            string sql = "update " + nameOfList + " set tc=@tc,isim=@isim,soyisim=@soyisim,mahalle=@mahalle,aciklama=@aciklama,telefon=@telefon,kayitdurumu=@kayitdurumu where dilekceno=@dilekceno";
            _sqlCommand = new SqlCommand(sql);
            _sqlCommand.Parameters.AddWithValue("@dilekceno", SqlDbType.Int).Value = ciftci.dilekceno;
            _sqlCommand.Parameters.AddWithValue("@tc", SqlDbType.NVarChar).Value = ciftci.tc;
            _sqlCommand.Parameters.AddWithValue("@isim", SqlDbType.NVarChar).Value = ciftci.isim;
            _sqlCommand.Parameters.AddWithValue("@soyisim", SqlDbType.NVarChar).Value = ciftci.soyisim;
            _sqlCommand.Parameters.AddWithValue("@mahalle", SqlDbType.NVarChar).Value = ciftci.mahalle;
            _sqlCommand.Parameters.AddWithValue("@aciklama", SqlDbType.NVarChar).Value = ciftci.aciklama.ToLower();
            _sqlCommand.Parameters.AddWithValue("@telefon", SqlDbType.NVarChar).Value = ciftci.telefon;
            _sqlCommand.Parameters.AddWithValue("@kayitdurumu", SqlDbType.SmallInt).Value = ciftci.KayitDurumu;
            dll.AddUpdateDelete(_sqlCommand);
        }
        public List<Ciftci> Search(string tcNumarasi, string nameOfList)
        {
            _liste = GetAll(nameOfList);
            _data = _liste.Find(x => x.tc == tcNumarasi);
            _liste = null;
            _liste = new List<Ciftci>();
            _liste.Add(_data);
            return _liste;
        }
    }
}
