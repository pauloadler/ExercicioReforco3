using ExercicioReforco3.Application.Features.Reunioes;
using ExercicioReforco3.Common.Tests.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Salas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Tests.Features.Reunioes
{
    [TestFixture]
    public class ReunioeserviceTest
    {
        Mock<IReuniaoRepository> _reuniaoRepositoryMockObject;
        Mock<Sala> _salaFake;


        ReuniaoService _Reunioeservice;
        Reuniao _reuniaoDefaultWithId;
        Reuniao _reuniaoDefault;


        [SetUp]
        public void ReunioeserviceTestSetUp()
        {
            _reuniaoRepositoryMockObject = new Mock<IReuniaoRepository>();

            _salaFake = new Mock<Sala>();

            _Reunioeservice = new ReuniaoService(_reuniaoRepositoryMockObject.Object);
            _reuniaoDefaultWithId = ReuniaoObjectMother.DefaultWithId;
            _reuniaoDefault = ReuniaoObjectMother.Default;
        }











        [Test]
        public void Alocacao_Deveria_incluir_Nova_Reuniao()
        {
            //Arrange
            List<Reuniao> reunioesSala = ReuniaoObjectMother.DefaultList;
         
            _reuniaoRepositoryMockObject.Setup(p => p.GetReuniaoBySalaId(It.IsAny<long>())).Returns(reunioesSala);
            _salaFake.Setup(s => s.ConsultarDisponibilidadeSala(It.IsAny<List<Reuniao>>(), It.IsAny<Reuniao>()));
            _reuniaoRepositoryMockObject.Setup(p => p.Save(It.IsAny<Reuniao>())).Returns(_reuniaoDefaultWithId);

            //Action 
            Reuniao retornoReuniao = _Reunioeservice.Alocacao(_reuniaoDefault);

            //Assert
            _reuniaoRepositoryMockObject.Verify(p => p.GetReuniaoBySalaId(It.IsAny<long>()), Times.Once());
            _reuniaoRepositoryMockObject.Verify(p => p.Save(It.IsAny<Reuniao>()), Times.Once());

            retornoReuniao.Id.Should().BeGreaterThan(0);
            retornoReuniao.Id.Should().Be(_reuniaoDefaultWithId.Id);
        }
        
        [Test]
        public void Realocao_Deveria_atualizar_Os_Dados_De_Reuniao()
        {
            //Arrange
            List<Reuniao> reunioesSala = ReuniaoObjectMother.DefaultList;

            _reuniaoRepositoryMockObject.Setup(p => p.GetReuniaoBySalaId(It.IsAny<long>())).Returns(reunioesSala);
            _salaFake.Setup(s => s.ConsultarDisponibilidadeSala(It.IsAny<List<Reuniao>>(), It.IsAny<Reuniao>()));
            _reuniaoRepositoryMockObject.Setup(p => p.Update(It.IsAny<Reuniao>()));

            //Action
            Action actionReuniaoUpdate = () => { _Reunioeservice.Realocacao(_reuniaoDefaultWithId); };

            //Assert
            actionReuniaoUpdate.Should().NotThrow<Exception>();
        }
        
        [Test]
        public void Get_Deveria_Retornar_Um_Reuniao()
        {
            //Arrange
            _reuniaoRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_reuniaoDefaultWithId);

            //Action 
            Reuniao retornoReuniao = _Reunioeservice.Get(_reuniaoDefaultWithId.Id);

            //Assert
            _reuniaoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _reuniaoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoReuniao.Id.Should().BeGreaterThan(0);
            retornoReuniao.Id.Should().Be(_reuniaoDefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Reunioes()
        {
            //Arrange
            List<Reuniao> _reuniaoDefaultList = ReuniaoObjectMother.DefaultList;

            _reuniaoRepositoryMockObject.Setup(p => p.GetAll()).Returns(_reuniaoDefaultList);

            //Action
            var resultReunioes = _Reunioeservice.GetAll();

            //Assert
            _reuniaoRepositoryMockObject.Verify(x => x.GetAll());
            resultReunioes.Should().NotBeEmpty();
            resultReunioes.Should().HaveCount(3);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Reuniao()
        {
            //Arrange
            _reuniaoRepositoryMockObject.Setup(x => x.Delete(_reuniaoDefaultWithId));

            //Action
            Action reuniaoDeleteAction = () => _Reunioeservice.Delete(_reuniaoDefaultWithId);
            
            //Assert
            reuniaoDeleteAction.Should().NotThrow<Exception>();
            _reuniaoRepositoryMockObject.Verify(x => x.Delete(_reuniaoDefaultWithId), Times.Once());
            _reuniaoRepositoryMockObject.Verify(x => x.Delete(_reuniaoDefaultWithId));
        }
    }
}
