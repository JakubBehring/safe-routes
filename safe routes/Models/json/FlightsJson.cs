using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class FlightsJson
    {
        public PaginationJson pagination { get; set; }
        public List<FlightsDataJson> data { get; set; }
    }
}
