using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRequestNoWeavingIED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED");

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "WeavingIED",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "WeavingIED",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingIED_RequestTypeId",
                table: "WeavingIED",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingIED_RequestType_RequestTypeId",
                table: "WeavingIED",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingIED_RequestType_RequestTypeId",
                table: "WeavingIED");

            migrationBuilder.DropIndex(
                name: "IX_WeavingIED_RequestTypeId",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "WeavingIED");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestType_RequestTypeId",
                table: "DyeingIED",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
