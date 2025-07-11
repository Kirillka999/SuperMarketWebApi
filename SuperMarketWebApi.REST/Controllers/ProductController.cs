using Microsoft.AspNetCore.Mvc;

public record NewProductRequest(string Email, string FullName, string Password);
public record UpdateProductRequest(string Email, string FullName, string Password);

namespace SuperMarketWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken ct)
        { 
            return Ok();
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id, CancellationToken ct)
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(NewProductRequest product, CancellationToken ct)
        { 
            return Ok();
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductById(int id, UpdateProductRequest product, CancellationToken ct)
        { 
            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductById(int id, CancellationToken ct)
        { 
            return Ok();
        }
    }
}