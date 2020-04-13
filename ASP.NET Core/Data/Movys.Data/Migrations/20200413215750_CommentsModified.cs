using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class CommentsModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_NewsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Comments");
        }
    }
}
