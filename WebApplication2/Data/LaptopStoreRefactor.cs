using LaptopStoreRefactorDb.Model;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreRefactorDb.Data
{
  public class LaptopStoreRefactor : DbContext
  {
    public LaptopStoreRefactor(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Laptop> Laptops { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<LaptopAndStore> LaptopsAndStores { get; set; } = null!;
  }
}
