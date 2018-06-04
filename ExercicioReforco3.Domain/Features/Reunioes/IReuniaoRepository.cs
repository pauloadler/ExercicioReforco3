using System.Collections.Generic;

namespace ExercicioReforco3.Domain.Features.Reunioes
{
    public interface IReuniaoRepository
    {
        Reuniao Save(Reuniao reuniao);

        void Update(Reuniao reuniao);

        Reuniao Get(long id);

        List<Reuniao> GetAll();

        List<Reuniao> GetReuniaoBySalaId(long salaId);

        void Delete(Reuniao reuniao);
    }
}
