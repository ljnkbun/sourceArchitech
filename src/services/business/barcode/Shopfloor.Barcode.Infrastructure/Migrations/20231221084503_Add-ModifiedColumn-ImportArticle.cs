using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddModifiedColumnImportArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ImportArticle");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "ImportArticle");

            migrationBuilder.RenameColumn(
                name: "Suppliername",
                table: "WfxPOArticle",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Supplier",
                table: "ImportArticle",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "SourceASNNo",
                table: "ImportArticle",
                newName: "SizeCode");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ImportArticle",
                newName: "OrderRefNum");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ImportArticle",
                newName: "Units");

            migrationBuilder.RenameColumn(
                name: "PONo",
                table: "ImportArticle",
                newName: "OCNum");

            migrationBuilder.RenameColumn(
                name: "OC",
                table: "ImportArticle",
                newName: "ColorCode");

            migrationBuilder.RenameColumn(
                name: "Buyer",
                table: "ImportArticle",
                newName: "ColorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "WfxPOArticle",
                newName: "Suppliername");

            migrationBuilder.RenameColumn(
                name: "Units",
                table: "ImportArticle",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "ImportArticle",
                newName: "Supplier");

            migrationBuilder.RenameColumn(
                name: "SizeCode",
                table: "ImportArticle",
                newName: "SourceASNNo");

            migrationBuilder.RenameColumn(
                name: "OrderRefNum",
                table: "ImportArticle",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "OCNum",
                table: "ImportArticle",
                newName: "PONo");

            migrationBuilder.RenameColumn(
                name: "ColorName",
                table: "ImportArticle",
                newName: "Buyer");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "ImportArticle",
                newName: "OC");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ImportArticle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "ImportArticle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
