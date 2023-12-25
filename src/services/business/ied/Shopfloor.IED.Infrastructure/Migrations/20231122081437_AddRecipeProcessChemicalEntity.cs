using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeProcessChemicalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeProcessChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeProcessId = table.Column<int>(type: "int", nullable: false),
                    LabRecipt = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    DyeingRecipt = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Unit = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProcessChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeProcessChemical_RecipeProcess_RecipeProcessId",
                        column: x => x.RecipeProcessId,
                        principalTable: "RecipeProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProcessChemical_RecipeProcessId",
                table: "RecipeProcessChemical",
                column: "RecipeProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeProcessChemical");
        }
    }
}
