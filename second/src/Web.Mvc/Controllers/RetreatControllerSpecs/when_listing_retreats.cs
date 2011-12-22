namespace Dahlia.Web.Mvc.Controllers.RetreatControllerSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Machine.Specifications;
    using Dahlia.Repositories;
    using Dahlia.ViewModels;

    public class when_listing_retreats
    {
        Establish context =()=>
        {
            repository = new InMemoryRetreatRepository();
            repository.Data.Add(new RetreatViewModel { Date = new DateTime(2011, 05, 20) });
            repository.Data.Add(new RetreatViewModel { Date = new DateTime(2011, 01, 01) });
            repository.Data.Add(new RetreatViewModel { Date = new DateTime(2011, 12, 31) });
        };

        Because of =()=> retreats = (new RetreatController(repository).List() as ViewResult).ViewData.Model as IEnumerable<RetreatViewModel>;

        It should_return_all_retreats_from_the_repository_ordered_by_date =()=> retreats.SequenceEqual(repository.Data.OrderBy(r => r.Date)).ShouldBeTrue();

        static InMemoryRetreatRepository repository;
        static IEnumerable<RetreatViewModel> retreats;
    }
}
