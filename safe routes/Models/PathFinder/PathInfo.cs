using safe_routes.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.PathFinder
{
    public record PathInfo
    {
        public int airportsCount { get; set; }
        public int routesCount { get; set; }
        public bool pathFound { get; set; }
        public List<Airport> airportsPath { get; set; }
        public List<RouteInfo> routsWithEdges;
    }
}
