namespace Dahlia.WebApplication.Controllers.HomeControllerSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Machine.Specifications;
    using Repositories;

    public class when_index_is_requested
    {
        Establish context =()=> controller = new HomeController(new TestProcessCommandRepository());

        Because of =()=> result = controller.Index();

        It should_be_a_RedirectToRouteResult =()=> (result as RedirectToRouteResult).ShouldNotBeNull();
        It should_redirect_to_the_retreat_controller =()=> (result as RedirectToRouteResult).RouteValues["controller"].ShouldEqual("Retreat");
        It should_redirect_to_the_list_action =()=> (result as RedirectToRouteResult).RouteValues["action"].ShouldEqual("List");

        private static HomeController controller;
        private static ActionResult result;

        class TestProcessCommandRepository : ProcessCommandRepository
        {
            public IEnumerable<Guid> CommandsSince(DateTime date)
            {
                return Enumerable.Empty<Guid>();
            }
        }
    }
}
