namespace SuperMarketWebApi.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? PlacementDate { get; set; }
        
        
        public CartStatus Status { get; set; }
        public int StatusId { get; set; } 
    }
}

