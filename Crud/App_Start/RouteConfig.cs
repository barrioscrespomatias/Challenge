using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Crud
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                //url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Usuarios", action = "Index", id = UrlParameter.Optional }
                name: "Default",                
                url: "{controller}/{action}/{id}",                
                defaults: new { controller = "Usuarios", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
