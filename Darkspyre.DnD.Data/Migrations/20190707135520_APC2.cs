using Microsoft.EntityFrameworkCore.Migrations;

namespace Darkspyre.DnD.Data.Migrations
{
    public partial class APC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPC_APCId",
                table: "PlayerCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerCharacterAPC",
                table: "PlayerCharacterAPC");

            migrationBuilder.RenameTable(
                name: "PlayerCharacterAPC",
                newName: "PlayerCharacterAPCs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerCharacterAPCs",
                table: "PlayerCharacterAPCs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPCs_APCId",
                table: "PlayerCharacters",
                column: "APCId",
                principalTable: "PlayerCharacterAPCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPCs_APCId",
                table: "PlayerCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerCharacterAPCs",
                table: "PlayerCharacterAPCs");

            migrationBuilder.RenameTable(
                name: "PlayerCharacterAPCs",
                newName: "PlayerCharacterAPC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerCharacterAPC",
                table: "PlayerCharacterAPC",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPC_APCId",
                table: "PlayerCharacters",
                column: "APCId",
                principalTable: "PlayerCharacterAPC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
