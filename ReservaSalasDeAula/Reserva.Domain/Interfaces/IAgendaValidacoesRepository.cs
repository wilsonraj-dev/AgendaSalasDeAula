namespace Reserva.Domain.Interfaces
{
    public interface IAgendaValidacoesRepository
    {
        int ConsultarAgendamentosPorDataEHorarios(DateTime dataAgenda, int horario, int salaId);
    }
}
