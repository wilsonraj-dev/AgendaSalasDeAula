using Reserva.Application.DTOs;

namespace Reserva.Application.Interfaces
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaDTO>> GetSalasAsync();
        Task<SalaDTO> GetSalaByIdAsync(int? id);
        Task CreateAsync(SalaDTO salaDTO);
        Task UpdateAsync(SalaDTO salaDTO);
        Task RemoveAsync(int id);
    }
}
