using IlluminareToys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlluminareToys.Infrastructure.Data.Configurations
{
    public class AgeConfiguration : IEntityTypeConfiguration<Age>
    {
        public void Configure(EntityTypeBuilder<Age> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
        }
    }
}
