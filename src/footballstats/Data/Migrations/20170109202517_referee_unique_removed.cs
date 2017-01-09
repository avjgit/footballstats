using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace footballstats.Data.Migrations
{
    public partial class referee_unique_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Referee_Vards_Uzvards",
                table: "Referee");

            migrationBuilder.AlterColumn<string>(
                name: "Vards",
                table: "Referee",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uzvards",
                table: "Referee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vards",
                table: "Referee",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uzvards",
                table: "Referee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referee_Vards_Uzvards",
                table: "Referee",
                columns: new[] { "Vards", "Uzvards" },
                unique: true);
        }
    }
}
