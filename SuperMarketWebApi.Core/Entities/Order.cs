using System.Security.AccessControl;

namespace SuperMarketWebApi.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        
        public int ProductId { get; set; }
        public ProductInfo Product { get; set; }
        
        public int Quantity { get; set; }
        
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }
        
        public decimal InstantPrice { get; set; }
    }
}