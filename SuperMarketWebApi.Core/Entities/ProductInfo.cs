namespace SuperMarketWebApi.Core.Entities
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProductCategory CategoryId { get; set; }
        public string? Photo { get; set; }
        public string? PhotoHash { get; set; }
        public decimal Price { get; set; }
    }
}