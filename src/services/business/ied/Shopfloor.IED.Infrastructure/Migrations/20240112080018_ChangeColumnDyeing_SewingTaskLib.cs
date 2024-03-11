using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDyeing_SewingTaskLib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SewingComponentGroupId",
                table: "SewingTaskLib",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "DyeingIED",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "DyeingIED",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskLib_SewingComponentGroupId",
                table: "SewingTaskLib",
                column: "SewingComponentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingIED_RequestTypeId",
                table: "DyeingIED",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingTaskLib",
                column: "SewingComponentGroupId",
                principalTable: "SewingComponentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingTaskLib_SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.DropIndex(
                name: "IX_DyeingIED_RequestTypeId",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "DyeingIED");
        }
    }
}
