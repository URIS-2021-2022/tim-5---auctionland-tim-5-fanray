using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UplataService.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataID = table.Column<Guid>(nullable: false),
                    Broj_Racuna = table.Column<int>(nullable: false),
                    Poziv_Na_Broj = table.Column<int>(nullable: false),
                    Iznos = table.Column<int>(nullable: false),
                    Svrha_Uplate = table.Column<string>(nullable: true),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    DatumKursa = table.Column<DateTime>(nullable: false),
                    Valuta = table.Column<string>(nullable: true),
                    Vrednost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataID);
                });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "UplataID", "Broj_Racuna", "DatumKursa", "DatumUplate", "Iznos", "Poziv_Na_Broj", "Svrha_Uplate", "Valuta", "Vrednost" },
                values: new object[] { new Guid("44af7348-2f6c-7763-84c7-0d3ddf556dde"), 289451, new DateTime(2021, 1, 1, 10, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 10, 3, 0, 0, DateTimeKind.Unspecified), 2584, 54185612, "Uplata javnog nadmetanja", "RSD", 2584f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uplata");
        }
    }
}
