using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Update_Fields_Strip_Detail : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_StripFactoryScheduleDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "PorDetailId",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "TypePORDetail",
                table: "StripScheduleDetail");

            migrationBuilder.DropColumn(
                name: "PorDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "RemainingQuantity",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "StripFactoryDetailId",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.DropColumn(
                name: "TypePORDetail",
                table: "StripFactoryScheduleDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripFactoryScheduleDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripFactorySchedule",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripScheduleDetail",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<int>(
                name: "PorDetailId",
                table: "StripScheduleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "TypePORDetail",
                table: "StripScheduleDetail",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripFactoryScheduleDetail",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<int>(
                name: "PorDetailId",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingQuantity",
                table: "StripFactoryScheduleDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypePORDetail",
                table: "StripFactoryScheduleDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "StripFactorySchedule",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryScheduleDetail_StripFactoryDetailId",
                table: "StripFactoryScheduleDetail",
                column: "StripFactoryDetailId");

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
        }
    }
}
