using Microsoft.AspNetCore.Mvc;
using EShop.Domain;
using EShop.Domain.Interfaces;

namespace EShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    // The repository is "Injected" here automatically by .NET
    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, decimal price, int stock)
    {
        // 1. Create the Object (Using the OOP rules we set in Step 2)
        var product = new Product(name, price, stock);

        // 2. Use the Repository to add it
        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return Ok(product);
    }
}
