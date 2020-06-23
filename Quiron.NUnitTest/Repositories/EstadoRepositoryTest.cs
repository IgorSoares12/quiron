using NUnit.Framework;
using Quiron.Data.Repositories;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Data;
using QuironNUnitTest.Comum;
using System.Linq;

namespace QuironNUnitTest.Repositories
{
    class EstadoRepositoryTest
    {
        private IEstadoRepository _estadoRepository;

        public EstadoRepositoryTest()
            => _estadoRepository = new EstadoRepository(UtilitariosTest.GetContext(), UtilitariosTest.GetMapper());

        [Test]
        public void CreateTest()
        {
            Estado estado = new Estado("CE", "Estado Teste Create");
            _estadoRepository.Create(estado);

            Estado novoEstado = _estadoRepository.FindById(estado.Id);

            Assert.IsNotNull(novoEstado);
        }

        [Test]
        public void UpdateTest()
        {
            Estado estado = new Estado("CE", "Estado Teste Update");
            _estadoRepository.Create(estado);

            estado.Descricao = "Estado Atualizado";
            _estadoRepository.Update(estado);

            Estado estadoAtualizado = _estadoRepository.FindBy(e => e.Descricao.Equals("Estado Atualizado"));

            Assert.IsNotNull(estadoAtualizado);
        }

        [Test]
        public void RemoveTest()
        {
            Estado estado = new Estado("CE", "Estado Teste Remove");
            _estadoRepository.Create(estado);

            _estadoRepository.Remove(estado);
            Estado estadoRemovido = _estadoRepository.FindById(estado.Id);

            Assert.IsNull(estadoRemovido);
        }

        [Test]
        public void GetAllTest()
        {
            IQueryable<Estado> estados = _estadoRepository.GetAll();
            Assert.IsNotNull(estados);
        }

        [Test]
        public void FindByTest()
        {
            Estado estado = new Estado("CE", "Estado Teste FindBy");
            _estadoRepository.Create(estado);

            Estado estadoPesquisa = _estadoRepository.FindBy(e => e.Id.Equals(estado.Id));
            Assert.IsNotNull(estadoPesquisa);
        }

        [Test]
        public void FindByIdTest()
        {
            Estado estado = new Estado("CE", "Estado Teste FindById");
            _estadoRepository.Create(estado);

            Estado estadoPesquisa = _estadoRepository.FindById(estado.Id);
            Assert.IsNotNull(estadoPesquisa);
        }

        [Test]
        public void FindAllByTest()
        {
            Estado estado = new Estado("CE", "Estado Teste FindAllBy");
            _estadoRepository.Create(estado);

            IQueryable<Estado> estados = _estadoRepository.FindAllBy(e => e.Id.Equals(estado.Id));
            Assert.IsNotNull(estados);
        }
    }
}