using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnCompanyAndTypeSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierType",
                table: "Supplier",
                newName: "SupplierTypeCode");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Supplier",
                newName: "SupplierTypeName");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Supplier");

            migrationBuilder.RenameColumn(
                name: "SupplierTypeName",
                table: "Supplier",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "SupplierTypeCode",
                table: "Supplier",
                newName: "SupplierType");
        }
    }
}
