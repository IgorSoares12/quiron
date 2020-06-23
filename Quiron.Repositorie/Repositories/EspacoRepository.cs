using AutoMapper;
using AutoMapper.QueryableExtensions;
using Quiron.Data.Comun;
using Quiron.Data.Context;
using Quiron.Domain.Dto;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quiron.Data.Repositories
{
    public class EspacoRepository : Repository<Espaco>, IEspacoRepository
    {
        private readonly IMapper _mapper;

        public EspacoRepository(QuironContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public new EspacoDto FindById(Guid id)
            => _context.Set<Espaco>().Where(e => e.Id.Equals(id)).ProjectTo<EspacoDto>(_mapper.ConfigurationProvider).FirstOrDefault();

        public new EspacoDto FindBy(Expression<Func<Espaco, bool>> predicate)
            => _context.Set<Espaco>().Where(predicate).ProjectTo<EspacoDto>(_mapper.ConfigurationProvider).FirstOrDefault();
    }
}