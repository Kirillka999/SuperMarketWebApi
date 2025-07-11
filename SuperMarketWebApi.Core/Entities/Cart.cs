namespace SuperMarketWebApi.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public SuperMarketUser User { get; set; }
        
        public DateTime? PlacementDate { get; set; }
        
        public int StatusId { get; set; }
        public CartStatus Status { get; set; }
    }
}

