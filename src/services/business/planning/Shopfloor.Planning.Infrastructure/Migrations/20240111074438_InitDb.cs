using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapacityColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromRange = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ToRange = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: true),
                    FactoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Standingcapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ActualCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Percent = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryCapacity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryProcessLinePlanning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    FactoryProcessId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProcessLinePlanning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryProcessMachinePlanning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachinePlanningId = table.Column<int>(type: "int", nullable: false),
                    FactoryProcessId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProcessMachinePlanning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningCurveEfficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_LearningCurveEfficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEfficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EfficiencyValue = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEfficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WfxOCId = table.Column<int>(type: "int", nullable: true),
                    OCNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    WfxPORId = table.Column<int>(type: "int", nullable: true),
                    PORNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DivisionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    WfxArticleId = table.Column<int>(type: "int", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BOMId = table.Column<int>(type: "int", nullable: true),
                    BOMNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    OCStatus = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "0"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsAllocated = table.Column<bool>(type: "bit", nullable: false),
                    ProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileEfficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProfileEfficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripEfficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripScheduleId = table.Column<int>(type: "int", nullable: false),
                    EfficiencyValue = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripEfficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningRowId = table.Column<int>(type: "int", nullable: false),
                    ProfileEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    OrderEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    StripEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    LearningCurveEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarWeekDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WorkHours = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ShiftType = table.Column<byte>(type: "tinyint", nullable: true),
                    CalendarConfigId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWeekDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                        column: x => x.CalendarConfigId,
                        principalTable: "CalendarConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningFactory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    FactoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    CalendarConfigId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningFactory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningFactory_CalendarConfig_CalendarConfigId",
                        column: x => x.CalendarConfigId,
                        principalTable: "CalendarConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningCurveDetailEfficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningCurveEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: true),
                    EfficiencyValue = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
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
                    table.PrimaryKey("PK_LearningCurveDetailEfficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningCurveDetailEfficiency_LearningCurveEfficiency_LearningCurveEfficiencyId",
                        column: x => x.LearningCurveEfficiencyId,
                        principalTable: "LearningCurveEfficiency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MergeSplitPOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromPORId = table.Column<int>(type: "int", nullable: true),
                    ToPORId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeSplitPOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeSplitPOR_POR_FromPORId",
                        column: x => x.FromPORId,
                        principalTable: "POR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MergeSplitPOR_POR_ToPORId",
                        column: x => x.ToPORId,
                        principalTable: "POR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PORDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PORId = table.Column<int>(type: "int", nullable: false),
                    UOM = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OrderedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PORDetail_POR_PORId",
                        column: x => x.PORId,
                        principalTable: "POR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileEfficiencyDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileEfficiencyId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    EfficiencyValue = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_ProfileEfficiencyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileEfficiencyDetail_ProfileEfficiency_ProfileEfficiencyId",
                        column: x => x.ProfileEfficiencyId,
                        principalTable: "ProfileEfficiency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StripScheduleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    StandardCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualCapacity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StripScheduleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripScheduleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripScheduleDetail_StripSchedule_StripScheduleId",
                        column: x => x.StripScheduleId,
                        principalTable: "StripSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StripSchedulePOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripScheduleId = table.Column<int>(type: "int", nullable: false),
                    PORDetailId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripSchedulePOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripSchedulePOR_StripSchedule_StripScheduleId",
                        column: x => x.StripScheduleId,
                        principalTable: "StripSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanningRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningFactoryId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    Worker = table.Column<int>(type: "int", nullable: true),
                    MachineHour = table.Column<int>(type: "int", nullable: true),
                    EfficiencyProfileId = table.Column<int>(type: "int", nullable: true),
                    CapacityMachine = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ProfileEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRow_PlanningFactory_PlanningFactoryId",
                        column: x => x.PlanningFactoryId,
                        principalTable: "PlanningFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanningRow_ProfileEfficiency_ProfileEfficiencyId",
                        column: x => x.ProfileEfficiencyId,
                        principalTable: "ProfileEfficiency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripFactory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningFactoryId = table.Column<int>(type: "int", nullable: false),
                    PORId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsPlanning = table.Column<bool>(type: "bit", nullable: true),
                    IsAllocated = table.Column<bool>(type: "bit", nullable: true),
                    StripFactoryStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripFactory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripFactory_PlanningFactory_PlanningFactoryId",
                        column: x => x.PlanningFactoryId,
                        principalTable: "PlanningFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StripScheduleDetailTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripScheduleDetailId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripScheduleDetailTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripScheduleDetailTime_StripScheduleDetail_StripScheduleDetailId",
                        column: x => x.StripScheduleDetailId,
                        principalTable: "StripScheduleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarLeave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningRowId = table.Column<int>(type: "int", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LeaveHourPerDay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarLeave_PlanningRow_PlanningRowId",
                        column: x => x.PlanningRowId,
                        principalTable: "PlanningRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningFactoryId = table.Column<int>(type: "int", nullable: true),
                    PlanningRowId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Monday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Tuesday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Wednesday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Thursday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Friday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Saturday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Sunday = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarRow_PlanningFactory_PlanningFactoryId",
                        column: x => x.PlanningFactoryId,
                        principalTable: "PlanningFactory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarRow_PlanningRow_PlanningRowId",
                        column: x => x.PlanningRowId,
                        principalTable: "PlanningRow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripFactorySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripFactoryId = table.Column<int>(type: "int", nullable: false),
                    StripScheduleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripFactorySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                        column: x => x.StripFactoryId,
                        principalTable: "StripFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StripFactorySchedule_StripSchedule_StripScheduleId",
                        column: x => x.StripScheduleId,
                        principalTable: "StripSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarLeave_PlanningRowId",
                table: "CalendarLeave",
                column: "PlanningRowId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_PlanningFactoryId",
                table: "CalendarRow",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_PlanningRowId",
                table: "CalendarRow",
                column: "PlanningRowId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWeekDay_CalendarConfigId",
                table: "CalendarWeekDay",
                column: "CalendarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningCurveDetailEfficiency_Code",
                table: "LearningCurveDetailEfficiency",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningCurveDetailEfficiency_LearningCurveEfficiencyId",
                table: "LearningCurveDetailEfficiency",
                column: "LearningCurveEfficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningCurveEfficiency_Code",
                table: "LearningCurveEfficiency",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MergeSplitPOR_FromPORId",
                table: "MergeSplitPOR",
                column: "FromPORId");

            migrationBuilder.CreateIndex(
                name: "IX_MergeSplitPOR_ToPORId",
                table: "MergeSplitPOR",
                column: "ToPORId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningFactory_CalendarConfigId",
                table: "PlanningFactory",
                column: "CalendarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRow_PlanningFactoryId",
                table: "PlanningRow",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRow_ProfileEfficiencyId",
                table: "PlanningRow",
                column: "ProfileEfficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PORDetail_PORId",
                table: "PORDetail",
                column: "PORId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEfficiency_Code",
                table: "ProfileEfficiency",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEfficiencyDetail_Code",
                table: "ProfileEfficiencyDetail",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEfficiencyDetail_ProfileEfficiencyId",
                table: "ProfileEfficiencyDetail",
                column: "ProfileEfficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactory_PlanningFactoryId",
                table: "StripFactory",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactorySchedule_StripFactoryId",
                table: "StripFactorySchedule",
                column: "StripFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactorySchedule_StripScheduleId",
                table: "StripFactorySchedule",
                column: "StripScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_StripScheduleDetail_StripScheduleId",
                table: "StripScheduleDetail",
                column: "StripScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_StripScheduleDetailTime_StripScheduleDetailId",
                table: "StripScheduleDetailTime",
                column: "StripScheduleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StripSchedulePOR_StripScheduleId",
                table: "StripSchedulePOR",
                column: "StripScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarLeave");

            migrationBuilder.DropTable(
                name: "CalendarRow");

            migrationBuilder.DropTable(
                name: "CalendarWeekDay");

            migrationBuilder.DropTable(
                name: "CapacityColor");

            migrationBuilder.DropTable(
                name: "FactoryCapacity");

            migrationBuilder.DropTable(
                name: "FactoryProcessLinePlanning");

            migrationBuilder.DropTable(
                name: "FactoryProcessMachinePlanning");

            migrationBuilder.DropTable(
                name: "LearningCurveDetailEfficiency");

            migrationBuilder.DropTable(
                name: "MergeSplitPOR");

            migrationBuilder.DropTable(
                name: "OrderEfficiency");

            migrationBuilder.DropTable(
                name: "PORDetail");

            migrationBuilder.DropTable(
                name: "ProfileEfficiencyDetail");

            migrationBuilder.DropTable(
                name: "StripEfficiency");

            migrationBuilder.DropTable(
                name: "StripFactorySchedule");

            migrationBuilder.DropTable(
                name: "StripScheduleDetailTime");

            migrationBuilder.DropTable(
                name: "StripSchedulePOR");

            migrationBuilder.DropTable(
                name: "PlanningRow");

            migrationBuilder.DropTable(
                name: "LearningCurveEfficiency");

            migrationBuilder.DropTable(
                name: "POR");

            migrationBuilder.DropTable(
                name: "StripFactory");

            migrationBuilder.DropTable(
                name: "StripScheduleDetail");

            migrationBuilder.DropTable(
                name: "ProfileEfficiency");

            migrationBuilder.DropTable(
                name: "PlanningFactory");

            migrationBuilder.DropTable(
                name: "StripSchedule");

            migrationBuilder.DropTable(
                name: "CalendarConfig");
        }
    }
}
