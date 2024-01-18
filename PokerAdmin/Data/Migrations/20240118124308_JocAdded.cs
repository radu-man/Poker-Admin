using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokerAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class JocAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Denumire = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joc", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_ClubId",
                table: "Sesiune",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_JocId",
                table: "Sesiune",
                column: "JocId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_OrasId",
                table: "Sesiune",
                column: "OrasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiune_Club_ClubId",
                table: "Sesiune",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiune_Joc_JocId",
                table: "Sesiune",
                column: "JocId",
                principalTable: "Joc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesiune_Oras_OrasId",
                table: "Sesiune",
                column: "OrasId",
                principalTable: "Oras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesiune_Club_ClubId",
                table: "Sesiune");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesiune_Joc_JocId",
                table: "Sesiune");

            migrationBuilder.DropForeignKey(
                name: "FK_Sesiune_Oras_OrasId",
                table: "Sesiune");

            migrationBuilder.DropTable(
                name: "Joc");

            migrationBuilder.DropIndex(
                name: "IX_Sesiune_ClubId",
                table: "Sesiune");

            migrationBuilder.DropIndex(
                name: "IX_Sesiune_JocId",
                table: "Sesiune");

            migrationBuilder.DropIndex(
                name: "IX_Sesiune_OrasId",
                table: "Sesiune");
        }
    }
}
