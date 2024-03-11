using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldFPPOOutput : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "FPPOOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobOrderNo",
                table: "FPPOOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "JobOrderNo",
                table: "FPPOOutput");
        }
    }
}
