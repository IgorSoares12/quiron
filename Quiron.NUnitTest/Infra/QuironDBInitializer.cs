using Quiron.Data.Context;

namespace QuironNUnitTest.Infra
{
    class QuironDBInitializer
    {
        public QuironDBInitializer()
        {
        }

        public void Seed(QuironContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}