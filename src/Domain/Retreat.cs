namespace Dahlia.Domain
{
    using System;
    using Framework;
    using CurrentRetreatScheduledEvent = Events.RetreatScheduledEvent.Version1;
    using CurrentRetreatRescheduledEvent = Events.RetreatRescheduledEvent.Version1;
    using CurrentRetreatRenamedEvent = Events.RetreatRenamedEvent.Version1;
    using CurrentRetreatCanceledEvent = Events.RetreatCanceledEvent.Version1;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedToRetreatEvent.Version2;
    using CurrentParticipantRemovedEvent = Events.ParticipantRemovedFromRetreatEvent.Version1;
    using CurrentParticipantAssignedEvent = Events.ParticipantAssignedToRetreatEvent.Version1;
    using CurrentParticipantUnassignedEvent = Events.ParticipantUnassignedFromRetreatEvent.Version1;

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
            RegisterHandler<CurrentParticipantRemovedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantAssignedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantUnassignedEvent>(InternalApply);

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
            EnsureDescriptionIsValid(description);

            Id = SystemGuid.NewGuid();

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

        public void Remove(Guid participantId)
        {
            Apply(new CurrentParticipantRemovedEvent { RetreatDate = date, ParticipantId = participantId, ParticipantName = "how could i know?" });
        }

        public void Assign(Guid participantId, Guid bedId)
        {
            Apply(new CurrentParticipantAssignedEvent { ParticipantId = participantId, ParticipantName = "how could i know?", BedId = bedId, BedName = "its comfy?" });
        }

        public void Unassign(Guid participantId)
        {
            Apply(new CurrentParticipantUnassignedEvent { ParticipantId = participantId, ParticipantName = "how could i know?"/*, BedId = bedId*/, BedName = "its comfy?" });
        }

        static void EnsureDescriptionIsValid(string description)
        {
            EnsureDescriptionIsNotNull(description);
            EnsureDescriptionIsNotEmpty(description);
            EnsureDescriptionIsNotOnlyWhiteSpace(description);
        }

        static void EnsureDescriptionIsNotNull(string description)
        {
            if (description == null)
                DescriptionIsNotValid("null");
        }

        static void EnsureDescriptionIsNotEmpty(string description)
        {
            if (String.IsNullOrEmpty(description))
                DescriptionIsNotValid("empty");
        }

        static void EnsureDescriptionIsNotOnlyWhiteSpace(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
                DescriptionIsNotValid("only white space");
        }

        static void DescriptionIsNotValid(string reason)
        {
            throw new IsNotValidException("Retreat's description", "it is " + reason);
        }

        void InternalApply(CurrentRetreatScheduledEvent @event)
        {
            Id = @event.AggregateRootId;
            date = @event.Date;
        }

        void InternalApply(CurrentRetreatRescheduledEvent @event)
        {
            date = @event.Date;
        }

        void InternalApply(CurrentRetreatRenamedEvent @event)
        {
        }

        void InternalApply(CurrentRetreatCanceledEvent @event)
        {
        }

        void InternalApply(CurrentParticipantAddedEvent @event)
        {
        }

        void InternalApply(CurrentParticipantRemovedEvent @event)
        {
        }

        void InternalApply(CurrentParticipantAssignedEvent @event)
        {
        }

        void InternalApply(CurrentParticipantUnassignedEvent @event)
        {
        }
    }
}
