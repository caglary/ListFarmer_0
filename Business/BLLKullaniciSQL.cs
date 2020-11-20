using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
namespace Business
{
    public class BLLKullaniciSQL : IBusinessBase<Entities.Kullanici>
    {
        SqlConnection _baglanti;
        Database.KullanıcıDalSQL KullaniciDal;
        public BLLKullaniciSQL(SqlConnection baglanti)
        {
            
            KullaniciDal = new Database.KullanıcıDalSQL(baglanti);
            _baglanti = baglanti;
        }
     
        public void Delete(Kullanici Entity)
        {
           
        }
     
        public Kullanici Get(Kullanici Entity)
        {
            return KullaniciDal.Get(Entity);
        }
        public List<Kullanici> GetAll()
        {
            return KullaniciDal.GetAll();
        }
        public void Save(Kullanici Entity)
        {
         
        }
        public void Update(Kullanici Entity)
        {
          
           int retunValues= KullaniciDal.Update(Entity);
            if (retunValues > 0) MessageBox.Show("Güncelleme işlemi başarılı", "İşlem Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("İşlem BAŞARISIZ.", "İşlem Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
