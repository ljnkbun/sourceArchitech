using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_column_article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WFXProcessId",
                table: "Process",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WFXProcessId",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ServiceCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Article");
        }
    }
}
