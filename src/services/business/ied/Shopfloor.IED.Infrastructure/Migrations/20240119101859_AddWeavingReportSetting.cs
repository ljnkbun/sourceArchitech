using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWeavingReportSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeavingReportSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingIEDId = table.Column<int>(type: "int", nullable: false),
                    SettingType = table.Column<byte>(type: "tinyint", nullable: false),
                    NumberOfSplit = table.Column<int>(type: "int", nullable: false),
                    Repeat = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingReportSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingReportSetting_WeavingIED_WeavingIEDId",
                        column: x => x.WeavingIEDId,
                        principalTable: "WeavingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingReportSettingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingReportSettingId = table.Column<int>(type: "int", nullable: false),
                    GroupIndex = table.Column<int>(type: "int", nullable: false),
                    Split = table.Column<string>(type: "varchar(100)", nullable: true),
                    Repeat = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingReportSettingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingReportSettingDetail_WeavingReportSetting_WeavingReportSettingId",
                        column: x => x.WeavingReportSettingId,
                        principalTable: "WeavingReportSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeavingReportSetting_WeavingIEDId",
                table: "WeavingReportSetting",
                column: "WeavingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingReportSettingDetail_WeavingReportSettingId",
                table: "WeavingReportSettingDetail",
                column: "WeavingReportSettingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeavingReportSettingDetail");

            migrationBuilder.DropTable(
                name: "WeavingReportSetting");
        }
    }
}
