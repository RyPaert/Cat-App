using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class Cat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "KittyCreateViewModel",
                columns: table => new
                {
                    AdminCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatAge = table.Column<int>(type: "int", nullable: false),
                    AdminCatGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KittyCreateViewModel", x => x.AdminCatId);
                });

            migrationBuilder.CreateTable(
                name: "Kitty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatAge = table.Column<int>(type: "int", nullable: false),
                    AdminCatGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminCatRate = table.Column<int>(type: "int", nullable: false),
                    kittyCreateViewModelAdminCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitty_KittyCreateViewModel_kittyCreateViewModelAdminCatId",
                        column: x => x.kittyCreateViewModelAdminCatId,
                        principalTable: "KittyCreateViewModel",
                        principalColumn: "AdminCatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KittyImageViewModel",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KittyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KittyCreateViewModelAdminCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KittyImageViewModel", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_KittyImageViewModel_KittyCreateViewModel_KittyCreateViewModelAdminCatId",
                        column: x => x.KittyCreateViewModelAdminCatId,
                        principalTable: "KittyCreateViewModel",
                        principalColumn: "AdminCatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitty_kittyCreateViewModelAdminCatId",
                table: "Kitty",
                column: "kittyCreateViewModelAdminCatId");

            migrationBuilder.CreateIndex(
                name: "IX_KittyImageViewModel_KittyCreateViewModelAdminCatId",
                table: "KittyImageViewModel",
                column: "KittyCreateViewModelAdminCatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.DropTable(
                name: "Kitty");

            migrationBuilder.DropTable(
                name: "KittyImageViewModel");

            migrationBuilder.DropTable(
                name: "KittyCreateViewModel");
        }
    }
}
