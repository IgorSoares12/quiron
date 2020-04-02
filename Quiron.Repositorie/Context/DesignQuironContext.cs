using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Quiron.Data.Context
{
    public class DesignQuironContext : IDesignTimeDbContextFactory<QuironContext>
    {
        public QuironContext CreateDbContext(string[] args)
        {
            var local = @"Data Source=GLERYSTON-PC\SQLEXPRESS;Initial Catalog=Quiron;Persist Security Info=True;User ID=sa;Password=1234";
            DbContextOptionsBuilder<QuironContext> builder = new DbContextOptionsBuilder<QuironContext>();
            builder.UseSqlServer(local);
            return new QuironContext(builder.Options);
        }
    }
}