using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalLotNo",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "OrderCompany",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "StyleName",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "SupplierCompanyID",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ImportDetail");

            migrationBuilder.RenameColumn(
                name: "WashColorName",
                table: "WfxPOArticle",
                newName: "SizeName");

            migrationBuilder.RenameColumn(
                name: "WashColorCode",
                table: "WfxPOArticle",
                newName: "ShipmentTerm");

            migrationBuilder.RenameColumn(
                name: "SupplierShortName",
                table: "WfxPOArticle",
                newName: "ShipToAddress");

            migrationBuilder.RenameColumn(
                name: "SupplierRef",
                table: "WfxPOArticle",
                newName: "OCFactory");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "WfxPOArticle",
                newName: "FactorySite");

            migrationBuilder.RenameColumn(
                name: "StyleCode",
                table: "WfxPOArticle",
                newName: "PurchaseOfficer");

            migrationBuilder.RenameColumn(
                name: "OrderType",
                table: "WfxPOArticle",
                newName: "PaymentTerm");

            migrationBuilder.RenameColumn(
                name: "OrderCreationDate",
                table: "WfxPOArticle",
                newName: "PPYDGDate");

            migrationBuilder.RenameColumn(
                name: "OCNum",
                table: "WfxPOArticle",
                newName: "POStatus");

            migrationBuilder.RenameColumn(
                name: "MaterialType",
                table: "WfxPOArticle",
                newName: "PONo");

            migrationBuilder.RenameColumn(
                name: "ExecutionType",
                table: "WfxPOArticle",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "BuyerStyleNum",
                table: "WfxPOArticle",
                newName: "ETD");

            migrationBuilder.RenameColumn(
                name: "Units",
                table: "ImportArticle",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerms",
                table: "WfxPOArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ETA",
                table: "WfxPOArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InHouseDate",
                table: "WfxPOArticle",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRevisedDate",
                table: "WfxPOArticle",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "POCreationDate",
                table: "WfxPOArticle",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "WfxPOArticle",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalShade",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WfxGDIHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportDetailId = table.Column<int>(type: "int", nullable: true),
                    WfxGDIId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxGDIHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WfxGDIHistory_ExportDetail_ExportDetailId",
                        column: x => x.ExportDetailId,
                        principalTable: "ExportDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WfxGDIHistory_WfxGDI_WfxGDIId",
                        column: x => x.WfxGDIId,
                        principalTable: "WfxGDI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WfxGDNHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportDetailId = table.Column<int>(type: "int", nullable: true),
                    WfxGDNId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxGDNHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WfxGDNHistory_ExportDetail_ExportDetailId",
                        column: x => x.ExportDetailId,
                        principalTable: "ExportDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WfxGDNHistory_WfxGDN_WfxGDNId",
                        column: x => x.WfxGDNId,
                        principalTable: "WfxGDN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WfxPOArticleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportDetailId = table.Column<int>(type: "int", nullable: true),
                    WfxPOArticlelId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxPOArticleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WfxPOArticleHistory_ImportDetail_ImportDetailId",
                        column: x => x.ImportDetailId,
                        principalTable: "ImportDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WfxPOArticleHistory_WfxPOArticle_WfxPOArticlelId",
                        column: x => x.WfxPOArticlelId,
                        principalTable: "WfxPOArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WfxGDIHistory_ExportDetailId",
                table: "WfxGDIHistory",
                column: "ExportDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WfxGDIHistory_WfxGDIId",
                table: "WfxGDIHistory",
                column: "WfxGDIId");

            migrationBuilder.CreateIndex(
                name: "IX_WfxGDNHistory_ExportDetailId",
                table: "WfxGDNHistory",
                column: "ExportDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WfxGDNHistory_WfxGDNId",
                table: "WfxGDNHistory",
                column: "WfxGDNId");

            migrationBuilder.CreateIndex(
                name: "IX_WfxPOArticleHistory_ImportDetailId",
                table: "WfxPOArticleHistory",
                column: "ImportDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WfxPOArticleHistory_WfxPOArticlelId",
                table: "WfxPOArticleHistory",
                column: "WfxPOArticlelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WfxGDIHistory");

            migrationBuilder.DropTable(
                name: "WfxGDNHistory");

            migrationBuilder.DropTable(
                name: "WfxPOArticleHistory");

            migrationBuilder.DropColumn(
                name: "DeliveryTerms",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "ETA",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "InHouseDate",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "LastRevisedDate",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "POCreationDate",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "InternalShade",
                table: "ExportDetail");

            migrationBuilder.RenameColumn(
                name: "SizeName",
                table: "WfxPOArticle",
                newName: "WashColorName");

            migrationBuilder.RenameColumn(
                name: "ShipmentTerm",
                table: "WfxPOArticle",
                newName: "WashColorCode");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress",
                table: "WfxPOArticle",
                newName: "SupplierShortName");

            migrationBuilder.RenameColumn(
                name: "PurchaseOfficer",
                table: "WfxPOArticle",
                newName: "StyleCode");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm",
                table: "WfxPOArticle",
                newName: "OrderType");

            migrationBuilder.RenameColumn(
                name: "PPYDGDate",
                table: "WfxPOArticle",
                newName: "OrderCreationDate");

            migrationBuilder.RenameColumn(
                name: "POStatus",
                table: "WfxPOArticle",
                newName: "OCNum");

            migrationBuilder.RenameColumn(
                name: "PONo",
                table: "WfxPOArticle",
                newName: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "WfxPOArticle",
                newName: "ExecutionType");

            migrationBuilder.RenameColumn(
                name: "OCFactory",
                table: "WfxPOArticle",
                newName: "SupplierRef");

            migrationBuilder.RenameColumn(
                name: "FactorySite",
                table: "WfxPOArticle",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "ETD",
                table: "WfxPOArticle",
                newName: "BuyerStyleNum");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ImportArticle",
                newName: "Units");

            migrationBuilder.AddColumn<string>(
                name: "InternalLotNo",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderCompany",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StyleName",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCompanyID",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Units",
                table: "WfxPOArticle",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ImportDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
