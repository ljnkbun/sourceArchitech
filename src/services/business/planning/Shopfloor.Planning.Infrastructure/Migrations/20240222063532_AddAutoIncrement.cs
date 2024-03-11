using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileEfficiencyDetail_ProfileEfficiency_ProfileEfficiencyId",
                table: "ProfileEfficiencyDetail");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileEfficiencyDetail_ProfileEfficiency_ProfileEfficiencyId",
                table: "ProfileEfficiencyDetail",
                column: "ProfileEfficiencyId",
                principalTable: "ProfileEfficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileEfficiencyDetail_ProfileEfficiency_ProfileEfficiencyId",
                table: "ProfileEfficiencyDetail");

            migrationBuilder.DropTable(
                name: "AutoIncrement");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileEfficiencyDetail_ProfileEfficiency_ProfileEfficiencyId",
                table: "ProfileEfficiencyDetail",
                column: "ProfileEfficiencyId",
                principalTable: "ProfileEfficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
