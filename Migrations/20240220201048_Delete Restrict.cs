using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_film.Migrations
{
    public partial class DeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
