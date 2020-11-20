using Entities;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
namespace StaticsClass
{
    public static class StaticsMethods
    {
        private static string nameofproject = "StaticsMethods";
        // kullanıcı propertisinde aktif olan kullanıcı bilgisini tutuyoruz. 
        public static Kullanici _kullanici { get; set; }
        public static Kullanici kullaniciKim(Kullanici kullanici)
        {
            _kullanici = kullanici;
            return kullanici;
        }
        //email gönderme işlemi için yazılan metot.
        public static void emailGonder(string kime, string konu, string icerik, string attachmentPath = "Dosya yok")
        {
            Encoding encode = Encoding.GetEncoding("windows-1254");//türkçe karakter sorunu yaşamamk  için 
            MailMessage Email = new MailMessage();
            Email.To.Add(kime);
            MailAddress mailFrom = new MailAddress("caglar.yurdakul60@gmail.com", "Caglar-Gmail", encode);
            Email.From = mailFrom;
            //Email.CC.Add("");//Emailini alan kişi liste içerisinde tanımlı olan kişi veya kişileri görebilir.
            //Email.Bcc.Add("");// bu alanda kişi eklenen kişileri göremez.
            Email.Subject = konu;
            Email.Body = icerik;
            Email.IsBodyHtml = true;
            if (attachmentPath != "Dosya yok") Email.Attachments.Add(new Attachment(attachmentPath));
            SmtpClient smtpMail = new SmtpClient("smtp.gmail.com", 587);
            smtpMail.Credentials = new System.Net.NetworkCredential("caglar.yurdakul60@gmail.com", "e-mail şifresi yazılacak.");
            smtpMail.EnableSsl = true;
            smtpMail.Send(Email);
        }
        #region DATABASE
        // Database Bağlantı ayarları için 
        public static SqlConnection _sqlBaglanti { get; set; }
        public static SqlConnection sqlBaglanti(string connectionString)
        {
            Logger.LogTryCatch.TryCatch(() =>
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
                _sqlBaglanti = connection;
            }, nameofproject);
            return _sqlBaglanti;
        }
        //sql database içerisinde ayrı bir initial catolog geçisi yapmak için 2 adet metot yazıldı.
        //Sql server authentication için olan metot.
        public static SqlConnection changeinitialCatalog(string initialCatalog, string userID, string password)
        {
            SqlConnection degismisBaglanti = null;
            if (_sqlBaglanti != null)
            {
                string connectionString = _sqlBaglanti.ConnectionString;
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.DataSource = _sqlBaglanti.DataSource;
                sqlConnectionStringBuilder.InitialCatalog = initialCatalog;
                sqlConnectionStringBuilder.UserID = userID;
                sqlConnectionStringBuilder.Password = password;
                degismisBaglanti = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            }
            return degismisBaglanti;
        }
        //windows authentication için olan metot.
        public static SqlConnection changeinitialCatalog(string initialCatalog)
        {
            SqlConnection degismisBaglanti = null;
            if (_sqlBaglanti != null)
            {
                string connectionString = _sqlBaglanti.ConnectionString;
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.DataSource = _sqlBaglanti.DataSource;
                sqlConnectionStringBuilder.InitialCatalog = initialCatalog;
                sqlConnectionStringBuilder.IntegratedSecurity = true;
                degismisBaglanti = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            }
            return degismisBaglanti;
        }
        #endregion
        #region EF static classes
      
        #endregion
    }
}
