using ExercicioReforco3.Common.Tests.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Reunioes;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco3.Domain.Tests.Features.Reunioes
{
    [TestFixture]
    public class ReuniaoDomainTest
    {
        Reuniao _reuniaoDefault;

        [SetUp]
        public void EmprestimoDomainTestSetUp()
        {
            _reuniaoDefault = ReuniaoObjectMother.Default;
        }

        [Test]
        public void Reuniao_Deveria_Retornar_Excessao_HoraInicio_For_Maio_Que_HoraFinal()
        {
            //Arrange
            Reuniao reuniaoHorarioInvalido = ReuniaoObjectMother.HoraInicioMaiorHoraFinal;

            //Action
            Action actionValidaHorarios = () => reuniaoHorarioInvalido.ValidaHorarios();

            //Assert
            actionValidaHorarios.Should().Throw<HorarioInvalidoExcessao>();
        }
        
        [Test]
        public void Reuniao_Nao_Deveria_Retornar_Excessao_Quando_Horarios_Estiverem_Validos()
        {
            //Arrange-Action
            Action actionValidaHorarios = () => _reuniaoDefault.ValidaHorarios();

            //Assert
            actionValidaHorarios.Should().NotThrow<HorarioInvalidoExcessao>();
        }

        [Test]
        public void Reuniao_Deveria_Retornar_HorarioInicial_Atualizado_Com_A_Mesma_Data_Informada()
        {
            //Arrange
            DateTime data = DateTime.Now.AddDays(2);

            //Action
            Reuniao reuniao = ReuniaoObjectMother.DefaultDataHoraInicialDiferenteData;

            //Assert
            reuniao.HorarioInicioAtualizado.Should().Be(new DateTime(data.Year, data.Month, data.Day, 11, 0, 0));
        }

        [Test]
        public void Reuniao_Deveria_Retornar_HorarioFinal_Atualizado_Com_A_Mesma_Data_Informada()
        {
            //Arrange
            DateTime data = DateTime.Now.AddDays(2);

            //Action
            Reuniao reuniao = ReuniaoObjectMother.DefaultDataHoraFinalDiferenteData;

            //Assert
            reuniao.HorarioFinalAtualizado.Should().Be(new DateTime(data.Year, data.Month, data.Day, 12, 0, 0));
        }
    }
}
