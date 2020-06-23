using AutoMapper;
using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Dto;
using Quiron.Domain.Interfaces.Data;
using Quiron.Domain.Interfaces.Services;
using Quiron.Service.Services;
using QuironNUnitTest.Comum;

namespace QuironNUnitTest.Services
{
    public class EstadoServiceTest
    {
        private IMapper _mapper;
        private IEstadoRepository _estadoRepository;
        private IEstadoService _estadoService;

        public EstadoServiceTest()
        {
            _mapper = UtilitariosTest.GetMapper();
            _estadoRepository = new EstadoRepository(UtilitariosTest.GetContext(), _mapper);
            _estadoService = new EstadoService(_mapper, _estadoRepository);
        }

        [Test]
        public void CreateTest()
        {
            EstadoDto estado = new EstadoDto("CE", "Estado Teste Create");
            _estadoService.Create(estado);

            Assert.IsNotNull(_estadoService.FindById(estado.Id));
        }

        [Test]
        public void UpdateTest()
        {
            EstadoDto estado = new EstadoDto("CE", "Estado Teste Update");
            _estadoService.Create(estado);

            estado.Descricao = "Estado Atualizado";

            _estadoService.Update(estado);
            EstadoDto estadoAtualizada = _estadoService.FindById(estado.Id);

            Assert.IsTrue(estadoAtualizada.Descricao.Equals("Estado Atualizado"));
        }

        [Test]
        public void RemoveTest()
        {
            EstadoDto estado = new EstadoDto("CE", "Estado Teste Remove");
            _estadoService.Create(estado);

            _estadoService.Remove(estado);
            Assert.IsNull(_estadoService.FindById(estado.Id));
        }

        [Test]
        public void GetAllTest()
            => Assert.IsNotNull(_estadoService.GetAll());

        [Test]
        public void FindByIdTest()
        {
            EstadoDto estado = new EstadoDto("CE", "Estado Teste FindById");
            _estadoService.Create(estado);

            Assert.IsNotNull(_estadoService.FindById(estado.Id));
        }

        [Test]
        public void FindByDescricaoTest()
        {
            EstadoDto estado = new EstadoDto("CE", "Estado Teste FindByDescricao");
            _estadoService.Create(estado);

            Assert.IsNotNull(_estadoService.FindByDescricao(estado.Descricao));
        }
    }
}