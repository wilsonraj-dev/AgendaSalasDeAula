using Microsoft.EntityFrameworkCore;
using Reserva.Domain.Entidades;
using Reserva.Domain.Interfaces;
using Reserva.Infra.Data.Context;

namespace Reserva.Infra.Data.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _context;

        public SalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sala>> GetSalasAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala> GetSalaByIdAsync(int? id)
        {
            return await _context.Salas.FindAsync(id) ?? throw new ArgumentException();
        }

        public async Task<Sala> CreateAsync(Sala sala)
        {
            _context.Add(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task<Sala> UpdateAsync(Sala sala)
        {
            _context.Update(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task<Sala> RemoveAsync(Sala sala)
        {
            _context.Remove(sala);
            await _context.SaveChangesAsync();
            return sala;
        }
    }
}
