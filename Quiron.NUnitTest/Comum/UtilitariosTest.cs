using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiron.Data.Context;
using Quiron.Service.AutoMapper;
using QuironNUnitTest.Infra;

namespace QuironNUnitTest.Comum
{
    class UtilitariosTest
    {
        private static QuironContext quironContext;

        public static QuironContext GetContext()
        {
            if (quironContext == null)
            {
                DbContextOptions<QuironContext> dbContextOptions = new DbContextOptionsBuilder<QuironContext>()
                    .UseNpgsql("Host=ec2-18-209-187-54.compute-1.amazonaws.com;Database=d948lujo4ribs2;Username=agvnvejhcubyzp;Password=7f4989a7bd9b6e83dd8843034b08aaac06400ee2daf40cc6385a5e00a8b85108;")
                    .Options;

                quironContext = new QuironContext(dbContextOptions);
                QuironDBInitializer quironDBInitializer = new QuironDBInitializer();
                quironDBInitializer.Seed(quironContext);
            }

            return quironContext;
        }

        public static IMapper GetMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
            return mapperConfiguration.CreateMapper();
        }
    }
}