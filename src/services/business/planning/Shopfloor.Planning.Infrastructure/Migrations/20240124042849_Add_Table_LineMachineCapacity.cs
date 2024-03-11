using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_LineMachineCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineMachineCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    LineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Standingcapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    WorkingHours = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineMachineCapacity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripFactory_PORId",
                table: "StripFactory",
                column: "PORId");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactory_POR_PORId",
                table: "StripFactory",
                column: "PORId",
                principalTable: "POR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactory_POR_PORId",
                table: "StripFactory");

            migrationBuilder.DropTable(
                name: "LineMachineCapacity");

            migrationBuilder.DropIndex(
                name: "IX_StripFactory_PORId",
                table: "StripFactory");
        }
    }
}
