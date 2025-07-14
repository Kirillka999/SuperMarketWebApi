using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Core.Entities;
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
            
        return productById;
    }
    
    public async Task CreateNewProduct(CreateNewProductRequest request, CancellationToken ct)
    {
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
        var productToUpdate = await _context.ProductInfo
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(ct);

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

        _context.ProductInfo.Remove(productToDelete);
        await _context.SaveChangesAsync(ct);
    }
}