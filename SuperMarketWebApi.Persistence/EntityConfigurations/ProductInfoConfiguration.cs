using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarketWebApi.Core.Entities;

namespace SuperMarketWebApi.Persistence.EntityConfigurations;

public class ProductInfoConfiguration : IEntityTypeConfiguration<ProductInfo>
{
    public void Configure(EntityTypeBuilder<ProductInfo> builder)
    {
        builder.HasKey(pi => pi.Id);
    }
}