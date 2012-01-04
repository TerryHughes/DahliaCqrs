namespace Dahlia.Domain
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Framework;
    using CurrentRetreatCreatedEvent = Events.RetreatCreatedEvent.Version1;
    using CurrentParticipantAddedToRetreatEvent = Events.ParticipantAddedToRetreatEvent.Version1;

    public class Retreat : AggregateRoot
    {
        private readonly ICollection<Guid> participants;

        public Retreat()
        {
            participants = new List<Guid>();

            RegisterHandler<CurrentRetreatCreatedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantAddedToRetreatEvent>(InternalApply);
        }

        public void Create(string name, DateTime date)
        {
            EnsureNameIsValid(name);

            Id = SystemGuid.NewGuid();

            Apply(new CurrentRetreatCreatedEvent(name, date));
        }

        public void Add(Participant participant)
        {
            Guard();
            EnsureParticipantIsCreated(participant);
            EnsureParticipantIsNotOnList(participant);

            //Apply(new CurrentParticipantAddedToRetreatEvent(participant.Id));
        }

        private static void EnsureNameIsValid(string name)
        {
            EnsureNameIsNotNull(name);
            EnsureNameIsNotEmpty(name);
            EnsureNameIsNotOnlyWhiteSpace(name);
        }

        private static void EnsureNameIsNotNull(string name)
        {
            if (name == null)
            {
                NameIsNotValid("null");
            }
        }

        private static void EnsureNameIsNotEmpty(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                NameIsNotValid("empty");
            }
        }

        private static void EnsureNameIsNotOnlyWhiteSpace(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                NameIsNotValid("only white space");
            }
        }

        private static void NameIsNotValid(string reason)
        {
            throw new IsNotValidException("Retreat's name", "it is " + reason);
        }

        private static void EnsureParticipantIsCreated(Participant participant)
        {
            //if (participant.Id == Guid.Empty)
            //{
            //    throw new AggregateRootNotCreatedException(participant);
            //}
        }

        private void EnsureParticipantIsNotOnList(Participant participant)
        {
            //if (participants.Contains(participant.Id))
            //{
            //    throw new InvalidOperationException("Participant is already on the list");
            //}
        }

        private void InternalApply(CurrentRetreatCreatedEvent @event)
        {
            Id = @event.AggregateRootId;
        }

        private void InternalApply(CurrentParticipantAddedToRetreatEvent @event)
        {
            participants.Add(@event.ParticipantId);
        }
    }
}
