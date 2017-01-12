using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class goals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PenaltiesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltiesList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PenaltiesListId = table.Column<int>(nullable: true),
                    PlayerNr = table.Column<int>(nullable: false),
                    TimeRecord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalty_PenaltiesList_PenaltiesListId",
                        column: x => x.PenaltiesListId,
                        principalTable: "PenaltiesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "PenaltiesRecordId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_PenaltiesRecordId",
                table: "Team",
                column: "PenaltiesRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId1",
                table: "Player",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_PenaltiesListId",
                table: "Penalty",
                column: "PenaltiesListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId1",
                table: "Player",
                column: "TeamId1",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_PenaltiesList_PenaltiesRecordId",
                table: "Team",
                column: "PenaltiesRecordId",
                principalTable: "PenaltiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId1",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_PenaltiesList_PenaltiesRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_PenaltiesRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId1",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "PenaltiesRecordId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Penalty");

            migrationBuilder.DropTable(
                name: "PenaltiesList");
        }
    }
}
