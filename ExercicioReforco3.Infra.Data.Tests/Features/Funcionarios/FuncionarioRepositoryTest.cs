using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Funcionarios;
using ExercicioReforco3.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco3.Infra.Data.Tests.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioRepositoryTest
    {
        FuncionarioRepository _funcionarioRepository;
        Funcionario _funcionarioDefault;

        [SetUp]
        public void FuncionarioRepositoryTestsTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _funcionarioRepository = new FuncionarioRepository();
            _funcionarioDefault = FuncionarioObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Uma_Nova_Funcionario()
        {
            //Action-Arrange
            Funcionario resultFuncionario = _funcionarioRepository.Save(_funcionarioDefault);

            //Assert
            Funcionario resultGet = _funcionarioRepository.Get(resultFuncionario.Id);

            resultFuncionario.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultFuncionario.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Funcionario()
        {
            //Arrange
            Funcionario funcionarioResult = _funcionarioRepository.Save(_funcionarioDefault);
            funcionarioResult.Nome = "Nome Update";

            //Action
            _funcionarioRepository.Update(funcionarioResult);

            //Assert
            Funcionario resultGet = _funcionarioRepository.Get(funcionarioResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(funcionarioResult.Id);
            resultGet.Nome.Should().Be("Nome Update");
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Funcionario()
        {
            //Arrange
            Funcionario resultFuncionario = _funcionarioRepository.Save(_funcionarioDefault);

            //Action
            Funcionario resultGet = _funcionarioRepository.Get(resultFuncionario.Id);

            //Assert
            resultFuncionario.Nome.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultFuncionario);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Funcionarios()
        {
            //Action-Arrange 
            List<Funcionario> resultGetAll = _funcionarioRepository.GetAll();

            //Assert
            var ultimaFuncionario = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(3);
            ultimaFuncionario.Should().Equals(_funcionarioDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Funcionario()
        {
            //Arrange 
            Funcionario resultFuncionario = _funcionarioRepository.Save(_funcionarioDefault);

            //Action
            _funcionarioRepository.Delete(resultFuncionario);

            //Assert
            Funcionario resultGet = _funcionarioRepository.Get(resultFuncionario.Id);
            List<Funcionario> resultGetAll = _funcionarioRepository.GetAll();

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
