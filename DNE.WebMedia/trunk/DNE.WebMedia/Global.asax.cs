using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNE.WebMedia {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "SuraIndex", // Route name
            "SuraIndex/", // URL with parameters
            new { controller = "Aya", action = "SuraIndex" }
        );

            routes.MapRoute(
            "PageIndex", // Route name
            "PageIndex/", // URL with parameters
            new { controller = "Aya", action = "PageIndex" }
        );

            routes.MapRoute(
            "PagesApi", // Route name
            "pages/{pageno}.{type}", // URL with parameters
            new { controller = "Aya", action = "Page", pageno = 1 }
        );

            routes.MapRoute(
             "Pages", // Route name
             "pages/{pageno}", // URL with parameters
             new { controller = "Aya", action = "Page", pageno = 1 }
         );

            routes.MapRoute(
              "Page", // Route name
              "page/{pageno}", // URL with parameters
              new { controller = "Aya", action = "Page", pageno = 1 }
          );
            routes.MapRoute(
              "PagesPartial", // Route name
              "pagespartial/{pageno}", // URL with parameters
              new { controller = "Aya", action = "PagePartial", pageno = 1 }
          );


            routes.MapRoute(
              "SuraApi", // Route name
              "sura/{id}.{type}", // URL with parameters
              new { controller = "Aya", action = "SuraDetail" }
          );

            routes.MapRoute(
               "Sura", // Route name
               "sura/{id}", // URL with parameters
               new { controller = "Aya", action = "SuraDetail" }
           );


            routes.MapRoute(
         "SuraAyaService", // Route name
         "aya/{sid}/{aid}.{type}", // URL with parameters
         new { controller = "Aya", action = "SuraAya" }
     );

            routes.MapRoute(
             "SuraAya", // Route name
             "aya/{sid}/{aid}", // URL with parameters
             new { controller = "Aya", action = "SuraAya" }
         );

            routes.MapRoute(
                         "TranslateAya", // Route name
                         "translate/{suraid}/{ayaid}/{langid}", // URL with parameters
                         new { controller = "Aya", action = "Translate" }
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

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
 //          RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

        }
    }
}