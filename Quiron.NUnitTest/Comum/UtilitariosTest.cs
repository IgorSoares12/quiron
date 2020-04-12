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
                    .UseNpgsql("Host=127.0.0.1;Database=Quiron;Username=postgres;Password=1234;")
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