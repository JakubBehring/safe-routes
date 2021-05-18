using Microsoft.EntityFrameworkCore.Migrations;

namespace safe_routes.Migrations
{
    public partial class addcountriestodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    countryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    iso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iso3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cases = table.Column<int>(type: "int", nullable: false),
                    todayCases = table.Column<int>(type: "int", nullable: false),
                    deaths = table.Column<int>(type: "int", nullable: false),
                    todayDeaths = table.Column<int>(type: "int", nullable: false),
                    recovered = table.Column<int>(type: "int", nullable: false),
                    todayRecovered = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<int>(type: "int", nullable: false),
                    critical = table.Column<int>(type: "int", nullable: false),
                    casesPerOneMillion = table.Column<double>(type: "float", nullable: false),
                    deathsPerOneMillion = table.Column<double>(type: "float", nullable: false),
                    tests = table.Column<int>(type: "int", nullable: false),
                    testsPerOneMillion = table.Column<double>(type: "float", nullable: false),
                    population = table.Column<int>(type: "int", nullable: false),
                    continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oneCasePerPeople = table.Column<double>(type: "float", nullable: false),
                    oneDeathPerPeople = table.Column<double>(type: "float", nullable: false),
                    oneTestPerPeople = table.Column<double>(type: "float", nullable: false),
                    activePerOneMillion = table.Column<double>(type: "float", nullable: false),
                    recoveredPerOneMillion = table.Column<double>(type: "float", nullable: false),
                    criticalPerOneMillion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.countryName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
