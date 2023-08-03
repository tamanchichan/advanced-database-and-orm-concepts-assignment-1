using LaptopStoreRefactorDb.Model;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreRefactorDb.Data
{
  public class SeedData
  {
    public async static Task Initialize(IServiceProvider serviceProvider)
    {
      LaptopStoreRefactor db = new LaptopStoreRefactor(
        serviceProvider
        .GetRequiredService<DbContextOptions<LaptopStoreRefactor>>()
        );

      db.Database.EnsureDeleted();
      db.Database.Migrate();

      // Brand
      Brand brandOne = new Brand()
      {
        Id = Guid.NewGuid(),
        Name = "Apple"
      };

      Brand brandTwo = new Brand()
      {
        Id = Guid.NewGuid(),
        Name = "Asus"
      };

      Brand brandThree = new Brand()
      {
        Id = Guid.NewGuid(),
        Name = "2.A.M. Gaming"
      };

      if (!db.Brands.Any())
      {
        db.Add(brandOne);
        db.Add(brandTwo);
        db.Add(brandThree);
        db.SaveChanges();
      }

      // Laptop
      Laptop laptopOne = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandOne,
        Model = "MacBook Air",
        Price = 1500.00m,
        Condition = LaptopCondition.New
      };

      Laptop laptopTwo = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandOne,
        Model = "MacBook Pro",
        Price = 850.00m,
        Condition = LaptopCondition.Refurbished
      };

      Laptop laptopThree = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandOne,
        Model = "iMac",
        Price = 59.99m,
        Condition = LaptopCondition.Rental
      };

      Laptop laptopFour = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandTwo,
        Model = "Rog Strix",
        Price = 3000.00m,
        Condition = LaptopCondition.New
      };

      Laptop laptopFive = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandTwo,
        Model = "Rog Zephyrus",
        Price = 1000.00m,
        Condition = LaptopCondition.Refurbished
      };

      Laptop laptopSix = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandTwo,
        Model = "TUF Gaming",
        Price = 29.99m,
        Condition = LaptopCondition.Rental
      };

      Laptop laptopSeven = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandThree,
        Model = "Y500",
        Price = 750.00m,
        Condition = LaptopCondition.New
      };

      Laptop laptopEight = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandThree,
        Model = "E500",
        Price = 500.00m,
        Condition = LaptopCondition.Refurbished
      };

      Laptop laptopNine = new Laptop()
      {
        Id = Guid.NewGuid(),
        Brand = brandThree,
        Model = "E550",
        Price = 44.99m,
        Condition = LaptopCondition.Rental
      };

      if (!db.Laptops.Any())
      {
        db.Add(laptopOne);
        db.Add(laptopTwo);
        db.Add(laptopThree);
        db.Add(laptopFour);
        db.Add(laptopFive);
        db.Add(laptopSix);
        db.Add(laptopSeven);
        db.Add(laptopEight);
        db.Add(laptopNine);
        db.SaveChanges();
      }

      // Store
      Store storeOne = new Store()
      {
        Id = Guid.NewGuid(),
        StreetName = "Fake St",
        StreetNumber = 111,
        Province = "Manitoba"
      };

      Store storeTwo = new Store()
      {
        Id = Guid.NewGuid(),
        StreetName = "Fake Ave",
        StreetNumber = 222,
        Province = "Manitoba"
      };

      Store storeThree = new Store()
      {
        Id = Guid.NewGuid(),
        StreetName = "Fake Pl",
        StreetNumber = 333,
        Province = "Manitoba"
      };

      if (!db.Stores.Any())
      {
        db.Add(storeOne);
        db.Add(storeTwo);
        db.Add(storeThree);
        db.SaveChanges();
      }

      // Laptop And Store
      LaptopAndStore lsOne = new LaptopAndStore()
      {
        Laptop = laptopOne,
        Store = storeOne,
        Quantity = 10
      };

      LaptopAndStore lsTwo = new LaptopAndStore()
      {
        Laptop = laptopTwo,
        Store = storeOne,
        Quantity = 5
      };

      LaptopAndStore lsThree = new LaptopAndStore()
      {
        Laptop = laptopThree,
        Store = storeOne,
        Quantity = 1
      };

      LaptopAndStore lsFour = new LaptopAndStore()
      {
        Laptop = laptopFour,
        Store = storeTwo,
        Quantity = 10
      };

      LaptopAndStore lsFive = new LaptopAndStore()
      {
        Laptop = laptopFive,
        Store = storeTwo,
        Quantity = 5
      };

      LaptopAndStore lsSix = new LaptopAndStore()
      {
        Laptop = laptopSix,
        Store = storeTwo,
        Quantity = 10
      };

      LaptopAndStore lsSeven = new LaptopAndStore()
      {
        Laptop = laptopSeven,
        Store = storeThree,
        Quantity = 10
      };

      LaptopAndStore lsEight = new LaptopAndStore()
      {
        Laptop = laptopEight,
        Store = storeThree,
        Quantity = 5
      };

      LaptopAndStore lsNine = new LaptopAndStore()
      {
        Laptop = laptopNine,
        Store = storeThree,
        Quantity = 1
      };

      if (!db.LaptopsAndStores.Any())
      {
        db.Add(lsOne);
        db.Add(lsTwo);
        db.Add(lsThree);
        db.Add(lsFour);
        db.Add(lsFive);
        db.Add(lsSix);
        db.Add(lsSeven);
        db.Add(lsEight);
        db.Add(lsNine);
        db.SaveChanges();
      }
    }
  }
}
