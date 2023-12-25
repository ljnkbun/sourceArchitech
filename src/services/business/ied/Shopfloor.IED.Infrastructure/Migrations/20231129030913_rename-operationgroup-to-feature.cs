using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameoperationgrouptofeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingOperationGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationGroupLibs");

            migrationBuilder.CreateTable(
                name: "SewingFeatureLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLibs_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeatureMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingFeatureLibId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureMapLibs_SewingFeatureLibs_SewingFeatureLibId",
                        column: x => x.SewingFeatureLibId,
                        principalTable: "SewingFeatureLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingFeatureMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLibs_FolderTreeId",
                table: "SewingFeatureLibs",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureMapLibs_SewingFeatureLibId",
                table: "SewingFeatureMapLibs",
                column: "SewingFeatureLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureMapLibs_SewingOperationLibId",
                table: "SewingFeatureMapLibs",
                column: "SewingOperationLibId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingFeatureMapLibs");

            migrationBuilder.DropTable(
                name: "SewingFeatureLibs");

            migrationBuilder.CreateTable(
                name: "SewingOperationGroupLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationGroupLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationGroupLibs_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationGroupMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationGroupLibId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationGroupMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationGroupMapLibs_SewingOperationGroupLibs_SewingOperationGroupLibId",
                        column: x => x.SewingOperationGroupLibId,
                        principalTable: "SewingOperationGroupLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationGroupMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupLibs_FolderTreeId",
                table: "SewingOperationGroupLibs",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupMapLibs_SewingOperationGroupLibId",
                table: "SewingOperationGroupMapLibs",
                column: "SewingOperationGroupLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupMapLibs_SewingOperationLibId",
                table: "SewingOperationGroupMapLibs",
                column: "SewingOperationLibId");
        }
    }
}
