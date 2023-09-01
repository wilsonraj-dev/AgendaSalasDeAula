using AutoMapper;
using Reserva.Application.DTOs;
using Reserva.Application.Interfaces;
using Reserva.Domain.Entidades;
using Reserva.Domain.Interfaces;

namespace Reserva.Application.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IMapper mapper, IAgendaRepository agendaRepository)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<AgendaDTO>> GetAgendasAsync()
        {
            var agendas = await _agendaRepository.GetAgendasAsync();
            return _mapper.Map<IEnumerable<AgendaDTO>>(agendas);
        }

        public async Task<IEnumerable<AgendaDTO>> GetAgendasPorDataAsync(DateTime dataAgenda)
        {
            var agendas = await _agendaRepository.GetAgendasPorDataAsync(dataAgenda);
            return _mapper.Map<IEnumerable<AgendaDTO>>(agendas);
        }

        public async Task<IEnumerable<AgendaDTO>> GetAgendasPorProfessorAsync(string professor)
        {
            var agendas = await _agendaRepository.GetAgendasPorProfessorAsync(professor);
            return _mapper.Map<IEnumerable<AgendaDTO>>(agendas);
        }

        public async Task CreateAsync(AgendaDTO agendaDTO)
        {
            var agenda = _mapper.Map<Agenda>(agendaDTO);
            await _agendaRepository.CreateAsync(agenda);
        }

        public async Task UpdateAsync(AgendaDTO agendaDTO)
        {
            var agenda = _mapper.Map<Agenda>(agendaDTO);
            await _agendaRepository.UpdateAsync(agenda);
        }

        public async Task RemoveAsync(int id)
        {
            var agenda = _agendaRepository.GetAgendaPorIdAsync(id).Result;
            await _agendaRepository.RemoveAsync(agenda);
        }
    }
}
