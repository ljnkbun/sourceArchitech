using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGDI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GDI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SummaryOc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeliveryOc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GDIStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    GDIType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDI", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GDI_Code",
                table: "GDI",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GDI");
        }
    }
}
