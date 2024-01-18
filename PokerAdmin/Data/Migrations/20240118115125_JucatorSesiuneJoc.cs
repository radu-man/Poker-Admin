using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokerAdmin.Data.Migrations
{
    /// <inheritdoc />
    public partial class JucatorSesiuneJoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jucator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", nullable: false),
                    Prenume = table.Column<string>(type: "TEXT", nullable: false),
                    Porecla = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jucator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sesiune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrasId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true),
                    JocId = table.Column<int>(type: "INTEGER", nullable: true),
                    JucatorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiune_Jucator_JucatorId",
                        column: x => x.JucatorId,
                        principalTable: "Jucator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sesiune_JucatorId",
                table: "Sesiune",
                column: "JucatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesiune");

            migrationBuilder.DropTable(
                name: "Jucator");
        }
    }
}
