using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "Supplier",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "PriceList",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "MaterialRequest",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestNo",
                table: "Buyer",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "MaterialRequest");

            migrationBuilder.AlterColumn<string>(
                name: "RequestNo",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}
