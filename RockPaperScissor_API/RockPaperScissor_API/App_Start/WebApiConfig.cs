using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RockPaperScissor_API.Logic;

namespace RockPaperScissor_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /* config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );*/

            config.Routes.MapHttpRoute(
                name: "playApiCall",
                routeTemplate: "api/playOneGame/{playerPlay}",
                defaults: new { controller = "Play", action = "playOneGame" },
                constraints: new { playerPlay = getPlayOptions ()}
            );
        }

        private static string getPlayOptions()
        {
            var options = Enum.GetNames(typeof(playOption));
            return string.Join("|", options);
        }
    }
}
