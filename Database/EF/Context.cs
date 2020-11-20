using System.Data.Entity;
using Entities;
namespace Database.EF
{
    public class Context : DbContext
    {
        public static string whichConnectionString;
        public Context() : base(whichConnectionString)
        {
        }
        public DbSet<Entities.EF.liste2019> liste2019 { get; set; }
        public DbSet<Entities.EF.liste2018> liste2018 { get; set; }
        public DbSet<Entities.EF.DILEKCE2019> DILEKCE2019 { get; set; }
        public DbSet<Entities.EF.DILEKCE2018> DILEKCE2018 { get; set; }
    }
}
