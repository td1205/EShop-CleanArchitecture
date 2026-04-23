using Microsoft.EntityFrameworkCore;
using EShop.Domain;

namespace EShop.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // This represents the "Products" table in your SQL database
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // This is "Fluent API" - The professional way to configure tables
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id); // Set ID as Primary Key
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Price).HasPrecision(18, 2); // 18 digits, 2 decimal places
        });
    }
}