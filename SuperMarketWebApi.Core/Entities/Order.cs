namespace SuperMarketWebApi.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public ProductInfo ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus StatusId { get; set; }
        public decimal InstantPrice { get; set; }
    }
}