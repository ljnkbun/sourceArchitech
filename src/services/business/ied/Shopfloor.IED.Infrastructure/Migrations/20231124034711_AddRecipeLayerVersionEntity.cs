using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeLayerVersionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProcess_RecipeLayer_RecipeLayerId",
                table: "RecipeProcess");

            migrationBuilder.RenameColumn(
                name: "RecipeLayerId",
                table: "RecipeProcess",
                newName: "RecipeLayerVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeProcess_RecipeLayerId",
                table: "RecipeProcess",
                newName: "IX_RecipeProcess_RecipeLayerVersionId");

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "RecipeLayer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeLayerVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeLayerId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLayerVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeLayerVersion_RecipeLayer_RecipeLayerId",
                        column: x => x.RecipeLayerId,
                        principalTable: "RecipeLayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLayerVersion_RecipeLayerId",
                table: "RecipeLayerVersion",
                column: "RecipeLayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProcess_RecipeLayerVersion_RecipeLayerVersionId",
                table: "RecipeProcess",
                column: "RecipeLayerVersionId",
                principalTable: "RecipeLayerVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProcess_RecipeLayerVersion_RecipeLayerVersionId",
                table: "RecipeProcess");

            migrationBuilder.DropTable(
                name: "RecipeLayerVersion");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "RecipeLayer");

            migrationBuilder.RenameColumn(
                name: "RecipeLayerVersionId",
                table: "RecipeProcess",
                newName: "RecipeLayerId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeProcess_RecipeLayerVersionId",
                table: "RecipeProcess",
                newName: "IX_RecipeProcess_RecipeLayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProcess_RecipeLayer_RecipeLayerId",
                table: "RecipeProcess",
                column: "RecipeLayerId",
                principalTable: "RecipeLayer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
