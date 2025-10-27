using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class sdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Create",
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
                    table.PrimaryKey("PK_Create", x => x.Id);
                });

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
                name: "FileToDatabaseDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdminCatID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabaseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileToDatabaseDto_Create_CreateId",
                        column: x => x.CreateId,
                        principalTable: "Create",
                        principalColumn: "Id");
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
                    createId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitty_Create_createId",
                        column: x => x.createId,
                        principalTable: "Create",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabaseDto_CreateId",
                table: "FileToDatabaseDto",
                column: "CreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitty_createId",
                table: "Kitty",
                column: "createId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.DropTable(
                name: "FileToDatabaseDto");

            migrationBuilder.DropTable(
                name: "Kitty");

            migrationBuilder.DropTable(
                name: "Create");
        }
    }
}
