using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reserva.Domain.Entidades;

namespace Reserva.Infra.Data.EntitiesConfiguration
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeSala).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TipoSala).HasColumnType("int").IsRequired();
        }
    }
}
