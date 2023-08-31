using System.ComponentModel.DataAnnotations;
using static Reserva.Domain.Entidades.Enumeradores;

namespace Reserva.Application.DTOs
{
    public class SalaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string NomeSala { get; set; } = string.Empty;

        [Required]
        public TipoSala TipoSala { get; set; }
    }
}
