using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdresaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    AdresaID = table.Column<Guid>(nullable: false),
                    Ulica = table.Column<string>(nullable: true),
                    Broj = table.Column<string>(nullable: true),
                    Mesto = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false),
                    DrzavaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.AdresaID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<Guid>(nullable: false),
                    NazivDrzave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "AdresaID", "Broj", "DrzavaID", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[] { new Guid("98e5e83e-857f-4930-8b7f-276055d38557"), "5", new Guid("a8d29242-7df3-4bfb-be49-48519f65649b"), "Novi Sad", 21207, "Bulevar Evrope" });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "DrzavaID", "NazivDrzave" },
                values: new object[] { new Guid("a8d29242-7df3-4bfb-be49-48519f65649b"), "Srbija" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
