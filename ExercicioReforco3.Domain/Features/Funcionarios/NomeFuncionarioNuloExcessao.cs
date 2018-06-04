using ExercicioReforco3.Domain.Exceptions;

namespace ExercicioReforco3.Domain.Features.Funcionarios
{
    public class NomeFuncionarioNuloExcessao : BusinessException
    {
        public NomeFuncionarioNuloExcessao() : base("Nome de Funcionário não pode ser nulo!")
        {
        }
    }
}