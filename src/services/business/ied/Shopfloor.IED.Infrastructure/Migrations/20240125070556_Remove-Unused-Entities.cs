using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingFeatureBOL");

            migrationBuilder.DropTable(
                name: "SewingMacroBOL");

            migrationBuilder.DropTable(
                name: "SewingOperationBOL");

            migrationBuilder.DropTable(
                name: "SewingFeature");

            migrationBuilder.DropTable(
                name: "SewingMacro");

            migrationBuilder.DropTable(
                name: "SewingOperation");

            migrationBuilder.DropTable(
                name: "SewingTask");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SewingFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalBasicMinutes = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaskType = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WFXMachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeatureBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationId = table.Column<int>(type: "int", nullable: true),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RPM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                        column: x => x.SewingFeatureId,
                        principalTable: "SewingFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingFeatureBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingMacroId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskId = table.Column<int>(type: "int", nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                        column: x => x.SewingMacroId,
                        principalTable: "SewingMacro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingMacroBOL_SewingTask_SewingTaskId",
                        column: x => x.SewingTaskId,
                        principalTable: "SewingTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingMacroId = table.Column<int>(type: "int", nullable: true),
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskId = table.Column<int>(type: "int", nullable: true),
                    Allowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationBOL_SewingMacro_SewingMacroId",
                        column: x => x.SewingMacroId,
                        principalTable: "SewingMacro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationBOL_SewingTask_SewingTaskId",
                        column: x => x.SewingTaskId,
                        principalTable: "SewingTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingFeatureId",
                table: "SewingFeatureBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingOperationId",
                table: "SewingFeatureBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingMacroId",
                table: "SewingMacroBOL",
                column: "SewingMacroId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingTaskId",
                table: "SewingMacroBOL",
                column: "SewingTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingMacroId",
                table: "SewingOperationBOL",
                column: "SewingMacroId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingOperationId",
                table: "SewingOperationBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingTaskId",
                table: "SewingOperationBOL",
                column: "SewingTaskId");
        }
    }
}
