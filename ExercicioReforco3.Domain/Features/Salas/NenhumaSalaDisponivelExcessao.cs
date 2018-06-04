using ExercicioReforco3.Domain.Exceptions;

namespace ExercicioReforco3.Domain.Features.Salas
{
    public class NenhumaSalaDisponivelExcessao : BusinessException
    {
        public NenhumaSalaDisponivelExcessao() : base("Nenhuma Sala está disponível!")
        {
        }
    }
}
