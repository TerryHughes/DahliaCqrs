namespace Dahlia.Domain
{
    using System;
    using Events;
    using Framework;
    using CurrentRetreatScheduledEvent = Events.RetreatScheduledEvent.Version1;

    public class Retreat : AggregateRoot
    {
        public Retreat()
        {
            RegisterHandler<CurrentRetreatScheduledEvent>(InternalApply);
        }

        public void Schedule(DateTime date, string description)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: (" + date + ") " + description);
            Apply(new CurrentRetreatScheduledEvent { Date = date, Description = description });
        }

        void InternalApply(CurrentRetreatScheduledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
        }
    }
}
