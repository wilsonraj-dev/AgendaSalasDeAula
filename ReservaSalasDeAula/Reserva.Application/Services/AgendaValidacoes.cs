using Reserva.Application.Interfaces;
using Reserva.Domain.Interfaces;

namespace Reserva.Application.Services
{
    public class AgendaValidacoes : IAgendaValidacoes
    {
        private readonly IAgendaValidacoesRepository _agenda;

        public AgendaValidacoes(IAgendaValidacoesRepository agenda)
        {
            _agenda = agenda;
        }

        public int ConsultarAgendamentosPorDataEHorarios(DateTime dataAgenda, int horario, int salaId)
        {
            return _agenda.ConsultarAgendamentosPorDataEHorarios(dataAgenda, horario, salaId);
        }
    }
}
