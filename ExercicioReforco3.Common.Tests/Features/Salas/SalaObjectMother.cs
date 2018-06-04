using ExercicioReforco3.Domain.Features.Salas;
using System.Collections.Generic;

namespace ExercicioReforco3.Common.Tests.Features.Salas
{
    public class SalaObjectMother
    {
        public static Sala Default
        {
            get
            {
                return new Sala()
                {
                   Nome = "Sala de Teste",
                   QtdeLugares = 15
                };
            }
        }

        public static Sala DefaultWithId
        {
            get
            {
                return new Sala()
                {
                    Id = 2,
                    Nome = "Sala de Teste",
                    QtdeLugares = 15
                };
            }
        }

        public static Sala DefaulQtdeLugaresZero
        {
            get
            {
                return new Sala()
                {
                    Id = 3,
                    Nome = "Sala de Teste",
                    QtdeLugares = 0
                };
            }
        }

        public static List<Sala> DefaultList
        {
            get
            {
                List<Sala> salasList = new List<Sala>();

                salasList.Add(new Sala()
                {
                    Id = 1,
                    Nome = "Sala Teste 1",
                    QtdeLugares = 10
                }
                );

                salasList.Add(new Sala()
                {
                    Id = 1,
                    Nome = "Sala Teste 2",
                    QtdeLugares = 14
                }
                );

                salasList.Add(new Sala()
                {
                    Id = 1,
                    Nome = "Sala Teste 3",
                    QtdeLugares = 15
                }
                );

                return salasList;
            }
        }
    }
}
