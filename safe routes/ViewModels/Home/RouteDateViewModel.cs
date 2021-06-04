using safe_routes.data;
using safe_routes.Models.PathFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.ViewModels.Home
{
    public class RouteDateViewModel
    {
        // data to get input
        public string airportArrival { get; set; }

        public string airportDeparture { get; set; }

        public DateTimeOffset DateTimeArrival { get; set; }

        public int maxNumberOfChanges { get; set; }

        public IEnumerable<Airport> airports { get; set; }

        // data to show path found 

       public PathInfo PathInfo { get; set; }

    }
}
