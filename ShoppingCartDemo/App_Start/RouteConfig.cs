using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCartDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(null,
               "Store", new
               {
                   controller = "Home",
                   action = "Store",
                   category = (string)null,
                   page = 1
               }
                );

            routes.MapRoute(null,
               "Store/Page{page}", new
               {
                   controller = "Home",
                   action = "Store",
                   category = (string)null,
               },
               new { page = @"\d+" }
                );

            routes.MapRoute(null,
               "Store/{category}", new
               {
                   controller = "Home",
                   action = "Store",
                   page = 1
               }
                );

            routes.MapRoute(null,
               "Store/{category}/Page{page}", new
               {
                   controller = "Home",
                   action = "Store",
               },
               new { page = @"\d+" }
                );

            routes.MapRoute(
                name: null,
                url: "Store/Page{page}",
                defaults: new { Controller = "Home", Action = "Store" }
                );

            routes.MapRoute(
                name: null,
                url: "Store/{category}/Page{page}",
                defaults: new { Controller = "Home", Action = "Store" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
