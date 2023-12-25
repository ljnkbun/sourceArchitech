using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Request");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "Request",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Request",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
