using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catblog.Migrations
{
    /// <inheritdoc />
    public partial class hihi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Files",
                table: "Kitty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitty",
                table: "Kitty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FileToDatabaseDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdminCatID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KittyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabaseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileToDatabaseDto_Kitty_KittyId",
                        column: x => x.KittyId,
                        principalTable: "Kitty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabase_AdminCatID",
                table: "FileToDatabase",
                column: "AdminCatID");

            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabaseDto_KittyId",
                table: "FileToDatabaseDto",
                column: "KittyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileToDatabase_Kitty_AdminCatID",
                table: "FileToDatabase",
                column: "AdminCatID",
                principalTable: "Kitty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileToDatabase_Kitty_AdminCatID",
                table: "FileToDatabase");

            migrationBuilder.DropTable(
                name: "FileToDatabaseDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitty",
                table: "Kitty");

            migrationBuilder.DropIndex(
                name: "IX_FileToDatabase_AdminCatID",
                table: "FileToDatabase");

            migrationBuilder.AlterColumn<string>(
                name: "Files",
                table: "Kitty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
