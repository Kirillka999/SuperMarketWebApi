namespace SuperMarketWebApi.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Cart { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public decimal InstantPrice { get; set; }
    }
}