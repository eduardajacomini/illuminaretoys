using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlluminareToys.Infrastructure.Data.Migrations
{
    public partial class AddProductsGroupsAges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products_groups_ages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    age_id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products_groups_ages", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_groups_ages_ages_age_id",
                        column: x => x.age_id,
                        principalTable: "ages",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_products_groups_ages_products_groups_product_group_id",
                        column: x => x.product_group_id,
                        principalTable: "products_groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_groups_ages_age_id",
                table: "products_groups_ages",
                column: "age_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_groups_ages_product_group_id",
                table: "products_groups_ages",
                column: "product_group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products_groups_ages");
        }
    }
}
