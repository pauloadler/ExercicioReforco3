using ExercicioReforco3.Domain.Exceptions;

namespace ExercicioReforco3.Domain.Features.Salas
{
    public class SalaNaoDisponivelExcessao : BusinessException
    {
        public SalaNaoDisponivelExcessao() : base("Sala não está disponível!")
        {
        }
    }
}
