using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class ProductGroupAgeConfiguration : IEntityTypeConfiguration<ProductGroupAge>
    {
        public void Configure(EntityTypeBuilder<ProductGroupAge> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.ProductGroup)
              .WithMany(x => x.ProductsGroupsAges)
              .HasForeignKey(x => x.ProductGroupId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Age)
             .WithMany(x => x.ProductsGroupsAges)
             .HasForeignKey(x => x.AgeId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
