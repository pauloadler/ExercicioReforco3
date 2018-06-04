using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco3.Domain.Features.Funcionarios;

namespace ExercicioReforco3.Infra.Data.Features.Funcionarios
{

    public class FuncionarioRepository : IFuncionarioRepository
    {
        #region QUERIES

        private const string SqlInsereFuncionario =
            @"INSERT INTO Funcionario 
                (nome_funcionario, cargo, setor)
            VALUES
                (@nome_funcionario, @cargo, @setor)";

        private const string SqlEditaFuncionario =
            @"UPDATE Funcionario
                SET
                     nome_funcionario = @nome_funcionario, 
                     cargo = @cargo, 
                     setor = @setor
                WHERE id_funcionario = {0}id_funcionario";

        private const string SqlSelecionaTodosFuncionarios =
           @"SELECT * FROM Funcionario";

        private const string SqlSelecionaFuncionarioPorId =
           @"SELECT * FROM Funcionario WHERE id_funcionario = {0}id_funcionario";

        private const string SqlDeletaFuncionario =
           @"DELETE FROM Funcionario
                WHERE id_funcionario = {0}id_funcionario";
        
        #endregion QUERIES

        public Funcionario Save(Funcionario funcionario)
        {
            funcionario.Id = Db.Insert(SqlInsereFuncionario, GetParametros(funcionario));

            return funcionario;
        }

        public void Update(Funcionario funcionario)
        {
            Db.Update(SqlEditaFuncionario, GetParametros(funcionario));
        }

        public void Delete(Funcionario funcionario)
        {
            var parms = new Dictionary<string, object> { { "id_funcionario", funcionario.Id } };

            Db.Delete(SqlDeletaFuncionario, parms);
        }

        public Funcionario Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_funcionario", id } };

            return Db.Get(SqlSelecionaFuncionarioPorId, Converter, parms);
        }

        public List<Funcionario> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosFuncionarios, Converter);
        }

        private Dictionary<string, object> GetParametros(Funcionario funcionario)
        {
            return new Dictionary<string, object>
            {
                { "id_funcionario", funcionario.Id },
                { "nome_funcionario", funcionario.Nome },
                { "cargo", funcionario.Cargo },
                { "setor", funcionario.Setor }

            };
        }

        private static Func<IDataReader, Funcionario> Converter = reader =>
         new Funcionario
         {
             Id = Convert.ToInt64(reader["id_funcionario"]),
             Nome = reader["nome_funcionario"].ToString(),
             Cargo = reader["cargo"].ToString(),
             Setor = reader["setor"].ToString()
         };
    }
}

