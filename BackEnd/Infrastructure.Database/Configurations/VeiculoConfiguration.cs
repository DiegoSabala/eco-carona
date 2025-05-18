using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("veiculos", "carona");
        builder.HasKey(v => v.Id);
        builder.HasIndex(v => v.Placa).IsUnique();
        builder.Property(v => v.Vagas).IsRequired();
        builder.Property(v => v.ConsumoMedio).IsRequired();
        builder.HasOne(v => v.Usuario).WithMany().HasForeignKey(v => v.UsuarioId);
    }
}
