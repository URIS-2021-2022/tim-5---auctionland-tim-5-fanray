using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicitacijaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumentacija",
                columns: table => new
                {
                    DokumentacijaID = table.Column<Guid>(nullable: false),
                    NazivDokumentacije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumentacija", x => x.DokumentacijaID);
                });

            migrationBuilder.CreateTable(
                name: "DokumentacijaZaFizickoLice",
                columns: table => new
                {
                    DokumentacijaFlID = table.Column<Guid>(nullable: false),
                    DokumentacijaID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentacijaZaFizickoLice", x => x.DokumentacijaFlID);
                });

            migrationBuilder.CreateTable(
                name: "DokumentacijaZaPravnoLice",
                columns: table => new
                {
                    DokumentacijaPlID = table.Column<Guid>(nullable: false),
                    DokumentacijaID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentacijaZaPravnoLice", x => x.DokumentacijaPlID);
                });

            migrationBuilder.CreateTable(
                name: "Licitacija",
                columns: table => new
                {
                    LicitacijaID = table.Column<Guid>(nullable: false),
                    DokumentacijaID = table.Column<Guid>(nullable: true),
                    Broj = table.Column<int>(nullable: false),
                    Godina = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Ogranicenje = table.Column<string>(nullable: true),
                    KorakCene = table.Column<string>(nullable: true),
                    RokZaPrijavu = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacija", x => x.LicitacijaID);
                });

            migrationBuilder.InsertData(
                table: "Dokumentacija",
                columns: new[] { "DokumentacijaID", "NazivDokumentacije" },
                values: new object[,]
                {
                    { new Guid("f1247d53-334e-433f-84dd-b67a3660a269"), "Dokumentacija1" },
                    { new Guid("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa"), "Dokumentacija2" },
                    { new Guid("4cc35a36-46cc-4115-bc4b-a580e20cd23f"), "Dokumentacija3" },
                    { new Guid("d8695c8d-ce0f-40be-a7b4-82042c223e39"), "Dokumentacija4" }
                });

            migrationBuilder.InsertData(
                table: "DokumentacijaZaFizickoLice",
                columns: new[] { "DokumentacijaFlID", "DokumentacijaID" },
                values: new object[,]
                {
                    { new Guid("050c3e3d-0698-48a3-a1c5-eda9dc448da5"), new Guid("f1247d53-334e-433f-84dd-b67a3660a269") },
                    { new Guid("ee695aa1-7e7b-47d4-9670-541b3537c07e"), new Guid("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa") }
                });

            migrationBuilder.InsertData(
                table: "DokumentacijaZaPravnoLice",
                columns: new[] { "DokumentacijaPlID", "DokumentacijaID" },
                values: new object[,]
                {
                    { new Guid("20e00a61-9e6a-4d6b-9df0-0b85e645849d"), new Guid("4cc35a36-46cc-4115-bc4b-a580e20cd23f") },
                    { new Guid("71ba2ade-8528-4b22-8bd2-2b3bc1ec523c"), new Guid("d8695c8d-ce0f-40be-a7b4-82042c223e39") }
                });

            migrationBuilder.InsertData(
                table: "Licitacija",
                columns: new[] { "LicitacijaID", "Broj", "Datum", "DokumentacijaID", "Godina", "KorakCene", "Ogranicenje", "RokZaPrijavu" },
                values: new object[] { new Guid("50af7348-2f6c-4763-84c7-0d9ddf556dde"), 1, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3465e0f2-a2bd-4ef6-bcda-fa2e71488caa"), 2022, "", "", new DateTime(2020, 12, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumentacija");

            migrationBuilder.DropTable(
                name: "DokumentacijaZaFizickoLice");

            migrationBuilder.DropTable(
                name: "DokumentacijaZaPravnoLice");

            migrationBuilder.DropTable(
                name: "Licitacija");
        }
    }
}
