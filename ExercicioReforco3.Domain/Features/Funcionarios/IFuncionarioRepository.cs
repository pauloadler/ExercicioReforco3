using System.Collections.Generic;

namespace ExercicioReforco3.Domain.Features.Funcionarios
{
    public interface IFuncionarioRepository
    {
        Funcionario Save(Funcionario funcionario);

        void Update(Funcionario funcionario);

        Funcionario Get(long id);

        List<Funcionario> GetAll();

        void Delete(Funcionario funcionario);
    }
}
