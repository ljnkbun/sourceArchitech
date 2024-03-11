using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStripScheduleDetailTime_FixProfileEfficiency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripScheduleDetailTime");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryCode",
                table: "ProfileEfficiencyDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "ProfileEfficiencyDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "ProfileEfficiency",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ProfileEfficiency",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroupCode",
                table: "ProfileEfficiency",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroupName",
                table: "ProfileEfficiency",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryCode",
                table: "ProfileEfficiencyDetail");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "ProfileEfficiencyDetail");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "ProfileEfficiency");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ProfileEfficiency");

            migrationBuilder.DropColumn(
                name: "ProductGroupCode",
                table: "ProfileEfficiency");

            migrationBuilder.DropColumn(
                name: "ProductGroupName",
                table: "ProfileEfficiency");

            migrationBuilder.CreateTable(
                name: "StripScheduleDetailTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripScheduleDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripScheduleDetailTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripScheduleDetailTime_StripScheduleDetail_StripScheduleDetailId",
                        column: x => x.StripScheduleDetailId,
                        principalTable: "StripScheduleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripScheduleDetailTime_StripScheduleDetailId",
                table: "StripScheduleDetailTime",
                column: "StripScheduleDetailId");
        }
    }
}
