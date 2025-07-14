namespace SuperMarketWebApi.Core.Records;

public record CreateNewProductRequest(string Name, string Description, int CategoryId, string Photo, decimal Price);