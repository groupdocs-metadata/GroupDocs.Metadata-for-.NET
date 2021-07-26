using System.Web.Mvc;
using System.Web.Routing;

namespace GroupDocs.Metadata.MVC
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Metadata", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
