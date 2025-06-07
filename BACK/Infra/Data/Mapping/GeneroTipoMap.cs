using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping;

public class GeneroTipoMap : IEntityTypeConfiguration<GeneroEnum>
{
    public void Configure(EntityTypeBuilder<GeneroEnum> builder)
    {
        builder.ToTable("GeneroTipo","enum");

        builder.HasKey(x => x.Id);
        builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
    }
}