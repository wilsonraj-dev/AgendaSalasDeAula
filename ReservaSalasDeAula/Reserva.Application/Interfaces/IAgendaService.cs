using Reserva.Application.DTOs;

namespace Reserva.Application.Interfaces
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaDTO>> GetAgendasAsync();
        Task<IEnumerable<AgendaDTO>> GetAgendasPorDataAsync(DateTime dataAgenda);
        Task<IEnumerable<AgendaDTO>> GetAgendasPorProfessorAsync(string professor);
        Task CreateAsync(AgendaDTO agendaDTO);
        Task UpdateAsync(AgendaDTO agendaDTO);
        Task RemoveAsync(int id);
    }
}
