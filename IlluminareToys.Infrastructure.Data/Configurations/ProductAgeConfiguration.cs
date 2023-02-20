using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class ProductAgeConfiguration : IEntityTypeConfiguration<ProductAge>
    {
        public void Configure(EntityTypeBuilder<ProductAge> builder)
        {
            builder.HasOne(x => x.Product)
               .WithMany(x => x.ProductsAges)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Age)
               .WithMany(x => x.ProductsAges)
               .HasForeignKey(x => x.AgeId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
        }
    }
}
