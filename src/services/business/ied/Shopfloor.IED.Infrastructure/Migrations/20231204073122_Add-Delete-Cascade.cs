using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDivisionProcess_RequestDivision_RequestDivisionId",
                table: "RequestDivisionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDivisionProcess_RequestDivision_RequestDivisionId",
                table: "RequestDivisionProcess",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle",
                column: "RequestDivisionProcessId",
                principalTable: "RequestDivisionProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDivisionProcess_RequestDivision_RequestDivisionId",
                table: "RequestDivisionProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDivisionProcess_RequestDivision_RequestDivisionId",
                table: "RequestDivisionProcess",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle",
                column: "RequestDivisionProcessId",
                principalTable: "RequestDivisionProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
