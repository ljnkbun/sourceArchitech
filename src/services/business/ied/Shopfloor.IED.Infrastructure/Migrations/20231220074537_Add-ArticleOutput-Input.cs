using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddArticleOutputInput : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "RequestArticleOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestArticleOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestArticleOutput_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestArticleInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestArticleOutputId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestArticleInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestArticleInput_RequestArticleOutput_RequestArticleOutputId",
                        column: x => x.RequestArticleOutputId,
                        principalTable: "RequestArticleOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestArticleInput_RequestArticleOutputId",
                table: "RequestArticleInput",
                column: "RequestArticleOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestArticleOutput_RequestDivisionProcessId",
                table: "RequestArticleOutput",
                column: "RequestDivisionProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestArticleInput");

            migrationBuilder.DropTable(
                name: "RequestArticleOutput");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingTask");
        }
    }
}
