using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavnoNadmetanjeService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JavnoNadmetanje",
                columns: table => new
                {
                    JavnoNadmetanjeId = table.Column<Guid>(nullable: false),
                    TipJavnogNadmetanjaId = table.Column<Guid>(nullable: false),
                    StatusJavnogNadmetanjaId = table.Column<Guid>(nullable: false),
                    KatastarskaOpstinaId = table.Column<Guid>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    VremePocetka = table.Column<DateTime>(nullable: false),
                    VremeKraja = table.Column<DateTime>(nullable: false),
                    PocetnaCenaHektar = table.Column<int>(nullable: false),
                    Izuzeto = table.Column<bool>(nullable: false),
                    IzlicitiranaCena = table.Column<int>(nullable: false),
                    PeriodZakupa = table.Column<int>(nullable: false),
                    BrojUcesnika = table.Column<int>(nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(nullable: false),
                    Krug = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanje", x => x.JavnoNadmetanjeId);
                });

            migrationBuilder.CreateTable(
                name: "SluzbeniList",
                columns: table => new
                {
                    SluzbeniListId = table.Column<Guid>(nullable: false),
                    Opstina = table.Column<string>(nullable: true),
                    BrojSluzbenogLista = table.Column<string>(nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    JavnoNadmetanjeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SluzbeniList", x => x.SluzbeniListId);
                });

            migrationBuilder.CreateTable(
                name: "StatusJavnogNadmetanja",
                columns: table => new
                {
                    StatusJavnogNadmetanjaId = table.Column<Guid>(nullable: false),
                    NazivStatusaJavnogNadmetanja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusJavnogNadmetanja", x => x.StatusJavnogNadmetanjaId);
                });

            migrationBuilder.CreateTable(
                name: "TipJavnogNadmetanja",
                columns: table => new
                {
                    TipJavnogNadmetanjaId = table.Column<Guid>(nullable: false),
                    NazivTipaJavnogNadmetanja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipJavnogNadmetanja", x => x.TipJavnogNadmetanjaId);
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "JavnoNadmetanjeId", "BrojUcesnika", "Datum", "IzlicitiranaCena", "Izuzeto", "KatastarskaOpstinaId", "Krug", "PeriodZakupa", "PocetnaCenaHektar", "StatusJavnogNadmetanjaId", "TipJavnogNadmetanjaId", "VisinaDopuneDepozita", "VremeKraja", "VremePocetka" },
                values: new object[] { new Guid("1ae8137b-1674-4c91-a4b5-87a133f5dd87"), 15, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8600, false, new Guid("24742b99-32c6-4999-b0a7-757a178f9ee7"), 1, 12, 7000, new Guid("167a01c0-2e68-46a8-b201-3a23e3a20bff"), new Guid("bc679089-e19f-43e4-946f-651ffbdb2afb"), 200, new DateTime(2022, 2, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SluzbeniList",
                columns: new[] { "SluzbeniListId", "BrojSluzbenogLista", "DatumIzdavanja", "JavnoNadmetanjeId", "Opstina" },
                values: new object[] { new Guid("496ac934-a718-43a6-ac7f-8db141478180"), "5/2022", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1ae8137b-1674-4c91-a4b5-87a133f5dd87"), "Bikovo" });

            migrationBuilder.InsertData(
                table: "StatusJavnogNadmetanja",
                columns: new[] { "StatusJavnogNadmetanjaId", "NazivStatusaJavnogNadmetanja" },
                values: new object[,]
                {
                    { new Guid("167a01c0-2e68-46a8-b201-3a23e3a20bff"), "Prvi krug" },
                    { new Guid("f876fbcc-a7d0-49f8-b6ef-9b5a59c44fa0"), "Drugi krug sa starim uslovima" },
                    { new Guid("cb5b3279-811c-4ca4-abaa-69016ba157b6"), "Drugi krug sa novim uslovima" }
                });

            migrationBuilder.InsertData(
                table: "TipJavnogNadmetanja",
                columns: new[] { "TipJavnogNadmetanjaId", "NazivTipaJavnogNadmetanja" },
                values: new object[,]
                {
                    { new Guid("bc679089-e19f-43e4-946f-651ffbdb2afb"), "Javna licitacija" },
                    { new Guid("d7a80343-d802-43d6-b128-79ba8554acd2"), "Otvaranje zatvorenih ponuda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnoNadmetanje");

            migrationBuilder.DropTable(
                name: "SluzbeniList");

            migrationBuilder.DropTable(
                name: "StatusJavnogNadmetanja");

            migrationBuilder.DropTable(
                name: "TipJavnogNadmetanja");
        }
    }
}
