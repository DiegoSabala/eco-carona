using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class ViagemConfiguration : IEntityTypeConfiguration<Viagem>
{
    public void Configure(EntityTypeBuilder<Viagem> builder)
    {
        builder.ToTable("viagens", "carona");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.VagasDisponiveis).IsRequired();
        builder.Property(v => v.CustoEstimado).IsRequired();
        builder.HasCheckConstraint("check_vagas", "vagas_disponiveis >= 0");
        builder.HasCheckConstraint("check_custo", "custo_estimado >= 0");
    }
}
