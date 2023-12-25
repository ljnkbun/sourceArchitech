using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperation_SewingProcess_SewingProcessId",
                table: "SewingOperation");

            migrationBuilder.DropTable(
                name: "SewingOperationDetail");

            migrationBuilder.DropTable(
                name: "SewingProcess");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperation_SewingProcessId",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "AllowedTime",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Effort",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "LabourCost",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "NonMachineTime",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "QualityComments",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "QuatityPoints",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "SewingProcessId",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "TotalSMV",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "SewingOperation");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingOperation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BundelTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LineCode",
                table: "SewingOperation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "RequestDivisionProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDivisionProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDivisionProcess_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacro_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundelTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestDivisionProcessArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDivisionProcessArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDivisionProcessArticle_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationWFX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    WFXProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WFXProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductSubCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostOp = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactory = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationWFX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationWFX_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeatureBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                        column: x => x.SewingFeatureId,
                        principalTable: "SewingFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SewingTaskId = table.Column<int>(type: "int", nullable: false),
                    SewingMacroId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                        column: x => x.SewingMacroId,
                        principalTable: "SewingMacro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskId = table.Column<int>(type: "int", nullable: true),
                    SewingMacroId = table.Column<int>(type: "int", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingOperationBOL_SewingTask_SewingTaskId",
                        column: x => x.SewingTaskId,
                        principalTable: "SewingTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationWFXVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationWFXVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationWFXVersion_SewingOperationWFX_SewingOperationWFXId",
                        column: x => x.SewingOperationWFXId,
                        principalTable: "SewingOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationWFXVersionId = table.Column<int>(type: "int", nullable: false),
                    WFXProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WFXProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NonMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    QuatityPoints = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QualityComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Effort = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFX_SewingOperationWFXVersion_SewingOperationWFXVersionId",
                        column: x => x.SewingOperationWFXVersionId,
                        principalTable: "SewingOperationWFXVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFXBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingSubOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFXBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                        column: x => x.SewingFeatureId,
                        principalTable: "SewingFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                        column: x => x.SewingSubOperationWFXId,
                        principalTable: "SewingSubOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFXResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingSubOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    TMUType = table.Column<byte>(type: "tinyint", nullable: false),
                    TMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BasicMunite = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFXResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXResult_SewingSubOperationWFX_SewingSubOperationWFXId",
                        column: x => x.SewingSubOperationWFXId,
                        principalTable: "SewingSubOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivisionProcess_RequestDivisionId",
                table: "RequestDivisionProcess",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivisionProcessArticle_RequestDivisionProcessId",
                table: "RequestDivisionProcessArticle",
                column: "RequestDivisionProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingFeatureId",
                table: "SewingFeatureBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingOperationId",
                table: "SewingFeatureBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacro_FolderTreeId",
                table: "SewingMacro",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingMacroId",
                table: "SewingMacroBOL",
                column: "SewingMacroId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingTaskId",
                table: "SewingMacroBOL",
                column: "SewingTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingOperationId",
                table: "SewingOperationBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingTaskId",
                table: "SewingOperationBOL",
                column: "SewingTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFX_RequestDivisionProcessId",
                table: "SewingOperationWFX",
                column: "RequestDivisionProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId",
                table: "SewingOperationWFXVersion",
                column: "SewingOperationWFXId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFX_SewingOperationWFXVersionId",
                table: "SewingSubOperationWFX",
                column: "SewingOperationWFXVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingSubOperationWFXId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXResult",
                column: "SewingSubOperationWFXId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDivisionProcessArticle");

            migrationBuilder.DropTable(
                name: "SewingFeatureBOL");

            migrationBuilder.DropTable(
                name: "SewingMacroBOL");

            migrationBuilder.DropTable(
                name: "SewingOperationBOL");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXBOL");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXResult");

            migrationBuilder.DropTable(
                name: "SewingMacro");

            migrationBuilder.DropTable(
                name: "SewingTask");

            migrationBuilder.DropTable(
                name: "SewingFeature");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFX");

            migrationBuilder.DropTable(
                name: "SewingOperationWFXVersion");

            migrationBuilder.DropTable(
                name: "SewingOperationWFX");

            migrationBuilder.DropTable(
                name: "RequestDivisionProcess");

            migrationBuilder.DropColumn(
                name: "BundelTMU",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "LineCode",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingOperation");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingOperation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AllowedTime",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Effort",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCost",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NonMachineTime",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "QualityComments",
                table: "SewingOperation",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuatityPoints",
                table: "SewingOperation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SewingProcessId",
                table: "SewingOperation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSMV",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "SewingOperation",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "SewingOperation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SewingOperationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationDetail_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactoryTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabourCostFactory = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabourCostOp = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperation_SewingProcessId",
                table: "SewingOperation",
                column: "SewingProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationDetail_SewingOperationId",
                table: "SewingOperationDetail",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingProcess_RequestDivisionId",
                table: "SewingProcess",
                column: "RequestDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperation_SewingProcess_SewingProcessId",
                table: "SewingOperation",
                column: "SewingProcessId",
                principalTable: "SewingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
