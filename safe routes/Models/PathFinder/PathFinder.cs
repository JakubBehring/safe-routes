using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using safe_routes.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.PathFinder
{
    public class PathFinder
    {
        private readonly ApplicationDbContext applicationDbContext;

        public PathFinder(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }
        public List<Route> Routes { get; set; } = new List<Route>();
        public List<Airport> airports { get; set; } = new List<Airport>();

        public Dictionary<int, Airport> airportsDicionary { get; set; } = new Dictionary<int, Airport>();
       
        public void findRoutes()
        {
            var airportsDict = new Dictionary<Airport, int>();
            foreach (var item in applicationDbContext.Routes.Include(r => r.airportDeparture).Include(r => r.airportArrival))
            {
                if(airportsDict.ContainsKey(item.airportDeparture))
                {
                    airportsDict[item.airportDeparture] += 1;
                }
                else
                {
                    airportsDict.Add(item.airportDeparture, 1);
                }
            }
            var airportsWithMostFlight = airportsDict.OrderBy(a => a.Value).Reverse().Take(50).ToDictionary(e => e.Key, e => e.Value);


            DateTimeOffset dateTimeOffset = new DateTimeOffset(2019, 4, 17, 0, 0, 0,
                                          new TimeSpan(+2, 0, 0));

            foreach (var airportDeparture in airportsWithMostFlight.Keys)
            {
                foreach (var airportArrival in airportsWithMostFlight.Keys)
                {
                    if (airportDeparture == airportArrival)
                        continue;

                    Routes = new List<Route>();
                    airports = new List<Airport>();
                    airportsDicionary = new Dictionary<int, Airport>();
                    var pathinfo = FindPath(airportDeparture, airportArrival, dateTimeOffset, 8);

                    if (pathinfo.airportsPath.Count >= 3)
                    {
                        File.AppendAllLines("C:\\Users\\jakub\\Desktop\\TrasyNajbardziejObleganeLotniska.txt", new List<string>() { airportDeparture.cityAndAirportName });
                        File.AppendAllLines("C:\\Users\\jakub\\Desktop\\TrasyNajbardziejObleganeLotniska.txt", new List<string>() { airportArrival.cityAndAirportName });
                        File.AppendAllLines("C:\\Users\\jakub\\Desktop\\TrasyNajbardziejObleganeLotniska.txt", new List<string>() { dateTimeOffset.ToString(), "\n" });

                    }

                }
            }

        }


        public PathInfo FindPath(Airport airportDeparture, Airport airportArrival, DateTimeOffset arrivalDateTime, int maxChange = 3)
        {
            findAllRoutesFromAirport(airportDeparture, 1, arrivalDateTime, maxChange);
            mapAirportsToDicionary(airports);
            var airpotCount = airports.Count;
            RouteAndEdge[,] graph = new RouteAndEdge[airpotCount, airpotCount];
            fillInGraph(graph);
            var vortexStart = airportsDicionary.Where(a => a.Value == airportDeparture).FirstOrDefault().Key;
            var vortexEnd = airportsDicionary.Where(a => a.Value == airportArrival).FirstOrDefault().Key;
            var pathFound = false;
            List<Airport> airpotsPath = new List<Airport>();
            List<RouteAndEdge> routesInGraph = new List<RouteAndEdge>();
            if (vortexEnd == 0)
            {
                // nie znaziono trasy
            }
            else
            {
                pathFound = true;
                DijkstrasAlgorithm dijkstrasAlgorithm = new DijkstrasAlgorithm();
                var shortestPath = dijkstrasAlgorithm.dijkstra(graph, vortexStart, vortexEnd);
                for (int i = 0; i < shortestPath.Count; i++)
                {
                    var vertex = airportsDicionary[shortestPath[i]];
                    if (i + 1 < shortestPath.Count)
                    {
                        var nextVertex = airportsDicionary[shortestPath[i + 1]];
                        var route = graph[shortestPath[i], shortestPath[i + 1]];
                        routesInGraph.Add(route);
                    }
                }
                foreach (var vertex in shortestPath)
                {
                    airpotsPath.Add(airportsDicionary[vertex]);


                }

            }

            return new PathInfo() { airportsCount = airports.Count, routesCount = Routes.Count, pathFound = pathFound, airportsPath = airpotsPath, routsWithEdges = routesInGraph };


        }

        public void findAllRoutesFromAirport(Airport airport, int iteration, DateTimeOffset arrivalDateTime, int maxChange)
        {

            var routesFromAirport = applicationDbContext.Routes.Include(r => r.airportDeparture).Include(r => r.airportArrival)
                .Where(r => r.airportDeparture.airportName == airport.airportName)
                .ToList();


            routesFromAirport = iteration == 1 ? routesFromAirport = routesFromAirport.Where(r => (r.timeDeparture > arrivalDateTime)).ToList()
                  : routesFromAirport = routesFromAirport.Where(r => (r.timeDeparture - arrivalDateTime).TotalHours >= 1 && (r.timeDeparture - arrivalDateTime).TotalHours <= 4).ToList();
            Routes.AddRange(routesFromAirport);

            

            if (!airports.Contains(airport))
                airports.Add(airport);
            else
                return;

            iteration++;

            if (iteration <= maxChange + 1)
            {
                foreach (var route in routesFromAirport.ToList())
                {
                    if (!airports.Contains(route.airportArrival))
                        findAllRoutesFromAirport(route.airportArrival, iteration, route.timeArrival, maxChange);
                }
            }
            else
            {
                foreach (var route in routesFromAirport)
                {
                    if (!airports.Contains(route.airportArrival))
                        airports.Add(route.airportArrival);
                }
            }
           
        }

        public void mapAirportsToDicionary(List<Airport> airports)
        {
            for (int i = 0; i < airports.Count; i++)
            {
                airportsDicionary.Add(i, airports[i]);
            }
        }

        public void fillInGraph(RouteAndEdge[,] graph)
        {
            Routes = Routes.Distinct().ToList();
            var countriesEpidemicState = applicationDbContext.Countries;
            foreach (var route in Routes)
            {
                var vertexDeparture = route.airportDeparture;
                var vertexArrival = route.airportArrival;
                int indexDeparture = airportsDicionary.FirstOrDefault(a => a.Value == vertexDeparture).Key;
                int indexArrival = airportsDicionary.FirstOrDefault(a => a.Value == vertexArrival).Key;

                //obliczyc krawedź
                var departureCord = new GeoCoordinate(vertexDeparture.latiude, vertexDeparture.longitude);
                var arrivalcord = new GeoCoordinate(vertexArrival.latiude, vertexArrival.longitude);
                var distance = departureCord.GetDistanceTo(arrivalcord);

                var countryStateArrival = countriesEpidemicState.FirstOrDefault(c => c.iso2 == vertexArrival.countryIso2);
                var activeCases = countryStateArrival == null ? 0 : countryStateArrival.active;
                var population = countryStateArrival == null ? 1 : countryStateArrival.population;
                double casesPerPopulation = (double)(activeCases) / population;


                // wpisać krawedz 

                var route2 = new { route2 = route, edge = distance + (distance * casesPerPopulation) };

                graph[indexDeparture, indexArrival] = new RouteAndEdge() { Route = route, Edge = distance + (distance * casesPerPopulation) };

            }
        }



    }

    public record RouteAndEdge
    {
        public Route Route { get; set; }
        public double Edge { get; set; }
    }






}
