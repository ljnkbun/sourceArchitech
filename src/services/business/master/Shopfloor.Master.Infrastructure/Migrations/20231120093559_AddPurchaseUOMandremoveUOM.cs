using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseUOMandremoveUOM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UOM");

            migrationBuilder.CreateTable(
                name: "PurchaseUOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false),
                    OrderDecimalPlaces = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_PurchaseUOM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseUOM_Code",
                table: "PurchaseUOM",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseUOM");

            migrationBuilder.CreateTable(
                name: "UOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderDecimalPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UOM_Code",
                table: "UOM",
                column: "Code",
                unique: true);
        }
    }
}
