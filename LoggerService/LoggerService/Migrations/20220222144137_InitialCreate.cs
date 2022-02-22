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
                    Mikroservis = table.Column<string>(nullable: false),
                    Entitet = table.Column<string>(nullable: false),
                    Zahtjev = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<string>(nullable: false),
                    VremeKreiranja = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                });

            migrationBuilder.InsertData(
                table: "Log",
                columns: new[] { "LogID", "DatumKreiranja", "Entitet", "Mikroservis", "Status", "VremeKreiranja", "Zahtjev" },
                values: new object[] { new Guid("d592cc56-f9ec-484d-b082-e8ae655b586c"), "22/02/2022 00:00:00", "Log", "Logger", 201, "15:41:36.7259689", "POST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
