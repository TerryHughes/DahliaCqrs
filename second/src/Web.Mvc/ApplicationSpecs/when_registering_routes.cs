namespace Dahlia.Web.Mvc.ApplicationSpecs
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Machine.Specifications;

    public class when_registering_routes
    {
        Establish context =()=> routes = new RouteCollection();

        Because of =()=> Application.Register(routes);

        It should_add_two_routes =()=> routes.Count.ShouldEqual(2);
        It should_add_ignore =()=>
        {
            (routes["Default"] is Route).ShouldBeTrue();
            (routes[0] as Route).Url.ShouldEqual("{resource}.axd/{*pathinfo}");
        };
        It should_add_default =()=>
        {
            routes["Default"].ShouldNotBeNull();
            (routes["Default"] is Route).ShouldBeTrue();
        };
        It should_define_the_url_for_the_default_route =()=> (routes["Default"] as Route).Url.ShouldEqual("{controller}/{action}/{id}");
        It should_define_the_default_controller_for_the_default_route =()=> (routes["Default"] as Route).Defaults["controller"].ShouldEqual("Home");
        It should_define_the_default_action_for_the_default_route =()=> (routes["Default"] as Route).Defaults["action"].ShouldEqual("Index");
        It should_define_the_default_id_for_the_default_route =()=> (routes["Default"] as Route).Defaults["id"].ShouldEqual(UrlParameter.Optional);

        static RouteCollection routes;
    }
}
