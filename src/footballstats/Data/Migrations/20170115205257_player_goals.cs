using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class player_goals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Passes",
                table: "Player",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Passes",
                table: "Player");
        }
    }
}
