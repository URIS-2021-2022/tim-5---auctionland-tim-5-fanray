// <auto-generated />
using System;
using KorisnikSistemaService.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KorisnikSistemaService.Migrations
{
    [DbContext(typeof(KorisnikContext))]
    [Migration("20220221154854_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("TipKorisnikaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KorisnikID");

                    b.HasIndex("TipKorisnikaID");

                    b.ToTable("Korisnik");

                    b.HasData(
                        new
                        {
                            KorisnikID = new Guid("34f11383-cb12-481d-9ff7-2fd458dc7e2b"),
                            Ime = "Tamara",
                            KorisnickoIme = "tamaraR",
                            Lozinka = "IqXLp0SHh6vgO13/zoIYARufDn7KKd6P/I4GryashMHgtzs8KnkRTZ6wwtBgMcdGB55ZMhQZk5ZMoWRjdzBraEIH/o5bPFSBqZwqLKlnIriKDnT+uCpoAZVbfR59UteqktqPYUsmcQb3EvYu2duhvVI1tcyrR3hdk+YLyr4sz1HbNjLmgexyM+3DMCypPrzHeeW8GSk9O6tOrsqjBiMsLVDSpiDJcToqVC/cXMWzXEpMHIivPJQs5VcI0DW12br7RaVV/xGXCBpLivEPjvJgADZdmwDukDBMkUsYeiQYOWicpNs32nYo85OhiDI/UyxhlvpATEUOblZq4VU4gO4JaA==",
                            Prezime = "Radulovic",
                            Salt = "pO0aEPLIZvtJ",
                            TipKorisnikaID = new Guid("acfbe150-40cb-4f3e-9c38-2ad33bf1b0f0")
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

            modelBuilder.Entity("KorisnikSistemaService.Entites.Korisnik", b =>
                {
                    b.HasOne("KorisnikSistemaService.Entites.TipKorisnika", "TipKorisnika")
                        .WithMany("KorisnikList")
                        .HasForeignKey("TipKorisnikaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
