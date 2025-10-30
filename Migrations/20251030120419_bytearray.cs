using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class bytearray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitty",
                table: "Kitty");

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "Kitty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "Kitty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitty",
                table: "Kitty",
                column: "Id");
        }
    }
}
