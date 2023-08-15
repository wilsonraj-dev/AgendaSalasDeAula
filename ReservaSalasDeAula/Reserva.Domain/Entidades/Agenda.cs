using Reserva.Domain.Validation;

namespace Reserva.Domain.Entidades
{
    public sealed class Agenda : Entity
    {
        public DateTime DataAgenda { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string ProfessorResponsavel { get; set; } = string.Empty;
        public int QtdeHorarios { get; set; }
        public bool Disponivel { get; set; } = true;
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }

        public Agenda(DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, bool disponivel, int salaId)
        {
            ValidateDomain(dataAgenda, descricao, professorResponsavel, qtdeHorarios, disponivel, salaId);
        }

        public Agenda(int id, DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, bool disponivel, int salaId)
        {
            DomainExceptionValidation.When(id <= 0, "Id inválido.");
            Id = id;

            ValidateDomain(dataAgenda, descricao, professorResponsavel, qtdeHorarios, disponivel, salaId);
        }

        private void ValidateDomain(DateTime dataAgenda, string descricao, string professorResponsavel, int qtdeHorarios, bool disponivel, int salaId)
        {
            DomainExceptionValidation.When(dataAgenda < DateTime.UtcNow, "A data de agendamento da sala não pode ser menor que a data atual.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Preencha a descrição de uso.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(professorResponsavel), "Informe o professor responsável.");
            DomainExceptionValidation.When(qtdeHorarios <= 0, "Informe quantos horários serão usados.");
            DomainExceptionValidation.When(salaId <= 0, "Informe qual sala será usada.");

            DataAgenda = dataAgenda;
            Descricao = descricao;
            ProfessorResponsavel = professorResponsavel;
            QtdeHorarios = qtdeHorarios;
            Disponivel = disponivel;
            SalaId = salaId;
        }
    }
}
