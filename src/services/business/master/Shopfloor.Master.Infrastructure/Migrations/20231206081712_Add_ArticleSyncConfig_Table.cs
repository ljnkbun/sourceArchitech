using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_ArticleSyncConfig_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleSyncConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSyncConfig", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleSyncConfig");
        }
    }
}
