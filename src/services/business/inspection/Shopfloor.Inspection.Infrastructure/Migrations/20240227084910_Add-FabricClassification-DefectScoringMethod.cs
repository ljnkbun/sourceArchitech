using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricClassificationDefectScoringMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FourPointSystemId",
                table: "Sampling",
                newName: "FabricClassificationId");

            migrationBuilder.AddColumn<int>(
                name: "DefectScoringMethodId",
                table: "Sampling",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DefectScoringMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    DirectionType = table.Column<byte>(type: "tinyint", nullable: false),
                    FourPointType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectScoringMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FabricType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricClassification", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_DefectScoringMethodId",
                table: "Sampling",
                column: "DefectScoringMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FabricClassificationId",
                table: "Sampling",
                column: "FabricClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling",
                column: "DefectScoringMethodId",
                principalTable: "DefectScoringMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling",
                column: "FabricClassificationId",
                principalTable: "FabricClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling");

            migrationBuilder.DropTable(
                name: "DefectScoringMethod");

            migrationBuilder.DropTable(
                name: "FabricClassification");

            migrationBuilder.DropIndex(
                name: "IX_Sampling_DefectScoringMethodId",
                table: "Sampling");

            migrationBuilder.DropIndex(
                name: "IX_Sampling_FabricClassificationId",
                table: "Sampling");

            migrationBuilder.DropColumn(
                name: "DefectScoringMethodId",
                table: "Sampling");

            migrationBuilder.RenameColumn(
                name: "FabricClassificationId",
                table: "Sampling",
                newName: "FourPointSystemId");
        }
    }
}
