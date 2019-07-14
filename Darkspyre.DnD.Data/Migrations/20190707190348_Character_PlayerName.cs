using Microsoft.EntityFrameworkCore.Migrations;

namespace Darkspyre.DnD.Data.Migrations
{
    public partial class Character_PlayerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "PlayerCharacters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "PlayerCharacters");
        }
    }
}
