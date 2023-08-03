using LaptopStoreRefactorDb.Data;
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

app.Run();
