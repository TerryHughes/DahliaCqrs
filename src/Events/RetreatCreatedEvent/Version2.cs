namespace Dahlia.Events.RetreatCreatedEvent
{
    using System;

    public class Version2 : Event
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Version2(Guid aggregateRootId, DateTime date, string description)
        {
            AggregateRootId = aggregateRootId;
            Date = date;
            Description = description;
        }
    }
}
