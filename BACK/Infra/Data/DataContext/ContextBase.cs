using Microsoft.EntityFrameworkCore;

namespace Data.DataContext;

public abstract class ContextBase : DbContext
{
    protected ContextBase(DbContextOptions options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}