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
                .HasKey(e => e.Id);

            builder.Entity<Cart>()
                .HasOne(e => e.Status)
                .WithMany(e => e.Carts)
                .HasForeignKey(e => e.StatusId);
            
            builder.Entity<CartStatus>()
                .HasKey(e => e.Id);
            
            builder.Entity<Order>()
                .HasKey(e => e.CartId);
            
            builder.Entity<OrderStatus>()
                .HasKey(e => e.Id);
            
            builder.Entity<ProductCategory>()
                .HasKey(e => e.Id);
            
            builder.Entity<ProductInfo>()
                .HasKey(e => e.Id);
            
            
            
            base.OnModelCreating(builder);
        }
    }
}