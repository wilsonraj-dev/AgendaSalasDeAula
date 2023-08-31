using AutoMapper;
using Reserva.Application.DTOs;
using Reserva.Domain.Entidades;

namespace Reserva.Application.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Agenda, AgendaDTO>().ReverseMap();
            CreateMap<Sala, SalaDTO>().ReverseMap();
        }
    }
}
