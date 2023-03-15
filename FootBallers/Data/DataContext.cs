using FootBallers.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBallers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Initialize();
        }

        private void Initialize()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Countries.Add(new Country { Id = new Guid(), Name = "Россия" });
            Countries.Add(new Country { Id = new Guid(), Name = "США" });
            Countries.Add(new Country { Id = new Guid(), Name = "Италия" });
            SaveChanges();
        }

        public DbSet<Footballer> Footballers => Set<Footballer>();
        public DbSet<Country> Countries => Set<Country>();
    }
}
