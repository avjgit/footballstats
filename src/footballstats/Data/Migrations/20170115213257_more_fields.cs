using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class more_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AvgPenaltiesPerGame",
                table: "Referee",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Games",
                table: "Referee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Penalties",
                table: "Referee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "AvgGoalsMissed",
                table: "Player",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayedInMainTeam",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinutesPlayed",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalGoalsMissed",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCards",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AverageTimePlayed",
                table: "DomainTeam",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Defendors",
                table: "DomainTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Forwards",
                table: "DomainTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goalkeepers",
                table: "DomainTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PenaltyGoals",
                table: "DomainTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalTimePlayed",
                table: "DomainTeam",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgPenaltiesPerGame",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Games",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Penalties",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "AvgGoalsMissed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "GamesPlayedInMainTeam",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "MinutesPlayed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TotalGoalsMissed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "YellowCards",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "AverageTimePlayed",
                table: "DomainTeam");

            migrationBuilder.DropColumn(
                name: "Defendors",
                table: "DomainTeam");

            migrationBuilder.DropColumn(
                name: "Forwards",
                table: "DomainTeam");

            migrationBuilder.DropColumn(
                name: "Goalkeepers",
                table: "DomainTeam");

            migrationBuilder.DropColumn(
                name: "PenaltyGoals",
                table: "DomainTeam");

            migrationBuilder.DropColumn(
                name: "TotalTimePlayed",
                table: "DomainTeam");
        }
    }
}
