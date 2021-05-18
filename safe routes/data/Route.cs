using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.data
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public string timezoneDeparture { get; set; }
        public string iataDeparture { get; set; }
        public string icaoDeparture { get; set; }
        public string terminalDeparture { get; set; }
        public DateTimeOffset timeDeparture { get; set; }

        public string timezoneArrival { get; set; }
        public string iataArrival { get; set; }
        public string icaoArrival { get; set; }
        public string terminalArrival { get; set; }
        public DateTimeOffset timeArrival { get; set; }

        public string airlineName { get; set; }
        public string airlineSign { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }

        public long flightNumber { get; set; }

        public Airport airportDeparture { get; set; }
        public Airport airportArrival { get; set; }
    }

}
