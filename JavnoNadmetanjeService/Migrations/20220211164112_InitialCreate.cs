using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavnoNadmetanjeService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatastarskaOpstina",
                columns: table => new
                {
                    KatastarskaOpstinaId = table.Column<Guid>(nullable: false),
                    NazivKatastarskeOpstine = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskaOpstina", x => x.KatastarskaOpstinaId);
                });

            migrationBuilder.CreateTable(
                name: "StatusJavnogNadmetanja",
                columns: table => new
                {
                    StatusJavnogNadmetanjaId = table.Column<Guid>(nullable: false),
                    NazivStatusaJavnogNadmetanja = table.Column<string>(nullable: false)
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
                    NazivTipaJavnogNadmetanja = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipJavnogNadmetanja", x => x.TipJavnogNadmetanjaId);
                });

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
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_KatastarskaOpstina_KatastarskaOpstinaId",
                        column: x => x.KatastarskaOpstinaId,
                        principalTable: "KatastarskaOpstina",
                        principalColumn: "KatastarskaOpstinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_StatusJavnogNadmetanja_StatusJavnogNadmetanjaId",
                        column: x => x.StatusJavnogNadmetanjaId,
                        principalTable: "StatusJavnogNadmetanja",
                        principalColumn: "StatusJavnogNadmetanjaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_TipJavnogNadmetanja_TipJavnogNadmetanjaId",
                        column: x => x.TipJavnogNadmetanjaId,
                        principalTable: "TipJavnogNadmetanja",
                        principalColumn: "TipJavnogNadmetanjaId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_SluzbeniList_JavnoNadmetanje_JavnoNadmetanjeId",
                        column: x => x.JavnoNadmetanjeId,
                        principalTable: "JavnoNadmetanje",
                        principalColumn: "JavnoNadmetanjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KatastarskaOpstina",
                columns: new[] { "KatastarskaOpstinaId", "NazivKatastarskeOpstine" },
                values: new object[,]
                {
                    { new Guid("7d03a946-40a3-41e8-8feb-dbe9381d2170"), "Čantavir" },
                    { new Guid("5a20c276-5b98-4e24-92b4-0996cb51b293"), "Bački Vinogradi" },
                    { new Guid("24742b99-32c6-4999-b0a7-757a178f9ee7"), "Bikovo" },
                    { new Guid("55c5e423-e70c-452f-a89f-42c412163b76"), "Đuđin" },
                    { new Guid("714f831b-b86b-443d-abf5-f248694a8b2e"), "Žednik" },
                    { new Guid("835bd51d-80e3-4c28-9e34-3951bac861c7"), "Tavankut" },
                    { new Guid("ddc12930-390b-4e16-8c91-b9259d53bf16"), "Bajmok" },
                    { new Guid("a077a57d-6e63-41c8-a944-c93eb938b8f7"), "Donji Grad" },
                    { new Guid("26831746-3efb-48a5-8cd9-9810db3a75f4"), "Stari Grad" },
                    { new Guid("f0152fa7-8abc-43e9-956d-1eff5a4ace62"), "Novi Grad" },
                    { new Guid("870742be-2358-45f2-bb1b-1d4efa6bf9d2"), "Palić" }
                });

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

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "JavnoNadmetanjeId", "BrojUcesnika", "Datum", "IzlicitiranaCena", "Izuzeto", "KatastarskaOpstinaId", "Krug", "PeriodZakupa", "PocetnaCenaHektar", "StatusJavnogNadmetanjaId", "TipJavnogNadmetanjaId", "VisinaDopuneDepozita", "VremeKraja", "VremePocetka" },
                values: new object[] { new Guid("1ae8137b-1674-4c91-a4b5-87a133f5dd87"), 15, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8600, false, new Guid("24742b99-32c6-4999-b0a7-757a178f9ee7"), 1, 12, 7000, new Guid("167a01c0-2e68-46a8-b201-3a23e3a20bff"), new Guid("bc679089-e19f-43e4-946f-651ffbdb2afb"), 200, new DateTime(2022, 2, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SluzbeniList",
                columns: new[] { "SluzbeniListId", "BrojSluzbenogLista", "DatumIzdavanja", "JavnoNadmetanjeId", "Opstina" },
                values: new object[] { new Guid("496ac934-a718-43a6-ac7f-8db141478180"), "5/2022", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1ae8137b-1674-4c91-a4b5-87a133f5dd87"), "Bikovo" });

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_KatastarskaOpstinaId",
                table: "JavnoNadmetanje",
                column: "KatastarskaOpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_StatusJavnogNadmetanjaId",
                table: "JavnoNadmetanje",
                column: "StatusJavnogNadmetanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_TipJavnogNadmetanjaId",
                table: "JavnoNadmetanje",
                column: "TipJavnogNadmetanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_SluzbeniList_JavnoNadmetanjeId",
                table: "SluzbeniList",
                column: "JavnoNadmetanjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SluzbeniList");

            migrationBuilder.DropTable(
                name: "JavnoNadmetanje");

            migrationBuilder.DropTable(
                name: "KatastarskaOpstina");

            migrationBuilder.DropTable(
                name: "StatusJavnogNadmetanja");

            migrationBuilder.DropTable(
                name: "TipJavnogNadmetanja");
        }
    }
}
