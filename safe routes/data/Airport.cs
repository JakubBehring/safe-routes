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


    }
}
