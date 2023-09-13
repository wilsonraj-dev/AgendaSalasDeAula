using Reserva.Domain.Validation;

namespace Reserva.Domain.Entidades
{
    public class Agenda : Entity
    {
        public DateTime DataAgenda { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string ProfessorResponsavel { get; set; } = string.Empty;
        public int QtdeHorarios { get; set; }
        public int SalaId { get; set; }
        public virtual Sala? Sala { get; set; }

        public Agenda(DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, int salaId)
        {
            ValidateDomain(dataAgenda, descricao, professorResponsavel, qtdeHorarios, salaId);
        }

        public Agenda(int id, DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, int salaId)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;

            ValidateDomain(dataAgenda, descricao, professorResponsavel, qtdeHorarios, salaId);
        }

        private void ValidateDomain(DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, int salaId)
        {
            DomainExceptionValidation.When(new DateTime(dataAgenda.Year, dataAgenda.Month, dataAgenda.Day) < DateTime.Today, "A data de agendamento da sala não pode ser menor que a data atual.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Preencha a descrição de uso.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(professorResponsavel), "Informe o professor responsável.");
            DomainExceptionValidation.When(qtdeHorarios <= 0, "Informe quantos horários serão usados.");
            DomainExceptionValidation.When(salaId <= 0, "Informe qual sala será usada.");

            DataAgenda = new DateTime(dataAgenda.Year, dataAgenda.Month, dataAgenda.Day);
            Descricao = descricao;
            ProfessorResponsavel = professorResponsavel;
            QtdeHorarios = qtdeHorarios;
            SalaId = salaId;
        }
    }
}
