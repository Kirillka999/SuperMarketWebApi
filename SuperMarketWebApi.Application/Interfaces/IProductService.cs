using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Records;

namespace SuperMarketWebApi.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductInfo>> GetAllProducts(CancellationToken ct);
    Task<ProductInfo> GetProductById(int id, CancellationToken ct);
    Task CreateNewProduct(CreateNewProductRequest request, CancellationToken ct);
    Task UpdateProductById(int id, UpdateProductRequest request, CancellationToken ct);
    Task DeleteProductById(int id, CancellationToken ct);
}