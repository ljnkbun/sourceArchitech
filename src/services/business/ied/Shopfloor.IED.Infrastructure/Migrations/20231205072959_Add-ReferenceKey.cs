using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReferenceKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_RequestTypeId",
                table: "Request",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_RequestTypeId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "Request");
        }
    }
}
