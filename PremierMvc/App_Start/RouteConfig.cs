using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PremierMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


              routes.MapRoute(
                  name: "allo",
                  url: "allo/{prenom}/{nom}",
                  defaults: new { controller = "Horloge", action = "Test" }
              );


            routes.MapRoute(
              name: "bonjour",
              url: "bonjour/{prenom}/{nom}",
              defaults: new { controller = "Horloge", action = "Test"}
          );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
