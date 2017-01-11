using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Referee_RefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_RefereeId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "RefereeId",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "MainRefereeId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_MainRefereeId",
                table: "Game",
                column: "MainRefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_MainRefereeId",
                table: "Game",
                column: "MainRefereeId",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Referee_MainRefereeId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_MainRefereeId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "MainRefereeId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.AddColumn<int>(
                name: "RefereeId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefereeId",
                table: "Game",
                column: "RefereeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_RefereeId",
                table: "Game",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
