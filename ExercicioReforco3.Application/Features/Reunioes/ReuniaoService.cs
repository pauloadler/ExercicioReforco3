using System.Collections.Generic;
using ExercicioReforco3.Domain.Features.Reunioes;

namespace ExercicioReforco3.Application.Features.Reunioes
{
    public class ReuniaoService : IReuniaoService
    {
        private IReuniaoRepository _reuniaoRepository;

        public ReuniaoService(IReuniaoRepository reuniaoRepository)
        {
            _reuniaoRepository = reuniaoRepository;
        }
        
        public Reuniao Alocacao(Reuniao reuniao)
        {
            List<Reuniao> reunioesSala = _reuniaoRepository.GetReuniaoBySalaId(reuniao.Sala.Id);

            reuniao.Sala.ConsultarDisponibilidadeSala(reunioesSala, reuniao);

            return _reuniaoRepository.Save(reuniao);
        }
        
        public void Realocacao(Reuniao reuniao)
        {
            List<Reuniao> reunioesSala = _reuniaoRepository.GetReuniaoBySalaId(reuniao.Sala.Id);

            reuniao.Sala.ConsultarDisponibilidadeSala(reunioesSala, reuniao);

            _reuniaoRepository.Update(reuniao);
        }
        
        public void Delete(Reuniao reuniao)
        {
            _reuniaoRepository.Delete(reuniao);
        }

        public Reuniao Get(long id)
        {
            return _reuniaoRepository.Get(id);
        }

        public List<Reuniao> GetAll()
        {
            return _reuniaoRepository.GetAll();
        }
    }
}
