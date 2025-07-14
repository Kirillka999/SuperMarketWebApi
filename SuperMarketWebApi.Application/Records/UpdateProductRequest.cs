namespace SuperMarketWebApi.Core.Records;

public record UpdateProductRequest(string Name, string Description, int CategoryId, string Photo, decimal Price);