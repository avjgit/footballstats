using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class games_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    RefereeId = table.Column<int>(nullable: true),
                    Spectators = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Referee_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Referee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referee_GameId",
                table: "Referee",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefereeId",
                table: "Game",
                column: "RefereeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Game_GameId",
                table: "Referee",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Game_GameId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Referee_GameId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Referee");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
