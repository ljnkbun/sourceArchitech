using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSewingMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingOperationLib",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingOperationLib",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SewingComponentId",
                table: "SewingOperationLib",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryCode",
                table: "SewingOperationLib",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "SewingOperationLib",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingFeatureLib",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingFeatureLib",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerCode",
                table: "SewingFeatureLib",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "SewingFeatureLib",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SewingComponentId",
                table: "SewingFeatureLib",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryCode",
                table: "SewingFeatureLib",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "SewingFeatureLib",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SewingComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingComponentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingComponentGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLib_Code",
                table: "SewingOperationLib",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLib_SewingComponentId",
                table: "SewingOperationLib",
                column: "SewingComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLib_Code",
                table: "SewingFeatureLib",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLib_SewingComponentId",
                table: "SewingFeatureLib",
                column: "SewingComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingComponent_Code",
                table: "SewingComponent",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingComponentGroup_Code",
                table: "SewingComponentGroup",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLib_SewingComponent_SewingComponentId",
                table: "SewingFeatureLib",
                column: "SewingComponentId",
                principalTable: "SewingComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationLib_SewingComponent_SewingComponentId",
                table: "SewingOperationLib",
                column: "SewingComponentId",
                principalTable: "SewingComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLib_SewingComponent_SewingComponentId",
                table: "SewingFeatureLib");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationLib_SewingComponent_SewingComponentId",
                table: "SewingOperationLib");

            migrationBuilder.DropTable(
                name: "SewingComponent");

            migrationBuilder.DropTable(
                name: "SewingComponentGroup");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationLib_Code",
                table: "SewingOperationLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationLib_SewingComponentId",
                table: "SewingOperationLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingFeatureLib_Code",
                table: "SewingFeatureLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingFeatureLib_SewingComponentId",
                table: "SewingFeatureLib");

            migrationBuilder.DropColumn(
                name: "SewingComponentId",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "SubCategoryCode",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "BuyerCode",
                table: "SewingFeatureLib");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "SewingFeatureLib");

            migrationBuilder.DropColumn(
                name: "SewingComponentId",
                table: "SewingFeatureLib");

            migrationBuilder.DropColumn(
                name: "SubCategoryCode",
                table: "SewingFeatureLib");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "SewingFeatureLib");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingOperationLib",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingOperationLib",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SewingFeatureLib",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SewingFeatureLib",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
