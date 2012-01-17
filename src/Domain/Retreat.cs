namespace Dahlia.Domain
{
    using System;
    using Framework;
    using CurrentRetreatScheduledEvent = Events.RetreatScheduledEvent.Version1;
    using CurrentRetreatRescheduledEvent = Events.RetreatRescheduledEvent.Version1;
    using CurrentRetreatRenamedEvent = Events.RetreatRenamedEvent.Version1;
    using CurrentRetreatCanceledEvent = Events.RetreatCanceledEvent.Version1;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedToRetreatEvent.Version2;

    public class Retreat : AggregateRoot
    {
        DateTime date;

        public Retreat()
        {
            RegisterHandler<CurrentRetreatScheduledEvent>(InternalApply);
            RegisterHandler<CurrentRetreatRescheduledEvent>(InternalApply);
            RegisterHandler<CurrentRetreatRenamedEvent>(InternalApply);
            RegisterHandler<CurrentRetreatCanceledEvent>(InternalApply);
            RegisterHandler<CurrentParticipantAddedEvent>(InternalApply);

            RegisterConverter<Events.ParticipantAddedToRetreatEvent.Version1, Events.ParticipantAddedToRetreatEvent.Version2>(e => new Events.ParticipantAddedToRetreatEvent.Version2
            {
                AggregateRootId = e.AggregateRootId,
                RetreatDate = DateTime.MinValue,
                ParticipantId = e.ParticipantId,
                ParticipantName = "how should i know what this was?"
            });
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
            Apply(new CurrentParticipantAddedEvent { RetreatDate = date, ParticipantId = participantId, ParticipantName = "how could i know?" });
        }

        void InternalApply(CurrentRetreatScheduledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
            date = @event.Date;
        }

        void InternalApply(CurrentRetreatRescheduledEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            date = @event.Date;
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
