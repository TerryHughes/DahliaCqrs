namespace Dahlia.Events.RetreatCreatedEvent.Specs
{
    using System;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=>
        {
            aggregateRootId = Guid.NewGuid();
            date = new DateTime(2011, 06, 07);
            description = "description";
        };

        Because of =()=> @event = new Version1(aggregateRootId, date, description);

        It should_not_alter_the_aggregate_root_id =()=> @event.AggregateRootId.ShouldEqual(aggregateRootId);
        It should_not_alter_the_date =()=> @event.Date.ShouldEqual(date);
        It should_not_alter_the_description =()=> @event.Description.ShouldEqual(description);

        static Guid aggregateRootId;
        static DateTime date;
        static string description;
        static Version1 @event;
    }
}
