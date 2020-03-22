using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movys.Data.Migrations
{
    public partial class ConfiguredModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastMembers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BornInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    ReleaseYear = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    TrailerUrl = table.Column<string>(nullable: true),
                    ReviewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    ReleaseYear = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    TrailerUrl = table.Column<string>(nullable: true),
                    ReviewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCastMember",
                columns: table => new
                {
                    MovieId = table.Column<string>(nullable: false),
                    CastMemberId = table.Column<string>(nullable: false),
                    RoleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCastMember", x => new { x.CastMemberId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MoviesCastMember_CastMembers_CastMemberId",
                        column: x => x.CastMemberId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviesCastMember_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieUsers",
                columns: table => new
                {
                    MovieId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUsers", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieUsers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TVShowsCastMember",
                columns: table => new
                {
                    TVShowId = table.Column<string>(nullable: false),
                    CastMemberId = table.Column<string>(nullable: false),
                    RoleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowsCastMember", x => new { x.CastMemberId, x.TVShowId });
                    table.ForeignKey(
                        name: "FK_TVShowsCastMember_CastMembers_CastMemberId",
                        column: x => x.CastMemberId,
                        principalTable: "CastMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVShowsCastMember_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastMembers_IsDeleted",
                table: "CastMembers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_IsDeleted",
                table: "Movies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCastMember_MovieId",
                table: "MoviesCastMember",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUsers_UserId",
                table: "MovieUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_IsDeleted",
                table: "TVShows",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowsCastMember_TVShowId",
                table: "TVShowsCastMember",
                column: "TVShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesCastMember");

            migrationBuilder.DropTable(
                name: "MovieUsers");

            migrationBuilder.DropTable(
                name: "TVShowsCastMember");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "CastMembers");

            migrationBuilder.DropTable(
                name: "TVShows");
        }
    }
}
