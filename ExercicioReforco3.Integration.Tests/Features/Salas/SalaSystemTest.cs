using ExercicioReforco3.Application.Features.Salas;
using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Salas;
using ExercicioReforco3.Domain.Features.Salas;
using ExercicioReforco3.Infra.Data.Features.Salas;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco3.Integration.Tests.Features.Salas
{
    [TestFixture]
    public class SalaSystemTest
    {
        ISalaRepository _salaRepository;
        SalaService _salaService;
        Sala _salaDefault;

        [SetUp]
        public void SalaSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _salaRepository = new SalaRepository();
            _salaService = new SalaService(_salaRepository);
            _salaDefault = SalaObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Sala_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Sala resultSala = _salaService.Add(_salaDefault);

            //Assert
            resultSala.Should().NotBeNull();
            resultSala.Id.Should().NotBe(0);

            Sala resultGet = _salaService.Get(resultSala.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultSala);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Sala_Pelo_Id()
        {
            //Arrange
            Sala resultSala = _salaService.Add(_salaDefault);
            resultSala.Nome = "Nome Atualizado";

            //Action 
            _salaService.Update(resultSala);

            //Assert
            Sala resultGet = _salaService.Get(resultSala.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultSala.Id);
            resultGet.Nome.Should().Be("Nome Atualizado");
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Sala_Pelo_Id()
        {
            //Arrange 
            Sala resultSala = _salaService.Add(_salaDefault);

            //Action
            Sala resultGet = _salaService.Get(resultSala.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultSala.Id);
            resultGet.Should().Equals(resultSala);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todas_Os_Sala()
        {
            //Arrange 
            Sala resultSala = _salaService.Add(_salaDefault);

            //Action
            List<Sala> resultGetAll = _salaService.GetAll();

            //Assert
            var ultimaSala = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(3);
            ultimaSala.Should().Equals(_salaDefault);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todas_As_Sala_Disponiveis()
        {
            //Arrange 
            Sala resultSala = _salaService.Add(_salaDefault);

            //Action
            List<Sala> resultGetAll = _salaService.ConsultarTodasSalasDisponiveis();

            //Assert
            var ultimaSala = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(3);
            ultimaSala.Should().Equals(_salaDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Sala_Pelo_Id()
        {
            Sala resultSala = _salaService.Add(_salaDefault);

            //Action
            _salaService.Delete(resultSala);

            //Assert
            Sala resultGet = _salaService.Get(resultSala.Id);
            List<Sala> resultGetAll = _salaService.GetAll();

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
