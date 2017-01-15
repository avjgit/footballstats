using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace footballstats.Data.Migrations
{
    public partial class domain_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoalsLost = table.Column<int>(nullable: false),
                    GoalsWon = table.Column<int>(nullable: false),
                    LossesDuringAddedTime = table.Column<int>(nullable: false),
                    LossesDuringMainTime = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    WinsDuringAddedTime = table.Column<int>(nullable: false),
                    WinsDuringMainTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainTeam", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainTeam");
        }
    }
}
