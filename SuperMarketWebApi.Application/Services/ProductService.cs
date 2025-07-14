using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Application.Interfaces;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Exceptions;
using SuperMarketWebApi.Core.Records;
using SuperMarketWebApi.Persistence.Contexts;

namespace SuperMarketWebApi.Application.Services;

public class ProductService : IProductService
{
    private readonly SuperMarketDbContext _context;

    public ProductService(SuperMarketDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductInfo>> GetAllProducts(CancellationToken ct)
    {
        var products = await _context.ProductInfo.ToListAsync(ct);
        return products;
    }
    
    public async Task<ProductInfo> GetProductById(int id, CancellationToken ct)
    {
        var productById = await _context.ProductInfo
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(ct);

        if (productById is null)
        {
            throw new ProductException("Can not find product with this id");
        }
        
        return productById;
    }

    public async Task CreateNewProduct(CreateNewProductRequest request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name.Trim()))
        {
            throw new ProductException("Can not create product with blank name");
        }

        if (request.Price <= 0)
        {
            throw new ProductException("Can not create product with negative or zero price");
        }

        var categories = await _context.ProductCategory
            .ToListAsync(ct);

        if (!categories.Any(pc => pc.Id == request.CategoryId))
        {
            throw new ProductException("This category does not exist");
        }

        var newProduct = new ProductInfo()
        {
            Name = request.Name,
            Description = request.Description,
            CategoryId = request.CategoryId,
            Photo = request.Photo,
            Price = request.Price
        };
        
        await _context.ProductInfo.AddAsync(newProduct, ct);
        await _context.SaveChangesAsync(ct);
    }
    
    public async Task UpdateProductById(int id, UpdateProductRequest request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name.Trim()))
        {
            throw new ProductException("Can not create product with blank name");
        }

        if (request.Price <= 0)
        {
            throw new ProductException("Can not create product with negative or zero price");
        }
        
        var productToUpdate = await _context.ProductInfo
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(ct);

        if (productToUpdate is null)
        {
            throw new ProductException("Can not find product with this id");
        }

        productToUpdate.Name = request.Name;
        productToUpdate.Description = request.Description;
        productToUpdate.CategoryId = request.CategoryId;
        productToUpdate.Photo = request.Photo;
        productToUpdate.Price = request.Price;

        await _context.SaveChangesAsync(ct);
    }
    
    public async Task DeleteProductById(int id, CancellationToken ct)
    {
        var productToDelete = await _context.ProductInfo
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(ct);
        
        if (productToDelete is null)
        {
            throw new ProductException("Can not find product with this id");
        }

        _context.ProductInfo.Remove(productToDelete);
        await _context.SaveChangesAsync(ct);
    }
}