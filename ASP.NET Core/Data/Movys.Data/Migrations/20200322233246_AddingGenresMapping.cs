using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class AddingGenresMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Movies_MovieId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_TVShows_TVShowId",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_MovieId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_TVShowId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GenresMovies",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    MovieId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresMovies", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenresMovies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenresMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenresTVShows",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    TVShowId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresTVShows", x => new { x.GenreId, x.TVShowId });
                    table.ForeignKey(
                        name: "FK_GenresTVShows_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenresTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MovieId",
                table: "GenresMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresTVShows_TVShowId",
                table: "GenresTVShows",
                column: "TVShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "GenresTVShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "Genre",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TVShowId",
                table: "Genre",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieId",
                table: "Genre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_TVShowId",
                table: "Genre",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Movies_MovieId",
                table: "Genre",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_TVShows_TVShowId",
                table: "Genre",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
