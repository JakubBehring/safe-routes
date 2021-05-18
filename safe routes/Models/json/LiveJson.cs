using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace safe_routes.Models.json
{
    public class LiveJson
    {
       public string? updated { get; set; }
       public double? latitude { get; set; }
       public double? longitude { get; set; }
       public double? altitude { get; set; }
       public double? direction { get; set; }
       public double? speed_horizontal { get; set; }
       public double? speed_vertical { get; set; }
       public bool? is_ground { get; set; }
    }
}
