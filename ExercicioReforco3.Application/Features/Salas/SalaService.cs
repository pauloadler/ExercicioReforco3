using System.Collections.Generic;
using ExercicioReforco3.Domain.Features.Salas;

namespace ExercicioReforco3.Application.Features.Salas
{
    public class SalaService : ISalaService
    {
        private ISalaRepository _salaRepository;

        public SalaService(ISalaRepository SalaRepository)
        {
            _salaRepository = SalaRepository;
        }

        public Sala Add(Sala sala)
        {
            return _salaRepository.Save(sala);
        }

        public void Update(Sala sala)
        {
            _salaRepository.Update(sala);
        }
        public Sala Get(long id)
        {
            return _salaRepository.Get(id);
        }

        public List<Sala> GetAll()
        {
            return _salaRepository.GetAll();
        }

        public void Delete(Sala sala)
        {
            _salaRepository.Delete(sala);
        }

        public List<Sala> ConsultarTodasSalasDisponiveis()
        {
            List<Sala> salaDisponiveis = _salaRepository.GetAllSalasDisponiveis();

            if (salaDisponiveis.Count == 0)
                throw new NenhumaSalaDisponivelExcessao();
            else
                return salaDisponiveis;
        }
    }
}
