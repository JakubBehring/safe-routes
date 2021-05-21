using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using safe_routes.data;
using safe_routes.Models;
using safe_routes.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using safe_routes.Models.PathFinder;

namespace safe_routes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        [BindProperty]
       public RouteDateViewModel routeDateViewModel { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
         // PathFinder pathFinder = new PathFinder(applicationDbContext);
         // pathFinder.FindRoutes();
            routeDateViewModel = new RouteDateViewModel() { airports = applicationDbContext.Airports};
            return View(routeDateViewModel);
        }
        public IActionResult PathFound()
        {
            var airportDeparture = applicationDbContext.Airports.Where(a => a.cityAndAirportName == routeDateViewModel.airportDeparture).FirstOrDefault();
            var airportArrival = applicationDbContext.Airports.Where(a => a.cityAndAirportName == routeDateViewModel.airportArrival).FirstOrDefault();
            if(airportArrival == null || airportDeparture == null)
            {
                return NotFound();
            }
            PathFinder pathFinder = new PathFinder(applicationDbContext);
          var pathInfo =  pathFinder.FindPath(airportDeparture, airportArrival, routeDateViewModel.DateTimeArrival, routeDateViewModel.maxNumberOfChanges);
            return View(pathInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
