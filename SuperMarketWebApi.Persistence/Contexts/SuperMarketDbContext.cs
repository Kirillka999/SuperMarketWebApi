using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Core.Entities;

namespace SuperMarketWebApi.Persistence.Contexts
{
    public class SuperMarketDbContext : IdentityDbContext
    {
        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartStatus> CartStatus { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasKey(o => o.Id);
            
            builder.Entity<CartStatus>()
                .HasKey(cs => cs.Id);

            builder.Entity<Order>()
                .HasKey(o => o.Id);

            builder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.Status);
            
            builder.Entity<OrderStatus>()
                .HasKey(os => os.Id);
            
            builder.Entity<ProductCategory>()
                .HasKey(pc => pc.Id);
            
            builder.Entity<ProductInfo>()
                .HasKey(pi => pi.Id);
            
            
            
            base.OnModelCreating(builder);
        }
    }
}