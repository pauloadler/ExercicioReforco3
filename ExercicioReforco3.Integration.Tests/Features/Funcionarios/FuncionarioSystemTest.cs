using ExercicioReforco3.Application.Features.Funcionarios;
using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Funcionarios;
using ExercicioReforco3.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco3.Integration.Tests.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioSystemTest
    {
        IFuncionarioRepository _funcionarioRepository;
        FuncionarioService _funcionarioService;
        Funcionario _funcionarioDefault;

        [SetUp]
        public void FuncionarioSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _funcionarioRepository = new FuncionarioRepository();
            _funcionarioService = new FuncionarioService(_funcionarioRepository);
            _funcionarioDefault = FuncionarioObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Funcionario_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Funcionario resultFuncionario = _funcionarioService.Add(_funcionarioDefault);

            //Assert
            resultFuncionario.Should().NotBeNull();
            resultFuncionario.Id.Should().NotBe(0);

            Funcionario resultGet = _funcionarioService.Get(resultFuncionario.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultFuncionario);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Funcionario_Pelo_Id()
        {
            //Arrange
            Funcionario resultFuncionario = _funcionarioService.Add(_funcionarioDefault);
            resultFuncionario.Nome = "Nome Atualizado";

            //Action 
            _funcionarioService.Update(resultFuncionario);

            //Assert
            Funcionario resultGet = _funcionarioService.Get(resultFuncionario.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultFuncionario.Id);
            resultGet.Nome.Should().Be("Nome Atualizado");
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Funcionario_Pelo_Id()
        {
            //Arrange 
            Funcionario resultFuncionario = _funcionarioService.Add(_funcionarioDefault);

            //Action
            Funcionario resultGet = _funcionarioService.Get(resultFuncionario.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultFuncionario.Id);
            resultGet.Should().Equals(resultFuncionario);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Funcionario()
        {
            //Arrange 
            Funcionario resultFuncionario = _funcionarioService.Add(_funcionarioDefault);

            //Action
            List<Funcionario> resultGetAll = _funcionarioService.GetAll();

            //Assert
            var ultimaFuncionario = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(4);
            ultimaFuncionario.Should().Equals(_funcionarioDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Funcionario_Pelo_Id()
        {
            Funcionario resultFuncionario = _funcionarioService.Add(_funcionarioDefault);

            //Action
            _funcionarioService.Delete(resultFuncionario);

            //Assert
            Funcionario resultGet = _funcionarioService.Get(resultFuncionario.Id);
            List<Funcionario> resultGetAll = _funcionarioService.GetAll();

            resultGet.Should().BeNull();
            resultGetAll.Should().HaveCount(3);
        }

        [TearDown]
        public void LimparDataBase()
        {
            BaseSqlTest.SeedDeleteDatabase();
        }
    }
}
