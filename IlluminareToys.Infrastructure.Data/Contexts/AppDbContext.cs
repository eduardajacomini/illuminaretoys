using Ardalis.EFCore.Extensions;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Infrastructure.Data.Configurations;
using IlluminareToys.Infrastructure.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IlluminareToys.Infrastructure.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.NamesToSnakeCase();

            builder.ApplyAllConfigurationsFromCurrentAssembly();

            IdentityConfiguration.SetTableNames(builder);
        }
    }
}
