using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitySewingOperationLibResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingRoutingResult");

            migrationBuilder.CreateTable(
                name: "SewingOperationLibResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    TMUType = table.Column<byte>(type: "tinyint", nullable: false),
                    TMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BasicMunite = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationLibResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationLibResult_SewingOperationLib_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibResult_SewingOperationLibId_TMUType",
                table: "SewingOperationLibResult",
                columns: new[] { "SewingOperationLibId", "TMUType" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingOperationLibResult");

            migrationBuilder.CreateTable(
                name: "SewingRoutingResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingRoutingId = table.Column<int>(type: "int", nullable: false),
                    BasicMunite = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TMUType = table.Column<byte>(type: "tinyint", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingRoutingResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingRoutingResult_SewingRouting_SewingRoutingId",
                        column: x => x.SewingRoutingId,
                        principalTable: "SewingRouting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingRoutingResult_SewingRoutingId_TMUType",
                table: "SewingRoutingResult",
                columns: new[] { "SewingRoutingId", "TMUType" },
                unique: true);
        }
    }
}
