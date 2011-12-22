namespace Dahlia.Web.Mvc
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using NServiceBus;

    public class Application : HttpApplication
    {
        public static void Register(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathinfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Register(GlobalFilters.Filters);
            Register(RouteTable.Routes);

            Configure
                .WithWeb()
                .DefaultBuilder()
                .ForMvc()
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .ImpersonateSender(false)
                .CreateBus()
                .Start();
        }
    }
}
