using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_tables_operation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskGroupLib_GroupTaskId",
                table: "SewingTaskGroupMapLibs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskLib_TaskId",
                table: "SewingTaskGroupMapLibs");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "SewingTaskGroupMapLibs",
                newName: "SewingTaskLibId");

            migrationBuilder.RenameColumn(
                name: "GroupTaskId",
                table: "SewingTaskGroupMapLibs",
                newName: "SewingTaskGroupLibId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingTaskGroupMapLibs_TaskId",
                table: "SewingTaskGroupMapLibs",
                newName: "IX_SewingTaskGroupMapLibs_SewingTaskLibId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingTaskGroupMapLibs_GroupTaskId",
                table: "SewingTaskGroupMapLibs",
                newName: "IX_SewingTaskGroupMapLibs_SewingTaskGroupLibId");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "SewingTaskLib",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "SewingTaskGroupLib",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "SewingOperationGroupLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SewingOperationGroupLibs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SewingOperationLibs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationGroupMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationGroupLibId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SewingOperationTaskGroupMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskGroupLibId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationTaskGroupMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskGroupMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskGroupMapLibs_SewingTaskGroupLib_SewingTaskGroupLibId",
                        column: x => x.SewingTaskGroupLibId,
                        principalTable: "SewingTaskGroupLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationTaskMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationTaskMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskMapLibs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupMapLibs_SewingOperationGroupLibId",
                table: "SewingOperationGroupMapLibs",
                column: "SewingOperationGroupLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationGroupMapLibs_SewingOperationLibId",
                table: "SewingOperationGroupMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskGroupMapLibs_SewingOperationLibId",
                table: "SewingOperationTaskGroupMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskGroupMapLibs_SewingTaskGroupLibId",
                table: "SewingOperationTaskGroupMapLibs",
                column: "SewingTaskGroupLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskMapLibs_SewingOperationLibId",
                table: "SewingOperationTaskMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskMapLibs_SewingTaskLibId",
                table: "SewingOperationTaskMapLibs",
                column: "SewingTaskLibId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskGroupLib_SewingTaskGroupLibId",
                table: "SewingTaskGroupMapLibs",
                column: "SewingTaskGroupLibId",
                principalTable: "SewingTaskGroupLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskLib_SewingTaskLibId",
                table: "SewingTaskGroupMapLibs",
                column: "SewingTaskLibId",
                principalTable: "SewingTaskLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskGroupLib_SewingTaskGroupLibId",
                table: "SewingTaskGroupMapLibs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskLib_SewingTaskLibId",
                table: "SewingTaskGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationTaskGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationTaskMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationGroupLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationLibs");

            migrationBuilder.RenameColumn(
                name: "SewingTaskLibId",
                table: "SewingTaskGroupMapLibs",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "SewingTaskGroupLibId",
                table: "SewingTaskGroupMapLibs",
                newName: "GroupTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingTaskGroupMapLibs_SewingTaskLibId",
                table: "SewingTaskGroupMapLibs",
                newName: "IX_SewingTaskGroupMapLibs_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingTaskGroupMapLibs_SewingTaskGroupLibId",
                table: "SewingTaskGroupMapLibs",
                newName: "IX_SewingTaskGroupMapLibs_GroupTaskId");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "SewingTaskLib",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "SewingTaskGroupLib",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskGroupLib_GroupTaskId",
                table: "SewingTaskGroupMapLibs",
                column: "GroupTaskId",
                principalTable: "SewingTaskGroupLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskGroupMapLibs_SewingTaskLib_TaskId",
                table: "SewingTaskGroupMapLibs",
                column: "TaskId",
                principalTable: "SewingTaskLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
