namespace SuperMarketWebApi.Core.Entities
{
    public class CartStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Cart> Carts { get; set; }
    }
}

