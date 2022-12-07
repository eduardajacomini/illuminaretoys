using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class TagGroupConfiguration : IEntityTypeConfiguration<TagGroup>
    {
        public void Configure(EntityTypeBuilder<TagGroup> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.Tag)
               .WithMany(x => x.TagsGroups)
               .HasForeignKey(x => x.TagId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Group)
               .WithMany(x => x.TagsGroups)
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
