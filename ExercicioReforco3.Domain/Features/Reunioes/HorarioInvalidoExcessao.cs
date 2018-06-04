using ExercicioReforco3.Domain.Exceptions;

namespace ExercicioReforco3.Domain.Features.Reunioes
{
    public class HorarioInvalidoExcessao : BusinessException
    {
        public HorarioInvalidoExcessao() : base("Horario inicial deve menor que horario final!")
        {
        }
    }
}
