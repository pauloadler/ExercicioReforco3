using ExercicioReforco3.Domain.Exceptions;

namespace ExercicioReforco3.Domain.Features.Salas
{
    public class SalaQtdeLugaresInvalidaExcessao : BusinessException
    {
        public SalaQtdeLugaresInvalidaExcessao() : base("Quantidade não deve ser igual a zero!")
        {
        }
    }
}
