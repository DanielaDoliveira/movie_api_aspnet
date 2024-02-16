using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_film.Migrations
{
    public partial class MovieTheaterupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_MoviesTheaters_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesTheaters_Addresses_AddressId",
                table: "MoviesTheaters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesTheaters",
                table: "MoviesTheaters");

            migrationBuilder.RenameTable(
                name: "MoviesTheaters",
                newName: "MovieTheaters");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesTheaters_AddressId",
                table: "MovieTheaters",
                newName: "IX_MovieTheaters_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheaters",
                table: "MovieTheaters");

            migrationBuilder.RenameTable(
                name: "MovieTheaters",
                newName: "MoviesTheaters");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTheaters_AddressId",
                table: "MoviesTheaters",
                newName: "IX_MoviesTheaters_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesTheaters",
                table: "MoviesTheaters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_MoviesTheaters_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId",
                principalTable: "MoviesTheaters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesTheaters_Addresses_AddressId",
                table: "MoviesTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
