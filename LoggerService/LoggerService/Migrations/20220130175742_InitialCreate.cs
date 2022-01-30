using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoggerService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<Guid>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    DatumKreiranja = table.Column<string>(nullable: false),
                    VremeKreiranja = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                });

            migrationBuilder.InsertData(
                table: "Log",
                columns: new[] { "LogID", "DatumKreiranja", "Opis", "VremeKreiranja" },
                values: new object[] { new Guid("d592cc56-f9ec-484d-b082-e8ae655b586c"), "30/01/2022 00:00:00", "Logger je inicijalizovan u bazi podataka", "18:57:42.4842139" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
