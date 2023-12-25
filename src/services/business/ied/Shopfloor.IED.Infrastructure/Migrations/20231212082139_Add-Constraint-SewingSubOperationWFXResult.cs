using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintSewingSubOperationWFXResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXResult");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId_TMUType",
                table: "SewingSubOperationWFXResult",
                columns: new[] { "SewingSubOperationWFXId", "TMUType" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId_TMUType",
                table: "SewingSubOperationWFXResult");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXResult",
                column: "SewingSubOperationWFXId");
        }
    }
}
