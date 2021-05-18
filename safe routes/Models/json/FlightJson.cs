using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class FlightJson
    {
        public string number { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
       public codesharedJson codeshared { get; set; }
    }
}
