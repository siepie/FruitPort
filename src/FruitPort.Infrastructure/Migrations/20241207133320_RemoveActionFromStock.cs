using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitPort.Infrastructure.Migrations;

/// <inheritdoc />
public partial class RemoveActionFromStock : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Action",
            table: "FruitStocks");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Action",
            table: "FruitStocks",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }
}
