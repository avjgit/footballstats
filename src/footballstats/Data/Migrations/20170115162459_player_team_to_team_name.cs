using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class player_team_to_team_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Player",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "Player");
        }
    }
}
