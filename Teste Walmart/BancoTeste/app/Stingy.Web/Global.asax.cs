using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Stingy.Infra.IoC;

namespace Stingy.Web
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            IoC.RegistrarModulos();
        }

        protected void Application_BeginRequest()
        {
            IoC.IniciarHttpRequest();
        }

        protected void Application_EndRequest()
        {
            IoC.TerminarHttpRequest();
        }
    }
}