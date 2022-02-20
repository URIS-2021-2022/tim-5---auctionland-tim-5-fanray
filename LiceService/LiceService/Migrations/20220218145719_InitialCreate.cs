using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiceService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FizickoLice",
                columns: table => new
                {
                    LiceID = table.Column<Guid>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickoLice", x => x.LiceID);
                });

            migrationBuilder.CreateTable(
                name: "KontaktOsoba",
                columns: table => new
                {
                    KontaktOsobaID = table.Column<Guid>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Funkcija = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Maticni_Broj = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontaktOsoba", x => x.KontaktOsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Lice",
                columns: table => new
                {
                    LiceID = table.Column<Guid>(nullable: false),
                    Broj_Telefona1 = table.Column<int>(nullable: false),
                    Broj_Telefona2 = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Broj_Racuna = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lice", x => x.LiceID);
                });

            migrationBuilder.CreateTable(
                name: "PravnoLice",
                columns: table => new
                {
                    LiceID = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    MaticniBroj = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravnoLice", x => x.LiceID);
                });

            migrationBuilder.InsertData(
                table: "FizickoLice",
                columns: new[] { "LiceID", "Ime", "JMBG", "Prezime" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "Marko", new Guid("18dca15b-188f-49f9-b4db-ece15575995a"), "Markovic" });

            migrationBuilder.InsertData(
                table: "KontaktOsoba",
                columns: new[] { "KontaktOsobaID", "Funkcija", "Ime", "Maticni_Broj", "Prezime", "Telefon" },
                values: new object[] { new Guid("a43a31f7-ffad-4aff-a199-1a6d31a8b850"), "Generalni direktor", "Petar", new Guid("ffc4407f-68a8-4d74-a48d-17389cc3f01f"), "Petrovic", "0658899471" });

            migrationBuilder.InsertData(
                table: "Lice",
                columns: new[] { "LiceID", "Broj_Racuna", "Broj_Telefona1", "Broj_Telefona2", "Email" },
                values: new object[,]
                {
                    { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), 123456789, 654488522, 654488521, "nekolice@gmail.com" },
                    { new Guid("e7c1316d-5805-4d2b-be96-f764f0247acc"), 987456123, 614188522, 624489521, "nekolice99@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "PravnoLice",
                columns: new[] { "LiceID", "MaticniBroj", "Naziv" },
                values: new object[] { new Guid("e7c1316d-5805-4d2b-be96-f764f0247acc"), new Guid("ffc4407f-68a8-4d74-a48d-17389cc3f01f"), "Firma1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickoLice");

            migrationBuilder.DropTable(
                name: "KontaktOsoba");

            migrationBuilder.DropTable(
                name: "Lice");

            migrationBuilder.DropTable(
                name: "PravnoLice");
        }
    }
}
