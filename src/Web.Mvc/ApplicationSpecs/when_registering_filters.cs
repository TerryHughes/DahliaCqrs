namespace Dahlia.Web.Mvc.ApplicationSpecs
{
    using System.Linq;
    using System.Web.Mvc;
    using Machine.Specifications;

    public class when_registering_filters
    {
        Establish context =()=> filters = new GlobalFilterCollection();

        Because of =()=> Application.Register(filters);

        It should_add_one_filter =()=> filters.Count.ShouldEqual(1);
        It should_add_HandleErrorAttribute =()=> (filters.First().Instance is HandleErrorAttribute).ShouldBeTrue();

        static GlobalFilterCollection filters;
    }
}
