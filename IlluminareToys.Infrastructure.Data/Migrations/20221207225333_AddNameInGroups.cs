using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlluminareToys.Infrastructure.Data.Migrations
{
    public partial class AddNameInGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "groups",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "groups");
        }
    }
}
