using Reserva.Domain.Validation;
using static Reserva.Domain.Entidades.Enumeradores;

namespace Reserva.Domain.Entidades
{
    public sealed class Sala : Entity
    {
        public string NomeSala { get; set; } = string.Empty;
        public TipoSala TipoSala { get; set; }
        public Agenda? Agenda { get; set; }

        public Sala(string nomeSala, TipoSala tipoSala)
        {
            ValidateDomain(nomeSala, tipoSala);
        }

        public Sala(int id, string nomeSala, TipoSala tipoSala)
        {
            DomainExceptionValidation.When(id <= 0, "Id inválido");
            Id = id;

            ValidateDomain(nomeSala, tipoSala);
        }

        public void ValidateDomain(string nomeSala, TipoSala tipoSala)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeSala), "Informe o nome da sala");

            NomeSala = nomeSala;
            TipoSala = tipoSala;
        }
    }
}
