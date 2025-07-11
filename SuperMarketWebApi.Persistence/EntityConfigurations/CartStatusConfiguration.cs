using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarketWebApi.Core.Entities;

namespace SuperMarketWebApi.Persistence.EntityConfigurations;

public class CartStatusConfiguration : IEntityTypeConfiguration<CartStatus>
{
    public void Configure(EntityTypeBuilder<CartStatus> builder)
    {
        builder.HasKey(cs => cs.Id);
    }
}