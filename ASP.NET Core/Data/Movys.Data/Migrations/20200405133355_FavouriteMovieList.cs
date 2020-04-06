using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class FavouriteMovieList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesUsers_Movies_MovieId",
                table: "MoviesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesUsers_AspNetUsers_UserId",
                table: "MoviesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesUsers",
                table: "MoviesUsers");

            migrationBuilder.RenameTable(
                name: "MoviesUsers",
                newName: "UsersFavouriteMovies");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesUsers_UserId",
                table: "UsersFavouriteMovies",
                newName: "IX_UsersFavouriteMovies_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFavouriteMovies",
                table: "UsersFavouriteMovies",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavouriteMovies_Movies_MovieId",
                table: "UsersFavouriteMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavouriteMovies_AspNetUsers_UserId",
                table: "UsersFavouriteMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavouriteMovies_Movies_MovieId",
                table: "UsersFavouriteMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavouriteMovies_AspNetUsers_UserId",
                table: "UsersFavouriteMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFavouriteMovies",
                table: "UsersFavouriteMovies");

            migrationBuilder.RenameTable(
                name: "UsersFavouriteMovies",
                newName: "MoviesUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UsersFavouriteMovies_UserId",
                table: "MoviesUsers",
                newName: "IX_MoviesUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesUsers",
                table: "MoviesUsers",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesUsers_Movies_MovieId",
                table: "MoviesUsers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesUsers_AspNetUsers_UserId",
                table: "MoviesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
