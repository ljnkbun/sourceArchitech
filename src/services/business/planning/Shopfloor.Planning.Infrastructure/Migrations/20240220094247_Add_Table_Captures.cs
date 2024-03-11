using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_Captures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StripScheduleCapture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfileEfficiencyValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    OrderEfficiencyValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StripEfficiencyValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    LearningCurveEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    FromWorkingHours = table.Column<int>(type: "int", nullable: false),
                    ToWorkingHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsManualPlanning = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripScheduleCapture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripScheduleDetailCapture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    StripScheduleCaptureId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripScheduleDetailCapture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripScheduleDetailCapture_StripScheduleCapture_StripScheduleCaptureId",
                        column: x => x.StripScheduleCaptureId,
                        principalTable: "StripScheduleCapture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripSchedulePlanningDetailCapture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    WorkingHours = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    StandardCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ReceivedCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StripScheduleCaptureId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripSchedulePlanningDetailCapture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripSchedulePlanningDetailCapture_StripScheduleCapture_StripScheduleCaptureId",
                        column: x => x.StripScheduleCaptureId,
                        principalTable: "StripScheduleCapture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripScheduleDetailCapture_StripScheduleCaptureId",
                table: "StripScheduleDetailCapture",
                column: "StripScheduleCaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_StripSchedulePlanningDetailCapture_StripScheduleCaptureId",
                table: "StripSchedulePlanningDetailCapture",
                column: "StripScheduleCaptureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripScheduleDetailCapture");

            migrationBuilder.DropTable(
                name: "StripSchedulePlanningDetailCapture");

            migrationBuilder.DropTable(
                name: "StripScheduleCapture");
        }
    }
}
