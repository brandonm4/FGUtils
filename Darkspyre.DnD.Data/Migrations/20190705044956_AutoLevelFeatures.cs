using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Darkspyre.DnD.Data.Migrations
{
    public partial class AutoLevelFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ScoreImprovement",
                table: "ClassAutoLevel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "ClassAutoLevel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassAutolevelFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Proficiency = table.Column<string>(nullable: true),
                    Special = table.Column<string>(nullable: true),
                    Optional = table.Column<bool>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    SourceAbr = table.Column<string>(nullable: true),
                    ImportDate = table.Column<DateTime>(nullable: false),
                    ImportSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAutolevelFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassAutolevelFeatureModifier",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ClassAutolevelFeatureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAutolevelFeatureModifier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassAutolevelFeatureModifier_ClassAutolevelFeature_ClassAutolevelFeatureId",
                        column: x => x.ClassAutolevelFeatureId,
                        principalTable: "ClassAutolevelFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassAutoLevel_FeatureId",
                table: "ClassAutoLevel",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAutolevelFeatureModifier_ClassAutolevelFeatureId",
                table: "ClassAutolevelFeatureModifier",
                column: "ClassAutolevelFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAutoLevel_ClassAutolevelFeature_FeatureId",
                table: "ClassAutoLevel",
                column: "FeatureId",
                principalTable: "ClassAutolevelFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAutoLevel_ClassAutolevelFeature_FeatureId",
                table: "ClassAutoLevel");

            migrationBuilder.DropTable(
                name: "ClassAutolevelFeatureModifier");

            migrationBuilder.DropTable(
                name: "ClassAutolevelFeature");

            migrationBuilder.DropIndex(
                name: "IX_ClassAutoLevel_FeatureId",
                table: "ClassAutoLevel");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ClassAutoLevel");

            migrationBuilder.AlterColumn<string>(
                name: "ScoreImprovement",
                table: "ClassAutoLevel",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
