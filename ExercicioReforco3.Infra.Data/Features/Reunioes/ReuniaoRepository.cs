using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco3.Domain.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Salas;

namespace ExercicioReforco3.Infra.Data.Features.Reunioes
{

    public class ReuniaoRepository : IReuniaoRepository
    {
        #region QUERIES

        private const string SqlInsereReuniao =
            @"INSERT INTO Reuniao 
                (funcionario_id, sala_id, data, hora_inicio, hora_final)
            VALUES
                (@funcionario_id, @sala_id, @data, @hora_inicio, @hora_final)";

        private const string SqlEditaReuniao =
            @"UPDATE Reuniao
                SET
                     funcionario_id = @funcionario_id, 
                     sala_id = @sala_id, 
                     data = @data, 
                     hora_inicio = @hora_inicio, 
                     hora_final = @hora_final
                WHERE id_reuniao = {0}id_reuniao";

        private const string SqlSelecionaTodosReunioes =
           @"SELECT * FROM Reuniao
             INNER JOIN Funcionario on Reuniao.funcionario_id = Funcionario.id_funcionario
             INNER JOIN Sala on Reuniao.sala_id = Sala.id_sala";

        private const string SqlSelecionaReuniaoPorId =
           @"SELECT * FROM Reuniao 
             INNER JOIN Funcionario on Reuniao.funcionario_id = Funcionario.id_funcionario
             INNER JOIN Sala on Reuniao.sala_id = Sala.id_sala
             WHERE id_reuniao = {0}id_reuniao";

        private const string SqlDeletaReuniao =
           @"DELETE FROM Reuniao
                WHERE id_reuniao = {0}id_reuniao";

        private const string SqlGetReuniaoBySalaId =
          @" select* from Reuniao
               INNER JOIN Funcionario on Reuniao.funcionario_id = Funcionario.id_funcionario
               INNER JOIN Sala on Reuniao.sala_id = Sala.id_sala
               where sala_id = @sala_id";
        
        #endregion QUERIES

        public Reuniao Save(Reuniao reuniao)
        {
            reuniao.Id = Db.Insert(SqlInsereReuniao, GetParametros(reuniao));

            return reuniao;
        }

        public void Update(Reuniao reuniao)
        {
            Db.Update(SqlEditaReuniao, GetParametros(reuniao));
        }

        public void Delete(Reuniao reuniao)
        {
            var parms = new Dictionary<string, object> { { "id_reuniao", reuniao.Id } };

            Db.Delete(SqlDeletaReuniao, parms);
        }

        public Reuniao Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_reuniao", id } };

            return Db.Get(SqlSelecionaReuniaoPorId, Converter, parms);
        }
        
        public List<Reuniao> GetReuniaoBySalaId(long salaId)
        {
            var parms = new Dictionary<string, object> { { "sala_id", salaId } };

            return Db.GetAll(SqlGetReuniaoBySalaId, Converter, parms);
        }
        
        public List<Reuniao> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosReunioes, Converter);
        }

        private Dictionary<string, object> GetParametros(Reuniao reuniao)
        {
            return new Dictionary<string, object>
            {
                { "id_reuniao", reuniao.Id },
                { "funcionario_id", reuniao.Funcionario.Id },
                { "sala_id", reuniao.Sala.Id },
                { "data", reuniao.Data },
                { "hora_inicio", reuniao.HorarioInicioAtualizado },
                { "hora_final", reuniao.HorarioFinalAtualizado }
            };
        }
        
        private static Func<IDataReader, Reuniao> Converter = reader =>
         new Reuniao
         {
             Id = Convert.ToInt64(reader["id_reuniao"]),

             Funcionario = new Funcionario()
             {
                 Id = Convert.ToInt64(reader["id_funcionario"]),
                 Nome = reader["nome_funcionario"].ToString(),
                 Cargo = reader["cargo"].ToString(),
                 Setor = reader["setor"].ToString()
             },

             Sala = new Sala()
             {
                 Id = Convert.ToInt64(reader["id_sala"]),
                 Nome = reader["nome_sala"].ToString(),
                 QtdeLugares = Convert.ToInt32(reader["qtde_lugares"])
             },

             Data = Convert.ToDateTime(reader["data"]),
             HorarioInicio = Convert.ToDateTime(reader["hora_inicio"]),
             HorarioFinal = Convert.ToDateTime(reader["hora_final"])
         };
    }
}

