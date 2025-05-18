using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("reservas", "carona");
        builder.HasKey(r => r.Id);

        builder.HasCheckConstraint("check_status", "status IN ('PENDENTE', 'ACEITA', 'RECUSADA')");
        builder.HasCheckConstraint("check_viagem_ou_rota", "viagem_id IS NOT NULL OR rota_id IS NOT NULL");
    }
}
