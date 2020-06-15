using AutoMapper;
using AutoMapper.QueryableExtensions;
using Quiron.Domain.Dto;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;
using Quiron.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace Quiron.Service.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IMapper mapper, IEstadoRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public void Create(EstadoDto estadoDto)
            => _estadoRepository.Create(_mapper.Map<Estado>(estadoDto));

        public void Update(EstadoDto estadoDto)
            => _estadoRepository.Update(_mapper.Map<Estado>(estadoDto));

        public void Remove(EstadoDto estadoDto)
            => _estadoRepository.Remove(_mapper.Map<Estado>(estadoDto));

        public IQueryable<EstadoDto> GetAll()
            => _estadoRepository.GetAll().ProjectTo<EstadoDto>(_mapper.ConfigurationProvider);

        public EstadoDto FindById(Guid id)
            => _mapper.Map<EstadoDto>(_estadoRepository.FindById(id));

        public EstadoDto FindByDescricao(string descricao)
            => _mapper.Map<EstadoDto>(_estadoRepository.FindBy(e => e.Descricao.Equals(descricao)));
    }
}