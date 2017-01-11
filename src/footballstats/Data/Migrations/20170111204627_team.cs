using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.CreateTable(
                name: "MainCast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersNr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainCastId = table.Column<int>(nullable: true),
                    Nr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersNr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersNr_MainCast_MainCastId",
                        column: x => x.MainCastId,
                        principalTable: "MainCast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: true),
                    MainCastId = table.Column<int>(nullable: true),
                    PlayersListId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_MainCast_MainCastId",
                        column: x => x.MainCastId,
                        principalTable: "MainCast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_PlayersList_PlayersListId",
                        column: x => x.PlayersListId,
                        principalTable: "PlayersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "PlayersListId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlayersListId",
                table: "Player",
                column: "PlayersListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersNr_MainCastId",
                table: "PlayersNr",
                column: "MainCastId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_GameId",
                table: "Team",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_MainCastId",
                table: "Team",
                column: "MainCastId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayersListId",
                table: "Team",
                column: "PlayersListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_PlayersList_PlayersListId",
                table: "Player",
                column: "PlayersListId",
                principalTable: "PlayersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_PlayersList_PlayersListId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_PlayersListId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PlayersListId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "PlayersNr");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "MainCast");

            migrationBuilder.DropTable(
                name: "PlayersList");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
