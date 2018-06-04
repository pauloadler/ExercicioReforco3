using ExercicioReforco3.Common.Tests.Features.Funcionarios;
using ExercicioReforco3.Common.Tests.Features.Salas;
using ExercicioReforco3.Domain.Features.Reunioes;
using System;
using System.Collections.Generic;

namespace ExercicioReforco3.Common.Tests.Features.Reunioes
{
    public class ReuniaoObjectMother
    {
        public static Reuniao Default
        {
            get
            {
                return new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
                };
            }
        }

        public static Reuniao DefaultWithId
        {
            get
            {
                return new Reuniao()
                {
                    Id = 1,
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
                };
            }
        }

        public static Reuniao DefaultDataHoraInicialDiferenteData
        {
            get
            {
                return new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now.AddDays(2),
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
                };
            }
        }

        public static Reuniao DefaultDataHoraFinalDiferenteData
        {
            get
            {
                return new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now.AddDays(2),
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
                };
            }
        }

        public static Reuniao HoraInicioMaiorHoraFinal
        {
            get
            {
                return new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0)
                };
            }
        }
        
        public static Reuniao DefaultHoursNotAvailable
        {
            get
            {
                return new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0)
                };
            }
        }

        public static List<Reuniao> DefaultList
        {
            get
            {
                List<Reuniao> ReunioesList = new List<Reuniao>();

                ReunioesList.Add(new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0)
                }
                );

                ReunioesList.Add(new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 30, 0)
                }
                );

                ReunioesList.Add(new Reuniao()
                {
                    Funcionario = FuncionarioObjectMother.DefaultWithId,
                    Sala = SalaObjectMother.DefaultWithId,
                    Data = DateTime.Now,
                    HorarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 30, 0),
                    HorarioFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0)
                }
                );

                return ReunioesList;
            }
        }
    }
}

