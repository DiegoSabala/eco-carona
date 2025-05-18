using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations;

public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.ToTable("avaliacoes", "carona");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Nota).IsRequired();
    }
}
