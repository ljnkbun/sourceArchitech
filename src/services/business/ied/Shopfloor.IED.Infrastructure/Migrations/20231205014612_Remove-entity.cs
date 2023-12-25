using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removeentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDivisionProcessArticle");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RequestDivisionProcess",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestDivisionProcess",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestDivisionProcess");

            migrationBuilder.CreateTable(
                name: "RequestDivisionProcessArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDivisionProcessArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivisionProcessArticle_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle",
                column: "RequestDivisionProcessId");
        }
    }
}
