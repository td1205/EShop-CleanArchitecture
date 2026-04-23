using EShop.Infrastructure;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore; // Quan trọng: Cần để dùng .UseSqlServer()
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Get and Validate Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

// 2. Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Register Services & Repositories
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configure Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Lưu ý: Trên WSL, nếu gặp lỗi HTTPS port, hãy tạm comment dòng này
// app.UseHttpsRedirection(); 

app.MapControllers();

app.Run();
