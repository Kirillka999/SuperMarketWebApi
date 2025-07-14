namespace SuperMarketWebApi.Core.Records;

public record AddOrderToCartRequest(int ProductId, int Quantity);