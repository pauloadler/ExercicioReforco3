namespace ExercicioReforco3.Domain.Features.Funcionarios
{
    public class Funcionario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }


        public void ValidaNome()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeFuncionarioNuloExcessao();
        }
    }
}
