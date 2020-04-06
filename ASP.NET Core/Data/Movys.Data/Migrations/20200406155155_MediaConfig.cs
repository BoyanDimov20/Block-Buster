using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class MediaConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaLinks_CastMembers_CastMemberId",
                table: "MediaLinks");

            migrationBuilder.DropIndex(
                name: "IX_MediaLinks_CastMemberId",
                table: "MediaLinks");

            migrationBuilder.DropColumn(
                name: "CastMemberId",
                table: "MediaLinks");

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "MediaLinks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MediaLinks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaLinks_MovieId",
                table: "MediaLinks",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaLinks_Movies_MovieId",
                table: "MediaLinks",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaLinks_Movies_MovieId",
                table: "MediaLinks");

            migrationBuilder.DropIndex(
                name: "IX_MediaLinks_MovieId",
                table: "MediaLinks");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MediaLinks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MediaLinks");

            migrationBuilder.AddColumn<string>(
                name: "CastMemberId",
                table: "MediaLinks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaLinks_CastMemberId",
                table: "MediaLinks",
                column: "CastMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaLinks_CastMembers_CastMemberId",
                table: "MediaLinks",
                column: "CastMemberId",
                principalTable: "CastMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
