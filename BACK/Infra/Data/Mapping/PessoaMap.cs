using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Excluido).IsRequired();
        builder.Property(p => p.CriadoDataHora).IsRequired().HasColumnType("date");
        builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("date");
        builder.Property(p => p.CPF).IsRequired().HasColumnType("varchar(11)");
        builder.Property(p => p.Genero).IsRequired();
    }
}