using ExercicioReforco3.Common.Tests.Features.Salas;
using ExercicioReforco3.Common.Tests.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Salas;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using FluentAssertions;

namespace ExercicioReforco3.Domain.Tests.Features.Salas
{
    [TestFixture]
    public class SalaDomainTest
    {
        Sala _salaDefault;

        [SetUp]
        public void LivroDomainTestSetUp()
        {
            _salaDefault = SalaObjectMother.Default;
        }
        
        [Test]
        public void Sala_Deveria_Retornar_Excessao_Quando_Consultado_Data_E_Horarios_Nao_Disponiveis()
        {
            //arrange
            List<Reuniao> listReunioesSala = ReuniaoObjectMother.DefaultList;
            Reuniao reuniaoDefaultHoursNotAvailable = ReuniaoObjectMother.DefaultHoursNotAvailable;

            //Action
            Action actionConsultarDiponibilidadeSala = () => _salaDefault.ConsultarDisponibilidadeSala(listReunioesSala, reuniaoDefaultHoursNotAvailable);

            //Assert
            actionConsultarDiponibilidadeSala.Should().Throw<SalaNaoDisponivelExcessao>();
        }

        [Test]
        public void Sala_Nao_Deveria_Retornar_Excessao_Quando_Consultado_Data_E_Horarios_Disponiveis()
        {
            //arrange
            List<Reuniao> listReunioesSala = ReuniaoObjectMother.DefaultList;
            Reuniao reuniaoDefaultHoursNotAvailable = ReuniaoObjectMother.Default;

            //Action
            Action actionConsultarDiponibilidadeSala = () => _salaDefault.ConsultarDisponibilidadeSala(listReunioesSala, reuniaoDefaultHoursNotAvailable);

            //Assert
            actionConsultarDiponibilidadeSala.Should().NotThrow<SalaNaoDisponivelExcessao>();
        }

        [Test]
        public void Sala_Deveria_Retornar_Excessao_Quando_Quantidade_De_Lugares_For_Igual_A_Zero()
        {
            //arrange
            Sala salaDefaulQrdeLgaresZero = SalaObjectMother.DefaulQtdeLugaresZero;

            //Action
            Action actioValidaQtdeLugares = () => salaDefaulQrdeLgaresZero.ValidaQtdeLugares();

            //Assert
            actioValidaQtdeLugares.Should().Throw<SalaQtdeLugaresInvalidaExcessao>();
        }

        [Test]
        public void Sala_Nao_Deveria_Retornar_Excessao_Quando_Quantidade_De_Lugares_For_Maior_Que_Zero()
        {
            //Action-Arrange
            Action actioValidaQtdeLugares = () => _salaDefault.ValidaQtdeLugares();

            //Assert
            actioValidaQtdeLugares.Should().NotThrow<SalaQtdeLugaresInvalidaExcessao>();
        }
    }
}
