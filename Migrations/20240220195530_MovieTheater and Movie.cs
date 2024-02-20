using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_film.Migrations
{
    public partial class MovieTheaterandMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieSessions",
                table: "MovieSessions");

            migrationBuilder.DropIndex(
                name: "IX_MovieSessions_MovieID",
                table: "MovieSessions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieSessions");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "MovieSessions",
                newName: "MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "MovieSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieSessions",
                table: "MovieSessions",
                columns: new[] { "MovieId", "MovieTheaterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_Movies_MovieId",
                table: "MovieSessions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_Movies_MovieId",
                table: "MovieSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieSessions",
                table: "MovieSessions");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieSessions",
                newName: "MovieID");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "MovieSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "MovieSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieSessions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieSessions",
                table: "MovieSessions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSessions_MovieID",
                table: "MovieSessions",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_Movies_MovieID",
                table: "MovieSessions",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSessions_MovieTheaters_MovieTheaterId",
                table: "MovieSessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }
    }
}
