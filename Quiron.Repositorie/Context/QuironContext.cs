using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quiron.Data.Configuration;
using Quiron.Domain.Entities;

namespace Quiron.Data.Context
{
    public class QuironContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public QuironContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public QuironContext(DbContextOptions<QuironContext> options) : base(options)
        {
        }

        public DbSet<Espaco> Espaco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EspacoConfig());

            modelBuilder.Entity<Espaco>().HasData(
                new Espaco("Salão de Festas"),
                new Espaco("Piscina"),
                new Espaco("Churrasqueira"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration != null)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}