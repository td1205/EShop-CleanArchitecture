using Microsoft.EntityFrameworkCore;
using EShop.Domain;

namespace EShop.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Sử dụng Set<Product>() để tránh cảnh báo Nullable trong .NET 8
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products"); // Định nghĩa tên bảng rõ ràng
            entity.HasKey(p => p.Id); 
            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(200);
            
            entity.Property(p => p.Price)
                  .HasPrecision(18, 2); 

            // Gợi ý thêm: Bạn có thể cấu hình giá trị mặc định cho Stock
            entity.Property(p => p.Stock)
                  .HasDefaultValue(0);
        });
    }
}
