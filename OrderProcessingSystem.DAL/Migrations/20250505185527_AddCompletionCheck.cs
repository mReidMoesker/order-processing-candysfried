using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletionCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isComplete",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isComplete",
                table: "Orders");
        }
    }
}
