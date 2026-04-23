using EShop.Domain;
using EShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id) => 
        await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product) => 
        await _context.Products.AddAsync(product);

    public async Task SaveChangesAsync() => 
        await _context.SaveChangesAsync();
}
