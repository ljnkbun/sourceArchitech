using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addWfxGDN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WfxGDN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GDNNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDNType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderRefNum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WFXArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDNCreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    WFXArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FPPOOCNUm = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RollNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RollBarcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RollUnits = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ParentRollBarcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RollOCRefNum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WareHouse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InternalShade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDINum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxGDN", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WfxGDN");
        }
    }
}
