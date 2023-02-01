using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenceTrace.Migrations
{
    /// <inheritdoc />
    public partial class AddExpProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "ExpenceDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ExpenceDetails");
        }
    }
}
