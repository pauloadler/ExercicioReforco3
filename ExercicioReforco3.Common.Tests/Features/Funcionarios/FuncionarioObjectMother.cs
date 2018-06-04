using ExercicioReforco3.Domain.Features.Funcionarios;
using System.Collections.Generic;

namespace ExercicioReforco3.Common.Tests.Features.Funcionarios
{
    public class FuncionarioObjectMother
    {
        public static Funcionario Default
        {
            get
            {
                return new Funcionario()
                {
                    Nome = "Nome de Teste",
                    Cargo = "Cargo de Teste",
                    Setor = "Setor de Teste"
                };
            }
        }

        public static List<Funcionario> DefaultList
        {
            get
            {
                List<Funcionario> funcionariosList = new List<Funcionario>();

                funcionariosList.Add(new Funcionario()
                {
                    Id = 1,
                    Nome = "Sala Teste 1",
                    Cargo = "Cargo de teste",
                    Setor = "Setor de teste"
                }
                );

                funcionariosList.Add(new Funcionario()
                {
                    Id = 1,
                    Nome = "Sala Teste 2",
                    Cargo = "Cargo de teste",
                    Setor = "Setor de teste"
                }
                );

                funcionariosList.Add(new Funcionario()
                {
                    Id = 1,
                    Nome = "Sala Teste 3",
                    Cargo = "Cargo de teste",
                    Setor = "Setor de teste"
                }
                );

                return funcionariosList;
            }
        }

        public static Funcionario DefaultWithId
        {
            get
            {
                return new Funcionario()
                {
                    Id = 3,
                    Nome = "Nome de Teste",
                    Cargo = "Cargo de Teste",
                    Setor = "Setor de Teste"
                };
            }
        }

        public static Funcionario NomeVazio
        {
            get
            {
                return new Funcionario()
                {
                    Nome = "",
                    Cargo = "Cargo de Teste",
                    Setor = "Setor de Teste"
                };
            }
        }
    }
}
