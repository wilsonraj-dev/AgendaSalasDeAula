using Reserva.Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reserva.Application.DTOs
{
    public class AgendaDTO
    {
        public int Id { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataAgenda { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string ProfessorResponsavel { get; set; } = string.Empty;

        [Required]
        [Range(1, 5)]
        public int QtdeHorarios { get; set; }

        [JsonIgnore]
        public Sala? Sala;

        [Required]
        public int SalaId { get; set; }
    }
}
