using lodgify_RPS_Server.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lodgify_RPS_Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "api/Play/playOneGame/{playOptionString}",
                defaults: new { controller = "Play", action = "playOneGame" }
            );
        }
    }
}
