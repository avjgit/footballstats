using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class referee_configured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uzvards",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Vards",
                table: "Referee");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Referee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Referee");

            migrationBuilder.AddColumn<string>(
                name: "Uzvards",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vards",
                table: "Referee",
                nullable: true);
        }
    }
}
