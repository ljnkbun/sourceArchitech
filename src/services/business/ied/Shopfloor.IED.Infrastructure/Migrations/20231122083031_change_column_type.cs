using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_column_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                table: "SewingProcess");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Request",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                table: "SewingProcess",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                table: "SewingProcess");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Request",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                table: "SewingProcess",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
