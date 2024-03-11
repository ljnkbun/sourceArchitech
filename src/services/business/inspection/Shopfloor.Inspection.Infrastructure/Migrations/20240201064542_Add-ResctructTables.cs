using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddResctructTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDefectError_Inspection_InspectionId",
                table: "InspectionDefectError");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "QCRequestNo",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "SamplePlan",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "SampleQty",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Inspection");

            migrationBuilder.RenameColumn(
                name: "QCDefinitionDefectId",
                table: "InspectionMesurement",
                newName: "QCDefectId");

            migrationBuilder.RenameColumn(
                name: "InspectionId",
                table: "InspectionDefectError",
                newName: "InspectionDefectCapturingId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDefectError_InspectionId",
                table: "InspectionDefectError",
                newName: "IX_InspectionDefectError_InspectionDefectCapturingId");

            migrationBuilder.RenameColumn(
                name: "QCDefinitionDefectId",
                table: "InspectionDefectCapturing",
                newName: "QCDefectId");

            migrationBuilder.RenameColumn(
                name: "QCRequestArticleID",
                table: "Inspection",
                newName: "QCRequestArticleId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InspectionMesurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InspectionMesurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "InspectionMesurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InspectionDefectCapturing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InspectionDefectCapturing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "InspectionDefectCapturing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_QCRequestArticleId",
                table: "Inspection",
                column: "QCRequestArticleId",
                unique: true,
                filter: "[QCRequestArticleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_QCRequestArticle_QCRequestArticleId",
                table: "Inspection",
                column: "QCRequestArticleId",
                principalTable: "QCRequestArticle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDefectError_InspectionDefectCapturing_InspectionDefectCapturingId",
                table: "InspectionDefectError",
                column: "InspectionDefectCapturingId",
                principalTable: "InspectionDefectCapturing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_QCRequestArticle_QCRequestArticleId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDefectError_InspectionDefectCapturing_InspectionDefectCapturingId",
                table: "InspectionDefectError");

            migrationBuilder.DropIndex(
                name: "IX_Inspection_QCRequestArticleId",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InspectionMesurement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InspectionMesurement");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "InspectionMesurement");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InspectionDefectCapturing");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InspectionDefectCapturing");

            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "InspectionDefectCapturing");

            migrationBuilder.RenameColumn(
                name: "QCDefectId",
                table: "InspectionMesurement",
                newName: "QCDefinitionDefectId");

            migrationBuilder.RenameColumn(
                name: "InspectionDefectCapturingId",
                table: "InspectionDefectError",
                newName: "InspectionId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionDefectError_InspectionDefectCapturingId",
                table: "InspectionDefectError",
                newName: "IX_InspectionDefectError_InspectionId");

            migrationBuilder.RenameColumn(
                name: "QCDefectId",
                table: "InspectionDefectCapturing",
                newName: "QCDefinitionDefectId");

            migrationBuilder.RenameColumn(
                name: "QCRequestArticleId",
                table: "Inspection",
                newName: "QCRequestArticleID");

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Inspection",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QCRequestNo",
                table: "Inspection",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SamplePlan",
                table: "Inspection",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SampleQty",
                table: "Inspection",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Inspection",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDefectError_Inspection_InspectionId",
                table: "InspectionDefectError",
                column: "InspectionId",
                principalTable: "Inspection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
