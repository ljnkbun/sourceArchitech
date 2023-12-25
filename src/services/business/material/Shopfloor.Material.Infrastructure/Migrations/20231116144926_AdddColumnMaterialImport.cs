using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdddColumnMaterialImport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PriceList");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Supplier",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupNameCode",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignAndPatternName",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupNameCode",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNameCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DesignAndPatternName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GroupNameCode",
                table: "Buyer");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
