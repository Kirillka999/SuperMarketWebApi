namespace SuperMarketWebApi.Core.Entities
{
    public class Order
    {
        public Cart CartId { get; set; }
        public ProductInfo ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus StatusId { get; set; }
        public decimal InstantPrice { get; set; }
    }
}