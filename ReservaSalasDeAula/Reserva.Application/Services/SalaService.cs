using AutoMapper;
using Reserva.Application.DTOs;
using Reserva.Application.Interfaces;
using Reserva.Domain.Entidades;
using Reserva.Domain.Interfaces;

namespace Reserva.Application.Services
{

    public class SalaService : ISalaService
    {
        private readonly IMapper _mapper;
        private readonly ISalaRepository _salaRepository;

        public SalaService(IMapper mapper, ISalaRepository salaRepository)
        {
            _mapper = mapper;
            _salaRepository = salaRepository;
        }

        public async Task<SalaDTO> GetSalaByIdAsync(int? id)
        {
            var sala = await _salaRepository.GetSalaByIdAsync(id);
            return _mapper.Map<SalaDTO>(sala);
        }

        public async Task<IEnumerable<SalaDTO>> GetSalasAsync()
        {
            var salas = await _salaRepository.GetSalasAsync();
            return _mapper.Map<IEnumerable<SalaDTO>>(salas);
        }

        public async Task CreateAsync(SalaDTO salaDTO)
        {
            var sala = _mapper.Map<Sala>(salaDTO);
            await _salaRepository.CreateAsync(sala);
        }

        public async Task UpdateAsync(SalaDTO salaDTO)
        {
            var sala = _mapper.Map<Sala>(salaDTO);
            await _salaRepository.UpdateAsync(sala);
        }

        public async Task RemoveAsync(int id)
        {
            var sala = _salaRepository.GetSalaByIdAsync(id).Result;
            await _salaRepository.RemoveAsync(sala);
        }
    }
}
