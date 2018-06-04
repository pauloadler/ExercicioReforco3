using ExercicioReforco3.Domain.Features.Reunioes;
using System.Collections.Generic;

namespace ExercicioReforco3.Domain.Features.Salas
{
    public class Sala
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int QtdeLugares { get; set; }


        public virtual void ConsultarDisponibilidadeSala(List<Reuniao> listReunioesSala, Reuniao reuniaoDefault)
        {
            int contSalaOcupada = 0;

            foreach (var Reunioesala in listReunioesSala)
            {
                if ((reuniaoDefault.HorarioInicio > Reunioesala.HorarioInicio &&
                    reuniaoDefault.HorarioInicio < Reunioesala.HorarioFinal)
                    ||
                    (reuniaoDefault.HorarioFinal > Reunioesala.HorarioInicio &&
                    reuniaoDefault.HorarioFinal < Reunioesala.HorarioFinal))

                    contSalaOcupada++;
            }

            if (contSalaOcupada > 0)
                throw new SalaNaoDisponivelExcessao();
        }
        
        public void ValidaQtdeLugares()
        {
            if (QtdeLugares == 0)
                throw new SalaQtdeLugaresInvalidaExcessao();
        }
    }
}
