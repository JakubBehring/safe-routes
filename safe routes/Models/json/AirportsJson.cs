using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using safe_routes.Models.json;

namespace safe_routes.Models.json
{
    public class AirportsJson
    {
        public PaginationJson pagination { get; set; }
        public List<AirportJson> data { get; set; }
    }
}
