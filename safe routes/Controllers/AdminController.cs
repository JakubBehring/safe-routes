using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using safe_routes.data;
using safe_routes.Models.json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace safe_routes.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IConfiguration configuration;
        private readonly string apiKey;
        static HttpClient client = new HttpClient();


        public AdminController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            this.applicationDbContext = applicationDbContext;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Airports()
        {
            var airports = applicationDbContext.Airports.ToList();
            return View(airports);
        }

        public async Task<IActionResult> Countries()
        {
            var countries = applicationDbContext.Countries.ToList();
            return View(countries);
        }

        public async Task<IActionResult> Routes()
        {
            var routes = applicationDbContext.Routes.Include(r => r.airportArrival).Include(r => r.airportDeparture)
                .Where(r => r.airportArrival != null && r.airportDeparture != null).ToList();
            return View(routes);
        }
        public async Task<IActionResult> GenereteCountriesCoronaInfo()
        {
            var path = "https://disease.sh/v3/covid-19/countries/";
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();

            }
            var countries = await response.Content.ReadFromJsonAsync<List<CountryJson>>();

            foreach (var country in countries.Where(c => c.population > 0))
            {
                Country countryDb = new Country()
                {
                    active = country.active.Value,
                    activePerOneMillion = country.activePerOneMillion.Value,
                    cases = country.cases.Value,
                    casesPerOneMillion = country.casesPerOneMillion.Value,
                    continent = country.continent,
                    countryName = country.country,
                    critical = country.critical.Value,
                    criticalPerOneMillion = country.criticalPerOneMillion.Value,
                    deaths = country.deaths.Value,
                    deathsPerOneMillion = country.deathsPerOneMillion.Value,
                    iso2 = country.countryInfo.iso2,
                    iso3 = country.countryInfo.iso3,
                    oneCasePerPeople = country.oneCasePerPeople.Value,
                    oneDeathPerPeople = country.oneDeathPerPeople.Value,
                    oneTestPerPeople = country.oneTestPerPeople.Value,
                    population = country.population.Value,
                    recovered = country.recovered.Value,
                    recoveredPerOneMillion = country.recoveredPerOneMillion.Value,
                    tests = country.tests.Value,
                    testsPerOneMillion = country.testsPerOneMillion.Value,
                    todayCases = country.todayCases.Value,
                    todayDeaths = country.todayDeaths.Value,
                    todayRecovered = country.todayRecovered.Value,

                };

                var existInDb = await applicationDbContext.AddAsync(countryDb);

            }

            await applicationDbContext.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> GenerateRoutes()
        {

            for (int offset = 0; offset <= 270000; offset += 100)
            {
                var appKey = configuration["AppApiKey"];
                var path = "http://api.aviationstack.com/v1/flights?access_key=" + appKey + "&offset=" + offset.ToString();
                var response = await client.GetAsync(path);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();

                }

                var flights = await response.Content.ReadFromJsonAsync<FlightsJson>();

                foreach (var flight in flights.data)
                {
                    if (flight.flight_date == null || flight.airline.name == null || flight.flight.number == null
                        || DepartureArrival.containsNulls(flight.arrival) || DepartureArrival.containsNulls(flight.departure))
                        continue;

                    try
                    {

                        Route routeDb = new Route()
                        {
                            airlineName = flight.airline.name,
                            flightNumber = long.Parse(flight.flight.number),
                            iata = flight.flight.iata,
                            iataArrival = flight.arrival.iata,
                            iataDeparture = flight.departure.iata,
                            icao = flight.flight.icao,
                            icaoArrival = flight.departure.icao,
                            icaoDeparture = flight.departure.icao,
                            airportArrival = new Airport()
                            {
                                airportName = flight.arrival.airport,
                                timezone = flight.arrival.timezone,

                            },
                            airportDeparture = new Airport()
                            {
                                airportName = flight.departure.airport,
                                timezone = flight.departure.timezone
                            },

                            timezoneArrival = flight.arrival.timezone,
                            timezoneDeparture = flight.departure.timezone,

                            terminalArrival = flight.arrival.terminal,
                            terminalDeparture = flight.departure.terminal,

                            timeArrival = DateTimeOffset.Parse(flight.arrival.scheduled),
                            timeDeparture = DateTimeOffset.Parse(flight.departure.scheduled)

                        };
                        var airportArrival = applicationDbContext.Airports.Where(a => a.airportName == flight.arrival.airport).FirstOrDefault();
                        var airportDeparture = applicationDbContext.Airports.Where(a => a.airportName == flight.departure.airport).FirstOrDefault();
                        routeDb.airportArrival = airportArrival;
                        routeDb.airportDeparture = airportDeparture;


                        await applicationDbContext.AddAsync(routeDb);
                        await applicationDbContext.SaveChangesAsync();

                    }
                    catch (Exception e)
                    {
                        continue;
                    }


                }

            }
            return View();
        }

        public async Task<IActionResult> GenerateAirports()
        {
            for (int offset = 0; offset <= 6400; offset += 100)
            {
                var appKey = configuration["AppApiKey"];
                var path = "http://api.aviationstack.com/v1/airports?access_key=" + appKey + "&offset=" + offset.ToString();
                var response = await client.GetAsync(path);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();

                }

                var airports = await response.Content.ReadFromJsonAsync<AirportsJson>();

                foreach (var airport in airports.data)
                {

                    if (airport.airport_name == null || airport.city_iata_code == null || airport.country_iso2 == null
                        || airport.country_name == null || airport.latitude == null || airport.gmt == null
                        || airport.iata_code == null || airport.longitude == null)
                        continue;
                    try
                    {
                        Airport airpotDb = new Airport
                        {
                            airportName = airport.airport_name,
                            cityIataCode = airport.city_iata_code,
                            countryIso2 = airport.country_iso2,
                            countryName = airport.country_name,
                            gmt = double.Parse(airport.gmt),
                            longitude = double.Parse(airport.longitude),
                            latiude = double.Parse(airport.latitude),
                            timezone = airport.timezone
                        };


                        bool existInDb = applicationDbContext.Airports.Find(airpotDb.airportName) != null;
                        if (!existInDb)
                        {
                            await applicationDbContext.Airports.AddAsync(airpotDb);
                            await applicationDbContext.SaveChangesAsync();
                        }
                    }
                    catch (Exception)
                    {
                        continue;

                    }

                }

            }
            return View();
        }

        public async Task<IActionResult> GenerateCities()
        {
            for (int offset = 0; offset <= 9300; offset += 100) // 9368
            {
                var appKey = configuration["AppApiKey"];
                var path = "http://api.aviationstack.com/v1/cities?access_key=" + appKey + "&offset=" + offset.ToString();
                var response = await client.GetAsync(path);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();

                }

                var cities = await response.Content.ReadFromJsonAsync<CitiesJson>();

                foreach (var city in cities.data)
                {

                    if (city.city_name == null || city.country_iso2 == null
                        || city.gmt == null || city.iata_code == null || city.latitude == null
                        || city.longitude == null || city.timezone == null)
                        continue;
                    try
                    {
                        City citytDb = new City
                        {
                            cityName = city.city_name,
                            countryIso2 = city.country_iso2,
                            geonameId = city.geoname_id,
                            gmt = city.gmt,
                            iataCode = city.iata_code,
                            latitude = city.latitude,
                            longitude = city.longitude,
                            timezone = city.timezone,
                        };

                        bool existInDb = applicationDbContext.Cities.Find(city.city_name) != null;
                        if (!existInDb)
                        {
                            await applicationDbContext.Cities.AddAsync(citytDb);
                            await applicationDbContext.SaveChangesAsync();
                        }


                    }
                    catch (Exception)
                    {
                        continue;

                    }

                }

            }
            return View();

        }
        public async Task<IActionResult> DeleteCities()
        {
            var cites = applicationDbContext.Cities.ToList();
            applicationDbContext.RemoveRange(cites);
            await applicationDbContext.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> GenereteCityNameForEachAirport()
        {
            var aripo = applicationDbContext.Airports.Where(a => a.countryIso2 == "PL").ToList();
            var airports = applicationDbContext.Airports.ToList();
            int deleted = 0;
            foreach (var airport in airports)
            {
                var cityIataCode = airport.cityIataCode;
                var city = applicationDbContext.Cities.Where(c => c.iataCode == cityIataCode).FirstOrDefault();
                if(city != null)
                {
                    if(city.cityName == airport.airportName)
                    {
                        airport.cityName = city.cityName;
                        airport.cityAndAirportName = city.cityName;
                    }
                    else if(airport.airportName.Contains(city.cityName))
                    {
                        airport.cityName = city.cityName;
                        airport.cityAndAirportName = airport.airportName;
                    }
                    else
                    {
                        airport.cityName = city.cityName;
                        airport.cityAndAirportName = city.cityName + " " + airport.airportName;
                        applicationDbContext.Airports.Update(airport);
                    }
                   
                   await applicationDbContext.SaveChangesAsync();
                }
                else
                {
                    var routes = applicationDbContext.Routes.Include(r => r.airportArrival).Include(r => r.airportDeparture)
                        .Where(r => r.airportDeparture == airport || r.airportArrival == airport);
                    applicationDbContext.Routes.RemoveRange(routes);
                    applicationDbContext.Airports.Remove(airport);
                    await applicationDbContext.SaveChangesAsync();
                    deleted++;
                 
                }
                
            }
            return View();
        }

        public async Task<IActionResult> clearAllRoutesWithoutAirport()
        {
            var routes = await applicationDbContext.Routes.Include(r => r.airportDeparture).Include(r => r.airportArrival)
                .Where(r => r.airportDeparture == null || r.airportArrival == null).ToListAsync();
                
            applicationDbContext.Routes.RemoveRange(routes);
            applicationDbContext.SaveChanges();
            return View();
        }

        public async Task<IActionResult> DistinctAllRoutes()
        {
            var routes = applicationDbContext.Routes.Include(r => r.airportDeparture).Include(r => r.airportArrival).ToList() ;
            var routesDistinic = routes.Distinct().ToList();
            return View();
             
        }

    }

}
