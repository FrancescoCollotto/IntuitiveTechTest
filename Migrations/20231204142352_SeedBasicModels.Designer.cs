﻿// <auto-generated />
using IntuitiveTechTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntuitiveTechTest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231204142352_SeedBasicModels")]
    partial class SeedBasicModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IntuitiveTechTest.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AirportTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("IATACode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.HasKey("Id");

                    b.HasIndex("AirportTypeId");

                    b.HasIndex("CountryId");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirportTypeId = 1,
                            CountryId = 1,
                            IATACode = "LGW"
                        },
                        new
                        {
                            Id = 2,
                            AirportTypeId = 3,
                            CountryId = 2,
                            IATACode = "PMI"
                        },
                        new
                        {
                            Id = 3,
                            AirportTypeId = 3,
                            CountryId = 3,
                            IATACode = "LAX"
                        });
                });

            modelBuilder.Entity("IntuitiveTechTest.AirportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AirportTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Departure and Arrival"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Departure Only"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Arrival Only"
                        });
                });

            modelBuilder.Entity("IntuitiveTechTest.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 3,
                            Name = "United States"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Turkey"
                        });
                });

            modelBuilder.Entity("IntuitiveTechTest.Airport", b =>
                {
                    b.HasOne("IntuitiveTechTest.AirportType", "AirportType")
                        .WithMany("Airports")
                        .HasForeignKey("AirportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntuitiveTechTest.Country", "Country")
                        .WithMany("Airports")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirportType");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("IntuitiveTechTest.AirportType", b =>
                {
                    b.Navigation("Airports");
                });

            modelBuilder.Entity("IntuitiveTechTest.Country", b =>
                {
                    b.Navigation("Airports");
                });
#pragma warning restore 612, 618
        }
    }
}
