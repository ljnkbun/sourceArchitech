using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryNameForSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Supplier",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "ProductCategory",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
