using LaptopStoreRefactorDb.Model;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreRefactorDb.Data
{
  public class LaptopStoreRefactor : DbContext
  {
    public LaptopStoreRefactor(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Laptop>()
        .HasOne(l => l.Brand)
        .WithMany(b => b.Laptops)
        .HasForeignKey(l => l.BrandId);

      modelBuilder.Entity<LaptopAndStore>()
        .HasKey(lp => new
        {
          lp.StoreId,
          lp.LaptopId
        });
    }

    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Laptop> Laptops { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<LaptopAndStore> LaptopsAndStores { get; set; } = null!;
  }
}
