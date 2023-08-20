using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reserva.Domain.Entidades;

namespace Reserva.Infra.Data.EntitiesConfiguration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataAgenda).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ProfessorResponsavel).HasMaxLength(50).IsRequired();
            builder.Property(x => x.QtdeHorarios).IsRequired();
            builder.HasOne(x => x.Sala).WithOne(x => x.Agenda)
                                       .HasForeignKey<Agenda>(x => x.SalaId).IsRequired();
        }
    }
}
