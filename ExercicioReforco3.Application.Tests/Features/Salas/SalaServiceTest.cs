using ExercicioReforco3.Application.Features.Salas;
using ExercicioReforco3.Common.Tests.Features.Salas;
using ExercicioReforco3.Domain.Features.Salas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Tests.Features.Salas
{
    [TestFixture]
    public class SalaServiceTest
    {
        Mock<ISalaRepository> _salaRepositoryMockObject;
        SalaService _salaService;
        Sala _salaefaultWithId;

        [SetUp]
        public void SalaServiceTestSetUp()
        {
            _salaRepositoryMockObject = new Mock<ISalaRepository>();
            _salaService = new SalaService(_salaRepositoryMockObject.Object);
            _salaefaultWithId = SalaObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Nova_Sala()
        {
            //Arrange
            _salaRepositoryMockObject.Setup(p => p.Save(It.IsAny<Sala>())).Returns(_salaefaultWithId);

            //Action 
            Sala retornoSala = _salaService.Add(_salaefaultWithId);

            //Assert
            _salaRepositoryMockObject.Verify(p => p.Save(It.IsAny<Sala>()));
            _salaRepositoryMockObject.Verify(p => p.Save(It.IsAny<Sala>()), Times.Once());
            retornoSala.Id.Should().BeGreaterThan(0);
            retornoSala.Id.Should().Be(_salaefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_Da_Sala()
        {
            //Arrange
            _salaRepositoryMockObject.Setup(p => p.Update(It.IsAny<Sala>()));

            //Action
            Action actionSalaUpdate = () => { _salaService.Update(_salaefaultWithId); };

            //Assert
            actionSalaUpdate.Should().NotThrow<Exception>();
            _salaRepositoryMockObject.Verify(p => p.Update(It.IsAny<Sala>()), Times.Once());
            _salaRepositoryMockObject.Verify(p => p.Update(It.IsAny<Sala>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Sala()
        {
            //Arrange
            _salaRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_salaefaultWithId);

            //Action 
            Sala retornoSala = _salaService.Get(_salaefaultWithId.Id);

            //Assert
            _salaRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _salaRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoSala.Id.Should().BeGreaterThan(0);
            retornoSala.Id.Should().Be(_salaefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Salas()
        {
            //Arrange
            List<Sala> _salaDefaultList = SalaObjectMother.DefaultList;

            _salaRepositoryMockObject.Setup(p => p.GetAll()).Returns(_salaDefaultList);

            //Action
            var resultSalas = _salaService.GetAll();

            //Assert
            _salaRepositoryMockObject.Verify(x => x.GetAll());
            resultSalas.Should().NotBeEmpty();
            resultSalas.Should().HaveCount(3);
        }

        [Test]
        public void ConsultarTodasSalasDisponiveis_Deveria_Retornar_As_Salas_Disponiveis()
        {
            //Arrange
            List<Sala> _salaDefaultList = SalaObjectMother.DefaultList;

            _salaRepositoryMockObject.Setup(p => p.GetAllSalasDisponiveis()).Returns(_salaDefaultList);

            //Action
            var resultSalasDisponiveis = _salaService.ConsultarTodasSalasDisponiveis();

            //Assert
            _salaRepositoryMockObject.Verify(x => x.GetAllSalasDisponiveis());
            resultSalasDisponiveis.Should().NotBeEmpty();
            resultSalasDisponiveis.Should().HaveCount(3);
        }

        [Test]
        public void ConsultarTodasSalasDisponiveis_Deveria_Retornar_Excessao_Quando_Nao_Tiver_Salas_Disponiveis()
        {
            //Arrange
            List<Sala> _salaDefaultList = new List<Sala>();

            _salaRepositoryMockObject.Setup(p => p.GetAllSalasDisponiveis()).Returns(_salaDefaultList);

            //Action
            Action resultSalasDisponiveis = () => _salaService.ConsultarTodasSalasDisponiveis();

            //Assert
            resultSalasDisponiveis.Should().Throw<NenhumaSalaDisponivelExcessao>();
            _salaRepositoryMockObject.Verify(x => x.GetAllSalasDisponiveis());
            
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Sala()
        {
            //Arrange
            _salaRepositoryMockObject.Setup(x => x.Delete(_salaefaultWithId));

            //Action
            Action salaDeleteAction = () => _salaService.Delete(_salaefaultWithId);

            //Assert
            salaDeleteAction.Should().NotThrow<Exception>();
            _salaRepositoryMockObject.Verify(x => x.Delete(_salaefaultWithId), Times.Once());
            _salaRepositoryMockObject.Verify(x => x.Delete(_salaefaultWithId));
        }
    }
}

