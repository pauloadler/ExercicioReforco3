using ExercicioReforco3.Domain.Features.Funcionarios;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Features.Funcionarios
{
    public interface IFuncionarioService
    {
        Funcionario Add(Funcionario funcionario);

        void Update(Funcionario funcionario);

        Funcionario Get(long id);

        List<Funcionario> GetAll();

        void Delete(Funcionario id);
    }
}
