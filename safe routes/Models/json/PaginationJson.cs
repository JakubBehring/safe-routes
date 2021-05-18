using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class PaginationJson
    {
        public int? offset { get; set; }
        public int? limit { get; set; }
        public int? count { get; set; }
        public int? total { get; set; }
    }
}
