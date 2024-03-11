using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjust_Machine_Line_Map_ProcessId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_Factory_FactoryId",
                table: "Line");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Factory_FactoryId",
                table: "Machine");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_ProcessId",
                table: "Machine",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_ProcessId",
                table: "Line",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_Factory_FactoryId",
                table: "Line",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Line_Process_ProcessId",
                table: "Line",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Factory_FactoryId",
                table: "Machine",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Process_ProcessId",
                table: "Machine",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_Factory_FactoryId",
                table: "Line");

            migrationBuilder.DropForeignKey(
                name: "FK_Line_Process_ProcessId",
                table: "Line");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Factory_FactoryId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Process_ProcessId",
                table: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Machine_ProcessId",
                table: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Line_ProcessId",
                table: "Line");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_Factory_FactoryId",
                table: "Line",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Factory_FactoryId",
                table: "Machine",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
