using Quiron.Data.Comun;
using Quiron.Data.Context;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;

namespace Quiron.Data.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(QuironContext context) : base(context)
        {
        }
    }
}