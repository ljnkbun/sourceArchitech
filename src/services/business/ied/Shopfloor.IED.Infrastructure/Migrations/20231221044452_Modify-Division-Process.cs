using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDivisionProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeChemical_RecipeTask_RecipeTaskId",
                table: "RecipeChemical");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTask_Recipe_RecipeId",
                table: "RecipeTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestArticleInput_RequestArticleOutput_RequestArticleOutputId",
                table: "RequestArticleInput");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestArticleOutput_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestArticleOutput");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestArticleOutput",
                table: "RequestArticleOutput");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestArticleInput",
                table: "RequestArticleInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTask",
                table: "RecipeTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeChemical",
                table: "RecipeChemical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "RequestDivision");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "RequestDivision");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "RequestDivision");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "RequestDivision");

            migrationBuilder.RenameTable(
                name: "RequestArticleOutput",
                newName: "RequestArticleOutputs");

            migrationBuilder.RenameTable(
                name: "RequestArticleInput",
                newName: "RequestArticleInputs");

            migrationBuilder.RenameTable(
                name: "RecipeTask",
                newName: "RecipeTasks");

            migrationBuilder.RenameTable(
                name: "RecipeChemical",
                newName: "RecipeChemicals");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Division",
                table: "RequestDivision",
                newName: "LineNumber");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleOutput_RequestDivisionProcessId",
                table: "RequestArticleOutputs",
                newName: "IX_RequestArticleOutputs_RequestDivisionProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleInput_RequestArticleOutputId",
                table: "RequestArticleInputs",
                newName: "IX_RequestArticleInputs_RequestArticleOutputId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTask_RecipeId",
                table: "RecipeTasks",
                newName: "IX_RecipeTasks_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeChemical_RecipeTaskId",
                table: "RecipeChemicals",
                newName: "IX_RecipeChemicals_RecipeTaskId");

            migrationBuilder.AddColumn<int>(
                name: "LineNumber",
                table: "RequestDivisionProcess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProcessCode",
                table: "RequestDivisionProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "RequestDivisionProcess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "RequestDivisionProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DivisionCode",
                table: "RequestDivision",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "RequestDivision",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DivisionName",
                table: "RequestDivision",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RequestArticleOutputs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestArticleOutputs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RequestArticleOutputs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "RequestArticleOutputs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "RequestArticleOutputs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RequestArticleInputs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestArticleInputs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RequestArticleInputs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "RequestArticleInputs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "RequestArticleInputs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "RequestArticleInputs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "RecipeTasks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RecipeTasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "MachineType",
                table: "RecipeTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecipeTasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<string>(
                name: "DyeingOpreation",
                table: "RecipeTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RecipeTasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "RecipeChemicals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "RecipeChemicals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RecipeChemicals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecipeChemicals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RecipeChemicals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalName",
                table: "RecipeChemicals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCode",
                table: "RecipeChemicals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TCFNO",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Speed",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RollKg",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipeNo",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NozzleB",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NozzleA",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Recipes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Manager",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LotNo",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LAB",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Recipes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<string>(
                name: "InCharge",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FabricName",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FabricCode",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Recipes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleOutputs",
                table: "RequestArticleOutputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleInputs",
                table: "RequestArticleInputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTasks",
                table: "RecipeTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeChemicals",
                table: "RecipeChemicals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeChemicals_RecipeTasks_RecipeTaskId",
                table: "RecipeChemicals",
                column: "RecipeTaskId",
                principalTable: "RecipeTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTasks_Recipes_RecipeId",
                table: "RecipeTasks",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestArticleInputs_RequestArticleOutputs_RequestArticleOutputId",
                table: "RequestArticleInputs",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestArticleOutputs_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestArticleOutputs",
                column: "RequestDivisionProcessId",
                principalTable: "RequestDivisionProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeChemicals_RecipeTasks_RecipeTaskId",
                table: "RecipeChemicals");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTasks_Recipes_RecipeId",
                table: "RecipeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestArticleInputs_RequestArticleOutputs_RequestArticleOutputId",
                table: "RequestArticleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestArticleOutputs_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestArticleOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestArticleOutputs",
                table: "RequestArticleOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestArticleInputs",
                table: "RequestArticleInputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTasks",
                table: "RecipeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeChemicals",
                table: "RecipeChemicals");

            migrationBuilder.DropColumn(
                name: "LineNumber",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "ProcessCode",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "DivisionCode",
                table: "RequestDivision");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "RequestDivision");

            migrationBuilder.DropColumn(
                name: "DivisionName",
                table: "RequestDivision");

            migrationBuilder.RenameTable(
                name: "RequestArticleOutputs",
                newName: "RequestArticleOutput");

            migrationBuilder.RenameTable(
                name: "RequestArticleInputs",
                newName: "RequestArticleInput");

            migrationBuilder.RenameTable(
                name: "RecipeTasks",
                newName: "RecipeTask");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "RecipeChemicals",
                newName: "RecipeChemical");

            migrationBuilder.RenameColumn(
                name: "LineNumber",
                table: "RequestDivision",
                newName: "Division");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleOutputs_RequestDivisionProcessId",
                table: "RequestArticleOutput",
                newName: "IX_RequestArticleOutput_RequestDivisionProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleInputs_RequestArticleOutputId",
                table: "RequestArticleInput",
                newName: "IX_RequestArticleInput_RequestArticleOutputId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTasks_RecipeId",
                table: "RecipeTask",
                newName: "IX_RecipeTask_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeChemicals_RecipeTaskId",
                table: "RecipeChemical",
                newName: "IX_RecipeChemical_RecipeTaskId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RequestDivisionProcess",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestDivisionProcess",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "RequestDivision",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "RequestDivision",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "RequestDivision",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "RequestDivision",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RequestArticleOutput",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestArticleOutput",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RequestArticleOutput",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "RequestArticleOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "RequestArticleOutput",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RequestArticleInput",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestArticleInput",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RequestArticleInput",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "RequestArticleInput",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "RequestArticleInput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "RequestArticleInput",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "RecipeTask",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RecipeTask",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineType",
                table: "RecipeTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecipeTask",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "DyeingOpreation",
                table: "RecipeTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RecipeTask",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TCFNO",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Speed",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RollKg",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipeNo",
                table: "Recipe",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NozzleB",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NozzleA",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Recipe",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Manager",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LotNo",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LAB",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "InCharge",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FabricName",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FabricCode",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Recipe",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Recipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "RecipeChemical",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "RecipeChemical",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "RecipeChemical",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecipeChemical",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RecipeChemical",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalName",
                table: "RecipeChemical",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChemicalCode",
                table: "RecipeChemical",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleOutput",
                table: "RequestArticleOutput",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleInput",
                table: "RequestArticleInput",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTask",
                table: "RecipeTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeChemical",
                table: "RecipeChemical",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeChemical_RecipeTask_RecipeTaskId",
                table: "RecipeChemical",
                column: "RecipeTaskId",
                principalTable: "RecipeTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTask_Recipe_RecipeId",
                table: "RecipeTask",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestArticleInput_RequestArticleOutput_RequestArticleOutputId",
                table: "RequestArticleInput",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestArticleOutput_RequestDivisionProcess_RequestDivisionProcessId",
                table: "RequestArticleOutput",
                column: "RequestDivisionProcessId",
                principalTable: "RequestDivisionProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
