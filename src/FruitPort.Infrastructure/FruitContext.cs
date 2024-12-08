using Microsoft.EntityFrameworkCore;

namespace FruitPort.Infrastructure;

public class FruitContext : DbContext
{
    public FruitContext() { }

    public FruitContext(DbContextOptions<FruitContext> options)
        : base(options) { }
    public DbSet<FruitType> FruitTypes => Set<FruitType>();
    public DbSet<FruitStock> FruitStocks => Set<FruitStock>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FruitType>()
            .HasMany(ft => ft.StockEntries)
            .WithOne(fs => fs.FruitType)
            .HasForeignKey(fs => fs.FruitTypeId);
    }
}
