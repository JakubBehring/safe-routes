using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class CityJson
    {
        public string? city_name { get; set; }
        public string? iata_code { get; set; }
        public string? country_iso2 { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public string? timezone { get; set; }
        public string? gmt { get; set; }
        public string? geoname_id { get; set; }
    }
}
