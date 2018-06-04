using ExercicioReforco3.Domain.Features.Reunioes;
using ExercicioReforco3.Domain.Features.Salas;
using System.Collections.Generic;

namespace ExercicioReforco3.Application.Features.Salas
{
    public interface ISalaService
    {
        Sala Add(Sala sala);

        void Update(Sala sala);

        Sala Get(long id);

        List<Sala> GetAll();
        
        void Delete(Sala id);
    }
}
