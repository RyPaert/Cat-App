using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class cat587 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminCats");

            migrationBuilder.CreateTable(
                name: "FileToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdminCatID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatAge = table.Column<int>(type: "int", nullable: false),
                    AdminCatGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.DropTable(
                name: "Kitties");

            migrationBuilder.CreateTable(
                name: "adminCats",
                columns: table => new
                {
                    AdminCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminCatId1 = table.Column<int>(type: "int", nullable: false),
                    AdminCatAge = table.Column<int>(type: "int", nullable: false),
                    AdminCatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatRate = table.Column<int>(type: "int", nullable: false),
                    AdminCatSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
