using Quiron.Domain.Dto;
using Quiron.Domain.Interfaces.Commun;

namespace Quiron.Domain.Interfaces.Services
{
    public interface IEstadoService : IService<EstadoDto>
    {
        EstadoDto FindByDescricao(string descricao);
    }
}