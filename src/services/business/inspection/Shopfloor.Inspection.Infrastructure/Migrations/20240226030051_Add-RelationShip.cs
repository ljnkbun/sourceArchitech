using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionDefectError");

            migrationBuilder.DropIndex(
                name: "IX_InpectionTCStandard_QCRequestArticleId",
                table: "InpectionTCStandard");

            migrationBuilder.DropIndex(
                name: "IX_Inpection4PointSys_QCRequestArticleId",
                table: "Inpection4PointSys");

            migrationBuilder.DropIndex(
                name: "IX_Inpection100PointSys_QCRequestArticleId",
                table: "Inpection100PointSys");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Inpection4PointSys");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Inpection100PointSys");

            migrationBuilder.RenameColumn(
                name: "InspectionDefectCapturing4PointSysId",
                table: "InspectionDefectError100PointSys",
                newName: "InspectionDefectCapturing100PointSysId");

            migrationBuilder.AlterColumn<int>(
                name: "InspectionId",
                table: "Attachment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Inpection100PointSysId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inpection4PointSysId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InpectionTCStandardId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectError4PointSys_InspectionDefectCapturing4PointSysId",
                table: "InspectionDefectError4PointSys",
                column: "InspectionDefectCapturing4PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectError100PointSys_InspectionDefectCapturing100PointSysId",
                table: "InspectionDefectError100PointSys",
                column: "InspectionDefectCapturing100PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_InpectionTCStandard_QCRequestArticleId",
                table: "InpectionTCStandard",
                column: "QCRequestArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inpection4PointSys_QCRequestArticleId",
                table: "Inpection4PointSys",
                column: "QCRequestArticleId",
                unique: true,
                filter: "[QCRequestArticleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inpection100PointSys_QCRequestArticleId",
                table: "Inpection100PointSys",
                column: "QCRequestArticleId",
                unique: true,
                filter: "[QCRequestArticleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Inpection100PointSysId",
                table: "Attachment",
                column: "Inpection100PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Inpection4PointSysId",
                table: "Attachment",
                column: "Inpection4PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_InpectionTCStandardId",
                table: "Attachment",
                column: "InpectionTCStandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Inpection100PointSys_Inpection100PointSysId",
                table: "Attachment",
                column: "Inpection100PointSysId",
                principalTable: "Inpection100PointSys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Inpection4PointSys_Inpection4PointSysId",
                table: "Attachment",
                column: "Inpection4PointSysId",
                principalTable: "Inpection4PointSys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_InpectionTCStandard_InpectionTCStandardId",
                table: "Attachment",
                column: "InpectionTCStandardId",
                principalTable: "InpectionTCStandard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDefectError100PointSys_InspectionDefectCapturing100PointSys_InspectionDefectCapturing100PointSysId",
                table: "InspectionDefectError100PointSys",
                column: "InspectionDefectCapturing100PointSysId",
                principalTable: "InspectionDefectCapturing100PointSys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDefectError4PointSys_InspectionDefectCapturing4PointSys_InspectionDefectCapturing4PointSysId",
                table: "InspectionDefectError4PointSys",
                column: "InspectionDefectCapturing4PointSysId",
                principalTable: "InspectionDefectCapturing4PointSys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Inpection100PointSys_Inpection100PointSysId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Inpection4PointSys_Inpection4PointSysId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_InpectionTCStandard_InpectionTCStandardId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDefectError100PointSys_InspectionDefectCapturing100PointSys_InspectionDefectCapturing100PointSysId",
                table: "InspectionDefectError100PointSys");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDefectError4PointSys_InspectionDefectCapturing4PointSys_InspectionDefectCapturing4PointSysId",
                table: "InspectionDefectError4PointSys");

            migrationBuilder.DropIndex(
                name: "IX_InspectionDefectError4PointSys_InspectionDefectCapturing4PointSysId",
                table: "InspectionDefectError4PointSys");

            migrationBuilder.DropIndex(
                name: "IX_InspectionDefectError100PointSys_InspectionDefectCapturing100PointSysId",
                table: "InspectionDefectError100PointSys");

            migrationBuilder.DropIndex(
                name: "IX_InpectionTCStandard_QCRequestArticleId",
                table: "InpectionTCStandard");

            migrationBuilder.DropIndex(
                name: "IX_Inpection4PointSys_QCRequestArticleId",
                table: "Inpection4PointSys");

            migrationBuilder.DropIndex(
                name: "IX_Inpection100PointSys_QCRequestArticleId",
                table: "Inpection100PointSys");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_Inpection100PointSysId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_Inpection4PointSysId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_InpectionTCStandardId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Inpection100PointSysId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Inpection4PointSysId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "InpectionTCStandardId",
                table: "Attachment");

            migrationBuilder.RenameColumn(
                name: "InspectionDefectCapturing100PointSysId",
                table: "InspectionDefectError100PointSys",
                newName: "InspectionDefectCapturing4PointSysId");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Inpection4PointSys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Inpection100PointSys",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectionId",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InspectionDefectError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDefectCapturingId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErrorType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectError_InspectionDefectCapturing_InspectionDefectCapturingId",
                        column: x => x.InspectionDefectCapturingId,
                        principalTable: "InspectionDefectCapturing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InpectionTCStandard_QCRequestArticleId",
                table: "InpectionTCStandard",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpection4PointSys_QCRequestArticleId",
                table: "Inpection4PointSys",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpection100PointSys_QCRequestArticleId",
                table: "Inpection100PointSys",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectError_InspectionDefectCapturingId",
                table: "InspectionDefectError",
                column: "InspectionDefectCapturingId");
        }
    }
}
