using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddZoneType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QCRequestDetail");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "QCRequestArticle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "QCRequestArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GRNQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QCReleasedQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SizeCode",
                table: "QCRequestArticle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "QCRequestArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZoneType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneType", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoneType");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "GRNQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "QCReleasedQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "SizeCode",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "QCRequestArticle");

            migrationBuilder.CreateTable(
                name: "QCRequestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestArticleId = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GRNQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QCReleasedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RequestedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SizeCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCRequestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCRequestDetail_QCRequestArticle_QCRequestArticleId",
                        column: x => x.QCRequestArticleId,
                        principalTable: "QCRequestArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCRequestDetail_QCRequestArticleId",
                table: "QCRequestDetail",
                column: "QCRequestArticleId");
        }
    }
}
