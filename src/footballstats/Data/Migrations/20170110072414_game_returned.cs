using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class game_returned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vieta",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpeleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Game_SpeleId",
                        column: x => x.SpeleId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Game",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefereeId",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Spectators",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Referee_GameId",
                table: "Referee",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RefereeId",
                table: "Game",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_SpeleId",
                table: "Record",
                column: "SpeleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Referee_RefereeId",
                table: "Game",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Game_Referee_RefereeId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Game_GameId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Referee_GameId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Game_RefereeId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "RefereeId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Spectators",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.AddColumn<string>(
                name: "Vieta",
                table: "Game",
                nullable: true);
        }
    }
}
