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


            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(name: "ProduitDetail",
            //                url: "Products/{id}",
            //                defaults: new { controller = "Products", action = "Details" },
            //                constraints: new { id= @"\d+" }
            //    );


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
