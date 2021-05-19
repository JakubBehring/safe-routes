using safe_routes.Models.json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.data
{
    public class City
    {
        [Key]
        public string cityName { get; set; }
        public string iataCode { get; set; }
        public string countryIso2 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string timezone { get; set; }
        public string gmt { get; set; }
        public string geonameId { get; set; }

        public City(CityJson cityJson)
        {
            cityName = cityJson.city_name;
            iataCode = cityJson.iata_code;
            countryIso2 = cityJson.country_iso2;
            latitude = cityJson.latitude;
            longitude = cityJson.longitude;
            timezone = cityJson.timezone;
            gmt = cityJson.gmt;
            geonameId = cityJson.geoname_id;
        }

        public City()
        {

        }
        public void updateCity(City city)
        {
            iataCode = city.iataCode;
            countryIso2 = city.countryIso2;
            latitude = city.latitude;
            longitude = city.longitude;
            timezone = city.timezone;
            gmt = city.gmt;
            geonameId = city.geonameId;
        }
    }
}
