﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Migrations
{
    [DbContext(typeof(OvlascenoLiceContext))]
    partial class OvlascenoLiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OvlascenoLiceService.Entities.BrojTable", b =>
                {
                    b.Property<Guid>("BrojTableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Broj_Table")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrojTableID");

                    b.ToTable("BrojTable");

                    b.HasData(
                        new
                        {
                            BrojTableID = new Guid("206a4efa-5389-41a8-a730-4df3842cf7fe"),
                            Broj_Table = "255"
                        },
                        new
                        {
                            BrojTableID = new Guid("0f8c16a6-0503-4871-a454-8ac3f9cb7e07"),
                            Broj_Table = "356"
                        },
                        new
                        {
                            BrojTableID = new Guid("aad4011e-d00a-49c0-ac13-27f485621e7e"),
                            Broj_Table = "143"
                        });
                });

            modelBuilder.Entity("OvlascenoLiceService.Entities.OvlascenoLice", b =>
                {
                    b.Property<Guid>("OvlascenoLiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojPasosa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BrojTableID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrzavaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OvlascenoLiceID");

                    b.HasIndex("BrojTableID");

                    b.ToTable("OvlascenoLice");

                    b.HasData(
                        new
                        {
                            OvlascenoLiceID = new Guid("d041c26e-34c1-4c2d-a9f6-0c0478f3f437"),
                            BrojPasosa = "BP0710",
                            BrojTableID = new Guid("206a4efa-5389-41a8-a730-4df3842cf7fe"),
                            DrzavaID = new Guid("bb9c4ebc-2028-4a83-88d7-04422ab58548"),
                            Ime = "Milos",
                            JMBG = "1007990171500",
                            Prezime = "Jovanovic"
                        });
                });

            modelBuilder.Entity("OvlascenoLiceService.Entities.OvlascenoLice", b =>
                {
                    b.HasOne("OvlascenoLiceService.Entities.BrojTable", "BrojTable")
                        .WithMany("OvlascenoLiceList")
                        .HasForeignKey("BrojTableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
