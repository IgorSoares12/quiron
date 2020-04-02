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
    public class EspacoService : IEspacoService
    {
        private readonly IMapper _mapper;
        private readonly IEspacoRepository _espacoRepository;

        public EspacoService(IMapper mapper, IEspacoRepository espacoRepository)
        {
            _mapper = mapper;
            _espacoRepository = espacoRepository;
        }

        public void Create(EspacoDto espacoDto)
            => _espacoRepository.Create(_mapper.Map<Espaco>(espacoDto));

        public void Update(EspacoDto espacoDto)
            => _espacoRepository.Update(_mapper.Map<Espaco>(espacoDto));

        public void Remove(EspacoDto espacoDto)
            => _espacoRepository.Remove(_mapper.Map<Espaco>(espacoDto));

        public IQueryable<EspacoDto> GetAll()
            => _espacoRepository.GetAll().ProjectTo<EspacoDto>(_mapper.ConfigurationProvider);

        public EspacoDto FindById(Guid id)
            => _mapper.Map<EspacoDto>(_espacoRepository.FindById(id));

        public EspacoDto FindByDescricao(string descricao)
            => _mapper.Map<EspacoDto>(_espacoRepository.FindBy(e => e.Descricao.Equals(descricao)));
    }
}