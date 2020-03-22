using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class AddMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCastMember_CastMembers_CastMemberId",
                table: "MoviesCastMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCastMember_Movies_MovieId",
                table: "MoviesCastMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieUsers_Movies_MovieId",
                table: "MovieUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieUsers_AspNetUsers_UserId",
                table: "MovieUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowsCastMember_CastMembers_CastMemberId",
                table: "TVShowsCastMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowsCastMember_TVShows_TVShowId",
                table: "TVShowsCastMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TVShowsCastMember",
                table: "TVShowsCastMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieUsers",
                table: "MovieUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesCastMember",
                table: "MoviesCastMember");

            migrationBuilder.RenameTable(
                name: "TVShowsCastMember",
                newName: "TVShowsCastMembers");

            migrationBuilder.RenameTable(
                name: "MovieUsers",
                newName: "MoviesUsers");

            migrationBuilder.RenameTable(
                name: "MoviesCastMember",
                newName: "MoviesCastMembers");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowsCastMember_TVShowId",
                table: "TVShowsCastMembers",
                newName: "IX_TVShowsCastMembers_TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieUsers_UserId",
                table: "MoviesUsers",
                newName: "IX_MoviesUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesCastMember_MovieId",
                table: "MoviesCastMembers",
                newName: "IX_MoviesCastMembers_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TVShowsCastMembers",
                table: "TVShowsCastMembers",
                columns: new[] { "CastMemberId", "TVShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesUsers",
                table: "MoviesUsers",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesCastMembers",
                table: "MoviesCastMembers",
                columns: new[] { "CastMemberId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCastMembers_CastMembers_CastMemberId",
                table: "MoviesCastMembers",
                column: "CastMemberId",
                principalTable: "CastMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCastMembers_Movies_MovieId",
                table: "MoviesCastMembers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowsCastMembers_CastMembers_CastMemberId",
                table: "TVShowsCastMembers",
                column: "CastMemberId",
                principalTable: "CastMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowsCastMembers_TVShows_TVShowId",
                table: "TVShowsCastMembers",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCastMembers_CastMembers_CastMemberId",
                table: "MoviesCastMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCastMembers_Movies_MovieId",
                table: "MoviesCastMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesUsers_Movies_MovieId",
                table: "MoviesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesUsers_AspNetUsers_UserId",
                table: "MoviesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowsCastMembers_CastMembers_CastMemberId",
                table: "TVShowsCastMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowsCastMembers_TVShows_TVShowId",
                table: "TVShowsCastMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TVShowsCastMembers",
                table: "TVShowsCastMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesUsers",
                table: "MoviesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesCastMembers",
                table: "MoviesCastMembers");

            migrationBuilder.RenameTable(
                name: "TVShowsCastMembers",
                newName: "TVShowsCastMember");

            migrationBuilder.RenameTable(
                name: "MoviesUsers",
                newName: "MovieUsers");

            migrationBuilder.RenameTable(
                name: "MoviesCastMembers",
                newName: "MoviesCastMember");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowsCastMembers_TVShowId",
                table: "TVShowsCastMember",
                newName: "IX_TVShowsCastMember_TVShowId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesUsers_UserId",
                table: "MovieUsers",
                newName: "IX_MovieUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesCastMembers_MovieId",
                table: "MoviesCastMember",
                newName: "IX_MoviesCastMember_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TVShowsCastMember",
                table: "TVShowsCastMember",
                columns: new[] { "CastMemberId", "TVShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieUsers",
                table: "MovieUsers",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesCastMember",
                table: "MoviesCastMember",
                columns: new[] { "CastMemberId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCastMember_CastMembers_CastMemberId",
                table: "MoviesCastMember",
                column: "CastMemberId",
                principalTable: "CastMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCastMember_Movies_MovieId",
                table: "MoviesCastMember",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieUsers_Movies_MovieId",
                table: "MovieUsers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieUsers_AspNetUsers_UserId",
                table: "MovieUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowsCastMember_CastMembers_CastMemberId",
                table: "TVShowsCastMember",
                column: "CastMemberId",
                principalTable: "CastMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowsCastMember_TVShows_TVShowId",
                table: "TVShowsCastMember",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
