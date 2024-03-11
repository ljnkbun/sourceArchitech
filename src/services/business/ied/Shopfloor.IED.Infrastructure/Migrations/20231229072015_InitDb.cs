using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoIncrement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Separate = table.Column<string>(type: "varchar(10)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    IndexFormat = table.Column<string>(type: "varchar(10)", nullable: true),
                    InputValue = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoIncrement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concentrate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concentrate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DCTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DyeingIED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingIED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StyleRef = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BuyerRef = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FolderTree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    ItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    DivisionType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderTree_FolderTree_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingBordyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingBordyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingFeeder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingFeeder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingMachineDiameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingMachineDiameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingShrinkage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingShrinkage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabourSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Light",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Light", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProcessTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_ProcessTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRequestId = table.Column<int>(type: "int", nullable: false),
                    DyeingTBRVersionId = table.Column<int>(type: "int", nullable: false),
                    RecipeNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    JobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TCFNO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Style = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FabricCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FabricName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RollKg = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NozzleA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NozzleB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InCharge = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalBasicMinutes = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "SewingOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_SewingOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TaskType = table.Column<byte>(type: "tinyint", nullable: false),
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
                name: "SewingTaskLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TaskType = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_SewingTaskLib", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeavingBackgrounStyle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingBackgrounStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeavingBorderStyle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingBorderStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneSalary = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DCTemplateTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DCTemplateId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    TaskCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Temperature = table.Column<string>(type: "varchar(50)", nullable: true),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplateTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCTemplateTask_DCTemplate_DCTemplateId",
                        column: x => x.DCTemplateId,
                        principalTable: "DCTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingIEDId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RecipeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RecipeNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingArticle_DyeingIED_DyeingIEDId",
                        column: x => x.DyeingIEDId,
                        principalTable: "DyeingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRequestId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArticleCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FabricContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Lights = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBMaterial_DyeingTBRequest_DyeingTBRequestId",
                        column: x => x.DyeingTBRequestId,
                        principalTable: "DyeingTBRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRequestFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRequestId = table.Column<int>(type: "int", nullable: false),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRequestFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRequestFile_DyeingTBRequest_DyeingTBRequestId",
                        column: x => x.DyeingTBRequestId,
                        principalTable: "DyeingTBRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeatureLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_SewingFeatureLib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLib_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalBasicMinutes = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_SewingMacroLib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroLib_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NoneMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_SewingOperationLib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationLib_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTemplateItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessTemplateId = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTemplateItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessTemplateItem_ProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "ProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    DyeingOpreation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MachineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTask_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    StatusComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
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
                    SewingOperationId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RPM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    SewingMacroId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                        name: "FK_SewingOperationBOL_SewingMacro_SewingMacroId",
                        column: x => x.SewingMacroId,
                        principalTable: "SewingMacro",
                        principalColumn: "Id");
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
                name: "DCTemplateDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DCTemplateTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCTemplateDetail_DCTemplateTask_DCTemplateTaskId",
                        column: x => x.DCTemplateTaskId,
                        principalTable: "DCTemplateTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingRouting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    DyeingProcess = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DyeingOperation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MachineCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Efficiency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    OperationTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingRouting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingRouting_DyeingArticle_DyeingArticleId",
                        column: x => x.DyeingArticleId,
                        principalTable: "DyeingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBMaterialColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBMaterialId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pantone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBMaterialColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBMaterialColor_DyeingTBMaterial_DyeingTBMaterialId",
                        column: x => x.DyeingTBMaterialId,
                        principalTable: "DyeingTBMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroLibBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroLibBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroLibBOL_SewingMacroLib_SewingMacroLibId",
                        column: x => x.SewingMacroLibId,
                        principalTable: "SewingMacroLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingMacroLibBOL_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingFeatureLibBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingFeatureLibId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RPM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureLibBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLibBOL_SewingFeatureLib_SewingFeatureLibId",
                        column: x => x.SewingFeatureLibId,
                        principalTable: "SewingFeatureLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLibBOL_SewingOperationLib_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationLibBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: true),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationLibBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationLibBOL_SewingMacroLib_SewingMacroLibId",
                        column: x => x.SewingMacroLibId,
                        principalTable: "SewingMacroLib",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SewingOperationLibBOL_SewingOperationLib_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingOperationLibBOL_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeChemical_RecipeTask_RecipeTaskId",
                        column: x => x.RecipeTaskId,
                        principalTable: "RecipeTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDivision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DivisionCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDivision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDivision_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingProcessChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingRoutingId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubCategoryCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingProcessChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingProcessChemical_DyeingRouting_DyeingRoutingId",
                        column: x => x.DyeingRoutingId,
                        principalTable: "DyeingRouting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBMaterialColorId = table.Column<int>(type: "int", nullable: false),
                    TBRecipeNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TCFNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ApproveVersionId = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BuyerRef = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GarmentStyleRef = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Concentration = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    VersionQty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRecipe_DyeingTBMaterialColor_DyeingTBMaterialColorId",
                        column: x => x.DyeingTBMaterialColorId,
                        principalTable: "DyeingTBMaterialColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDivisionFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDivisionFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDivisionFile_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDivisionProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    ProcessCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProcessName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingIED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingIED", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingIED_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRecipeId = table.Column<int>(type: "int", nullable: false),
                    DyeingProcessId = table.Column<int>(type: "int", nullable: false),
                    DyeingProcessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DyeingOperationId = table.Column<int>(type: "int", nullable: false),
                    DyeingOperationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRTask_DyeingTBRecipe_DyeingTBRecipeId",
                        column: x => x.DyeingTBRecipeId,
                        principalTable: "DyeingTBRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestArticleOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseColorList = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestArticleOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestArticleOutput_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationWFX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    CurrentVersionId = table.Column<int>(type: "int", nullable: true),
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
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "WeavingArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingIEDId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingArticle_WeavingIED_WeavingIEDId",
                        column: x => x.WeavingIEDId,
                        principalTable: "WeavingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRChemical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ChemicalSubCategory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Unit = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRChemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRChemical_DyeingTBRTask_DyeingTBRTaskId",
                        column: x => x.DyeingTBRTaskId,
                        principalTable: "DyeingTBRTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestArticleInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestArticleOutputId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestArticleInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestArticleInput_RequestArticleOutput_RequestArticleOutputId",
                        column: x => x.RequestArticleOutputId,
                        principalTable: "RequestArticleOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "WeavingDetailStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    StructureType = table.Column<byte>(type: "tinyint", nullable: false),
                    CombString = table.Column<int>(type: "int", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingDetailStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingDetailStructure_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRappo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    NumOfLine = table.Column<int>(type: "int", nullable: false),
                    YarnOfBorder = table.Column<int>(type: "int", nullable: false),
                    YarnOfBackground = table.Column<int>(type: "int", nullable: false),
                    NumOfRappo = table.Column<int>(type: "int", nullable: false),
                    VerticalRappoComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorizontalRappoComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappo_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRouting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    WeavingProcess = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeavingOperation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRouting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRouting_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRusticFabricSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    BackgroundType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BackgroundLoomFrame = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BorderType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BorderLoomFrame = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGM2 = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RPM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CombNum = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CombSize = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RusticSize = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensitySetting = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRusticFabricSpec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRusticFabricSpec_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DyeingTBRChemicalValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBRChemicalId = table.Column<int>(type: "int", nullable: false),
                    VersionIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingTBRChemicalValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingTBRChemicalValue_DyeingTBRChemical_DyeingTBRChemicalId",
                        column: x => x.DyeingTBRChemicalId,
                        principalTable: "DyeingTBRChemical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    LineNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                name: "WeavingRappoMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: false),
                    ColumnNo = table.Column<int>(type: "int", nullable: false),
                    PatternIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappoMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMark_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingYarn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    YarnType = table.Column<byte>(type: "tinyint", nullable: false),
                    YarnCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YarnName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YarnInRappo = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    YarnRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SizingRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ScaleRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ScrapRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingYarn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingYarn_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeavingYarn_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFXBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingSubOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationId = table.Column<int>(type: "int", nullable: true),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "WeavingRappoMatric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    ColumnIndex = table.Column<int>(type: "int", nullable: false),
                    LoopIndex = table.Column<int>(type: "int", nullable: false),
                    HorizontalYarnId = table.Column<int>(type: "int", nullable: false),
                    VerticleYarnId = table.Column<int>(type: "int", nullable: false),
                    BackgroundType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappoMatric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingYarn_HorizontalYarnId",
                        column: x => x.HorizontalYarnId,
                        principalTable: "WeavingYarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingYarn_VerticleYarnId",
                        column: x => x.VerticleYarnId,
                        principalTable: "WeavingYarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concentrate_Code",
                table: "Concentrate",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DCTemplateDetail_DCTemplateTaskId",
                table: "DCTemplateDetail",
                column: "DCTemplateTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DCTemplateTask_DCTemplateId",
                table: "DCTemplateTask",
                column: "DCTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingArticle_DyeingIEDId",
                table: "DyeingArticle",
                column: "DyeingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingProcessChemical_DyeingRoutingId",
                table: "DyeingProcessChemical",
                column: "DyeingRoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingRouting_DyeingArticleId",
                table: "DyeingRouting",
                column: "DyeingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBMaterial_DyeingTBRequestId",
                table: "DyeingTBMaterial",
                column: "DyeingTBRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBMaterialColor_DyeingTBMaterialId",
                table: "DyeingTBMaterialColor",
                column: "DyeingTBMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRChemical_DyeingTBRTaskId",
                table: "DyeingTBRChemical",
                column: "DyeingTBRTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRChemicalValue_DyeingTBRChemicalId",
                table: "DyeingTBRChemicalValue",
                column: "DyeingTBRChemicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe",
                column: "DyeingTBMaterialColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRequestFile_DyeingTBRequestId",
                table: "DyeingTBRequestFile",
                column: "DyeingTBRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRTask_DyeingTBRecipeId",
                table: "DyeingTBRTask",
                column: "DyeingTBRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderTree_ParentId",
                table: "FolderTree",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Formula_Code",
                table: "Formula",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabourSkill_Code",
                table: "LabourSkill",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Light_Code",
                table: "Light",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTemplateItem_ProcessTemplateId",
                table: "ProcessTemplateItem",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeChemical_RecipeTaskId",
                table: "RecipeChemical",
                column: "RecipeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTask_RecipeId",
                table: "RecipeTask",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUnit_Code",
                table: "RecipeUnit",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestArticleInput_RequestArticleOutputId",
                table: "RequestArticleInput",
                column: "RequestArticleOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestArticleOutput_RequestDivisionProcessId",
                table: "RequestArticleOutput",
                column: "RequestDivisionProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivision_RequestId",
                table: "RequestDivision",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivisionFile_RequestDivisionId",
                table: "RequestDivisionFile",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDivisionProcess_RequestDivisionId",
                table: "RequestDivisionProcess",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestType_Code",
                table: "RequestType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingFeatureId",
                table: "SewingFeatureBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureBOL_SewingOperationId",
                table: "SewingFeatureBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLib_FolderTreeId",
                table: "SewingFeatureLib",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLibBOL_SewingFeatureLibId",
                table: "SewingFeatureLibBOL",
                column: "SewingFeatureLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLibBOL_SewingOperationLibId",
                table: "SewingFeatureLibBOL",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingMacroId",
                table: "SewingMacroBOL",
                column: "SewingMacroId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroBOL_SewingTaskId",
                table: "SewingMacroBOL",
                column: "SewingTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLib_FolderTreeId",
                table: "SewingMacroLib",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLibBOL_SewingMacroLibId",
                table: "SewingMacroLibBOL",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLibBOL_SewingTaskLibId",
                table: "SewingMacroLibBOL",
                column: "SewingTaskLibId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLib_FolderTreeId",
                table: "SewingOperationLib",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOL_SewingMacroLibId",
                table: "SewingOperationLibBOL",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOL_SewingOperationLibId",
                table: "SewingOperationLibBOL",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOL_SewingTaskLibId",
                table: "SewingOperationLibBOL",
                column: "SewingTaskLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFX_RequestDivisionProcessId",
                table: "SewingOperationWFX",
                column: "RequestDivisionProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId_Version",
                table: "SewingOperationWFXVersion",
                columns: new[] { "SewingOperationWFXId", "Version" },
                unique: true);

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
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId_TMUType",
                table: "SewingSubOperationWFXResult",
                columns: new[] { "SewingSubOperationWFXId", "TMUType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shade_Code",
                table: "Shade",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingArticle_WeavingIEDId",
                table: "WeavingArticle",
                column: "WeavingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBackgrounStyle_Code",
                table: "WeavingBackgrounStyle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingBorderStyle_Code",
                table: "WeavingBorderStyle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingDetailStructure_WeavingArticleId",
                table: "WeavingDetailStructure",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingIED_RequestDivisionId",
                table: "WeavingIED",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappo_WeavingArticleId",
                table: "WeavingRappo",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMark_WeavingRappoId",
                table: "WeavingRappoMark",
                column: "WeavingRappoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_HorizontalYarnId",
                table: "WeavingRappoMatric",
                column: "HorizontalYarnId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_VerticleYarnId",
                table: "WeavingRappoMatric",
                column: "VerticleYarnId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_WeavingRappoId",
                table: "WeavingRappoMatric",
                column: "WeavingRappoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRouting_WeavingArticleId",
                table: "WeavingRouting",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingArticleId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingYarn_WeavingArticleId",
                table: "WeavingYarn",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingYarn_WeavingRappoId",
                table: "WeavingYarn",
                column: "WeavingRappoId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Code",
                table: "Zone",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoIncrement");

            migrationBuilder.DropTable(
                name: "Concentrate");

            migrationBuilder.DropTable(
                name: "DCTemplateDetail");

            migrationBuilder.DropTable(
                name: "DyeingProcessChemical");

            migrationBuilder.DropTable(
                name: "DyeingTBRChemicalValue");

            migrationBuilder.DropTable(
                name: "DyeingTBRequestFile");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropTable(
                name: "FormulaField");

            migrationBuilder.DropTable(
                name: "KnittingBordyType");

            migrationBuilder.DropTable(
                name: "KnittingFeeder");

            migrationBuilder.DropTable(
                name: "KnittingMachineDiameter");

            migrationBuilder.DropTable(
                name: "KnittingShrinkage");

            migrationBuilder.DropTable(
                name: "KnittingType");

            migrationBuilder.DropTable(
                name: "LabourSkill");

            migrationBuilder.DropTable(
                name: "Light");

            migrationBuilder.DropTable(
                name: "ProcessTask");

            migrationBuilder.DropTable(
                name: "ProcessTemplateItem");

            migrationBuilder.DropTable(
                name: "RecipeChemical");

            migrationBuilder.DropTable(
                name: "RecipeUnit");

            migrationBuilder.DropTable(
                name: "RequestArticleInput");

            migrationBuilder.DropTable(
                name: "RequestDivisionFile");

            migrationBuilder.DropTable(
                name: "SewingFeatureBOL");

            migrationBuilder.DropTable(
                name: "SewingFeatureLibBOL");

            migrationBuilder.DropTable(
                name: "SewingMacroBOL");

            migrationBuilder.DropTable(
                name: "SewingMacroLibBOL");

            migrationBuilder.DropTable(
                name: "SewingOperationBOL");

            migrationBuilder.DropTable(
                name: "SewingOperationLibBOL");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXBOL");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXResult");

            migrationBuilder.DropTable(
                name: "Shade");

            migrationBuilder.DropTable(
                name: "WeavingBackgrounStyle");

            migrationBuilder.DropTable(
                name: "WeavingBorderStyle");

            migrationBuilder.DropTable(
                name: "WeavingDetailStructure");

            migrationBuilder.DropTable(
                name: "WeavingRappoMark");

            migrationBuilder.DropTable(
                name: "WeavingRappoMatric");

            migrationBuilder.DropTable(
                name: "WeavingRouting");

            migrationBuilder.DropTable(
                name: "WeavingRusticFabricSpec");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "DCTemplateTask");

            migrationBuilder.DropTable(
                name: "DyeingRouting");

            migrationBuilder.DropTable(
                name: "DyeingTBRChemical");

            migrationBuilder.DropTable(
                name: "ProcessTemplate");

            migrationBuilder.DropTable(
                name: "RecipeTask");

            migrationBuilder.DropTable(
                name: "RequestArticleOutput");

            migrationBuilder.DropTable(
                name: "SewingFeatureLib");

            migrationBuilder.DropTable(
                name: "SewingMacro");

            migrationBuilder.DropTable(
                name: "SewingTask");

            migrationBuilder.DropTable(
                name: "SewingMacroLib");

            migrationBuilder.DropTable(
                name: "SewingOperationLib");

            migrationBuilder.DropTable(
                name: "SewingTaskLib");

            migrationBuilder.DropTable(
                name: "SewingFeature");

            migrationBuilder.DropTable(
                name: "SewingOperation");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFX");

            migrationBuilder.DropTable(
                name: "WeavingYarn");

            migrationBuilder.DropTable(
                name: "DCTemplate");

            migrationBuilder.DropTable(
                name: "DyeingArticle");

            migrationBuilder.DropTable(
                name: "DyeingTBRTask");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "FolderTree");

            migrationBuilder.DropTable(
                name: "SewingOperationWFXVersion");

            migrationBuilder.DropTable(
                name: "WeavingRappo");

            migrationBuilder.DropTable(
                name: "DyeingIED");

            migrationBuilder.DropTable(
                name: "DyeingTBRecipe");

            migrationBuilder.DropTable(
                name: "SewingOperationWFX");

            migrationBuilder.DropTable(
                name: "WeavingArticle");

            migrationBuilder.DropTable(
                name: "DyeingTBMaterialColor");

            migrationBuilder.DropTable(
                name: "RequestDivisionProcess");

            migrationBuilder.DropTable(
                name: "WeavingIED");

            migrationBuilder.DropTable(
                name: "DyeingTBMaterial");

            migrationBuilder.DropTable(
                name: "RequestDivision");

            migrationBuilder.DropTable(
                name: "DyeingTBRequest");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "RequestType");
        }
    }
}
