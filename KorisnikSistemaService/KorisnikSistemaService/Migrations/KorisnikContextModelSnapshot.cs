﻿// <auto-generated />
using System;
using KorisnikSistemaService.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KorisnikSistemaService.Migrations
{
    [DbContext(typeof(KorisnikContext))]
    partial class KorisnikContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KorisnikSistemaService.Entites.Korisnik", b =>
                {
                    b.Property<Guid>("KorisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TipKorisnikaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KorisnikID");

                    b.ToTable("Korisnik");

                    b.HasData(
                        new
                        {
                            KorisnikID = new Guid("34f11383-cb12-481d-9ff7-2fd458dc7e2b"),
                            Ime = "Tamara",
                            KorisnickoIme = "tamaraR",
                            Lozinka = "nhYpLzd/fTb2vxFYx+gABPbPeg+WWAoerw9Dlbb4jLbryFo7ibG+BB5n3G8Lqj5UHktQdep5sPQiBKEsoNIgx6eMtvA9P4QuwYb5NnJNI6e2hIVrptZYg04S62EgjKoudeBEQHpg5IInSZyixKD7/MyqbTv4YZdYnG/Uk3WIPwL5efURsvd+KO026fpsrx2C/ulFqfis2NM8lYyYpVJ7/ehqYhP3sQA6131tywYj+g/iwWLAjg/GwUbmc+KZh0FioXf9RctJD1I9+qsxKXBIEEepMc1CmzQVina+Rz9SsmZINSm38ssyeEi4AI9XXukw+k9NYYXxfD6nKihH5pv5+A==",
                            Prezime = "Radulovic",
                            Salt = "12+Dquh+FAKw",
                            TipKorisnikaID = new Guid("e4e52522-1f76-4c03-95d4-011bff472838")
                        });
                });

            modelBuilder.Entity("KorisnikSistemaService.Entites.TipKorisnika", b =>
                {
                    b.Property<Guid>("TipKorisnikaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivTipa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipKorisnikaID");

                    b.ToTable("TipKorisnika");

                    b.HasData(
                        new
                        {
                            TipKorisnikaID = new Guid("454f563e-3057-4ea7-8f5f-c871249ab128"),
                            NazivTipa = "Operater"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("65fcb492-d16d-400d-86ae-8c111a662b5c"),
                            NazivTipa = "Tehnicki sekretar"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("5c3dce22-db15-4e07-ba9e-639ea7052e6e"),
                            NazivTipa = "Prva komisija"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("acfbe150-40cb-4f3e-9c38-2ad33bf1b0f0"),
                            NazivTipa = "Superuser"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("1c32413b-218e-4072-904e-4b5eb97002f2"),
                            NazivTipa = "Operater nadmetanja"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("88b2f64b-1644-479a-b36f-6bfd99727aa8"),
                            NazivTipa = "Licitant"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("2df591a9-588f-407c-9976-509398712d9d"),
                            NazivTipa = "Menadzer"
                        },
                        new
                        {
                            TipKorisnikaID = new Guid("9ec688a2-c452-4f4b-9d4f-79cd14ecf25f"),
                            NazivTipa = "Administrator"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
