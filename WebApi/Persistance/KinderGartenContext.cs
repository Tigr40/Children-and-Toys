using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Persistance
{
    public class KinderGartenContext : DbContext
    {
        public DbSet<Child> children { get; set; }
        public DbSet<Toy> toys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = KinderGarten.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>().HasKey(sc => new {sc.Id});
            modelBuilder.Entity<Toy>().HasKey(sc => new {sc.Id});
        }
    }
}