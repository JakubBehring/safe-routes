using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class CitiesJson
    {
        public PaginationJson pagination { get; set; }
        public List<CityJson> data { get; set; }
    }
}
