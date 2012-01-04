namespace Dahlia.AggregateRootNotCreatedExceptionSpecifications
{
    using Dahlia.Domain;
    using Machine.Specifications;

    public class when_initializing_a_AggregateRootNotCreatedException
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> exception = new AggregateRootNotCreatedException(aggregateRoot);

        It should_have_a_useful_message =()=> exception.Message.ShouldEqual("The " + aggregateRoot.GetType() + " was not created");

        It should_say_what_type_of_aggregate_root_was_involved =()=> exception.AggregateRoot.ShouldEqual(aggregateRoot.GetType());

        static TestAggregateRoot aggregateRoot;
        static AggregateRootNotCreatedException exception;

        private class TestAggregateRoot : AggregateRoot
        {
        }
    }
}
