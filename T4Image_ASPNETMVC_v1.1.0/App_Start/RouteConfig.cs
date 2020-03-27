using System.Web.Mvc;
using System.Web.Routing;

namespace T4Image_ASPNETMVC_v1._1._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.RouteExistingFiles = true;
            //routes.MapRoute(
            //    name: "Images",
            //    url: "Images/{*url}",
            //    defaults: new { controller = "Image", action = "Index" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
