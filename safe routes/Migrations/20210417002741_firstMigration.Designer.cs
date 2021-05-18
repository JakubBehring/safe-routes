﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using safe_routes.data;

namespace safe_routes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210417002741_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("safe_routes.data.Airport", b =>
                {
                    b.Property<string>("airportName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cityIataCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countryIso2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("gmt")
                        .HasColumnType("float");

                    b.Property<double>("latiude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("timezone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("airportName");

                    b.ToTable("airports");
                });

            modelBuilder.Entity("safe_routes.data.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("airlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("airlineSign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("airportArrivalairportName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("airportDepartureairportName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("flightNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("iata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iataArrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iataDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icaoArrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icaoDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("terminalArrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("terminalDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("timeArrival")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("timeDeparture")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("timezoneArrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timezoneDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("airportArrivalairportName");

                    b.HasIndex("airportDepartureairportName");

                    b.ToTable("routes");
                });

            modelBuilder.Entity("safe_routes.data.Route", b =>
                {
                    b.HasOne("safe_routes.data.Airport", "airportArrival")
                        .WithMany()
                        .HasForeignKey("airportArrivalairportName");

                    b.HasOne("safe_routes.data.Airport", "airportDeparture")
                        .WithMany()
                        .HasForeignKey("airportDepartureairportName");

                    b.Navigation("airportArrival");

                    b.Navigation("airportDeparture");
                });
#pragma warning restore 612, 618
        }
    }
}