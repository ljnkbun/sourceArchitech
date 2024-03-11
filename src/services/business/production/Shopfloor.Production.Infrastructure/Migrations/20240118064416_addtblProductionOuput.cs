using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtblProductionOuput : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCDefinitionId = table.Column<int>(type: "int", nullable: true),
                    FPPOId = table.Column<int>(type: "int", nullable: true),
                    OCNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FPPONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Group = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Line = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperationName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdateToDate = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FRUpdateToDate = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FRBalance = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Strip = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    End = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    InputDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOutput", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionOutput");
        }
    }
}
