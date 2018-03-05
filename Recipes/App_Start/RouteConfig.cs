using System.Web.Mvc;
using System.Web.Routing;

namespace Recipes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Recipe", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
