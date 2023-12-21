using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class tweedemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Geboortedatum",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Geslacht",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefoonnummer",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Geboortedatum",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Geslacht",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Telefoonnummer",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "Gebruikers");
        }
    }
}
