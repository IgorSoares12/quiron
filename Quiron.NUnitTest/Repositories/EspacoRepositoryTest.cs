using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;
using QuironNUnitTest.Comun;
using System.Linq;

namespace QuironNUnitTest.Repositories
{
    class EspacoRepositoryTest
    {
        private IEspacoRepository _espacoRepository;

        public EspacoRepositoryTest()
            => _espacoRepository = new EspacoRepository(UtilitariosTest.GetContext());

        [Test]
        public void CreateTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Create");
            _espacoRepository.Create(espaco);

            Espaco novoEspaco = _espacoRepository.FindBy(e => e.Id.Equals(espaco.Id));

            Assert.IsNotNull(novoEspaco, "Espaço não foi cadastrado.");
        }

        [Test]
        public void UpdateTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Update");
            _espacoRepository.Create(espaco);

            Espaco espacoCriado = _espacoRepository.FindBy(e => e.Id.Equals(espaco.Id));
            espacoCriado.Descricao = "Espaco Atualizado";

            _espacoRepository.Update(espacoCriado);
            Espaco espacoAtualizado = _espacoRepository.FindBy(e => e.Descricao.Equals("Espaco Atualizado"));

            Assert.IsNotNull(espacoAtualizado, "Espaço não foi atualizado.");
        }

        [Test]
        public void RemoveTest()
        {
            Espaco espaco = new Espaco("Espaço Teste Delete");
            _espacoRepository.Create(espaco);

            Espaco espacoCriado = _espacoRepository.FindBy(e => e.Id.Equals(espaco.Id));

            _espacoRepository.Remove(espacoCriado);
            Espaco espacoRemovido = _espacoRepository.FindBy(e => e.Id.Equals(espacoCriado.Id));

            Assert.IsNull(espacoRemovido, "Espaço não foi removido.");
        }

        [Test]
        public void GetAllTest()
        {
            IQueryable<Espaco> espacos = _espacoRepository.GetAll();
            Assert.IsNotNull(espacos, "Não foram retornados todos os espaços.");
        }

        [Test]
        public void FindByTest()
        {
            Espaco espaco = new Espaco("Espaço Teste FindBy");
            _espacoRepository.Create(espaco);

            Espaco espacoPesquisa = _espacoRepository.FindBy(e => e.Id.Equals(espaco.Id));
            Assert.IsNotNull(espacoPesquisa, "O espaço não foi retornado.");
        }

        [Test]
        public void FindAllByTest()
        {
            Espaco espaco = new Espaco("Espaço Teste FindAllBy");
            _espacoRepository.Create(espaco);

            IQueryable<Espaco> espacos = _espacoRepository.FindAllBy(e => e.Id.Equals(espaco.Id));
            Assert.IsNotNull(espacos, "Não foram retornados todos os espaços.");
        }
    }
}