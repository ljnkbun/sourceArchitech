using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQCType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FourPointSystem_FourPointSystemId",
                table: "Sampling");

            migrationBuilder.DropTable(
                name: "FourPointSystem");

            migrationBuilder.DropIndex(
                name: "IX_Sampling_FourPointSystemId",
                table: "Sampling");

            migrationBuilder.AddColumn<int>(
                name: "QCTypeId",
                table: "QCDefinition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QCType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCScreenType = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_QCType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_QCTypeId",
                table: "QCDefinition",
                column: "QCTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QCType_Code",
                table: "QCType",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_QCType_QCTypeId",
                table: "QCDefinition",
                column: "QCTypeId",
                principalTable: "QCType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_QCType_QCTypeId",
                table: "QCDefinition");

            migrationBuilder.DropTable(
                name: "QCType");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_QCTypeId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "QCTypeId",
                table: "QCDefinition");

            migrationBuilder.CreateTable(
                name: "FourPointSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourPointSystem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FourPointSystemId",
                table: "Sampling",
                column: "FourPointSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_FourPointSystem_Code",
                table: "FourPointSystem",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FourPointSystem_FourPointSystemId",
                table: "Sampling",
                column: "FourPointSystemId",
                principalTable: "FourPointSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
