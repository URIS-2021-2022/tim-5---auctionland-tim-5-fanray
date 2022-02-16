using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(nullable: false),
                    PrioritetId = table.Column<Guid>(nullable: true),
                    OstvarenaPovrsina = table.Column<string>(nullable: true),
                    OvlascenoLiceId = table.Column<Guid>(nullable: true),
                    ImaZabranu = table.Column<bool>(nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(nullable: false),
                    DatumTrajanjaZabrane = table.Column<string>(nullable: true),
                    DatumPrestankaZabrane = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacId);
                });

            migrationBuilder.CreateTable(
                name: "Najbolji_Ponudjac",
                columns: table => new
                {
                    NajboljiPonudjacId = table.Column<Guid>(nullable: false),
                    KupacId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Najbolji_Ponudjac", x => x.NajboljiPonudjacId);
                });

            migrationBuilder.CreateTable(
                name: "Prijavljen_Kupac",
                columns: table => new
                {
                    PrijavljenKupacId = table.Column<Guid>(nullable: false),
                    KupacId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijavljen_Kupac", x => x.PrijavljenKupacId);
                });

            migrationBuilder.CreateTable(
                name: "Prioritet",
                columns: table => new
                {
                    PrioritetId = table.Column<Guid>(nullable: false),
                    NazivPrioriteta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioritet", x => x.PrioritetId);
                });

            migrationBuilder.InsertData(
                table: "Kupac",
                columns: new[] { "KupacId", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DatumTrajanjaZabrane", "ImaZabranu", "OstvarenaPovrsina", "OvlascenoLiceId", "PrioritetId" },
                values: new object[] { new Guid("a35d8ec7-4cea-42ec-859e-5c012476ced0"), new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "1 godinu", true, "200m2", new Guid("148805f4-3093-4fd3-aea1-f253038b3c8f"), new Guid("608ed376-c4bb-4bdd-84cb-f34147ca96df") });

            migrationBuilder.InsertData(
                table: "Najbolji_Ponudjac",
                columns: new[] { "NajboljiPonudjacId", "KupacId" },
                values: new object[] { new Guid("c566ecfd-a27d-4a0b-8032-66fc24754929"), new Guid("a35d8ec7-4cea-42ec-859e-5c012476ced0") });

            migrationBuilder.InsertData(
                table: "Prijavljen_Kupac",
                columns: new[] { "PrijavljenKupacId", "KupacId" },
                values: new object[] { new Guid("1a1bdf95-8ee1-4998-a78c-360039502626"), new Guid("a35d8ec7-4cea-42ec-859e-5c012476ced0") });

            migrationBuilder.InsertData(
                table: "Prioritet",
                columns: new[] { "PrioritetId", "NazivPrioriteta" },
                values: new object[] { new Guid("20e00a61-9e6a-4d6b-9df0-0b85e645849d"), "Prioritet1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Najbolji_Ponudjac");

            migrationBuilder.DropTable(
                name: "Prijavljen_Kupac");

            migrationBuilder.DropTable(
                name: "Prioritet");
        }
    }
}
