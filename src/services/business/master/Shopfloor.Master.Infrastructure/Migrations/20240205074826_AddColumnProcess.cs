using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Process",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_DivisionId",
                table: "Process",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Division_DivisionId",
                table: "Process",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Division_DivisionId",
                table: "Process");

            migrationBuilder.DropIndex(
                name: "IX_Process_DivisionId",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Process");
        }
    }
}
