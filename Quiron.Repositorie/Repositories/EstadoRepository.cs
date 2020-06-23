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
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        private readonly IMapper _mapper;

        public EstadoRepository(QuironContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public new EstadoDto FindById(Guid id)
            => _context.Set<Estado>().Where(e => e.Id.Equals(id)).ProjectTo<EstadoDto>(_mapper.ConfigurationProvider).FirstOrDefault();

        public new EstadoDto FindBy(Expression<Func<Estado, bool>> predicate)
            => _context.Set<Estado>().Where(predicate).ProjectTo<EstadoDto>(_mapper.ConfigurationProvider).FirstOrDefault();
    }
}