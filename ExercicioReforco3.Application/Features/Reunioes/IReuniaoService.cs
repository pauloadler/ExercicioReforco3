using ExercicioReforco3.Domain.Features.Reunioes;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Features.Reunioes
{
    public interface IReuniaoService
    {
        Reuniao Alocacao(Reuniao reuniao);

        void Realocacao(Reuniao reuniao);
        
        Reuniao Get(long id);

        List<Reuniao> GetAll();
        
        void Delete(Reuniao reuniao);
    }
}
