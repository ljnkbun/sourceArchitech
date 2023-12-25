using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateTestBeaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeProcessChemical");

            migrationBuilder.DropTable(
                name: "RecipeProcess");

            migrationBuilder.CreateTable(
                name: "DyeingTBRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBMaterialColorId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TCFNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ApproveVersionId = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRecipe_DyeingTBMaterialColor_DyeingTBMaterialColorId",
                        column: x => x.DyeingTBMaterialColorId,
                        principalTable: "DyeingTBMaterialColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRecipeId = table.Column<int>(type: "int", nullable: false),
                    DyeingProcess = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DyeingOpreation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DyeingTBRTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRTask_DyeingTBRecipe_DyeingTBRecipeId",
                        column: x => x.DyeingTBRecipeId,
                        principalTable: "DyeingTBRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRecipeId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    DoTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRVersion_DyeingTBRecipe_DyeingTBRecipeId",
                        column: x => x.DyeingTBRecipeId,
                        principalTable: "DyeingTBRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(20)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Unit = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRChemical_DyeingTBRTask_DyeingTBRTaskId",
                        column: x => x.DyeingTBRTaskId,
                        principalTable: "DyeingTBRTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRCValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRChemicalId = table.Column<int>(type: "int", nullable: false),
                    DyeingTBRVersionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRCValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRCValue_DyeingTBRVersion_DyeingTBRVersionId",
                        column: x => x.DyeingTBRVersionId,
                        principalTable: "DyeingTBRVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRChemical_DyeingTBRTaskId",
                table: "DyeingTBRChemical",
                column: "DyeingTBRTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRCValue_DyeingTBRVersionId",
                table: "DyeingTBRCValue",
                column: "DyeingTBRVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe",
                column: "DyeingTBMaterialColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRTask_DyeingTBRecipeId",
                table: "DyeingTBRTask",
                column: "DyeingTBRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRVersion_DyeingTBRecipeId",
                table: "DyeingTBRVersion",
                column: "DyeingTBRecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DyeingTBRChemical");

            migrationBuilder.DropTable(
                name: "DyeingTBRCValue");

            migrationBuilder.DropTable(
                name: "DyeingTBRTask");

            migrationBuilder.DropTable(
                name: "DyeingTBRVersion");

            migrationBuilder.DropTable(
                name: "DyeingTBRecipe");

            migrationBuilder.CreateTable(
                name: "RecipeProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeLayerVersionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MachineCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeProcess_DyeingTBMaterialColor_RecipeLayerVersionId",
                        column: x => x.RecipeLayerVersionId,
                        principalTable: "DyeingTBMaterialColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeProcessChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeProcessId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DyeingRecipt = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabRecipt = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Unit = table.Column<string>(type: "varchar(50)", nullable: true)
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
                name: "IX_RecipeProcess_RecipeLayerVersionId",
                table: "RecipeProcess",
                column: "RecipeLayerVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProcessChemical_RecipeProcessId",
                table: "RecipeProcessChemical",
                column: "RecipeProcessId");
        }
    }
}
