using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;
using QuironNUnitTest.Comum;
using System.Linq;

namespace QuironNUnitTest.Repositories
{
    class EspacoRepositoryTest
    {
        private IEspacoRepository _espacoRepository;

        public EspacoRepositoryTest()
            => _espacoRepository = new EspacoRepository(UtilitariosTest.GetContext(), UtilitariosTest.GetMapper());

        [Test]
        public void CreateTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Create");
            _espacoRepository.Create(espaco);

            Espaco novoEspaco = _espacoRepository.FindById(espaco.Id);

            Assert.IsNotNull(novoEspaco);
        }

        [Test]
        public void UpdateTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Update");
            _espacoRepository.Create(espaco);

            espaco.Descricao = "Espaco Atualizado";
            _espacoRepository.Update(espaco);

            Espaco espacoAtualizado = _espacoRepository.FindBy(e => e.Descricao.Equals("Espaco Atualizado"));

            Assert.IsNotNull(espacoAtualizado);
        }

        [Test]
        public void RemoveTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Remove");
            _espacoRepository.Create(espaco);

            _espacoRepository.Remove(espaco);
            Espaco espacoRemovido = _espacoRepository.FindById(espaco.Id);

            Assert.IsNull(espacoRemovido);
        }

        [Test]
        public void GetAllTest()
        {
            IQueryable<Espaco> espacos = _espacoRepository.GetAll();
            Assert.IsNotNull(espacos);
        }

        [Test]
        public void FindByTest()
        {
            Espaco espaco = new Espaco("Espaço Teste FindBy");
            _espacoRepository.Create(espaco);

            Espaco espacoPesquisa = _espacoRepository.FindBy(e => e.Id.Equals(espaco.Id));
            Assert.IsNotNull(espacoPesquisa);
        }

        [Test]
        public void FindByIdTest()
        {
            Espaco espaco = new Espaco("Espaço Teste FindById");
            _espacoRepository.Create(espaco);

            Espaco espacoPesquisa = _espacoRepository.FindById(espaco.Id);
            Assert.IsNotNull(espacoPesquisa);
        }

        [Test]
        public void FindAllByTest()
        {
            Espaco espaco = new Espaco("Espaço Teste FindAllBy");
            _espacoRepository.Create(espaco);

            IQueryable<Espaco> espacos = _espacoRepository.FindAllBy(e => e.Id.Equals(espaco.Id));
            Assert.IsNotNull(espacos);
        }
    }
}