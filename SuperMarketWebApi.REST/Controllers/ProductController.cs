using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Application.Services;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Records;
using SuperMarketWebApi.Persistence.Contexts;

namespace SuperMarketWebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(SuperMarketDbContext context, IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken ct)
        {
            var products = await _productService.GetAllProducts(ct);
            
            return Ok(products);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id, CancellationToken ct)
        {
            var productById = await _productService.GetProductById(id, ct);
            
            return Ok(productById);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(CreateNewProductRequest request, CancellationToken ct)
        {
            await _productService.CreateNewProduct(request, ct);
            
            return NoContent();
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductById(int id, UpdateProductRequest request, CancellationToken ct)
        {
            await _productService.UpdateProductById(id, request, ct);

            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductById(int id, CancellationToken ct)
        {
            await _productService.DeleteProductById(id, ct);
            
            return NoContent();
        }
    }
}