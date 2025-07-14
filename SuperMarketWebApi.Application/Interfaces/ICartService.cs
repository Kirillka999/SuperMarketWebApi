using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Core.Records;

namespace SuperMarketWebApi.Controllers;

public interface ICartService
{
    Task<Cart> CreateNewUserCart(string userId, CancellationToken ct);
    Task PlaceOrderForLatestCart(string userIdFromToken, CancellationToken ct);
    Task AddOrderToCart(string userIdFromToken, AddOrderToCartRequest request, CancellationToken ct);
    Task<Cart> GetUserLatestCart(string userIdFromToken, CancellationToken ct);
    Task<List<Order>> GetUserLatestCartOrders(string userIdFromToken, CancellationToken ct);
}