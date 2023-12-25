using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class keepjustoneUOMconversioninsteadofthree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumptionUOMConversion");

            migrationBuilder.DropTable(
                name: "PurchaseUOMConversion");

            migrationBuilder.DropTable(
                name: "StoringUOMConversion");

            migrationBuilder.CreateTable(
                name: "UOMConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ToUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMConversion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UOMConversion");

            migrationBuilder.CreateTable(
                name: "ConsumptionUOMConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionUOMConversion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseUOMConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseUOMConversion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoringUOMConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToUOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoringUOMConversion", x => x.Id);
                });
        }
    }
}
