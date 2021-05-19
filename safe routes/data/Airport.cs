using safe_routes.Models.json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.data
{
    public class Airport
    {

       
        [Key]
        public string airportName { get; set; }
        public string cityAndAirportName { get; set; }
        public double latiude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public double gmt { get; set; }
        public string countryName { get; set; }
        public string countryIso2 { get; set; }
        public string cityIataCode { get; set; }
        public string cityName { get; set; }

        public Airport()
        {

        }
        public Airport(AirportJson airportJson)
        {
            airportName = airportJson.airport_name;
            cityIataCode = airportJson.city_iata_code;
            countryIso2 = airportJson.country_iso2;
            countryName = airportJson.country_name;
            gmt = double.Parse(airportJson.gmt);
            longitude = double.Parse(airportJson.longitude);
            latiude = double.Parse(airportJson.latitude);
            timezone = airportJson.timezone;
        }

        public void updateAirport(Airport airport)
        {
            cityIataCode = airport.cityIataCode;
            countryIso2 = airport.countryIso2;
            countryName = airport.countryName;
            gmt = airport.gmt;
            longitude = airport.longitude;
            latiude = airport.latiude;
            timezone = airport.timezone;
        }

        public bool validAirport(AirportJson airportJson)
        {
            return !(airportJson.airport_name == null || airportJson.city_iata_code == null || airportJson.country_iso2 == null
                        || airportJson.country_name == null || airportJson.latitude == null || airportJson.gmt == null
                        || airportJson.iata_code == null || airportJson.longitude == null);
        }

    }
}
