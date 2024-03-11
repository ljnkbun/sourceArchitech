using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Table_PlanningFactory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactory_PlanningFactory_PlanningFactoryId",
                table: "StripFactory");

            migrationBuilder.DropTable(
                name: "PlanningFactory");

            migrationBuilder.DropIndex(
                name: "IX_StripFactory_PlanningFactoryId",
                table: "StripFactory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningFactory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarConfigId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    FactoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningFactory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningFactory_CalendarConfig_CalendarConfigId",
                        column: x => x.CalendarConfigId,
                        principalTable: "CalendarConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripFactory_PlanningFactoryId",
                table: "StripFactory",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningFactory_CalendarConfigId",
                table: "PlanningFactory",
                column: "CalendarConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactory_PlanningFactory_PlanningFactoryId",
                table: "StripFactory",
                column: "PlanningFactoryId",
                principalTable: "PlanningFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
