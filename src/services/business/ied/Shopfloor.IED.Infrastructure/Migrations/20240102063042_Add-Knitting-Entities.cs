using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKnittingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnittingBordyType");

            migrationBuilder.CreateTable(
                name: "KnittingBodyType",
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
                    table.PrimaryKey("PK_KnittingBodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingIED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_KnittingIED", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnittingIED_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnittingGreige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnittingIEDId = table.Column<int>(type: "int", nullable: false),
                    KnittingBodyTypeId = table.Column<int>(type: "int", nullable: false),
                    KnittingTypeId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WidthLossRate = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGMLossRate = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalDensityLossRate = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensityLossRate = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WrapShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    KnittingShrinkageId = table.Column<int>(type: "int", nullable: false),
                    WeftShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Gauge = table.Column<int>(type: "int", nullable: false),
                    Feeder = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    UsedFeeder = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Needle = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RappoLength = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineDiameter = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightKg = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingGreige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnittingGreige_KnittingBodyType_KnittingBodyTypeId",
                        column: x => x.KnittingBodyTypeId,
                        principalTable: "KnittingBodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnittingGreige_KnittingIED_KnittingIEDId",
                        column: x => x.KnittingIEDId,
                        principalTable: "KnittingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnittingGreige_KnittingShrinkage_KnittingShrinkageId",
                        column: x => x.KnittingShrinkageId,
                        principalTable: "KnittingShrinkage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KnittingGreige_KnittingType_KnittingTypeId",
                        column: x => x.KnittingTypeId,
                        principalTable: "KnittingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnittingRouting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnittingIEDId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    KnittingProcess = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KnittingOperation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MachineTypeId = table.Column<int>(type: "int", nullable: false),
                    MachineTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingRouting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnittingRouting_KnittingIED_KnittingIEDId",
                        column: x => x.KnittingIEDId,
                        principalTable: "KnittingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnittingYarn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnittingIEDId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    YarnId = table.Column<int>(type: "int", nullable: false),
                    YarnName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YarnCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YarnRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ConeQuality = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingYarn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnittingYarn_KnittingIED_KnittingIEDId",
                        column: x => x.KnittingIEDId,
                        principalTable: "KnittingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnittingGreige_KnittingBodyTypeId",
                table: "KnittingGreige",
                column: "KnittingBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingGreige_KnittingIEDId",
                table: "KnittingGreige",
                column: "KnittingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingGreige_KnittingShrinkageId",
                table: "KnittingGreige",
                column: "KnittingShrinkageId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingGreige_KnittingTypeId",
                table: "KnittingGreige",
                column: "KnittingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingIED_RequestDivisionId",
                table: "KnittingIED",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingRouting_KnittingIEDId",
                table: "KnittingRouting",
                column: "KnittingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_KnittingYarn_KnittingIEDId",
                table: "KnittingYarn",
                column: "KnittingIEDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnittingGreige");

            migrationBuilder.DropTable(
                name: "KnittingRouting");

            migrationBuilder.DropTable(
                name: "KnittingYarn");

            migrationBuilder.DropTable(
                name: "KnittingBodyType");

            migrationBuilder.DropTable(
                name: "KnittingIED");

            migrationBuilder.CreateTable(
                name: "KnittingBordyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingBordyType", x => x.Id);
                });
        }
    }
}
