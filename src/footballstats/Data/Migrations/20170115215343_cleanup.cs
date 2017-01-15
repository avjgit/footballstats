using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Change_Game_GameId",
                table: "Change");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Game_GameId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Game_GameId",
                table: "Penalty");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Penalty_GameId",
                table: "Penalty");

            migrationBuilder.DropIndex(
                name: "IX_Goal_GameId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Change_GameId",
                table: "Change");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Change");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Penalty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Goal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Change",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_GameId",
                table: "Penalty",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_GameId",
                table: "Goal",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Change_GameId",
                table: "Change",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Change_Game_GameId",
                table: "Change",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Game_GameId",
                table: "Goal",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalty_Game_GameId",
                table: "Penalty",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
