using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KorisnikSistemaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<Guid>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    TipKorisnikaID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    TipKorisnikaID = table.Column<Guid>(nullable: false),
                    NazivTipa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnika", x => x.TipKorisnikaID);
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "KorisnikID", "Ime", "KorisnickoIme", "Lozinka", "Prezime", "Salt", "TipKorisnikaID" },
                values: new object[] { new Guid("34f11383-cb12-481d-9ff7-2fd458dc7e2b"), "Ivan", "ivan.ilic", "ivanilic123", "Ilic", null, new Guid("e4e52522-1f76-4c03-95d4-011bff472838") });

            migrationBuilder.InsertData(
                table: "TipKorisnika",
                columns: new[] { "TipKorisnikaID", "NazivTipa" },
                values: new object[,]
                {
                    { new Guid("454f563e-3057-4ea7-8f5f-c871249ab128"), "Operater" },
                    { new Guid("65fcb492-d16d-400d-86ae-8c111a662b5c"), "Tehnicki sekretar" },
                    { new Guid("5c3dce22-db15-4e07-ba9e-639ea7052e6e"), "Prva komisija" },
                    { new Guid("acfbe150-40cb-4f3e-9c38-2ad33bf1b0f0"), "Superuser" },
                    { new Guid("1c32413b-218e-4072-904e-4b5eb97002f2"), "Operater nadmetanja" },
                    { new Guid("88b2f64b-1644-479a-b36f-6bfd99727aa8"), "Licitant" },
                    { new Guid("2df591a9-588f-407c-9976-509398712d9d"), "Menadzer" },
                    { new Guid("9ec688a2-c452-4f4b-9d4f-79cd14ecf25f"), "Administrator" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "TipKorisnika");
        }
    }
}
