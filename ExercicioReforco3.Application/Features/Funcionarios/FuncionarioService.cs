using System.Collections.Generic;
using ExercicioReforco3.Domain.Features.Funcionarios;

namespace ExercicioReforco3.Application.Features.Funcionarios
{
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository)
        {
            _funcionarioRepository = FuncionarioRepository;
        }

        public Funcionario Add(Funcionario funcionario)
        {
            return _funcionarioRepository.Save(funcionario);
        }

        public void Update(Funcionario funcionario)
        {
            _funcionarioRepository.Update(funcionario);
        }
        public Funcionario Get(long id)
        {
            return _funcionarioRepository.Get(id);
        }

        public List<Funcionario> GetAll()
        {
            return _funcionarioRepository.GetAll();
        }

        public void Delete(Funcionario funcionario)
        {
            _funcionarioRepository.Delete(funcionario);
        }
    }
}
