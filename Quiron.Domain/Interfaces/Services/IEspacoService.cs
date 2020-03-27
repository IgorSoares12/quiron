using Quiron.Domain.Dto;
using Quiron.Domain.Interfaces.Commun;

namespace Quiron.Domain.Interfaces.Services
{
    public interface IEspacoService : IService<EspacoDto>
    {
        EspacoDto FindByDescricao(string descricao);
    }
}