using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class goals_to_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoalType = table.Column<int>(nullable: false),
                    GoalsListId = table.Column<int>(nullable: true),
                    PlayerNr = table.Column<int>(nullable: false),
                    TimeRecord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_GoalsList_GoalsListId",
                        column: x => x.GoalsListId,
                        principalTable: "GoalsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "GoalsRecordId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "PlayersNr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_GoalsRecordId",
                table: "Team",
                column: "GoalsRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersNr_GoalId",
                table: "PlayersNr",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_GoalsListId",
                table: "Goal",
                column: "GoalsListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersNr_Goal_GoalId",
                table: "PlayersNr",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GoalsList_GoalsRecordId",
                table: "Team",
                column: "GoalsRecordId",
                principalTable: "GoalsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersNr_Goal_GoalId",
                table: "PlayersNr");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GoalsList_GoalsRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_GoalsRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_PlayersNr_GoalId",
                table: "PlayersNr");

            migrationBuilder.DropColumn(
                name: "GoalsRecordId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "PlayersNr");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "GoalsList");
        }
    }
}
