using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyColorArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Color",
                table: "RequestArticleInputs");

            migrationBuilder.RenameTable(
                name: "RequestArticleOutputs",
                newName: "RequestArticleOutput");

            migrationBuilder.RenameTable(
                name: "RequestArticleInputs",
                newName: "RequestArticleInput");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleOutputs_RequestDivisionProcessId",
                table: "RequestArticleOutput",
                newName: "IX_RequestArticleOutput_RequestDivisionProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleInputs_RequestArticleOutputId",
                table: "RequestArticleInput",
                newName: "IX_RequestArticleInput_RequestArticleOutputId");

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

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "RequestArticleOutput",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleOutput",
                table: "RequestArticleOutput",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleInput",
                table: "RequestArticleInput",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Color",
                table: "RequestArticleOutput");

            migrationBuilder.RenameTable(
                name: "RequestArticleOutput",
                newName: "RequestArticleOutputs");

            migrationBuilder.RenameTable(
                name: "RequestArticleInput",
                newName: "RequestArticleInputs");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleOutput_RequestDivisionProcessId",
                table: "RequestArticleOutputs",
                newName: "IX_RequestArticleOutputs_RequestDivisionProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestArticleInput_RequestArticleOutputId",
                table: "RequestArticleInputs",
                newName: "IX_RequestArticleInputs_RequestArticleOutputId");

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

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "RequestArticleInputs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleOutputs",
                table: "RequestArticleOutputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestArticleInputs",
                table: "RequestArticleInputs",
                column: "Id");

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
    }
}
