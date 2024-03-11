using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCodeMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingBorderStyle_Code",
                table: "WeavingBorderStyle");

            migrationBuilder.DropIndex(
                name: "IX_WeavingBackgroundStyle_Code",
                table: "WeavingBackgroundStyle");

            migrationBuilder.DropIndex(
                name: "IX_Shade_Code",
                table: "Shade");

            migrationBuilder.DropIndex(
                name: "IX_RequestType_Code",
                table: "RequestType");

            migrationBuilder.DropIndex(
                name: "IX_RecipeUnit_Code",
                table: "RecipeUnit");

            migrationBuilder.DropIndex(
                name: "IX_Light_Code",
                table: "Light");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "WeavingBorderStyle");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "WeavingBackgroundStyle");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Shade");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SewingEfficiencyProfile");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RequestType");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RecipeUnit");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Light");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeavingBorderStyle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeavingBackgroundStyle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RequestType",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Light",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBorderStyle_Name",
                table: "WeavingBorderStyle",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBackgroundStyle_Name",
                table: "WeavingBackgroundStyle",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestType_Name",
                table: "RequestType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Light_Name",
                table: "Light",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingBorderStyle_Name",
                table: "WeavingBorderStyle");

            migrationBuilder.DropIndex(
                name: "IX_WeavingBackgroundStyle_Name",
                table: "WeavingBackgroundStyle");

            migrationBuilder.DropIndex(
                name: "IX_RequestType_Name",
                table: "RequestType");

            migrationBuilder.DropIndex(
                name: "IX_Light_Name",
                table: "Light");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeavingBorderStyle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "WeavingBorderStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WeavingBackgroundStyle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "WeavingBackgroundStyle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Shade",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SewingEfficiencyProfile",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RequestType",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RequestType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RecipeUnit",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Light",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Light",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBorderStyle_Code",
                table: "WeavingBorderStyle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBackgroundStyle_Code",
                table: "WeavingBackgroundStyle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shade_Code",
                table: "Shade",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestType_Code",
                table: "RequestType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUnit_Code",
                table: "RecipeUnit",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Light_Code",
                table: "Light",
                column: "Code",
                unique: true);
        }
    }
}
