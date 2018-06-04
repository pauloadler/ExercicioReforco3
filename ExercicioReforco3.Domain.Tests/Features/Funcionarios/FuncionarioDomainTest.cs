using ExercicioReforco3.Common.Tests.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco3.Domain.Tests.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioDomainTest
    {
        Funcionario _funcionarioDefault;

        [SetUp]
        public void EmprestimoDomainTestSetUp()
        {
            _funcionarioDefault = FuncionarioObjectMother.Default;
        }

        [Test]
        public void Funcionario_Deveria_Retornar_Excessao_Quando_Nome_For_Nulo_Ou_Vazio()
        {
            //Arrange
            Funcionario funcionario = FuncionarioObjectMother.NomeVazio;

            //Action
            Action actionValidaFuncionarioNome = funcionario.ValidaNome;

            //Assert
            actionValidaFuncionarioNome.Should().Throw<NomeFuncionarioNuloExcessao>();
        }

        [Test]
        public void Funcionario_Nao_Deveria_Retornar_Excessao_Quando_Nome_Nao_For_Nulo_Ou_Vazio()
        {
            //Arrange-Action
            Action actionValidaFuncionarioNome = _funcionarioDefault.ValidaNome;

            //Assert
            actionValidaFuncionarioNome.Should().NotThrow<NomeFuncionarioNuloExcessao>();
        }
    }
}
