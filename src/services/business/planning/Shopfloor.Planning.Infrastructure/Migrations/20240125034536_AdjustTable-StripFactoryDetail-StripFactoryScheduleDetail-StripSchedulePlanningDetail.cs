using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableStripFactoryDetailStripFactoryScheduleDetailStripSchedulePlanningDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCapacity",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "StandardCapacity",
                table: "StripScheduleDetail");

            migrationBuilder.RenameColumn(
                name: "OrderedQuantity",
                table: "StripFactoryDetail",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "StripScheduleDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PorDetailId",
                table: "StripScheduleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingQuantity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "StripScheduleDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TypePORDetail",
                table: "StripScheduleDetail",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "StripScheduleDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UOM",
                table: "StripFactoryDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "StripFactoryDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StripFactoryScheduleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripFactoryDetailId = table.Column<int>(type: "int", nullable: false),
                    StripScheduleDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripFactoryScheduleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripFactoryScheduleDetail_StripFactoryDetail_StripFactoryDetailId",
                        column: x => x.StripFactoryDetailId,
                        principalTable: "StripFactoryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StripFactoryScheduleDetail_StripScheduleDetail_StripScheduleDetailId",
                        column: x => x.StripScheduleDetailId,
                        principalTable: "StripScheduleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripSchedulePlanningDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    StandardCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StripScheduleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripSchedulePlanningDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripSchedulePlanningDetail_StripSchedule_StripScheduleId",
                        column: x => x.StripScheduleId,
                        principalTable: "StripSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryScheduleDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripFactoryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryScheduleDetail_StripScheduleDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripScheduleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StripSchedulePlanningDetail_StripScheduleId",
                table: "StripSchedulePlanningDetail",
                column: "StripScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripFactoryScheduleDetail");

            migrationBuilder.DropTable(
                name: "StripSchedulePlanningDetail");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "PorDetailId",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "RemainingQuantity",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "TypePORDetail",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "StripScheduleDetail");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StripFactoryDetail",
                newName: "OrderedQuantity");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualCapacity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StripScheduleDetail",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StripScheduleDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StandardCapacity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UOM",
                table: "StripFactoryDetail",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "StripFactoryDetail",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
