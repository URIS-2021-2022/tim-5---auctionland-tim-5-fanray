using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZalbaService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RadnjaNaOsnovuZalbe",
                columns: table => new
                {
                    RadnjaNaOsnovuZalbeID = table.Column<Guid>(nullable: false),
                    NazivRadnjeNaOsnovuZalbe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnjaNaOsnovuZalbe", x => x.RadnjaNaOsnovuZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "StatusZalbe",
                columns: table => new
                {
                    StatusZalbeID = table.Column<Guid>(nullable: false),
                    NazivStatusaZalbe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusZalbe", x => x.StatusZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "TipZalbe",
                columns: table => new
                {
                    TipZalbeID = table.Column<Guid>(nullable: false),
                    NazivTipaZalbe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZalbe", x => x.TipZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "Zalba",
                columns: table => new
                {
                    ZalbaID = table.Column<Guid>(nullable: false),
                    Datum_Podnosenja_Zalbe = table.Column<DateTime>(nullable: false),
                    Razlog_Podnosenja_Zalbe = table.Column<string>(nullable: true),
                    Obrazlozenje = table.Column<string>(nullable: true),
                    Datum_Resenja = table.Column<DateTime>(nullable: false),
                    Broj_Resenja = table.Column<int>(nullable: false),
                    Broj_Nadmetanja = table.Column<int>(nullable: false),
                    RadnjaNaOsnovuZalbeID = table.Column<Guid>(nullable: true),
                    StatusZalbeID = table.Column<Guid>(nullable: true),
                    TipZalbeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalba", x => x.ZalbaID);
                });

            migrationBuilder.InsertData(
                table: "RadnjaNaOsnovuZalbe",
                columns: new[] { "RadnjaNaOsnovuZalbeID", "NazivRadnjeNaOsnovuZalbe" },
                values: new object[,]
                {
                    { new Guid("78f43850-ddc4-49ba-b71d-62266a13a164"), "JN ide u drugi krug sa novim uslovima" },
                    { new Guid("f0b093b4-b2ea-45e8-99d4-55e0b2d703b7"), "JN ide u drugi krug sa starim uslovima" },
                    { new Guid("ed7da07e-c1f6-4d4f-882c-d6c4b5118e46"), "JN ne ide u drugi krug" }
                });

            migrationBuilder.InsertData(
                table: "StatusZalbe",
                columns: new[] { "StatusZalbeID", "NazivStatusaZalbe" },
                values: new object[,]
                {
                    { new Guid("567ada34-3b58-4925-9227-7fa1be213f7e"), "Usvojena" },
                    { new Guid("8bb54326-11a9-4f6f-9dca-6afb917ba2bf"), "Odbijena" },
                    { new Guid("c6fb5ac5-eaef-4db2-99a5-84a938972183"), "Otvorena" }
                });

            migrationBuilder.InsertData(
                table: "TipZalbe",
                columns: new[] { "TipZalbeID", "NazivTipaZalbe" },
                values: new object[,]
                {
                    { new Guid("42058551-6a8a-4485-af7f-1124de19e566"), "Žalba na tok javnog nadmetanja" },
                    { new Guid("e3470949-664c-41fc-af1a-6850ff5a7a80"), "Žalba na Odluku o davanju u zakup" },
                    { new Guid("7e82c9ce-c998-40c0-b743-6b9456d3629e"), "Žalba na Odluku o davanju na korišćenje" }
                });

            migrationBuilder.InsertData(
                table: "Zalba",
                columns: new[] { "ZalbaID", "Broj_Nadmetanja", "Broj_Resenja", "Datum_Podnosenja_Zalbe", "Datum_Resenja", "Obrazlozenje", "RadnjaNaOsnovuZalbeID", "Razlog_Podnosenja_Zalbe", "StatusZalbeID", "TipZalbeID" },
                values: new object[] { new Guid("42058551-6a8a-4485-af7f-1124de19e566"), 53, 13, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Neispravno utvređno stanje razgraničenja parcela", new Guid("78f43850-ddc4-49ba-b71d-62266a13a164"), "Bitna povreda odredaba parničnog postupka", new Guid("c6fb5ac5-eaef-4db2-99a5-84a938972183"), new Guid("42058551-6a8a-4485-af7f-1124de19e566") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadnjaNaOsnovuZalbe");

            migrationBuilder.DropTable(
                name: "StatusZalbe");

            migrationBuilder.DropTable(
                name: "TipZalbe");

            migrationBuilder.DropTable(
                name: "Zalba");
        }
    }
}
