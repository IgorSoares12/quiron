using AutoMapper;
using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Dto;
using Quiron.Domain.Interfaces.Data;
using Quiron.Domain.Interfaces.Services;
using Quiron.Service.Services;
using QuironNUnitTest.Comun;

namespace QuironNUnitTest.Services
{
    public class EspacoServiceTest
    {
        private IMapper _mapper;
        private IEspacoRepository _espacoRepository;
        private IEspacoService _espacoService;

        public EspacoServiceTest()
        {
            _mapper = UtilitariosTest.GetMapper();
            _espacoRepository = new EspacoRepository(UtilitariosTest.GetContext());
            _espacoService = new EspacoService(_mapper, _espacoRepository);
        }

        [Test]
        public void CreateTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste Create");
            _espacoService.Create(espaco);

            Assert.IsNotNull(_espacoService.FindById(espaco.Id));
        }

        [Test]
        public void UpdateTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste Update");
            _espacoService.Create(espaco);

            espaco.Descricao = "Espaco Atualizado";

            _espacoService.Update(espaco);
            EspacoDto espacoAtualizada = _espacoService.FindById(espaco.Id);

            Assert.IsTrue(espacoAtualizada.Descricao.Equals("Espaco Atualizado"));
        }

        [Test]
        public void RemoveTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste Remove");
            _espacoService.Create(espaco);

            _espacoService.Remove(espaco);
            Assert.IsNull(_espacoService.FindById(espaco.Id));
        }

        [Test]
        public void GetAllTest()
            => Assert.IsNotNull(_espacoService.GetAll());

        [Test]
        public void FindByIdTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste FindById");
            _espacoService.Create(espaco);

            Assert.IsNotNull(_espacoService.FindById(espaco.Id));
        }

        [Test]
        public void FindByDescricaoTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste FindByDescricao");
            _espacoService.Create(espaco);

            Assert.IsNotNull(_espacoService.FindByDescricao(espaco.Descricao));
        }
    }
}