using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_film.Migrations
{
    public partial class MovieSessionandMovieTheater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "MovieSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieSessions_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_MoviesTheaters_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId",
                principalTable: "MoviesTheaters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_MoviesTheaters_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropIndex(
                name: "IX_MovieSessions_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "MovieSessions");
        }
    }
}
