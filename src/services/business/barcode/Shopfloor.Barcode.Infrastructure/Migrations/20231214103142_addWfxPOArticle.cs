using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addWfxPOArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WfxPOArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderRefNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderCreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OCNUm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Units = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Suppliername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierCompanyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCompany = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerStyleNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InternalLotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WashColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WashColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxPOArticle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WfxPOArticle");
        }
    }
}
