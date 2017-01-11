using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class renamings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersNr_MainCast_MainCastId",
                table: "PlayersNr");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_MainCast_MainCastId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_PlayersList_PlayersListId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_MainCastId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_PlayersListId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_PlayersNr_MainCastId",
                table: "PlayersNr");

            migrationBuilder.DropColumn(
                name: "MainCastId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "PlayersListId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "MainCastId",
                table: "PlayersNr");

            migrationBuilder.DropTable(
                name: "MainCast");

            migrationBuilder.CreateTable(
                name: "PlayersNrList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersNrList", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "AllPLayersRecordId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainPlayersRecordId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayersNrListId",
                table: "PlayersNr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_AllPLayersRecordId",
                table: "Team",
                column: "AllPLayersRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_MainPlayersRecordId",
                table: "Team",
                column: "MainPlayersRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersNr_PlayersNrListId",
                table: "PlayersNr",
                column: "PlayersNrListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersNr_PlayersNrList_PlayersNrListId",
                table: "PlayersNr",
                column: "PlayersNrListId",
                principalTable: "PlayersNrList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_PlayersList_AllPLayersRecordId",
                table: "Team",
                column: "AllPLayersRecordId",
                principalTable: "PlayersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_PlayersNrList_MainPlayersRecordId",
                table: "Team",
                column: "MainPlayersRecordId",
                principalTable: "PlayersNrList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersNr_PlayersNrList_PlayersNrListId",
                table: "PlayersNr");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_PlayersList_AllPLayersRecordId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_PlayersNrList_MainPlayersRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_AllPLayersRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_MainPlayersRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_PlayersNr_PlayersNrListId",
                table: "PlayersNr");

            migrationBuilder.DropColumn(
                name: "AllPLayersRecordId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "MainPlayersRecordId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "PlayersNrListId",
                table: "PlayersNr");

            migrationBuilder.DropTable(
                name: "PlayersNrList");

            migrationBuilder.CreateTable(
                name: "MainCast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCast", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "MainCastId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayersListId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainCastId",
                table: "PlayersNr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_MainCastId",
                table: "Team",
                column: "MainCastId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayersListId",
                table: "Team",
                column: "PlayersListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersNr_MainCastId",
                table: "PlayersNr",
                column: "MainCastId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersNr_MainCast_MainCastId",
                table: "PlayersNr",
                column: "MainCastId",
                principalTable: "MainCast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_MainCast_MainCastId",
                table: "Team",
                column: "MainCastId",
                principalTable: "MainCast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_PlayersList_PlayersListId",
                table: "Team",
                column: "PlayersListId",
                principalTable: "PlayersList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
