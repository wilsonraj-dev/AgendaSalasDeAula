using Reserva.Domain.Entidades;

namespace Reserva.Domain.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> GetSalasAsync();
        Task<Sala> GetSalaByIdAsync(int? id);
        Task<Sala> CreateAsync(Sala sala);
        Task<Sala> UpdateAsync(Sala sala);
        Task<Sala> RemoveAsync(Sala sala);
    }
}
