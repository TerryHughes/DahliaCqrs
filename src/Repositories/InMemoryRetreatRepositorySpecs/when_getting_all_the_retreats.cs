namespace Dahlia.Repositories.InMemoryRetreatRepositorySpecs
{
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Dahlia.ViewModels;

    public class when_getting_all_the_retreats
    {
        Establish context =()=>
        {
            repository = new InMemoryRetreatRepository();

            retreatCount = 3;
            for (var i = 0; i < retreatCount; i++)
            {
                repository.Data.Add(new RetreatViewModel());
            }
        };

        Because of =()=> retreats = repository.GetAllAsDynamic();

        It should_return_all_the_retreats =()=> retreats.Count().ShouldEqual(retreatCount);

        static int retreatCount;
        static InMemoryRetreatRepository repository;
        static IEnumerable<dynamic> retreats;
    }
}
