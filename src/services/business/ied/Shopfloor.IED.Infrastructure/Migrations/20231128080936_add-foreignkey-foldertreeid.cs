using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyfoldertreeid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderTree_FolderTree_ParentId",
                table: "FolderTree");

            migrationBuilder.AddColumn<int>(
                name: "FolderTreeId",
                table: "SewingTaskGroupLib",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FolderTreeId",
                table: "SewingOperationLibs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FolderTreeId",
                table: "SewingOperationGroupLibs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskGroupLib_FolderTreeId",
                table: "SewingTaskGroupLib",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibs_FolderTreeId",
                table: "SewingOperationLibs",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupLibs_FolderTreeId",
                table: "SewingOperationGroupLibs",
                column: "FolderTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FolderTree_FolderTree_ParentId",
                table: "FolderTree",
                column: "ParentId",
                principalTable: "FolderTree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationGroupLibs_FolderTree_FolderTreeId",
                table: "SewingOperationGroupLibs",
                column: "FolderTreeId",
                principalTable: "FolderTree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationLibs_FolderTree_FolderTreeId",
                table: "SewingOperationLibs",
                column: "FolderTreeId",
                principalTable: "FolderTree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskGroupLib_FolderTree_FolderTreeId",
                table: "SewingTaskGroupLib",
                column: "FolderTreeId",
                principalTable: "FolderTree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderTree_FolderTree_ParentId",
                table: "FolderTree");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationGroupLibs_FolderTree_FolderTreeId",
                table: "SewingOperationGroupLibs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationLibs_FolderTree_FolderTreeId",
                table: "SewingOperationLibs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskGroupLib_FolderTree_FolderTreeId",
                table: "SewingTaskGroupLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingTaskGroupLib_FolderTreeId",
                table: "SewingTaskGroupLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationLibs_FolderTreeId",
                table: "SewingOperationLibs");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationGroupLibs_FolderTreeId",
                table: "SewingOperationGroupLibs");

            migrationBuilder.DropColumn(
                name: "FolderTreeId",
                table: "SewingTaskGroupLib");

            migrationBuilder.DropColumn(
                name: "FolderTreeId",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "FolderTreeId",
                table: "SewingOperationGroupLibs");

            migrationBuilder.AddForeignKey(
                name: "FK_FolderTree_FolderTree_ParentId",
                table: "FolderTree",
                column: "ParentId",
                principalTable: "FolderTree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
