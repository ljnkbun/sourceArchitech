using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsForDyeingIED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputMaterialName",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TCFNo",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXInputMaterialId",
                table: "DyeingIED",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputMaterialName",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "TCFNo",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "WFXInputMaterialId",
                table: "DyeingIED");
        }
    }
}
