using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicnostService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licnost",
                columns: table => new
                {
                    LicnostID = table.Column<Guid>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Funkcija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licnost", x => x.LicnostID);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ClanID = table.Column<Guid>(nullable: false),
                    LicnostID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ClanID);
                    table.ForeignKey(
                        name: "FK_Clan_Licnost_LicnostID",
                        column: x => x.LicnostID,
                        principalTable: "Licnost",
                        principalColumn: "LicnostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predsednik",
                columns: table => new
                {
                    PredsednikID = table.Column<Guid>(nullable: false),
                    LicnostID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predsednik", x => x.PredsednikID);
                    table.ForeignKey(
                        name: "FK_Predsednik_Licnost_LicnostID",
                        column: x => x.LicnostID,
                        principalTable: "Licnost",
                        principalColumn: "LicnostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komisija",
                columns: table => new
                {
                    KomisijaID = table.Column<Guid>(nullable: false),
                    ClanID = table.Column<Guid>(nullable: true),
                    PredsednikID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisija", x => x.KomisijaID);
                    table.ForeignKey(
                        name: "FK_Komisija_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komisija_Predsednik_PredsednikID",
                        column: x => x.PredsednikID,
                        principalTable: "Predsednik",
                        principalColumn: "PredsednikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Licnost",
                columns: new[] { "LicnostID", "Funkcija", "Ime", "Prezime" },
                values: new object[] { new Guid("4a078606-30b2-497e-8650-7330a236e150"), "", "Nemanja", "Sudarski" });

            migrationBuilder.InsertData(
                table: "Licnost",
                columns: new[] { "LicnostID", "Funkcija", "Ime", "Prezime" },
                values: new object[] { new Guid("f45c4d55-00af-4f06-be69-f79e3fa9dcc2"), "", "Sofija", "Bozic" });

            migrationBuilder.InsertData(
                table: "Clan",
                columns: new[] { "ClanID", "LicnostID" },
                values: new object[] { new Guid("17fc842e-54f4-48fe-b189-0fd12d895c9a"), new Guid("4a078606-30b2-497e-8650-7330a236e150") });

            migrationBuilder.InsertData(
                table: "Predsednik",
                columns: new[] { "PredsednikID", "LicnostID" },
                values: new object[] { new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e"), new Guid("f45c4d55-00af-4f06-be69-f79e3fa9dcc2") });

            migrationBuilder.InsertData(
                table: "Komisija",
                columns: new[] { "KomisijaID", "ClanID", "PredsednikID" },
                values: new object[] { new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e"), new Guid("17fc842e-54f4-48fe-b189-0fd12d895c9a"), new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e") });

            migrationBuilder.CreateIndex(
                name: "IX_Clan_LicnostID",
                table: "Clan",
                column: "LicnostID");

            migrationBuilder.CreateIndex(
                name: "IX_Komisija_ClanID",
                table: "Komisija",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Komisija_PredsednikID",
                table: "Komisija",
                column: "PredsednikID");

            migrationBuilder.CreateIndex(
                name: "IX_Predsednik_LicnostID",
                table: "Predsednik",
                column: "LicnostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisija");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Predsednik");

            migrationBuilder.DropTable(
                name: "Licnost");
        }
    }
}
