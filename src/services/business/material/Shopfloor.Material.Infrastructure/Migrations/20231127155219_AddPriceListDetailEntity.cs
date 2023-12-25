using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceListDetailEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceListColor");

            migrationBuilder.DropTable(
                name: "PriceListSize");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "DeliveryTerm",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "Uom",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "PriceList");

            migrationBuilder.CreateTable(
                name: "PriceListDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Uom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryTerm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetail_PriceList_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListDetailColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PriceListDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetailColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetailColor_PriceListDetail_PriceListDetailId",
                        column: x => x.PriceListDetailId,
                        principalTable: "PriceListDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListDetailSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PriceListDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetailSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetailSize_PriceListDetail_PriceListDetailId",
                        column: x => x.PriceListDetailId,
                        principalTable: "PriceListDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetail_PriceListId",
                table: "PriceListDetail",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetailColor_PriceListDetailId",
                table: "PriceListDetailColor",
                column: "PriceListDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetailSize_PriceListDetailId",
                table: "PriceListDetailSize",
                column: "PriceListDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceListDetailColor");

            migrationBuilder.DropTable(
                name: "PriceListDetailSize");

            migrationBuilder.DropTable(
                name: "PriceListDetail");

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "PriceList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerm",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PriceList",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Uom",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "PriceList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriceListColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PriceListColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListColor_PriceList_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PriceListSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListSize_PriceList_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListColor_PriceListId",
                table: "PriceListColor",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListSize_PriceListId",
                table: "PriceListSize",
                column: "PriceListId");
        }
    }
}
