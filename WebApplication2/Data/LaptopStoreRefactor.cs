using LaptopStoreRefactorDb.Model;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreRefactorDb.Data
{
  public class LaptopStoreRefactor : DbContext
  {
    public LaptopStoreRefactor(DbContextOptions options) : base(options) { }

    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Laptop> Laptops { get; set; } = null!;
  }
}
