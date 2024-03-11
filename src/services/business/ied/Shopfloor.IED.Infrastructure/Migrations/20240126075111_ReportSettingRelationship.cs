using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReportSettingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingReportSetting_WeavingIEDId",
                table: "WeavingReportSetting");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingReportSetting_WeavingIEDId",
                table: "WeavingReportSetting",
                column: "WeavingIEDId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingReportSetting_WeavingIEDId",
                table: "WeavingReportSetting");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingReportSetting_WeavingIEDId",
                table: "WeavingReportSetting",
                column: "WeavingIEDId");
        }
    }
}
