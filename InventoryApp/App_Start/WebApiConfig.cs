using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace InventoryApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            config.Routes.MapHttpRoute(
              name: "TrackingsRoute",
              routeTemplate: "api/v1/inventoryitems/{inventoryItemId}/trackings/{id}",
              defaults: new { controller = "trackings", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "LocationsRoute",
                routeTemplate: "api/v1/locations/{id}",
                defaults: new { controller = "Locations", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/inventoryitems/{id}",
                defaults: new { controller = "InventoryItems", id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}