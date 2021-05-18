using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class DepartureArrival
    {
        public string? airport { get; set; }
        public string? timezone { get; set; }
        public string? iata { get; set; }
        public string? icao { get; set; }
        public string? terminal { get; set; }
        public string? gate { get; set; }
        public double? delay { get; set; }
        public string? scheduled { get; set; }
        public string? estimated { get; set; }
        public string? actual { get; set; }
        public string? estimated_runway { get; set; }
        public string? actual_runway { get; set; }

        public static bool containsNulls(DepartureArrival departureArrival)
        {
            return departureArrival.airport == null || departureArrival.timezone == null || departureArrival.scheduled == null;
                
        }
    }
}
