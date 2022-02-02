﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParcelaService.Entities;

namespace ParcelaService.Migrations
{
    [DbContext(typeof(ParcelaContext))]
    [Migration("20220130142454_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParcelaService.Entities.DeoParcele", b =>
                {
                    b.Property<Guid>("DeoParceleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivDelaParcele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParcelaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DeoParceleID");

                    b.HasIndex("ParcelaID");

                    b.ToTable("DeoParcele");

                    b.HasData(
                        new
                        {
                            DeoParceleID = new Guid("bdafb306-0e28-4dd3-ad97-14532d86552c"),
                            NazivDelaParcele = "Pored puta",
                            ParcelaID = new Guid("ae463837-b971-4354-9f40-92cc819edf25")
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.KatastarskaOpstina", b =>
                {
                    b.Property<Guid>("KatastarskaOpstinaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivKatastarskeOpstine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KatastarskaOpstinaID");

                    b.ToTable("KatastarskaOpstina");

                    b.HasData(
                        new
                        {
                            KatastarskaOpstinaID = new Guid("7d03a946-40a3-41e8-8feb-dbe9381d2170"),
                            NazivKatastarskeOpstine = "Čantavir"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("5a20c276-5b98-4e24-92b4-0996cb51b293"),
                            NazivKatastarskeOpstine = "Bački Vinogradi"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("24742b99-32c6-4999-b0a7-757a178f9ee7"),
                            NazivKatastarskeOpstine = "Bikovo"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("55c5e423-e70c-452f-a89f-42c412163b76"),
                            NazivKatastarskeOpstine = "Đuđin"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("714f831b-b86b-443d-abf5-f248694a8b2e"),
                            NazivKatastarskeOpstine = "Žednik"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("835bd51d-80e3-4c28-9e34-3951bac861c7"),
                            NazivKatastarskeOpstine = "Tavankut"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("ddc12930-390b-4e16-8c91-b9259d53bf16"),
                            NazivKatastarskeOpstine = "Bajmok"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("a077a57d-6e63-41c8-a944-c93eb938b8f7"),
                            NazivKatastarskeOpstine = "Donji Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("26831746-3efb-48a5-8cd9-9810db3a75f4"),
                            NazivKatastarskeOpstine = "Stari Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("f0152fa7-8abc-43e9-956d-1eff5a4ace62"),
                            NazivKatastarskeOpstine = "Novi Grad"
                        },
                        new
                        {
                            KatastarskaOpstinaID = new Guid("870742be-2358-45f2-bb1b-1d4efa6bf9d2"),
                            NazivKatastarskeOpstine = "Palić"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.Klasa", b =>
                {
                    b.Property<Guid>("KlasaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivKlase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlasaID");

                    b.ToTable("Klasa");

                    b.HasData(
                        new
                        {
                            KlasaID = new Guid("5c3ad689-4409-4e4d-8e93-fd452776c770"),
                            NazivKlase = "I"
                        },
                        new
                        {
                            KlasaID = new Guid("5af4b60e-1aaa-46c8-a4a0-550e602e633a"),
                            NazivKlase = "II"
                        },
                        new
                        {
                            KlasaID = new Guid("7cfbb7c4-6a83-4a69-bc73-5cacca0c01fd"),
                            NazivKlase = "III"
                        },
                        new
                        {
                            KlasaID = new Guid("4a0f4309-15ed-428b-b1a6-67245d316739"),
                            NazivKlase = "IV"
                        },
                        new
                        {
                            KlasaID = new Guid("2c063dc7-fc37-4071-a1be-60f574184909"),
                            NazivKlase = "V"
                        },
                        new
                        {
                            KlasaID = new Guid("480a44e0-dc28-4d2b-8013-96326d0f9982"),
                            NazivKlase = "VI"
                        },
                        new
                        {
                            KlasaID = new Guid("ae9b7c8e-3f80-43b6-bc97-14f50bee4fb7"),
                            NazivKlase = "VII"
                        },
                        new
                        {
                            KlasaID = new Guid("a95ea9b3-4eef-495e-9bcd-3ede006d7609"),
                            NazivKlase = "VIII"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.Kultura", b =>
                {
                    b.Property<Guid>("KulturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivKulture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KulturaID");

                    b.ToTable("Kultura");

                    b.HasData(
                        new
                        {
                            KulturaID = new Guid("562d2838-345b-46e0-977e-b1350199e46b"),
                            NazivKulture = "Njive"
                        },
                        new
                        {
                            KulturaID = new Guid("429b3bd9-c9e4-42e5-a94d-dcf10276756d"),
                            NazivKulture = "Vrtovi"
                        },
                        new
                        {
                            KulturaID = new Guid("c52c698e-ab99-4b69-bd7f-80addbd72e10"),
                            NazivKulture = "Voćnjaci"
                        },
                        new
                        {
                            KulturaID = new Guid("d54ae671-92eb-4892-8579-e91ef4a53f3e"),
                            NazivKulture = "Vinogradi"
                        },
                        new
                        {
                            KulturaID = new Guid("a644ca6e-89c2-4b16-84d8-6f5b76909ad2"),
                            NazivKulture = "Livade"
                        },
                        new
                        {
                            KulturaID = new Guid("101395f3-0ab9-4952-a691-530f14fa443d"),
                            NazivKulture = "Pašnjaci"
                        },
                        new
                        {
                            KulturaID = new Guid("fc963149-30b2-4038-b5f0-bdaff5e332c2"),
                            NazivKulture = "Šume"
                        },
                        new
                        {
                            KulturaID = new Guid("21b610b2-50fd-478e-b649-8d67694618c6"),
                            NazivKulture = "Trstici-močvare"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.OblikSvojine", b =>
                {
                    b.Property<Guid>("OblikSvojineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivOblikaSvojine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OblikSvojineID");

                    b.ToTable("OblikSvojine");

                    b.HasData(
                        new
                        {
                            OblikSvojineID = new Guid("84226e05-ec99-4c6c-827f-f0ccf63a0990"),
                            NazivOblikaSvojine = "Privatna svojina"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("36e7d2b4-188a-4560-8325-c8b591afcce4"),
                            NazivOblikaSvojine = "Državna svojina RS"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("2994163c-e08a-4647-996b-86eda5e0be7a"),
                            NazivOblikaSvojine = "Državna svojina"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("4938990b-fee0-464f-8fa7-835a0d1e71e1"),
                            NazivOblikaSvojine = "Društvena svojina"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("38f76c13-8b55-45f6-bf1a-7adfa9007aba"),
                            NazivOblikaSvojine = "Zadružna svojina"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("cf1e7bd8-2a93-4a08-9768-57e172643630"),
                            NazivOblikaSvojine = "Mešovita svojina"
                        },
                        new
                        {
                            OblikSvojineID = new Guid("718462dc-15e4-4dce-81cf-e150ce5846bd"),
                            NazivOblikaSvojine = "Drugi oblici"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.Obradivost", b =>
                {
                    b.Property<Guid>("ObradivostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivObradivosti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObradivostID");

                    b.ToTable("Obradivost");

                    b.HasData(
                        new
                        {
                            ObradivostID = new Guid("9e1a4745-8838-4130-8662-4337d153a5fd"),
                            NazivObradivosti = "Obradivo"
                        },
                        new
                        {
                            ObradivostID = new Guid("8a8d331a-3553-4de1-a8aa-c4a70e5b7765"),
                            NazivObradivosti = "Ostalo"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.Odvodnjavanje", b =>
                {
                    b.Property<Guid>("OdvodnjavanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivOdvodnjavanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OdvodnjavanjeID");

                    b.ToTable("Odvodnjavanje");

                    b.HasData(
                        new
                        {
                            OdvodnjavanjeID = new Guid("814f8e70-0edf-4cf5-8729-5091f7590b68"),
                            NazivOdvodnjavanja = "Površinsko odvodnjavanje"
                        },
                        new
                        {
                            OdvodnjavanjeID = new Guid("0f18b42e-3451-426d-8720-cdd50110989b"),
                            NazivOdvodnjavanja = "Podzemno odvodnjavanje"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.Parcela", b =>
                {
                    b.Property<Guid>("ParcelaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojListaNepokretnosti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojParcele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KatastarskaOpstinaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KlasaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KlasaStvarnoStanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KorisnikParceleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KulturaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KulturaStvarnoStanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OblikSvojineID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ObradivostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ObradivostStvarnoStanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OdvodnjavanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OdvodnjavanjeStvarnoStanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Povrsina")
                        .HasColumnType("int");

                    b.Property<Guid?>("ZasticenaZonaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZasticenaZonaStvarnoStanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParcelaID");

                    b.HasIndex("KatastarskaOpstinaID");

                    b.HasIndex("KlasaID");

                    b.HasIndex("KulturaID");

                    b.HasIndex("OblikSvojineID");

                    b.HasIndex("ObradivostID");

                    b.HasIndex("OdvodnjavanjeID");

                    b.HasIndex("ZasticenaZonaID");

                    b.ToTable("Parcela");

                    b.HasData(
                        new
                        {
                            ParcelaID = new Guid("ae463837-b971-4354-9f40-92cc819edf25"),
                            BrojListaNepokretnosti = "LN101",
                            BrojParcele = "PC-2601",
                            KatastarskaOpstinaID = new Guid("870742be-2358-45f2-bb1b-1d4efa6bf9d2"),
                            KlasaID = new Guid("5c3ad689-4409-4e4d-8e93-fd452776c770"),
                            KlasaStvarnoStanje = "",
                            KorisnikParceleID = new Guid("efb3be0f-7082-4998-858d-51340d2abbab"),
                            KulturaID = new Guid("a644ca6e-89c2-4b16-84d8-6f5b76909ad2"),
                            KulturaStvarnoStanje = "",
                            OblikSvojineID = new Guid("84226e05-ec99-4c6c-827f-f0ccf63a0990"),
                            ObradivostID = new Guid("9e1a4745-8838-4130-8662-4337d153a5fd"),
                            ObradivostStvarnoStanje = "",
                            OdvodnjavanjeID = new Guid("0f18b42e-3451-426d-8720-cdd50110989b"),
                            OdvodnjavanjeStvarnoStanje = "",
                            Povrsina = 100,
                            ZasticenaZonaID = new Guid("308a9704-2235-4310-9092-9cde4a40164b"),
                            ZasticenaZonaStvarnoStanje = ""
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.ZasticenaZona", b =>
                {
                    b.Property<Guid>("ZasticenaZonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivZasticeneZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZasticenaZonaID");

                    b.ToTable("ZasticenaZona");

                    b.HasData(
                        new
                        {
                            ZasticenaZonaID = new Guid("70c4f5fe-694f-4879-84ca-de5744bbd967"),
                            NazivZasticeneZone = "1"
                        },
                        new
                        {
                            ZasticenaZonaID = new Guid("7801b5f4-63ef-4990-b039-efa5afc22d1d"),
                            NazivZasticeneZone = "2"
                        },
                        new
                        {
                            ZasticenaZonaID = new Guid("308a9704-2235-4310-9092-9cde4a40164b"),
                            NazivZasticeneZone = "3"
                        },
                        new
                        {
                            ZasticenaZonaID = new Guid("25fb6ccc-6713-44e3-8234-44d680fc1b5f"),
                            NazivZasticeneZone = "4"
                        });
                });

            modelBuilder.Entity("ParcelaService.Entities.DeoParcele", b =>
                {
                    b.HasOne("ParcelaService.Entities.Parcela", "Parcela")
                        .WithMany("DeoParceleList")
                        .HasForeignKey("ParcelaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParcelaService.Entities.Parcela", b =>
                {
                    b.HasOne("ParcelaService.Entities.KatastarskaOpstina", "KatastarskaOpstina")
                        .WithMany("ParcelaList")
                        .HasForeignKey("KatastarskaOpstinaID");

                    b.HasOne("ParcelaService.Entities.Klasa", "Klasa")
                        .WithMany("ParcelaList")
                        .HasForeignKey("KlasaID");

                    b.HasOne("ParcelaService.Entities.Kultura", "Kultura")
                        .WithMany("ParcelaList")
                        .HasForeignKey("KulturaID");

                    b.HasOne("ParcelaService.Entities.OblikSvojine", "OblikSvojine")
                        .WithMany("ParcelaList")
                        .HasForeignKey("OblikSvojineID");

                    b.HasOne("ParcelaService.Entities.Obradivost", "Obradivost")
                        .WithMany("ParcelaList")
                        .HasForeignKey("ObradivostID");

                    b.HasOne("ParcelaService.Entities.Odvodnjavanje", "Odvodnjavanje")
                        .WithMany("ParcelaList")
                        .HasForeignKey("OdvodnjavanjeID");

                    b.HasOne("ParcelaService.Entities.ZasticenaZona", "ZasticenaZona")
                        .WithMany("ParcelaList")
                        .HasForeignKey("ZasticenaZonaID");
                });
#pragma warning restore 612, 618
        }
    }
}
