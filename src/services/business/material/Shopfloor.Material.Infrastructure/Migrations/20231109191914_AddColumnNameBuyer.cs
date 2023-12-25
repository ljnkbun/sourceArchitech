using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNameBuyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BuyerProductCategory");

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "BuyerProductCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "BuyerProductCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountGroupName",
                table: "Buyer",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerTypeName",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "BuyerProductCategory");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "BuyerProductCategory");

            migrationBuilder.DropColumn(
                name: "AccountGroupName",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "BuyerTypeName",
                table: "Buyer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BuyerProductCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
