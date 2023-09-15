namespace Reserva.Application.Interfaces
{
    public interface IAgendaValidacoes
    {
        int ConsultarAgendamentosPorDataEHorarios(DateTime dataAgenda, int horario, int salaId);
    }
}
