using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminCats",
                columns: table => new
                {
                    AdminCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminCatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatAge = table.Column<int>(type: "int", nullable: false),
                    AdminCatGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatRate = table.Column<int>(type: "int", nullable: false),
                    AdminCatId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminCats", x => x.AdminCatId);
                    table.ForeignKey(
                        name: "FK_adminCats_adminCats_AdminCatId1",
                        column: x => x.AdminCatId1,
                        principalTable: "adminCats",
                        principalColumn: "AdminCatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adminCats_AdminCatId1",
                table: "adminCats",
                column: "AdminCatId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminCats");
        }
    }
}
