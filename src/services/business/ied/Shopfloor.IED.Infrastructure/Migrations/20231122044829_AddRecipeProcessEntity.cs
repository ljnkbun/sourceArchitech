using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeProcessEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeLayerId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    MachineCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeProcess_RecipeLayer_RecipeLayerId",
                        column: x => x.RecipeLayerId,
                        principalTable: "RecipeLayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProcess_RecipeLayerId",
                table: "RecipeProcess",
                column: "RecipeLayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeProcess");
        }
    }
}
