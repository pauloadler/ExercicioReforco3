using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Salas;
using ExercicioReforco3.Domain.Features.Salas;
using ExercicioReforco3.Infra.Data.Features.Salas;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco3.Infra.Data.Tests.Features.Salas
{
    [TestFixture]
    public class SalaRepositoryTests
    {
        SalaRepository _salaRepository;
        Sala _salaDefault;

        [SetUp]
        public void SalaRepositoryTestsTestSetUp()
        {
           BaseSqlTest.SeedDeleteDatabase();
           BaseSqlTest.SeedInsertDatabase();

            _salaRepository = new SalaRepository();
            _salaDefault = SalaObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Uma_Nova_Sala()
        {
            //Action-Arrange
            Sala resultSala = _salaRepository.Save(_salaDefault);

            //Assert
            Sala resultGet = _salaRepository.Get(resultSala.Id);

            resultSala.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultSala.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Sala()
        {
            //Arrange
            Sala salaResult = _salaRepository.Save(_salaDefault);
            salaResult.Nome = "Nome Update";

            //Action
            _salaRepository.Update(salaResult);

            //Assert
            Sala resultGet = _salaRepository.Get(salaResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(salaResult.Id);
            resultGet.Nome.Should().Be("Nome Update");
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Sala()
        {
            //Arrange
            Sala resultSala = _salaRepository.Save(_salaDefault);

            //Action
            Sala resultGet = _salaRepository.Get(resultSala.Id);

            //Assert
            resultSala.Nome.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultSala);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Salas()
        {
            //Arrange 
            Sala resultSala = _salaRepository.Save(_salaDefault);

            //Action
            List<Sala> resultGetAll = _salaRepository.GetAll();

            //Assert
            var ultimaSala = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(3);
            ultimaSala.Should().Equals(_salaDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Sala()
        {
            //Arrange 
            Sala resultSala = _salaRepository.Save(_salaDefault);

            //Action
            _salaRepository.Delete(resultSala);

            //Assert
            Sala resultGet = _salaRepository.Get(resultSala.Id);
            List<Sala> resultGetAll = _salaRepository.GetAll();

            resultGet.Should().BeNull();
            resultGetAll.Should().HaveCount(2);
        }

        [TearDown]
        public void LimparDataBase()
        {
            BaseSqlTest.SeedDeleteDatabase();
        }
    }
}
