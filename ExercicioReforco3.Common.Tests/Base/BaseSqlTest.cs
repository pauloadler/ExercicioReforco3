using ExercicioReforco3.Infra;

namespace ExercicioReforco3.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_TABLES = @"
                                                DELETE FROM [dbo].[Reuniao]
                                                DBCC CHECKIDENT ('Reuniao', RESEED, 0)

                                                DELETE FROM [dbo].[Funcionario]
                                                DBCC CHECKIDENT ('Funcionario', RESEED, 0)

                                                DELETE FROM [dbo].[Sala]
                                                DBCC CHECKIDENT ('Sala', RESEED, 0)";

        private const string INSERT = @"
                                        insert into Funcionario (nome_funcionario, cargo, setor)
                                        values('Funcionario 1', 'Desenvolvedor', 'Produção')

                                        insert into Funcionario (nome_funcionario, cargo, setor)
                                        values('Funcionario 2', 'Tester', 'Produção')

                                        insert into Funcionario (nome_funcionario, cargo, setor)
                                        values('Funcionario 3', 'Suporte', 'Suporte')

                                        insert into Sala(nome_sala, qtde_lugares)
                                        values('Sala 1', '10')

                                        insert into Sala(nome_sala, qtde_lugares)
                                        values('Sala 2', '15')";

        public static void SeedDeleteDatabase()
        {
            Db.Update(RECREATE_TABLES);
        }

        public static void SeedInsertDatabase()
        {
            Db.Update(INSERT);
        }
    }
}
