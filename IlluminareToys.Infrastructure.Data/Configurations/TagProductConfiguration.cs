using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class TagProductConfiguration : IEntityTypeConfiguration<TagProduct>
    {
        public void Configure(EntityTypeBuilder<TagProduct> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.TagsProducts)
               .HasForeignKey(x => x.Id)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Tag)
               .WithMany(x => x.TagsProducts)
               .HasForeignKey(x => x.Id)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
