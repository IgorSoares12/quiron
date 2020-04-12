using Quiron.Data.Comun;
using Quiron.Data.Context;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;

namespace Quiron.Data.Repositories
{
    public class EspacoRepository : Repository<Espaco>, IEspacoRepository
    {
        public EspacoRepository(QuironContext context) : base(context)
        {
        }
    }
}