using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UgovorOZakupuService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<Guid>(nullable: false),
                    ZavodniBrojD = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DatumDonosenja = table.Column<DateTime>(nullable: false),
                    Sablon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Rok",
                columns: table => new
                {
                    RokID = table.Column<Guid>(nullable: false),
                    DatumRokaDospeca = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rok", x => x.RokID);
                });

            migrationBuilder.CreateTable(
                name: "TipGarancije",
                columns: table => new
                {
                    TipGarancijeID = table.Column<Guid>(nullable: false),
                    NazivTipaG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipGarancije", x => x.TipGarancijeID);
                });

            migrationBuilder.CreateTable(
                name: "Ugovor",
                columns: table => new
                {
                    UgovorID = table.Column<Guid>(nullable: false),
                    KorisnikID = table.Column<Guid>(nullable: false),
                    ZavodniBroj = table.Column<string>(nullable: true),
                    DatumZavodjenja = table.Column<DateTime>(nullable: false),
                    RokZaVracanjeZem = table.Column<DateTime>(nullable: false),
                    MestoPotpisivanja = table.Column<string>(nullable: true),
                    DatumPotpisa = table.Column<DateTime>(nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(nullable: true),
                    KupacID = table.Column<Guid>(nullable: true),
                    LicnostID = table.Column<Guid>(nullable: true),
                    DokumentID = table.Column<Guid>(nullable: true),
                    TipGarancijeID = table.Column<Guid>(nullable: true),
                    RokID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovor", x => x.UgovorID);
                });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "DokumentID", "Datum", "DatumDonosenja", "Sablon", "ZavodniBrojD" },
                values: new object[,]
                {
                    { new Guid("6d9bf251-8c70-495f-93bf-ff1e9ad85b88"), new DateTime(2020, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), "Rešenje o obrazovanju stručne komisije za izradu predloga godišnjeg Programa zaštite, uređenja i korišćenja poljoprivrednog zemljišta", "ROO-1/17" },
                    { new Guid("6e5dff7a-ea13-4294-8f95-5f258e32f96f"), new DateTime(2019, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "Rešenje o obrazovanju komisije za davanje mišljenja na godišnji Program zaštite, uređenja i korišćenja poljoprivrednog zemljišta", "ROO-2/17" },
                    { new Guid("38d906b5-f8d5-4775-b0a1-1edee955193f"), new DateTime(2021, 4, 12, 13, 22, 31, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), "Zahtev za davanje saglasnosti na godišnji Program zaštite, uređenja i korišćenja poljoprivrednog zemljišta", "ZDS-5/10" },
                    { new Guid("4a807a16-a73f-4f02-944a-0db26fd2fa5e"), new DateTime(2020, 2, 18, 10, 29, 41, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 1, 12, 44, 51, 0, DateTimeKind.Unspecified), "Program zaštite, uređenja i korišćenja poljopriverednog zemljišta", "PZU-3/11" },
                    { new Guid("f80153c4-322b-4eee-b73f-cd450fa8c1cd"), new DateTime(2020, 9, 12, 15, 12, 11, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 5, 12, 0, 51, 0, DateTimeKind.Unspecified), "Odluka o određivanju nadležnog organa za sprovođenje postupaka davanja poljoprivrednog zemljišta u zakup", "ONO-4/14" },
                    { new Guid("af511cdf-cd94-400a-815e-2bf5b329eff2"), new DateTime(2021, 6, 10, 14, 34, 15, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 5, 13, 2, 50, 0, DateTimeKind.Unspecified), "Rešenje o obrazovanju Komisije za sprovođenje postupaka davanje poljoprivrednog zemljišta u zakup", "ROK-7/19" },
                    { new Guid("cb41cfed-1d43-4f45-8971-a91fd9f144a7"), new DateTime(2022, 1, 30, 11, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 5, 12, 0, 12, 0, DateTimeKind.Unspecified), "Predlog odluke o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini", "POD-7/10" },
                    { new Guid("2f1c2288-8255-4128-aa44-91303617bcb8"), new DateTime(2020, 3, 25, 8, 35, 23, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 15, 13, 11, 23, 0, DateTimeKind.Unspecified), "Odluka o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini", "ONO-4/14" }
                });

            migrationBuilder.InsertData(
                table: "Rok",
                columns: new[] { "RokID", "DatumRokaDospeca" },
                values: new object[] { new Guid("34562293-3bb6-4ef3-922f-f9d7d3c57864"), new DateTime(2021, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TipGarancije",
                columns: new[] { "TipGarancijeID", "NazivTipaG" },
                values: new object[,]
                {
                    { new Guid("8a02b3ef-651c-4893-8c71-8cf5ca4619fe"), "Jemstvo" },
                    { new Guid("d2e52d2e-8c27-49e1-b4e0-4a873a6ca75e"), "Bankarska Garancija" },
                    { new Guid("8d66093b-bffa-4b50-8d94-f1a9dd9a336c"), "Garancija nekretninom" },
                    { new Guid("311eafc9-251d-40ee-835d-d40cedf96caf"), "Žirantska" },
                    { new Guid("14df6d32-8cf8-4516-975d-cbf6f63889ff"), "Uplata gotovinom" }
                });

            migrationBuilder.InsertData(
                table: "Ugovor",
                columns: new[] { "UgovorID", "DatumPotpisa", "DatumZavodjenja", "DokumentID", "JavnoNadmetanjeID", "KorisnikID", "KupacID", "LicnostID", "MestoPotpisivanja", "RokID", "RokZaVracanjeZem", "TipGarancijeID", "ZavodniBroj" },
                values: new object[] { new Guid("0ec914e2-a7a2-4935-ad30-5912fc86fd19"), new DateTime(2022, 1, 23, 14, 20, 57, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 18, 16, 14, 33, 0, DateTimeKind.Unspecified), new Guid("f00355a8-b3dc-4a6f-b4d7-46f4d7d7a9c7"), new Guid("84b3ea4c-e02f-41b1-a1ef-2734ef97abb2"), new Guid("25862727-de11-49c4-aea2-5431db48f0a5"), new Guid("81037b57-d24c-4d85-9649-7fc6ed635a0c"), new Guid("45aed467-8061-4011-bfc6-3bc4d01b65f9"), "Beograd", new Guid("8d6b2975-80bc-4823-9216-66cc6892d29e"), new DateTime(2023, 4, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5c2bfbf-06e0-4a11-9b05-e7940d146016"), "UGV-3/21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Rok");

            migrationBuilder.DropTable(
                name: "TipGarancije");

            migrationBuilder.DropTable(
                name: "Ugovor");
        }
    }
}
