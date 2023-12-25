using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeColumnTestBeakerRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DyeingTBMaterialColor");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DyeingTBMaterial");

            migrationBuilder.RenameColumn(
                name: "DyeingProcess",
                table: "DyeingTBRTask",
                newName: "DyeingProcessName");

            migrationBuilder.RenameColumn(
                name: "DyeingOpreation",
                table: "DyeingTBRTask",
                newName: "DyeingOperationName");

            migrationBuilder.AddColumn<int>(
                name: "DyeingOperationId",
                table: "DyeingTBRTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DyeingProcessId",
                table: "DyeingTBRTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "DyeingTBRTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "DyeingTBRecipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerRef",
                table: "DyeingTBRecipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "DyeingTBRecipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "DyeingTBRecipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Concentration",
                table: "DyeingTBRecipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDate",
                table: "DyeingTBRecipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GarmentStyleRef",
                table: "DyeingTBRecipe",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "DyeingTBRecipe",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "VersionQty",
                table: "DyeingTBRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChemicalId",
                table: "DyeingTBRChemical",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DyeingTBMaterialColor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DyeingOperationId",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "DyeingProcessId",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "Minute",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "BuyerRef",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "ExpectedDate",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "GarmentStyleRef",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "VersionQty",
                table: "DyeingTBRecipe");

            migrationBuilder.DropColumn(
                name: "ChemicalId",
                table: "DyeingTBRChemical");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DyeingTBMaterialColor");

            migrationBuilder.RenameColumn(
                name: "DyeingProcessName",
                table: "DyeingTBRTask",
                newName: "DyeingProcess");

            migrationBuilder.RenameColumn(
                name: "DyeingOperationName",
                table: "DyeingTBRTask",
                newName: "DyeingOpreation");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DyeingTBRTask",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Time",
                table: "DyeingTBRTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DyeingTBMaterialColor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DyeingTBMaterial",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
