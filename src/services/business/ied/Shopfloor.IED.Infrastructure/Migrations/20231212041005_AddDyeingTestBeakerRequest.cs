using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDyeingTestBeakerRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProcess_RecipeLayerVersion_RecipeLayerVersionId",
                table: "RecipeProcess");

            migrationBuilder.DropTable(
                name: "RecipeLayerVersion");

            migrationBuilder.DropTable(
                name: "RecipeRequestFile");

            migrationBuilder.DropTable(
                name: "RecipeLayer");

            migrationBuilder.DropTable(
                name: "RecipeRequest");

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
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
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
                name: "DyeingTBMaterialColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingTBMaterialId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pantone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBMaterial_DyeingTBRequestId",
                table: "DyeingTBMaterial",
                column: "DyeingTBRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBMaterialColor_DyeingTBMaterialId",
                table: "DyeingTBMaterialColor",
                column: "DyeingTBMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRequestFile_DyeingTBRequestId",
                table: "DyeingTBRequestFile",
                column: "DyeingTBRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProcess_DyeingTBMaterialColor_RecipeLayerVersionId",
                table: "RecipeProcess",
                column: "RecipeLayerVersionId",
                principalTable: "DyeingTBMaterialColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProcess_DyeingTBMaterialColor_RecipeLayerVersionId",
                table: "RecipeProcess");

            migrationBuilder.DropTable(
                name: "DyeingTBMaterialColor");

            migrationBuilder.DropTable(
                name: "DyeingTBRequestFile");

            migrationBuilder.DropTable(
                name: "DyeingTBMaterial");

            migrationBuilder.DropTable(
                name: "DyeingTBRequest");

            migrationBuilder.CreateTable(
                name: "RecipeRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fabric = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Implementer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    StyleNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeLayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DoTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RevokedComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeLayer_RecipeRequest_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RecipeRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRequestFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeRequestId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "varchar(50)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRequestFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeRequestFile_RecipeRequest_RecipeRequestId",
                        column: x => x.RecipeRequestId,
                        principalTable: "RecipeRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeLayerVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeLayerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLayerVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeLayerVersion_RecipeLayer_RecipeLayerId",
                        column: x => x.RecipeLayerId,
                        principalTable: "RecipeLayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLayer_RequestId",
                table: "RecipeLayer",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLayerVersion_RecipeLayerId",
                table: "RecipeLayerVersion",
                column: "RecipeLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRequestFile_RecipeRequestId",
                table: "RecipeRequestFile",
                column: "RecipeRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProcess_RecipeLayerVersion_RecipeLayerVersionId",
                table: "RecipeProcess",
                column: "RecipeLayerVersionId",
                principalTable: "RecipeLayerVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
