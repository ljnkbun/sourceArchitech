using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modify_operation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SewingTaskOrTaskGroupId",
                table: "SewingOperationDetail");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SewingOperation");

            migrationBuilder.RenameColumn(
                name: "ParentType",
                table: "SewingOperation",
                newName: "SewingProcessId");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "SewingProcess",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingProcess",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingProcess",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "SewingOperationDetail",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "SewingOperation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "SewingOperation",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperation_SewingProcessId",
                table: "SewingOperation",
                column: "SewingProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperation_SewingProcess_SewingProcessId",
                table: "SewingOperation",
                column: "SewingProcessId",
                principalTable: "SewingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperation_SewingProcess_SewingProcessId",
                table: "SewingOperation");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperation_SewingProcessId",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SewingOperation");

            migrationBuilder.RenameColumn(
                name: "SewingProcessId",
                table: "SewingOperation",
                newName: "ParentType");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SewingProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingProcess",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingProcess",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "SewingOperationDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "SewingTaskOrTaskGroupId",
                table: "SewingOperationDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "SewingOperation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "SewingOperation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
