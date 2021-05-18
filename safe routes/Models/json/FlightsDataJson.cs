using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class FlightsDataJson
    {
        public string? flight_date { get; set; }
        public string? flight_status { get; set; }

        public DepartureArrival departure { get; set; }

        public DepartureArrival arrival { get; set; }
        public AirlineJson airline { get; set; }
        public FlightJson flight { get; set; }

        public Aircraft? aircraft { get; set; }
        public LiveJson? live { get; set; }

    }
}
