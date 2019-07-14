using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Darkspyre.DnD.Data.Migrations
{
    public partial class APCEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "APCId",
                table: "PlayerCharacters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerCharacterAPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovementPattern = table.Column<string>(nullable: true),
                    TacticActiveCombat = table.Column<string>(nullable: true),
                    TacticActiveMelee = table.Column<string>(nullable: true),
                    TacticActiveRanged = table.Column<string>(nullable: true),
                    TacticActiveAssist = table.Column<string>(nullable: true),
                    TacticPostCombat = table.Column<string>(nullable: true),
                    TacticActiveExplorationMechanic = table.Column<string>(nullable: true),
                    Compaints = table.Column<string>(nullable: true),
                    IdleHabits = table.Column<string>(nullable: true),
                    GeneralMood = table.Column<string>(nullable: true),
                    GeneralAgreeability = table.Column<string>(nullable: true),
                    SpeechSolutionSuggestion = table.Column<string>(nullable: true),
                    SpeechExploring = table.Column<string>(nullable: true),
                    SpeechStrategy = table.Column<string>(nullable: true),
                    SpeechInCombat = table.Column<string>(nullable: true),
                    SpeechChallengeToNPC = table.Column<string>(nullable: true),
                    SpeechChallengeToPC = table.Column<string>(nullable: true),
                    SpeechThrowAway = table.Column<string>(nullable: true),
                    SpeechRestCamp = table.Column<string>(nullable: true),
                    SpeechRestInside = table.Column<string>(nullable: true),
                    VoteLeanings = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterAPC", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_APCId",
                table: "PlayerCharacters",
                column: "APCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPC_APCId",
                table: "PlayerCharacters",
                column: "APCId",
                principalTable: "PlayerCharacterAPC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCharacters_PlayerCharacterAPC_APCId",
                table: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "PlayerCharacterAPC");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCharacters_APCId",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "APCId",
                table: "PlayerCharacters");
        }
    }
}
