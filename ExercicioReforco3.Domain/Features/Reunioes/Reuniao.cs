using ExercicioReforco3.Domain.Features.Funcionarios;
using ExercicioReforco3.Domain.Features.Salas;
using System;

namespace ExercicioReforco3.Domain.Features.Reunioes
{
    public class Reuniao
    {
        public long Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFinal { get; set; }

        public DateTime HorarioInicioAtualizado
        {
            get
            {
                return new DateTime(
                    Data.Year,
                    Data.Month,
                    Data.Day,
                    HorarioInicio.Hour,
                    HorarioInicio.Minute,
                    HorarioInicio.Second);
            }
        }

        public DateTime HorarioFinalAtualizado
        {
            get
            {
                return new DateTime(
                    Data.Year,
                    Data.Month,
                    Data.Day,
                    HorarioFinal.Hour,
                    HorarioFinal.Minute,
                    HorarioFinal.Second);
            }
        }

        public void ValidaHorarios()
        {
            if (HorarioInicioAtualizado >= HorarioFinalAtualizado)
                throw new HorarioInvalidoExcessao();
        }
    }
}
