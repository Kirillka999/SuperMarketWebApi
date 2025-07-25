namespace SuperMarketWebApi.Core.Entities
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        
        public string? Photo { get; set; }
        public string? PhotoHash { get; set; }
        public decimal Price { get; set; }
    }
}