using System.Collections.Generic;

namespace ExercicioReforco3.Domain.Features.Salas
{
    public interface ISalaRepository
    {
        Sala Save(Sala sala);

        void Update(Sala sala);

        Sala Get(long id);

        List<Sala> GetAll();

        List<Sala> GetAllSalasDisponiveis();

        void Delete(Sala sala);
    }
}
