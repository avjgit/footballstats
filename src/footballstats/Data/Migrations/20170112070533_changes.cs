using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Change",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeRecordId = table.Column<int>(nullable: true),
                    PlayerIn = table.Column<int>(nullable: false),
                    PlayerOut = table.Column<int>(nullable: false),
                    TimeRecord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Change", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Change_ChangeRecord_ChangeRecordId",
                        column: x => x.ChangeRecordId,
                        principalTable: "ChangeRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "ChangeRecordId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ChangeRecordId",
                table: "Team",
                column: "ChangeRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Change_ChangeRecordId",
                table: "Change",
                column: "ChangeRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_ChangeRecord_ChangeRecordId",
                table: "Team",
                column: "ChangeRecordId",
                principalTable: "ChangeRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_ChangeRecord_ChangeRecordId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ChangeRecordId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ChangeRecordId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Change");

            migrationBuilder.DropTable(
                name: "ChangeRecord");
        }
    }
}
