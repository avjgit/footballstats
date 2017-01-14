using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class new_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId1",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId1",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Penalty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Penalty",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Penalty",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Goal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Goal",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Goal",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Change",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerIn_Id",
                table: "Change",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerOut_Id",
                table: "Change",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Change",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GoalId",
                table: "Player",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_GameId",
                table: "Penalty",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_PlayerId",
                table: "Penalty",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_GameId",
                table: "Goal",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PlayerId",
                table: "Goal",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Change_GameId",
                table: "Change",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Change_PlayerIn_Id",
                table: "Change",
                column: "PlayerIn_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Change_PlayerOut_Id",
                table: "Change",
                column: "PlayerOut_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Change_Game_GameId",
                table: "Change",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Change_Player_PlayerIn_Id",
                table: "Change",
                column: "PlayerIn_Id",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Change_Player_PlayerOut_Id",
                table: "Change",
                column: "PlayerOut_Id",
                principalTable: "Player",
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
                name: "FK_Goal_Player_PlayerId",
                table: "Goal",
                column: "PlayerId",
                principalTable: "Player",
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
                name: "FK_Penalty_Player_PlayerId",
                table: "Penalty",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Goal_GoalId",
                table: "Player",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Change_Game_GameId",
                table: "Change");

            migrationBuilder.DropForeignKey(
                name: "FK_Change_Player_PlayerIn_Id",
                table: "Change");

            migrationBuilder.DropForeignKey(
                name: "FK_Change_Player_PlayerOut_Id",
                table: "Change");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Game_GameId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Player_PlayerId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Game_GameId",
                table: "Penalty");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalty_Player_PlayerId",
                table: "Penalty");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_GameId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Goal_GoalId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_GoalId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Penalty_GameId",
                table: "Penalty");

            migrationBuilder.DropIndex(
                name: "IX_Penalty_PlayerId",
                table: "Penalty");

            migrationBuilder.DropIndex(
                name: "IX_Goal_GameId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Goal_PlayerId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Change_GameId",
                table: "Change");

            migrationBuilder.DropIndex(
                name: "IX_Change_PlayerIn_Id",
                table: "Change");

            migrationBuilder.DropIndex(
                name: "IX_Change_PlayerOut_Id",
                table: "Change");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Change");

            migrationBuilder.DropColumn(
                name: "PlayerIn_Id",
                table: "Change");

            migrationBuilder.DropColumn(
                name: "PlayerOut_Id",
                table: "Change");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Change");

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId1",
                table: "Player",
                column: "TeamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId1",
                table: "Player",
                column: "TeamId1",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
