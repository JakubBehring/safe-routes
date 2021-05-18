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
    }
}
