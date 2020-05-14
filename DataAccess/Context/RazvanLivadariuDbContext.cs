using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class RazvanLivadariuDbContext : DbContext
    {
        public RazvanLivadariuDbContext()
            : base("Server=desktop-sll1hic\\sqlexpress;Database=RazvanLivadariuDB;Trusted_Connection=True;")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }

     
    }
}
