using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("pagamentos", "carona");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Valor).IsRequired();
        builder.HasCheckConstraint("check_valor", "valor >= 0");
    }
}
