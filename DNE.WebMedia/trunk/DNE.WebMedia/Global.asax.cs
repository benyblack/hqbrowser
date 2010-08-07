using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNE.WebMedia
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Sura", // Route name
               "sura/{id}", // URL with parameters
               new { controller = "Aya", action = "SuraDetail" }
           );

            routes.MapRoute(
         "SuraAyaService", // Route name
         "sura/{sid}/aya/{aid}.{type}", // URL with parameters
         new { controller = "Aya", action = "SuraAya" }
     );

            routes.MapRoute(
             "SuraAya", // Route name
             "sura/{sid}/aya/{aid}", // URL with parameters
             new { controller = "Aya", action = "SuraAya" }
         );

            routes.MapRoute(
               "Aya", // Route name
               "sura/aya/{id}", // URL with parameters
               new { controller = "Aya", action = "AyaDetail" }
           );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            // RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

        }
    }
}