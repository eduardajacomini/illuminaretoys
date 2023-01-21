using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.Product)
              .WithMany(x => x.ProductsGroups)
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Group)
             .WithMany(x => x.ProductsGroups)
             .HasForeignKey(x => x.GroupId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
