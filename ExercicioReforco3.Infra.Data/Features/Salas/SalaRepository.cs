using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco3.Domain.Features.Salas;

namespace ExercicioReforco3.Infra.Data.Features.Salas
{
    public class SalaRepository : ISalaRepository
    {
        #region QUERIES

        private const string SqlInsereSala =
            @"INSERT INTO Sala
                (nome_sala, 
                 qtde_lugares)
            VALUES
                 (@nome_sala, 
                  @qtde_lugares)";

        private const string SqlEditaSala =
            @"UPDATE Sala
                SET
                    nome_sala = @nome_sala, 
                    qtde_lugares = @qtde_lugares
                WHERE id_sala = {0}id_sala";

        private const string SqlSelecionaTodosSalas =
           @"SELECT * FROM Sala";

        private const string SqlSelecionaSalaPorId =
           @"SELECT * FROM Sala
            WHERE id_sala = {0}id_sala";

        private const string SqlDeletaSala =
           @"DELETE FROM Sala
                WHERE id_sala = {0}id_sala";

        private const string SqlSalasDisponiveis =
           @" select id_sala, nome_sala, qtde_lugares from Sala
                left outer join Reuniao on Reuniao.sala_id = Sala.id_sala
                where id_reuniao is null";
        
        #endregion QUERIES

        public Sala Save(Sala Sala)
        {
            Sala.Id = Db.Insert(SqlInsereSala, GetParametros(Sala));

            return Sala;
        }

        public void Update(Sala Sala)
        {
            Db.Update(SqlEditaSala, GetParametros(Sala));
        }

        public void Delete(Sala Sala)
        {
            var parms = new Dictionary<string, object> { { "id_sala", Sala.Id } };

            Db.Delete(SqlDeletaSala, parms);
        }

        public Sala Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_sala", id } };

            return Db.Get(SqlSelecionaSalaPorId, Converter, parms);
        }

        public List<Sala> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosSalas, Converter);
        }

        public List<Sala> GetAllSalasDisponiveis()
        {
            return Db.GetAll(SqlSalasDisponiveis, Converter);
        }

        private Dictionary<string, object> GetParametros(Sala sala)
        {
            return new Dictionary<string, object>
            {
                {"id_sala", sala.Id },
                {"nome_sala", sala.Nome },
                {"qtde_lugares", sala.QtdeLugares }
            };
        }

        private static Func<IDataReader, Sala> Converter = reader =>
         new Sala
         {
             Id = Convert.ToInt64(reader["id_sala"]),
             Nome = reader["nome_sala"].ToString(),
             QtdeLugares = Convert.ToInt32(reader["qtde_lugares"])
         };
    }
}
