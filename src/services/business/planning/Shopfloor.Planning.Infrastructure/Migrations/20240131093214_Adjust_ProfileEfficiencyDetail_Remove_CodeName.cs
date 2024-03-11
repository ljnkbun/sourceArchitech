using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjust_ProfileEfficiencyDetail_Remove_CodeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileEfficiencyDetail_Code",
                table: "ProfileEfficiencyDetail");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProfileEfficiencyDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProfileEfficiencyDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProfileEfficiencyDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProfileEfficiencyDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEfficiencyDetail_Code",
                table: "ProfileEfficiencyDetail",
                column: "Code",
                unique: true);
        }
    }
}
