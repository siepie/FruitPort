using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitPort.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FruitTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FruitTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "FruitStocks",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FruitTypeId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                Action = table.Column<int>(type: "int", nullable: false),
                ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FruitStocks", x => x.Id);
                table.ForeignKey(
                    name: "FK_FruitStocks_FruitTypes_FruitTypeId",
                    column: x => x.FruitTypeId,
                    principalTable: "FruitTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_FruitStocks_FruitTypeId",
            table: "FruitStocks",
            column: "FruitTypeId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FruitStocks");

        migrationBuilder.DropTable(
            name: "FruitTypes");
    }
}
