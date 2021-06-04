#pragma checksum "G:\safe routes\safe routes\Views\Home\PathFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ab4253f24041d9f5e1b5377e63e52defce2fe9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PathFound), @"mvc.1.0.view", @"/Views/Home/PathFound.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\safe routes\safe routes\Views\_ViewImports.cshtml"
using safe_routes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\safe routes\safe routes\Views\_ViewImports.cshtml"
using safe_routes.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
using safe_routes.Models.PathFinder;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ab4253f24041d9f5e1b5377e63e52defce2fe9f", @"/Views/Home/PathFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d65de15da81e1a010ee1c43bdef0257d958d25e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PathFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PathInfo>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
  
    ViewData["Title"] = "Path";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ab4253f24041d9f5e1b5377e63e52defce2fe9f3321", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.7.1/dist/leaflet.css\"\r\n          integrity=\"sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A==\"");
                BeginWriteAttribute("crossorigin", "\r\n          crossorigin=\"", 305, "\"", 330, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n    <script src=\"https://unpkg.com/leaflet@1.7.1/dist/leaflet.js\"\r\n            integrity=\"sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==\"");
                BeginWriteAttribute("crossorigin", "\r\n            crossorigin=\"", 524, "\"", 551, 0);
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script src=\'//unpkg.com/leaflet-arc/bin/leaflet-arc.min.js\'></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n\r\n\r\n    <div>\r\n        <h1>sprawdziłem ");
#nullable restore
#line 21 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                   Write(Model.airportsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" lotnisk</h1>\r\n        <br />\r\n        <h1>sprawdziłem ");
#nullable restore
#line 23 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                   Write(Model.routesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" lotow: </h1>
    </div>
    <div class=""col-md-10"">
        <div id=""mapid"" style=""height:800px;"">

            <script type=""text/javascript"">
                var mymap = L.map('mapid').setView([51.505, -0.09], 2);
                L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoiamFrdWJiZWhyaW5nIiwiYSI6ImNrb2dmMnR2bDB2ZzEyb3IwOW84c3VoaG4ifQ.iZFbkeKqe0Fdd0beyzdfAg', {
                    attribution: 'Map data &copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a> contributors, Imagery © <a href=""https://www.mapbox.com/"">Mapbox</a>',
                    maxZoom: 18,
                    id: 'mapbox/streets-v11',
                    tileSize: 512,
                    zoomOffset: -1,
                    accessToken: 'your.mapbox.access.token'
                }).addTo(mymap);


                function addMarker(latitude, longitude, index, map) {
                    var marker = L.marker([latitude, longitude]).bindTooltip(index.toS");
            WriteLiteral(@"tring(),
                        {
                            permanent: true,
                            direction: 'right'
                        }).addTo(map);
                }
                function addpolyline(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, map) {
                    var pointA = new L.LatLng(latitudeStart, longitudeStart);
                    var pointB = new L.LatLng(latitudeEnd, longitudeEnd);
                    var pointList = [pointA, pointB];

                    var firstpolyline = new L.Polyline(pointList, {
                        color: 'red',
                        weight: 3,
                        opacity: 0.5,
                        smoothFactor: 1
                    });
                      firstpolyline.addTo(map);
                    L.Polyline.Arc([latitudeStart, longitudeStart], [latitudeEnd, longitudeEnd], {
                        color: 'blue',
                        vertices: 200
                    }).addTo(map);
       ");
            WriteLiteral("           //  L.addpolyline.arc(pointA, pointB)\r\n                }\r\n\r\n");
#nullable restore
#line 66 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                 for (int i =1; i <= Model.airportsPath.Count; i++)
                {
                    var airport = Model.airportsPath[i-1];

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            WriteLiteral("latitude = ");
#nullable restore
#line 69 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                            Write(airport.latiude);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
            WriteLiteral("longitude = ");
#nullable restore
#line 70 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                             Write(airport.longitude);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
            WriteLiteral("index = ");
#nullable restore
#line 71 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                         Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
            WriteLiteral("addMarker(latitude, longitude, index, mymap);\r\n");
#nullable restore
#line 73 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"

                    if(i+1 <= Model.airportsPath.Count)
                {
                        var nextAirport = Model.airportsPath[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                          ");
            WriteLiteral("latitudeNext = ");
#nullable restore
#line 77 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                                      Write(nextAirport.latiude);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
            WriteLiteral("longitudeNext = ");
#nullable restore
#line 78 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                                 Write(nextAirport.longitude);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    ");
            WriteLiteral("addpolyline(latitude, longitude, latitudeNext, longitudeNext, mymap)\r\n");
#nullable restore
#line 80 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </script>\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"col-md-2\">\r\n\r\n");
#nullable restore
#line 89 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
         if (Model.pathFound)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Trasa Lotnisk:</h1>\r\n            <ol>\r\n\r\n\r\n");
#nullable restore
#line 95 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                 foreach (var airport in Model.airportsPath)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 98 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                   Write(airport.cityAndAirportName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 99 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n");
#nullable restore
#line 102 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"



        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1> nie znalazlem trasy</h1>\r\n");
#nullable restore
#line 109 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    </div>\r\n");
#nullable restore
#line 114 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
     if (Model.pathFound)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n\r\n            <h4>szczegóły lotu</h4>\r\n");
#nullable restore
#line 119 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
             foreach (var routeInfo in Model.routsWithEdges)
            {
                var route = routeInfo.Route;
                var airportArrival = route.airportArrival;
                var airportDeparture = route.airportDeparture;


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n\r\n\r\n                    <span class=\"border border-secondary\">\r\n                        ");
#nullable restore
#line 129 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                   Write(airportDeparture.airportName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" departure at ");
#nullable restore
#line 129 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                                                              Write(route.timeDeparture.ToLocalTime().DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" =>");
#nullable restore
#line 129 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                                                                                                            Write(airportArrival.airportName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" arrival at ");
#nullable restore
#line 129 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
                                                                                                                                                   Write(route.timeArrival.ToLocalTime().DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n");
#nullable restore
#line 132 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 134 "G:\safe routes\safe routes\Views\Home\PathFound.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PathInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
