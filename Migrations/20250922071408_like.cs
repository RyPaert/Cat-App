using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class like : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Cats");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Cats");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Cats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
