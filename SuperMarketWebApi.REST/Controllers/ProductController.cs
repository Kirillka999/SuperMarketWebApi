using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.Application.Interfaces;
using SuperMarketWebApi.Core.Records;

namespace SuperMarketWebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
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