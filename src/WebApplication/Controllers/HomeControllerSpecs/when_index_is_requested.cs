namespace Dahlia.WebApplication.Controllers.HomeControllerSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Machine.Specifications;

    public class when_index_is_requested
    {
        Establish context =()=> controller = new HomeController();

        Because of =()=> result = controller.Index();

        It should_be_a_RedirectToRouteResult =()=> (result as RedirectToRouteResult).ShouldNotBeNull();
        It should_redirect_to_the_retreat_controller =()=> (result as RedirectToRouteResult).RouteValues["controller"].ShouldEqual("Retreat");
        It should_redirect_to_the_list_action =()=> (result as RedirectToRouteResult).RouteValues["action"].ShouldEqual("Current");

        private static HomeController controller;
        private static ActionResult result;
    }
}
