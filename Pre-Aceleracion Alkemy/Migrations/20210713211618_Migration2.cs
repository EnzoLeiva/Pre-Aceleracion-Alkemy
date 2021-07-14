using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pre_Aceleracion_Alkemy.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "characters");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "characters",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "characters",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_Genders_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "characters",
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                schema: "characters",
                columns: table => new
                {
                    CharactersCharacterID = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersCharacterID, x.MoviesMovieID });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharactersCharacterID",
                        column: x => x.CharactersCharacterID,
                        principalSchema: "characters",
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalSchema: "characters",
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "characters",
                table: "Characters",
                columns: new[] { "CharacterID", "Age", "Image", "Name", "Story", "Weight" },
                values: new object[] { 1, 18, null, "Mickey", null, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesMovieID",
                schema: "characters",
                table: "CharacterMovie",
                column: "MoviesMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenderID",
                schema: "characters",
                table: "Movies",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie",
                schema: "characters");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "characters");

            migrationBuilder.DropTable(
                name: "Movies",
                schema: "characters");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "characters");
        }
    }
}
