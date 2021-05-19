using safe_routes.Models.json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.data
{
    public class Country
    {
        [Key]
        public string countryName { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }

        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int todayRecovered { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public double casesPerOneMillion { get; set; }
        public double deathsPerOneMillion { get; set; }
        public int tests { get; set; }
        public double testsPerOneMillion { get; set; }
        public int population { get; set; }
        public string continent { get; set; }
        public double oneCasePerPeople { get; set; }
        public double oneDeathPerPeople { get; set; }
        public double oneTestPerPeople { get; set; }
        public double activePerOneMillion { get; set; }
        public double recoveredPerOneMillion { get; set; }
        public double criticalPerOneMillion { get; set; }
        public Country()
        {

        }

        public Country(CountryJson countryJson)
        {
            active = countryJson.active.Value;
            activePerOneMillion = countryJson.activePerOneMillion.Value;
            cases = countryJson.cases.Value;
            casesPerOneMillion = countryJson.casesPerOneMillion.Value;
            continent = countryJson.continent;
            countryName = countryJson.country;
            critical = countryJson.critical.Value;
            criticalPerOneMillion = countryJson.criticalPerOneMillion.Value;
            deaths = countryJson.deaths.Value;
            deathsPerOneMillion = countryJson.deathsPerOneMillion.Value;
            iso2 = countryJson.countryInfo.iso2;
            iso3 = countryJson.countryInfo.iso3;
            oneCasePerPeople = countryJson.oneCasePerPeople.Value;
            oneDeathPerPeople = countryJson.oneDeathPerPeople.Value;
            oneTestPerPeople = countryJson.oneTestPerPeople.Value;
            population = countryJson.population.Value;
            recovered = countryJson.recovered.Value;
            recoveredPerOneMillion = countryJson.recoveredPerOneMillion.Value;
            tests = countryJson.tests.Value;
            testsPerOneMillion = countryJson.testsPerOneMillion.Value;
            todayCases = countryJson.todayCases.Value;
            todayDeaths = countryJson.todayDeaths.Value;
            todayRecovered = countryJson.todayRecovered.Value;
        }
        public void updateCountry(Country countryInfo)
        {
            this.active = countryInfo.active;
            this.activePerOneMillion = countryInfo.activePerOneMillion;
            this.cases = countryInfo.cases;
            this.casesPerOneMillion = countryInfo.casesPerOneMillion;
            this.continent = countryInfo.continent;
            this.critical = countryInfo.critical;
            this.criticalPerOneMillion = countryInfo.criticalPerOneMillion;
            this.deaths = countryInfo.deaths;
            this.deathsPerOneMillion = countryInfo.deathsPerOneMillion;
            this.oneCasePerPeople = countryInfo.oneCasePerPeople;
            this.oneDeathPerPeople = countryInfo.oneDeathPerPeople;
            this.oneTestPerPeople = countryInfo.oneTestPerPeople;
            this.population = countryInfo.population;
            this.recovered = countryInfo.recovered;
            this.recoveredPerOneMillion = countryInfo.recoveredPerOneMillion;
            this.tests = countryInfo.tests;
            this.testsPerOneMillion = countryInfo.testsPerOneMillion;
            this.todayCases = countryInfo.todayCases;
            this.todayDeaths = countryInfo.todayDeaths;
            this.todayRecovered = countryInfo.todayRecovered;
        }


    }
}
