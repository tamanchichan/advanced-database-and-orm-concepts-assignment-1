using LaptopStoreRefactorDb.Data;
using LaptopStoreRefactorDb.Model;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("LaptopStoreRefactorDbConnection");

builder.Services.AddDbContext<LaptopStoreRefactor>(options =>
{
  options.UseSqlServer(connectionString);
});

builder.Services.Configure<JsonOptions>(options =>
{
  options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
  IServiceProvider services = scope.ServiceProvider;

  await SeedData.Initialize(services);
}

app.MapGet("/laptops/search", (LaptopStoreRefactor db, decimal? amountAbove, decimal? amountBelow, Guid? storeNumber, string? province, LaptopCondition? condition, Guid? brandId, string? searchPhrase) =>
{
  try
  {
    var laptopAndStore = db.LaptopsAndStores.AsQueryable();

    if (amountAbove != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Laptop.Price > amountAbove);
    }

    if (amountBelow != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Laptop.Price < amountBelow);
    }

    if (storeNumber != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Store.Id == storeNumber && ls.Quantity > 0);
    }
    else if (!String.IsNullOrEmpty(province))
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Store.Province == province && ls.Quantity > 0);
    }

    if (condition != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Laptop.Condition == condition);
    }

    if (brandId != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Laptop.BrandId == brandId);
    }

    if (searchPhrase != null)
    {
      laptopAndStore = laptopAndStore.Where(ls => ls.Laptop.Model.Contains(searchPhrase));
    }

    return Results.Ok(laptopAndStore.Select(ls => new
    {
      Laptop = new
      {
        Id = ls.Laptop.Id,
        Model = ls.Laptop.Model,
        Brand = ls.Laptop.Brand,
        Price = ls.Laptop.Price,
        Condition = ls.Laptop.Condition,
        Quantity = ls.Quantity
      }
    }));
  }
  catch (Exception ex)
  {
    return Results.Problem(ex.Message);
  }
});

app.Run();
