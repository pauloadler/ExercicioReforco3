using ExercicioReforco3.Application.Features.Reunioes;
using ExercicioReforco3.Common.Tests.Base;
using ExercicioReforco3.Common.Tests.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Infra.Data.Features.Reunioes;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco3.System.Tests.Features.Reunioes
{
    [TestFixture]
    public class ReuniaoSystemTest
    {
        IReuniaoRepository _reuniaoRepository;
        ReuniaoService _reuniaoService;
        Reuniao _reuniaoDefault;

        [SetUp]
        public void ReuniaoSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _reuniaoRepository = new ReuniaoRepository();
            _reuniaoService = new ReuniaoService(_reuniaoRepository);
            _reuniaoDefault = ReuniaoObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Reuniao_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Reuniao resultReuniao = _reuniaoService.Alocacao(_reuniaoDefault);

            //Assert
            resultReuniao.Should().NotBeNull();
            resultReuniao.Id.Should().NotBe(0);

            Reuniao resultGet = _reuniaoService.Get(resultReuniao.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultReuniao);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Reuniao_Pelo_Id()
        {
            //Arrange
            Reuniao resultReuniao = _reuniaoService.Alocacao(_reuniaoDefault);
            resultReuniao.Sala.Id = 2;

            //Action 
            _reuniaoService.Realocacao(resultReuniao);

            //Assert
            Reuniao resultGet = _reuniaoService.Get(resultReuniao.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultReuniao.Id);
            resultGet.Sala.Id.Should().Be(2);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Reuniao_Pelo_Id()
        {
            //Arrange 
            Reuniao resultReuniao = _reuniaoService.Alocacao(_reuniaoDefault);

            //Action
            Reuniao resultGet = _reuniaoService.Get(resultReuniao.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultReuniao.Id);
            resultGet.Should().Equals(resultReuniao);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Reuniao()
        {
            //Arrange 
            Reuniao resultReuniao = _reuniaoService.Alocacao(_reuniaoDefault);

            //Action
            List<Reuniao> resultGetAll = _reuniaoService.GetAll();

            //Assert
            var ultimoReuniao = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(1);
            ultimoReuniao.Should().Equals(_reuniaoDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Reuniao_Pelo_Id()
        {
            Reuniao resultReuniao = _reuniaoService.Alocacao(_reuniaoDefault);

            //Action
            _reuniaoService.Delete(resultReuniao);

            //Assert
            Reuniao resultGet = _reuniaoService.Get(resultReuniao.Id);
            List<Reuniao> resultGetAll = _reuniaoService.GetAll();

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
