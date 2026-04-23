using Microsoft.EntityFrameworkCore;
using EShop.Infrastructure;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Repositories;
using Microsoft.OpenApi.Models; // Add this if needed
var builder = WebApplication.CreateBuilder(args);

// 1. Get the Connection String from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Register ApplicationDbContext with Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This enables the /swagger/index.html page
}
// 3. Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
