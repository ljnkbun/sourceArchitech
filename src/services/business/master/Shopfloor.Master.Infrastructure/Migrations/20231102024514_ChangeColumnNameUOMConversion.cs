using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameUOMConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToOUM",
                table: "UOMConversion");

            migrationBuilder.RenameColumn(
                name: "FromOUM",
                table: "UOMConversion",
                newName: "ToUOM");

            migrationBuilder.AddColumn<string>(
                name: "FromUOM",
                table: "UOMConversion",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromUOM",
                table: "UOMConversion");

            migrationBuilder.RenameColumn(
                name: "ToUOM",
                table: "UOMConversion",
                newName: "FromOUM");

            migrationBuilder.AddColumn<string>(
                name: "ToOUM",
                table: "UOMConversion",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
