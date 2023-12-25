using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRequestId = table.Column<int>(type: "int", nullable: false),
                    DyeingTBRVersionId = table.Column<int>(type: "int", nullable: false),
                    RecipeNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    JobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TCFNO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Style = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FabricCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FabricName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RollKg = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NozzleA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NozzleB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InCharge = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DyeingOpreation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MachineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTask_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeChemical_RecipeTask_RecipeTaskId",
                        column: x => x.RecipeTaskId,
                        principalTable: "RecipeTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeChemical_RecipeTaskId",
                table: "RecipeChemical",
                column: "RecipeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTask_RecipeId",
                table: "RecipeTask",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeChemical");

            migrationBuilder.DropTable(
                name: "RecipeTask");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
