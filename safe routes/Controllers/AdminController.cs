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
                Country countryToDb = new Country(country);

                var countryInDB = await applicationDbContext.Countries.FindAsync(countryToDb.countryName);
                if (countryInDB != null)
                {
                    countryInDB.updateCountry(countryToDb);
                }
                else
                    await applicationDbContext.AddAsync(countryToDb);


            }

            await applicationDbContext.SaveChangesAsync();
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

                    if (city.conainsNulls())
                        continue;
                    else
                    {
                        City citytDb = new City(city);
                        var existInDb = applicationDbContext.Cities.Find(city.city_name);


                        if (existInDb != null)
                        {
                            existInDb.updateCity(citytDb);
                        }
                        else
                        {
                            await applicationDbContext.Cities.AddAsync(citytDb);
                        }

                        await applicationDbContext.SaveChangesAsync();
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
                    if (airport.conatinsNulls())
                        continue;

                    Airport airpotDb = new Airport(airport);
                    var city = applicationDbContext.Cities.FirstOrDefault(c => c.iataCode == airpotDb.cityIataCode);
                    if (city == null)
                        continue;
                    else
                    {
                        if (city.cityName == airpotDb.airportName || airpotDb.airportName.Contains(city.cityName))
                        {
                            airpotDb.cityName = city.cityName;
                            airpotDb.cityAndAirportName = airpotDb.airportName;
                        }
                        else
                        {
                            airpotDb.cityName = city.cityName;
                            airpotDb.cityAndAirportName = city.cityName + " " + airpotDb.airportName;
                        }
                    }

                    var airporttInDb = applicationDbContext.Airports.Find(airpotDb.airportName);

                    if (airporttInDb != null)
                    {
                        airporttInDb.updateAirport(airpotDb);
                    }
                    else
                    {
                        await applicationDbContext.Airports.AddAsync(airpotDb);
                    }
                    await applicationDbContext.SaveChangesAsync();
                }

            }
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
                    if (flight.containsNulls())
                        continue;

                   
                        Route routeDb = new Route(flight);
                        var airportArrival = applicationDbContext.Airports.FirstOrDefault(a => a.airportName == flight.arrival.airport);
                        var airportDeparture = applicationDbContext.Airports.FirstOrDefault(a => a.airportName == flight.departure.airport);
                        routeDb.airportArrival = airportArrival;
                        routeDb.airportDeparture = airportDeparture;
                        await applicationDbContext.AddAsync(routeDb);
                        await applicationDbContext.SaveChangesAsync();
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
            var routes = applicationDbContext.Routes.Include(r => r.airportDeparture).Include(r => r.airportArrival).ToList();
            var routesDistinic = routes.Distinct().ToList();
            return View();

        }

    }

}
