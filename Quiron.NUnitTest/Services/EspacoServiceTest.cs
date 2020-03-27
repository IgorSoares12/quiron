using AutoMapper;
using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Dto;
using Quiron.Domain.Interfaces.Data;
using Quiron.Domain.Interfaces.Services;
using Quiron.Service.Services;
using QuironNUnitTest.Comun;
using System.Linq;

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

            EspacoDto novoEspaco = _espacoService.FindById(espaco.Id);

            Assert.IsNotNull(novoEspaco, "Espaço não foi cadastrado.");
        }

        [Test]
        public void UpdateTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste Update");
            _espacoService.Create(espaco);

            EspacoDto espacoCriado = _espacoService.FindById(espaco.Id);
            espacoCriado.Descricao = "Espaco Atualizado";

            _espacoService.Update(espacoCriado);
            EspacoDto espacoAtualizado = _espacoService.FindByDescricao("Espaco Atualizado");

            Assert.IsNotNull(espacoAtualizado, "Espaço não foi atualizado.");
        }

        [Test]
        public void RemoveTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste Update");
            _espacoService.Create(espaco);

            EspacoDto espacoCriado = _espacoService.FindById(espaco.Id);

            _espacoService.Remove(espacoCriado);
            EspacoDto espacoRemovido = _espacoService.FindById(espaco.Id);

            Assert.IsNull(espacoRemovido, "Espaço não foi removido.");
        }

        [Test]
        public void GetAllTest()
        {
            IQueryable<EspacoDto> espacos = _espacoService.GetAll();
            Assert.IsNotNull(espacos, "Não foram retornados todos os espaços.");
        }

        [Test]
        public void FindByIdTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste FindById");
            _espacoService.Create(espaco);

            EspacoDto espacoPesquisa = _espacoService.FindById(espaco.Id);
            Assert.IsNotNull(espacoPesquisa, "O espaço não foi retornado.");
        }

        [Test]
        public void FindByDescricaoTest()
        {
            EspacoDto espaco = new EspacoDto("Espaço Teste FindByDescricao");
            _espacoService.Create(espaco);

            EspacoDto espacoPesquisa = _espacoService.FindByDescricao(espaco.Descricao);
            Assert.IsNotNull(espacoPesquisa, "O espaço não foi retornado.");
        }
    }
}