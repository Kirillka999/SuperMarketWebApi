using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SuperMarketWebApi.Core.Entities;
using SuperMarketWebApi.Persistence.EntityConfigurations;

namespace SuperMarketWebApi.Persistence.Contexts
{
    public class SuperMarketDbContext : IdentityDbContext<SuperMarketUser>
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
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CartStatusConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductInfoConfiguration());
        }
    }
}