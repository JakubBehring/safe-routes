using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace safe_routes.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airports",
                columns: table => new
                {
                    airportName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    latiude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gmt = table.Column<double>(type: "float", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryIso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityIataCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airports", x => x.airportName);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timezoneDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iataDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icaoDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    terminalDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeDeparture = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    timezoneArrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iataArrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icaoArrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    terminalArrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeArrival = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    airlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airlineSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightNumber = table.Column<long>(type: "bigint", nullable: false),
                    airportDepartureairportName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    airportArrivalairportName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_routes_airports_airportArrivalairportName",
                        column: x => x.airportArrivalairportName,
                        principalTable: "airports",
                        principalColumn: "airportName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_routes_airports_airportDepartureairportName",
                        column: x => x.airportDepartureairportName,
                        principalTable: "airports",
                        principalColumn: "airportName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_routes_airportArrivalairportName",
                table: "routes",
                column: "airportArrivalairportName");

            migrationBuilder.CreateIndex(
                name: "IX_routes_airportDepartureairportName",
                table: "routes",
                column: "airportDepartureairportName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "airports");
        }
    }
}
