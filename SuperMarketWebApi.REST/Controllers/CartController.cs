using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Records;
using SuperMarketWebApi.Persistence.Contexts;

namespace SuperMarketWebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]/[action]")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewCart(CancellationToken ct)
    {
        var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var newCart =  await _cartService.CreateNewUserCart(userIdFromToken, ct);

        return Ok(new CreateNewCartResponse(newCart.Id));
    }
    
    [HttpPut]
    public async Task<IActionResult> PlaceOrderForLatestCart(CancellationToken ct)
    {
        var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await _cartService.PlaceOrderForLatestCart(userIdFromToken, ct);

        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrderToCart(AddOrderToCartRequest request, CancellationToken ct)
    {
        var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await _cartService.AddOrderToCart(userIdFromToken, request, ct);

        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> ShowCartOrders(CancellationToken ct)
    {
        var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var tempOrders = await _cartService.GetUserLatestCartOrders(userIdFromToken, ct);
        var orders = tempOrders.Select(o => new
        {
            o.ProductId,
            o.Quantity,
            o.StatusId,
            o.InstantPrice
        });

        return Ok(orders);
    }
    
}