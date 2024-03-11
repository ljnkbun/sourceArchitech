using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWeavingOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "WeavingRouting");

            migrationBuilder.DropColumn(
                name: "MachineType",
                table: "WeavingRouting");

            migrationBuilder.DropColumn(
                name: "WeavingOperation",
                table: "WeavingRouting");

            migrationBuilder.CreateTable(
                name: "WeavingOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingRoutingId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WFXArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingOperation_WeavingRouting_WeavingRoutingId",
                        column: x => x.WeavingRoutingId,
                        principalTable: "WeavingRouting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingOperationInputArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingOperationId = table.Column<int>(type: "int", nullable: false),
                    WFXArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingOperationInputArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingOperationInputArticle_WeavingOperation_WeavingOperationId",
                        column: x => x.WeavingOperationId,
                        principalTable: "WeavingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeavingOperation_WeavingRoutingId",
                table: "WeavingOperation",
                column: "WeavingRoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingOperationInputArticle_WeavingOperationId",
                table: "WeavingOperationInputArticle",
                column: "WeavingOperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeavingOperationInputArticle");

            migrationBuilder.DropTable(
                name: "WeavingOperation");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "WeavingRouting",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "MachineType",
                table: "WeavingRouting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeavingOperation",
                table: "WeavingRouting",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
