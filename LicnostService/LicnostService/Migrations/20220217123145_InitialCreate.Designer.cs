// <auto-generated />
using System;
using LicnostService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LicnostService.Migrations
{
    [DbContext(typeof(LicnostContext))]
    [Migration("20220217123145_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LicnostService.Entities.Clan", b =>
                {
                    b.Property<Guid>("ClanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicnostID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClanID");

                    b.ToTable("Clan");

                    b.HasData(
                        new
                        {
                            ClanID = new Guid("17fc842e-54f4-48fe-b189-0fd12d895c9a"),
                            LicnostID = new Guid("4a078606-30b2-497e-8650-7330a236e150")
                        });
                });

            modelBuilder.Entity("LicnostService.Entities.Komisija", b =>
                {
                    b.Property<Guid>("KomisijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClanID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PredsednikID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KomisijaID");

                    b.ToTable("Komisija");

                    b.HasData(
                        new
                        {
                            KomisijaID = new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e"),
                            ClanID = new Guid("17fc842e-54f4-48fe-b189-0fd12d895c9a"),
                            PredsednikID = new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e")
                        });
                });

            modelBuilder.Entity("LicnostService.Entities.Licnost", b =>
                {
                    b.Property<Guid>("LicnostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicnostID");

                    b.ToTable("Licnost");

                    b.HasData(
                        new
                        {
                            LicnostID = new Guid("4a078606-30b2-497e-8650-7330a236e150"),
                            Funkcija = "",
                            Ime = "Nemanja",
                            Prezime = "Sudarski"
                        },
                        new
                        {
                            LicnostID = new Guid("f45c4d55-00af-4f06-be69-f79e3fa9dcc2"),
                            Funkcija = "",
                            Ime = "Sofija",
                            Prezime = "Bozic"
                        });
                });

            modelBuilder.Entity("LicnostService.Entities.Predsednik", b =>
                {
                    b.Property<Guid>("PredsednikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicnostID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PredsednikID");

                    b.HasIndex("LicnostID");

                    b.ToTable("Predsednik");

                    b.HasData(
                        new
                        {
                            PredsednikID = new Guid("8d878d03-fb76-42fc-91a0-5c8d3c36180e"),
                            LicnostID = new Guid("f45c4d55-00af-4f06-be69-f79e3fa9dcc2")
                        });
                });

            modelBuilder.Entity("LicnostService.Entities.Predsednik", b =>
                {
                    b.HasOne("LicnostService.Entities.Licnost", "Licnost")
                        .WithMany()
                        .HasForeignKey("LicnostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
