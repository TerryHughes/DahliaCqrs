namespace Dahlia.Domain.AggregateRootSpecs
{
    using Machine.Specifications;
    using Events.MultipleVersionEvents;

    public class when_multiple_versions_of_an_event_exist
    {
        Establish context =()=>
        {
            convertedName = "converted";
            newerName = "newer";

            aggregateRoot = new TestAggregateRoot();
        };

        It should_be_able_to_handle_the_older_version =()=>
        {
            aggregateRoot.ApplyOlderEvent();

            appliedEvent.Name.ShouldEqual(convertedName);
        };

        It should_be_able_to_handle_the_newer_version =()=>
        {
            aggregateRoot.ApplyNewerEvent();

            appliedEvent.Name.ShouldEqual(newerName);
        };

        static string convertedName;
        static string newerName;
        static TestAggregateRoot aggregateRoot;
        static NewerVersion appliedEvent;

        class TestAggregateRoot : AggregateRoot
        {
            internal TestAggregateRoot()
            {
                RegisterConverter<OlderVersion, NewerVersion>(e => new NewerVersion { Name = convertedName });

                RegisterHandler<NewerVersion>(e => appliedEvent = e);
            }

            internal void ApplyOlderEvent()
            {
                Apply(new OlderVersion());
            }

            internal void ApplyNewerEvent()
            {
                Apply(new NewerVersion { Name = newerName });
            }
        }
    }
}

namespace Dahlia.Events.MultipleVersionEvents
{
    internal class OlderVersion : Event
    {
    }

    internal class NewerVersion : Event
    {
        internal string Name;
    }
}
