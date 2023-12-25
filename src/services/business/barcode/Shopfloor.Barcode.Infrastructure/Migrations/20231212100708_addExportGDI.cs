using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Export",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GDIType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Export", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    GDINo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDIType = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SummaryOC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeliveryOC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportArticle_Export_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Export",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    ExportArticleId = table.Column<int>(type: "int", nullable: true),
                    ArticleBarcodeId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Yard = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Meter = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Unit = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ArticleBarcode_ArticleBarcodeId",
                        column: x => x.ArticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ExportArticle_ExportArticleId",
                        column: x => x.ExportArticleId,
                        principalTable: "ExportArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Export_Code",
                table: "Export",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportArticle_Code",
                table: "ExportArticle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportArticle_ExportId",
                table: "ExportArticle",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail",
                column: "ArticleBarcodeId",
                unique: true,
                filter: "[ArticleBarcodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_Code",
                table: "ExportDetail",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ExportArticleId",
                table: "ExportDetail",
                column: "ExportArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportDetail");

            migrationBuilder.DropTable(
                name: "ExportArticle");

            migrationBuilder.DropTable(
                name: "Export");
        }
    }
}
