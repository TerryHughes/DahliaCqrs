namespace Dahlia.Domain
{
    using System;
    using Framework;
    using CurrentRetreatScheduledEvent = Events.RetreatScheduledEvent.Version1;
    using CurrentRetreatRescheduledEvent = Events.RetreatRescheduledEvent.Version1;
    using CurrentRetreatRenamedEvent = Events.RetreatRenamedEvent.Version1;
    using CurrentRetreatCanceledEvent = Events.RetreatCanceledEvent.Version1;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedToRetreatEvent.Version1;

    public class Retreat : AggregateRoot
    {
        public Retreat()
        {
            RegisterHandler<CurrentRetreatScheduledEvent>(InternalApply);
            RegisterHandler<CurrentRetreatRescheduledEvent>(InternalApply);
            RegisterHandler<CurrentRetreatRenamedEvent>(InternalApply);
            RegisterHandler<CurrentRetreatCanceledEvent>(InternalApply);
            RegisterHandler<CurrentParticipantAddedEvent>(InternalApply);
        }

        public void Schedule(DateTime date, string description)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: (" + date + ") " + description);
            Apply(new CurrentRetreatScheduledEvent { Date = date, Description = description });
        }

        public void Reschedule(DateTime date)
        {
            Apply(new CurrentRetreatRescheduledEvent { Date = date });
        }

        public void Rename(string description)
        {
            Apply(new CurrentRetreatRenamedEvent { Description = description });
        }

        public void Cancel()
        {
            Apply(new CurrentRetreatCanceledEvent());
        }

        public void Add(Guid participantId)
        {
            Apply(new CurrentParticipantAddedEvent { ParticipantId = participantId });
        }

        void InternalApply(CurrentRetreatScheduledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
        }

        void InternalApply(CurrentRetreatRescheduledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //date = @event.Date;
        }

        void InternalApply(CurrentRetreatRenamedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //description = @event.Description;
        }

        void InternalApply(CurrentRetreatCanceledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }

        void InternalApply(CurrentParticipantAddedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }
    }
}
