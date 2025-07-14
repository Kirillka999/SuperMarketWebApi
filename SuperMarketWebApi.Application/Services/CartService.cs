using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Controllers;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Exceptions;
using SuperMarketWebApi.Core.Records;
using SuperMarketWebApi.Persistence.Contexts;
namespace SuperMarketWebApi.Application.Services;

public class CartService : ICartService
{
    private readonly SuperMarketDbContext _context;

    public CartService(SuperMarketDbContext context)
    {
        _context = context;
    }
    
    public async Task<Cart> CreateNewUserCart(string userIdFromToken, CancellationToken ct)
    {
        var newCart = new Cart()
        {
            UserId = userIdFromToken,
            StatusId = 1
        };
        
        _context.Cart.Add(newCart);
        await _context.SaveChangesAsync(ct);

        return newCart;
    }

    public async Task PlaceOrderForLatestCart(string userIdFromToken, CancellationToken ct)
    {
        var latestCart = await GetUserLatestCart(userIdFromToken, ct);
        
        if (latestCart.StatusId == 2 || latestCart.StatusId == 3)
        {
            throw new OrderPlaceException("Can not place order: cart order is already placed or completed");
        }
        
        var cartOrders = _context.Order
            .Where(o => o.CartId == latestCart.Id);

        if (!cartOrders.Any())
        {
            throw new OrderPlaceException("Can not place order: user cart is empty");
        }
        
        foreach (var cartOrder in cartOrders)
        {
            cartOrder.StatusId = 2;
        }
        
        latestCart.StatusId = 2;
        latestCart.PlacementDate = DateTime.UtcNow;
            
        await _context.SaveChangesAsync(ct);
    }

    public async Task AddOrderToCart(string userIdFromToken, AddOrderToCartRequest request, CancellationToken ct)
    {
        var latestCart = await GetUserLatestCart(userIdFromToken, ct);

        if (latestCart.StatusId == 2 || latestCart.StatusId == 3)
        {
            throw new OrderAddException("Can not add order to cart: cart order is already placed or completed");
        }

        if (request.Quantity <= 0)
        {
            throw new OrderAddException("Can not add order to cart: quantity can not be 0 or negative");
        }

        var productForOrder = await _context.ProductInfo
            .Where(p => p.Id == request.ProductId)
            .FirstOrDefaultAsync(ct);

        if (productForOrder is null)
        {
            throw new OrderAddException("Can not add order to cart: product with this id does not exit");
        }
        
        var newOrder = new Order()
        {
            CartId = latestCart.Id,
            ProductId = productForOrder.Id,
            StatusId = 1,
            Quantity = request.Quantity,
            InstantPrice = productForOrder.Price * request.Quantity
        };
        
        await _context.Order.AddAsync(newOrder, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Cart> GetUserLatestCart(string userIdFromToken, CancellationToken ct)
    {
        var latestCart = await _context.Cart
            .Where(c => c.UserId == userIdFromToken)
            .OrderByDescending(c => c.CreatedAt)
            .FirstOrDefaultAsync(ct);
        
        if (latestCart is null)
        {
            throw new GetCartException("Can not get latest user cart: create a cart first");
        }

        return latestCart;
    }

    public async Task<List<Order>> GetUserLatestCartOrders(string userIdFromToken, CancellationToken ct)
    {
        var latestCart = await GetUserLatestCart(userIdFromToken, ct);
        var latestCartOrders = await _context.Order
            .Where(o => o.CartId == latestCart.Id)
            .ToListAsync(ct);

        return latestCartOrders;
    }
}