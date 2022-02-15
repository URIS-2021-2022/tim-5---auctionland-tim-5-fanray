﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OvlascenoLiceService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrojTable",
                columns: table => new
                {
                    BrojTableID = table.Column<Guid>(nullable: false),
                    Broj_Table = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojTable", x => x.BrojTableID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<Guid>(nullable: false),
                    NazivDrzave = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "OvlascenoLice",
                columns: table => new
                {
                    OvlascenoLiceID = table.Column<Guid>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    BrojPasosa = table.Column<string>(nullable: true),
                    BrojTableID = table.Column<Guid>(nullable: true),
                    DrzavaID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenoLice", x => x.OvlascenoLiceID);
                    table.ForeignKey(
                        name: "FK_OvlascenoLice_BrojTable_BrojTableID",
                        column: x => x.BrojTableID,
                        principalTable: "BrojTable",
                        principalColumn: "BrojTableID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OvlascenoLice_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BrojTable",
                columns: new[] { "BrojTableID", "Broj_Table" },
                values: new object[,]
                {
                    { new Guid("206a4efa-5389-41a8-a730-4df3842cf7fe"), "255" },
                    { new Guid("0f8c16a6-0503-4871-a454-8ac3f9cb7e07"), "356" },
                    { new Guid("aad4011e-d00a-49c0-ac13-27f485621e7e"), "143" }
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "DrzavaID", "NazivDrzave" },
                values: new object[] { new Guid("bb9c4ebc-2028-4a83-88d7-04422ab58548"), "Srbija" });

            migrationBuilder.InsertData(
                table: "OvlascenoLice",
                columns: new[] { "OvlascenoLiceID", "BrojPasosa", "BrojTableID", "DrzavaID", "Ime", "JMBG", "Prezime" },
                values: new object[] { new Guid("d041c26e-34c1-4c2d-a9f6-0c0478f3f437"), "BP0710", new Guid("206a4efa-5389-41a8-a730-4df3842cf7fe"), new Guid("bb9c4ebc-2028-4a83-88d7-04422ab58548"), "Milos", "1007990171500", "Jovanovic" });

            migrationBuilder.CreateIndex(
                name: "IX_OvlascenoLice_BrojTableID",
                table: "OvlascenoLice",
                column: "BrojTableID");

            migrationBuilder.CreateIndex(
                name: "IX_OvlascenoLice_DrzavaID",
                table: "OvlascenoLice",
                column: "DrzavaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvlascenoLice");

            migrationBuilder.DropTable(
                name: "BrojTable");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}