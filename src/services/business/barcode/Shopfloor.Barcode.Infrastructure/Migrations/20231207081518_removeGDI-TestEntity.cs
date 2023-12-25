using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeGDITestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GDI");

            migrationBuilder.DropTable(
                name: "TestEntity");

            migrationBuilder.DropColumn(
                name: "ConsumptionUOM",
                table: "ImportPODetail");

            migrationBuilder.DropColumn(
                name: "ConsumptionUOM",
                table: "ImportPOArticle");

            migrationBuilder.DropColumn(
                name: "ConsumptionValue",
                table: "ImportPOArticle");

            migrationBuilder.DropColumn(
                name: "PurchaseUOM",
                table: "ImportPOArticle");

            migrationBuilder.DropColumn(
                name: "PurchaseValue",
                table: "ImportPOArticle");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "OC",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "SourceASNNo",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "TotalKg",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "TotalMeters",
                table: "ImportPO");

            migrationBuilder.DropColumn(
                name: "TotalYards",
                table: "ImportPO");

            migrationBuilder.RenameColumn(
                name: "StoringValue",
                table: "ImportPODetail",
                newName: "Yard");

            migrationBuilder.RenameColumn(
                name: "StoringUOM",
                table: "ImportPODetail",
                newName: "UOM");

            migrationBuilder.RenameColumn(
                name: "PurchaseValue",
                table: "ImportPODetail",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "PurchaseUOM",
                table: "ImportPODetail",
                newName: "Shade");

            migrationBuilder.RenameColumn(
                name: "ConsumptionValue",
                table: "ImportPODetail",
                newName: "Meter");

            migrationBuilder.RenameColumn(
                name: "StoringValue",
                table: "ImportPOArticle",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "StoringUOM",
                table: "ImportPOArticle",
                newName: "UOM");

            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "ImportPODetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OC",
                table: "ImportPODetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OC",
                table: "ImportPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_ArticleBarcodeId",
                table: "ImportPODetail",
                column: "ArticleBarcodeId",
                unique: true,
                filter: "[ArticleBarcodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportPODetail_ArticleBarcode_ArticleBarcodeId",
                table: "ImportPODetail",
                column: "ArticleBarcodeId",
                principalTable: "ArticleBarcode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportPODetail_ArticleBarcode_ArticleBarcodeId",
                table: "ImportPODetail");

            migrationBuilder.DropIndex(
                name: "IX_ImportPODetail_ArticleBarcodeId",
                table: "ImportPODetail");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "ImportPODetail");

            migrationBuilder.DropColumn(
                name: "OC",
                table: "ImportPODetail");

            migrationBuilder.RenameColumn(
                name: "Yard",
                table: "ImportPODetail",
                newName: "StoringValue");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "ImportPODetail",
                newName: "PurchaseValue");

            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "ImportPODetail",
                newName: "StoringUOM");

            migrationBuilder.RenameColumn(
                name: "Shade",
                table: "ImportPODetail",
                newName: "PurchaseUOM");

            migrationBuilder.RenameColumn(
                name: "Meter",
                table: "ImportPODetail",
                newName: "ConsumptionValue");

            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "ImportPOArticle",
                newName: "StoringUOM");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ImportPOArticle",
                newName: "StoringValue");

            migrationBuilder.AddColumn<string>(
                name: "ConsumptionUOM",
                table: "ImportPODetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OC",
                table: "ImportPOArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsumptionUOM",
                table: "ImportPOArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ConsumptionValue",
                table: "ImportPOArticle",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseUOM",
                table: "ImportPOArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseValue",
                table: "ImportPOArticle",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "ImportPO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ImportPO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "ImportPO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OC",
                table: "ImportPO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "ImportPO",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ImportPO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceASNNo",
                table: "ImportPO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "ImportPO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalKg",
                table: "ImportPO",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMeters",
                table: "ImportPO",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalYards",
                table: "ImportPO",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GDI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryOc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GDIStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    GDIType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SummaryOc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GDI_Code",
                table: "GDI",
                column: "Code",
                unique: true);
        }
    }
}
