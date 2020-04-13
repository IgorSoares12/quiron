using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Quiron.Data.Context
{
    public class DesignQuironContext : IDesignTimeDbContextFactory<QuironContext>
    {
        public QuironContext CreateDbContext(string[] args)
        {
            var local = "Host=ec2-18-209-187-54.compute-1.amazonaws.com;Database=d948lujo4ribs2;Username=agvnvejhcubyzp;Password=7f4989a7bd9b6e83dd8843034b08aaac06400ee2daf40cc6385a5e00a8b85108;";
            DbContextOptionsBuilder<QuironContext> builder = new DbContextOptionsBuilder<QuironContext>();
            builder.UseNpgsql(local);
            return new QuironContext(builder.Options);
        }
    }
}