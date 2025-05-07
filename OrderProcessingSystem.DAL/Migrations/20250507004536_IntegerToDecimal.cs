using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IntegerToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isComplete",
                table: "Orders",
                newName: "IsComplete");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountDue",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Orders",
                newName: "isComplete");

            migrationBuilder.AlterColumn<int>(
                name: "AmountDue",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
