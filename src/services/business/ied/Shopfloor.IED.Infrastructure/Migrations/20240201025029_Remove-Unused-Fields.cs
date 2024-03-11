using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SewingComponentGroup");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "SewingComponentGroup");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SewingComponent");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "SewingComponent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SewingComponentGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "SewingComponentGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SewingComponent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "SewingComponent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
