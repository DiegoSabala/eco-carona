using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class RotaConfiguration : IEntityTypeConfiguration<Rota>
{
    public void Configure(EntityTypeBuilder<Rota> builder)
    {
        builder.ToTable("rotas", "carona");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.DiasSemana).IsRequired().HasMaxLength(50);
        builder.HasOne(r => r.Veiculo).WithMany().HasForeignKey(r => r.MotoristaId);
    }
}
