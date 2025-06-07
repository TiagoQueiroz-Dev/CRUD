using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext;

public class Context : ContextBase
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<GeneroEnum> GeneroTipo { get; set; }


}