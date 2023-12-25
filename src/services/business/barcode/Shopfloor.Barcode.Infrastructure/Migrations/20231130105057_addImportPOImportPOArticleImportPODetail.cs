using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImportPOImportPOArticleImportPODetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SourceASNNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    TotalMeters = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    TotalYards = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    TotalKg = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
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
                    table.PrimaryKey("PK_ImportPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportPOArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ImportPOId = table.Column<int>(type: "int", nullable: false),
                    PONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PurchaseUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StoringUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConsumptionUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PurchaseValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StoringValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ConsumptionValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    SourceASNNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_ImportPOArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportPOArticle_ImportPO_ImportPOId",
                        column: x => x.ImportPOId,
                        principalTable: "ImportPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportPODetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    ImportPOArticleId = table.Column<int>(type: "int", nullable: true),
                    ArticleBarcodeId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StoringUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConsumptionUOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PurchaseValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StoringValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ConsumptionValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
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
                    table.PrimaryKey("PK_ImportPODetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportPODetail_ImportPOArticle_ImportPOArticleId",
                        column: x => x.ImportPOArticleId,
                        principalTable: "ImportPOArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportPO_Code",
                table: "ImportPO",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPOArticle_Code",
                table: "ImportPOArticle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPOArticle_ImportPOId",
                table: "ImportPOArticle",
                column: "ImportPOId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_Code",
                table: "ImportPODetail",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_ImportPOArticleId",
                table: "ImportPODetail",
                column: "ImportPOArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportPODetail");

            migrationBuilder.DropTable(
                name: "ImportPOArticle");

            migrationBuilder.DropTable(
                name: "ImportPO");
        }
    }
}
