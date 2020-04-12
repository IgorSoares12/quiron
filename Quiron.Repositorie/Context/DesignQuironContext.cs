using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Quiron.Data.Context
{
    public class DesignQuironContext : IDesignTimeDbContextFactory<QuironContext>
    {
        public QuironContext CreateDbContext(string[] args)
        {
            var local = "Host=127.0.0.1;Database=Quiron;Username=postgres;Password=1234;";
            DbContextOptionsBuilder<QuironContext> builder = new DbContextOptionsBuilder<QuironContext>();
            builder.UseNpgsql(local);
            return new QuironContext(builder.Options);
        }
    }
}