using Microsoft.EntityFrameworkCore;
using Reserva.Domain.Interfaces;
using Reserva.Infra.Data.Context;

namespace Reserva.Infra.Data.Repositories
{
    public class AgendaValidacoesRepository : IAgendaValidacoesRepository
    {
        private readonly AppDbContext _context;

        public AgendaValidacoesRepository(AppDbContext context)
        {
            _context = context;
        }

        public int ConsultarAgendamentosPorDataEHorarios(DateTime dataAgenda, int horario, int salaId)
        {
            var i = _context.Agendas.Include(x => x.Sala).Where(x => x.DataAgenda == dataAgenda &&
                                               x.QtdeHorarios == horario &&
                                               x.SalaId == salaId).Count();
            return i;
        }
    }
}
