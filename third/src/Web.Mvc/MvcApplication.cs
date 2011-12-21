namespace Dahlia.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Register(GlobalFilters.Filters);
            Register(RouteTable.Routes);

            AppStart();
        }

        protected virtual void AppStart()
        {
        }

        static void Register(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathinfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
