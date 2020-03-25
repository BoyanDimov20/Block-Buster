using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class CastMemberConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryBornIn",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullBiography",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleUrl",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "CastMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "CastMembers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaLinks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    CastMemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLinks_CastMembers_CastMemberId",
                        column: x => x.CastMemberId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaLinks_CastMemberId",
                table: "MediaLinks",
                column: "CastMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaLinks");

            migrationBuilder.DropColumn(
                name: "CountryBornIn",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "FullBiography",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "GoogleUrl",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "CastMembers");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "CastMembers");
        }
    }
}
