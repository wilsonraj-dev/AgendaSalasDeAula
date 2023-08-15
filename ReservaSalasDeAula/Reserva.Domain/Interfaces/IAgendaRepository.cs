using Reserva.Domain.Entidades;

namespace Reserva.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Agenda>> GetAgendasAsync();
        Task<IEnumerable<Agenda>> GetAgendasPorDataAsync(DateTime dataAgenda);
        Task<IEnumerable<Agenda>> GetAgendasPorProfessorAsync(string professor);
        Task<Agenda> CreateAsync(Agenda agenda);
        Task<Agenda> UpdateAsync(Agenda agenda);
        Task<Agenda> RemoveAsync(Agenda agenda);
    }
}
