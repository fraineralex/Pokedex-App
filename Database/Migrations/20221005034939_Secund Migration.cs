using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class SecundMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PrimaryTypeId",
                table: "Pokemons",
                column: "PrimaryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_PokemonTypes_PrimaryTypeId",
                table: "Pokemons",
                column: "PrimaryTypeId",
                principalTable: "PokemonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_PokemonTypes_PrimaryTypeId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_PrimaryTypeId",
                table: "Pokemons");
        }
    }
}
