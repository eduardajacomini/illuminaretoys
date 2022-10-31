using IlluminareToys.Domain.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IlluminareToys.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void NamesToSnakeCase(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.Name.ToSnakeCase());

                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());

                foreach (var key in entity.GetForeignKeys())
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }
        }
    }
}
