using Microsoft.EntityFrameworkCore.Migrations;

namespace safe_routes.Migrations
{
    public partial class citiesaddedtodbmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routes_airports_airportArrivalairportName",
                table: "routes");

            migrationBuilder.DropForeignKey(
                name: "FK_routes_airports_airportDepartureairportName",
                table: "routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_routes",
                table: "routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_airports",
                table: "airports");

            migrationBuilder.RenameTable(
                name: "routes",
                newName: "Routes");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "airports",
                newName: "Airports");

            migrationBuilder.RenameIndex(
                name: "IX_routes_airportDepartureairportName",
                table: "Routes",
                newName: "IX_Routes_airportDepartureairportName");

            migrationBuilder.RenameIndex(
                name: "IX_routes_airportArrivalairportName",
                table: "Routes",
                newName: "IX_Routes_airportArrivalairportName");

            migrationBuilder.AddColumn<string>(
                name: "cityAndAirportName",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cityName",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "countryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airports",
                table: "Airports",
                column: "airportName");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    cityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    iataCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryIso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    geonameId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.cityName);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Airports_airportArrivalairportName",
                table: "Routes",
                column: "airportArrivalairportName",
                principalTable: "Airports",
                principalColumn: "airportName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Airports_airportDepartureairportName",
                table: "Routes",
                column: "airportDepartureairportName",
                principalTable: "Airports",
                principalColumn: "airportName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Airports_airportArrivalairportName",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Airports_airportDepartureairportName",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airports",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "cityAndAirportName",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "cityName",
                table: "Airports");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "routes");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "countries");

            migrationBuilder.RenameTable(
                name: "Airports",
                newName: "airports");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_airportDepartureairportName",
                table: "routes",
                newName: "IX_routes_airportDepartureairportName");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_airportArrivalairportName",
                table: "routes",
                newName: "IX_routes_airportArrivalairportName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_routes",
                table: "routes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "countryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_airports",
                table: "airports",
                column: "airportName");

            migrationBuilder.AddForeignKey(
                name: "FK_routes_airports_airportArrivalairportName",
                table: "routes",
                column: "airportArrivalairportName",
                principalTable: "airports",
                principalColumn: "airportName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_routes_airports_airportDepartureairportName",
                table: "routes",
                column: "airportDepartureairportName",
                principalTable: "airports",
                principalColumn: "airportName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
