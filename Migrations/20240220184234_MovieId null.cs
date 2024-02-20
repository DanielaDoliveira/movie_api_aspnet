using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_film.Migrations
{
    public partial class MovieIdnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
