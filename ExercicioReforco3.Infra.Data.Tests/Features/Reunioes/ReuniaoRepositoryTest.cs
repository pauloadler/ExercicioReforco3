using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Infra.Data.Features.Reunioes;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco3.Infra.Data.Tests.Features.Reunioes
{
    [TestFixture]
    public class ReuniaoRepositoryTest
    {
        IReuniaoRepository _reuniaoRepository;
        Reuniao _reuniaoDefault;

        [SetUp]
        public void ReuniaoRepositoryTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _reuniaoRepository = new ReuniaoRepository();
            _reuniaoDefault = ReuniaoObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Um_Novo_Reuniao()
        {
            //Action-Arrange
            Reuniao resultReuniao = _reuniaoRepository.Save(_reuniaoDefault);

            //Assert
            Reuniao resultGet = _reuniaoRepository.Get(resultReuniao.Id);

            resultReuniao.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultReuniao.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Reuniao()
        {
            //Arrange
            DateTime dataAdiantada = DateTime.Now.AddDays(3);
            Reuniao reuniaoResult = _reuniaoRepository.Save(_reuniaoDefault);
            reuniaoResult.Data = dataAdiantada;

            //Action
            _reuniaoRepository.Update(reuniaoResult);

            //Assert
            Reuniao resultGet = _reuniaoRepository.Get(reuniaoResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(reuniaoResult.Id);
            resultGet.HorarioInicioAtualizado.Should().Be(new DateTime(dataAdiantada.Year, dataAdiantada.Month, dataAdiantada.Day, 11, 0, 0));
            resultGet.HorarioFinalAtualizado.Should().Be(new DateTime(dataAdiantada.Year, dataAdiantada.Month, dataAdiantada.Day, 12, 0, 0));
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Reuniao()
        {
            //Arrange 
            Reuniao resultReuniao = _reuniaoRepository.Save(_reuniaoDefault);

            //Action
            Reuniao resultGet = _reuniaoRepository.Get(resultReuniao.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultReuniao.Id);
            resultGet.Should().Equals(resultReuniao);
        }
        
        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Reunioes()
        {
            //Arrange 
            Reuniao resultReuniao = _reuniaoRepository.Save(_reuniaoDefault);

            //Action
            List<Reuniao> resultGetAll = _reuniaoRepository.GetAll();

            //Assert
            var ultimoReuniao = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(1);
            ultimoReuniao.Should().Equals(_reuniaoDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Reuniao()
        {
            //Arrange 
            Reuniao resultReuniao = _reuniaoRepository.Save(_reuniaoDefault);

            //Action
            _reuniaoRepository.Delete(resultReuniao);

            //Assert
            Reuniao resultGet = _reuniaoRepository.Get(resultReuniao.Id);
            List<Reuniao> resultGetAll = _reuniaoRepository.GetAll();

            resultGet.Should().BeNull();
            resultGetAll.Should().HaveCount(0);
        }

        [TearDown]
        public void LimparDataBase()
        {
            BaseSqlTest.SeedDeleteDatabase();
        }
    }
}
