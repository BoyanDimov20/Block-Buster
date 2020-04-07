using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class MediaTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoverImageUrl",
                table: "MediaLinks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "MediaLinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoverImageUrl",
                table: "MediaLinks");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "MediaLinks");
        }
    }
}
