using safe_routes.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.ViewModels.Home
{
    public class RouteDateViewModel
    {
        public string airportArrival { get; set; }

        public string airportDeparture { get; set; }

        public DateTimeOffset DateTimeArrival { get; set; }

        public int maxNumberOfChanges { get; set; }

        public IEnumerable<Airport> airports { get; set; }
    }
}
