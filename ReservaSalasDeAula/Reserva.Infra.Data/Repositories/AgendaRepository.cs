using Microsoft.EntityFrameworkCore;
using Reserva.Domain.Entidades;
using Reserva.Domain.Interfaces;
using Reserva.Infra.Data.Context;

namespace Reserva.Infra.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AppDbContext _context;

        public AgendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agenda>> GetAgendasAsync()
        {
            return await _context.Agendas.Include(x => x.Sala).Where(x => x.DataAgenda >= DateTime.UtcNow).ToListAsync();
        }

        public async Task<IEnumerable<Agenda>> GetAgendasPorDataAsync(DateTime dataAgenda)
        {
            return await _context.Agendas.TemporalBetween(dataAgenda, DateTime.Now).ToListAsync();
        }

        public async Task<IEnumerable<Agenda>> GetAgendasPorProfessorAsync(string professor)
        {
            return await _context.Agendas.Where(x => x.ProfessorResponsavel.Contains(professor)).ToListAsync();
        }

        public async Task<Agenda> GetAgendaPorIdAsync(int id)
        {
            return await _context.Agendas.FindAsync(id) ?? throw new ArgumentException();
        }

        public async Task<Agenda> CreateAsync(Agenda agenda)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();
            return agenda;
        }

        public async Task<Agenda> UpdateAsync(Agenda agenda)
        {
            _context.Update(agenda);
            await _context.SaveChangesAsync();
            return agenda;
        }

        public async Task<Agenda> RemoveAsync(Agenda agenda)
        {
            _context.Remove(agenda);
            await _context.SaveChangesAsync();
            return agenda;
        }
    }
}
