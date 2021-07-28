using Microsoft.EntityFrameworkCore;
using MicwayCodeChallenge.Entities;
using MicwayCodeChallenge.EntityConfigurations;

namespace MicwayCodeChallenge.DbContexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<Driver> Drivers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DriverConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}