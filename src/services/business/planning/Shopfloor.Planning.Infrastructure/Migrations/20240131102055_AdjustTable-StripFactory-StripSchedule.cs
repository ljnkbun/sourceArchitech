using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableStripFactoryStripSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripSchedule_StripScheduleId",
                table: "StripFactorySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactoryDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripScheduleDetail_StripScheduleDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "RemainingQuantity",
                table: "StripScheduleDetail");

            migrationBuilder.RenameColumn(
                name: "StripScheduleDetailId",
                table: "StripFactoryScheduleDetail",
                newName: "StripFactoryScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_StripFactoryScheduleDetail_StripScheduleDetailId",
                table: "StripFactoryScheduleDetail",
                newName: "IX_StripFactoryScheduleDetail_StripFactoryScheduleId");

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "StripSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "StripSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StripSchedule",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "StripFactoryScheduleDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PorDetailId",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StripFactoryScheduleDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingQuantity",
                table: "StripFactoryScheduleDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "StripFactoryScheduleDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypePORDetail",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "StripFactoryScheduleDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StripScheduleId",
                table: "StripFactorySchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "StripFactorySchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StripFactorySchedule",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsSplitBatch",
                table: "StripFactory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainningQuantity",
                table: "StripFactory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripSchedule_StripScheduleId",
                table: "StripFactorySchedule",
                column: "StripScheduleId",
                principalTable: "StripSchedule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactoryDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripFactoryDetailId",
                principalTable: "StripFactoryDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactorySchedule_StripFactoryScheduleId",
                table: "StripFactoryScheduleDetail",
                column: "StripFactoryScheduleId",
                principalTable: "StripFactorySchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripSchedule_StripScheduleId",
                table: "StripFactorySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactoryDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactorySchedule_StripFactoryScheduleId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "PorDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "RemainingQuantity",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "TypePORDetail",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "StripFactorySchedule");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StripFactorySchedule");

            migrationBuilder.DropColumn(
                name: "IsSplitBatch",
                table: "StripFactory");

            migrationBuilder.DropColumn(
                name: "RemainningQuantity",
                table: "StripFactory");

            migrationBuilder.RenameColumn(
                name: "StripFactoryScheduleId",
                table: "StripFactoryScheduleDetail",
                newName: "StripScheduleDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_StripFactoryScheduleDetail_StripFactoryScheduleId",
                table: "StripFactoryScheduleDetail",
                newName: "IX_StripFactoryScheduleDetail_StripScheduleDetailId");

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingQuantity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StripScheduleId",
                table: "StripFactorySchedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripSchedule_StripScheduleId",
                table: "StripFactorySchedule",
                column: "StripScheduleId",
                principalTable: "StripSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripFactoryDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripFactoryDetailId",
                principalTable: "StripFactoryDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryScheduleDetail_StripScheduleDetail_StripScheduleDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripScheduleDetailId",
                principalTable: "StripScheduleDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
