using ExercicioReforco3.Application.Features.Funcionarios;
using ExercicioReforco3.Common.Tests.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Funcionarios;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Tests.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioServiceTest
    {
        Mock<IFuncionarioRepository> _funcionarioRepositoryMockObject;
        FuncionarioService _funcionarioService;
        Funcionario _funcionarioefaultWithId;

        [SetUp]
        public void FuncionarioServiceTestSetUp()
        {
            _funcionarioRepositoryMockObject = new Mock<IFuncionarioRepository>();
            _funcionarioService = new FuncionarioService(_funcionarioRepositoryMockObject.Object);
            _funcionarioefaultWithId = FuncionarioObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Novo_Funcionario()
        {
            //Arrange
            _funcionarioRepositoryMockObject.Setup(p => p.Save(It.IsAny<Funcionario>())).Returns(_funcionarioefaultWithId);

            //Action 
            Funcionario retornoFuncionario = _funcionarioService.Add(_funcionarioefaultWithId);

            //Assert
            _funcionarioRepositoryMockObject.Verify(p => p.Save(It.IsAny<Funcionario>()));
            _funcionarioRepositoryMockObject.Verify(p => p.Save(It.IsAny<Funcionario>()), Times.Once());
            retornoFuncionario.Id.Should().BeGreaterThan(0);
            retornoFuncionario.Id.Should().Be(_funcionarioefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_Da_Funcionario()
        {
            //Arrange
            _funcionarioRepositoryMockObject.Setup(p => p.Update(It.IsAny<Funcionario>()));

            //Action
            Action actionFuncionarioUpdate = () => { _funcionarioService.Update(_funcionarioefaultWithId); };

            //Assert
            actionFuncionarioUpdate.Should().NotThrow<Exception>();
            _funcionarioRepositoryMockObject.Verify(p => p.Update(It.IsAny<Funcionario>()), Times.Once());
            _funcionarioRepositoryMockObject.Verify(p => p.Update(It.IsAny<Funcionario>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Funcionario()
        {
            //Arrange
            _funcionarioRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_funcionarioefaultWithId);

            //Action 
            Funcionario retornoFuncionario = _funcionarioService.Get(_funcionarioefaultWithId.Id);

            //Assert
            _funcionarioRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _funcionarioRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoFuncionario.Id.Should().BeGreaterThan(0);
            retornoFuncionario.Id.Should().Be(_funcionarioefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Funcionarios()
        {
            //Arrange
            List<Funcionario> _funcionarioDefaultList = FuncionarioObjectMother.DefaultList;

            _funcionarioRepositoryMockObject.Setup(p => p.GetAll()).Returns(_funcionarioDefaultList);

            //Action
            var resultFuncionarios = _funcionarioService.GetAll();

            //Assert
            _funcionarioRepositoryMockObject.Verify(x => x.GetAll());
            resultFuncionarios.Should().NotBeEmpty();
            resultFuncionarios.Should().HaveCount(3);
        }
        
        [Test]
        public void Delete_Deveria_Deletar_Um_Funcionario()
        {
            //Arrange
            _funcionarioRepositoryMockObject.Setup(x => x.Delete(_funcionarioefaultWithId));

            //Action
            Action funcionarioDeleteAction = () => _funcionarioService.Delete(_funcionarioefaultWithId);

            //Assert
            funcionarioDeleteAction.Should().NotThrow<Exception>();
            _funcionarioRepositoryMockObject.Verify(x => x.Delete(_funcionarioefaultWithId), Times.Once());
            _funcionarioRepositoryMockObject.Verify(x => x.Delete(_funcionarioefaultWithId));
        }
    }
}

