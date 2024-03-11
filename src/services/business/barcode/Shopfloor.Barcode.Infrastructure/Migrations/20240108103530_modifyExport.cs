using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meter",
                table: "ExportDetail");

            migrationBuilder.RenameColumn(
                name: "Yard",
                table: "ExportDetail",
                newName: "RollUnits");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "ExportDetail",
                newName: "WareHouse");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ExportDetail",
                newName: "RollOCRefNum");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ExportDetail",
                newName: "GDIPendingUnits");

            migrationBuilder.RenameColumn(
                name: "LotNo",
                table: "ExportDetail",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "ExportDetail",
                newName: "FPPOOCNUm");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ExportArticle",
                newName: "SizeCode");

            migrationBuilder.RenameColumn(
                name: "LotNo",
                table: "ExportArticle",
                newName: "WareHouse");

            migrationBuilder.RenameColumn(
                name: "GDINo",
                table: "ExportArticle",
                newName: "GDINum");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "ExportArticle",
                newName: "ColorCode");

            migrationBuilder.AddColumn<string>(
                name: "BuyerStyleRef",
                table: "ExportDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalShade",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "ExportDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentRollBarcode",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RollBarcode",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RollNo",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeCode",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "ExportArticle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderRefNum",
                table: "ExportArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerStyleRef",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "InternalShade",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "ParentRollBarcode",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "RollBarcode",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "RollNo",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "SizeCode",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "ExportArticle");

            migrationBuilder.DropColumn(
                name: "OrderRefNum",
                table: "ExportArticle");

            migrationBuilder.RenameColumn(
                name: "WareHouse",
                table: "ExportDetail",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "RollUnits",
                table: "ExportDetail",
                newName: "Yard");

            migrationBuilder.RenameColumn(
                name: "RollOCRefNum",
                table: "ExportDetail",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ExportDetail",
                newName: "LotNo");

            migrationBuilder.RenameColumn(
                name: "GDIPendingUnits",
                table: "ExportDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "FPPOOCNUm",
                table: "ExportDetail",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "WareHouse",
                table: "ExportArticle",
                newName: "LotNo");

            migrationBuilder.RenameColumn(
                name: "SizeCode",
                table: "ExportArticle",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "GDINum",
                table: "ExportArticle",
                newName: "GDINo");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "ExportArticle",
                newName: "Color");

            migrationBuilder.AddColumn<decimal>(
                name: "Meter",
                table: "ExportDetail",
                type: "decimal(28,8)",
                nullable: true);
        }
    }
}
