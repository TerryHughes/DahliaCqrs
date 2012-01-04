namespace Dahlia.Domain
{
    using System;
    using Events;
    using Framework;
    using CurrentRetreatCreatedEvent = Events.RetreatCreatedEvent.Version1;

    public class Retreat : AggregateRoot
    {
        public Retreat()
        {
            RegisterHandler<CurrentRetreatCreatedEvent>(InternalApply);
        }

        public void Create(DateTime date, string description)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: (" + date + ") " + description);
            Apply(new CurrentRetreatCreatedEvent { Date = date, Description = description });
        }

        void InternalApply(CurrentRetreatCreatedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
        }
    }
}
