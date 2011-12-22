namespace Dahlia.Domain
{
    using System;
    using Dahlia.Framework;
    using CurrentParticipantCreatedEvent = Events.ParticipantCreatedEvent.Version1;
    using CurrentParticipantNoteUpdatedEvent = Events.ParticipantNoteUpdatedEvent.Version1;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;

    public class Participant : AggregateRoot
    {
        private string firstName;
        private string lastName;

        public Participant()
        {
            RegisterHandler<CurrentParticipantCreatedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantNoteUpdatedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantRenamedEvent>(InternalApply);
        }

        public void Create(string firstName, string lastName, DateTime dateRecieved)
        {
            GuardAgainstName(firstName, lastName);

            Id = SystemGuid.NewGuid();

            Apply(new CurrentParticipantCreatedEvent(firstName, lastName, dateRecieved));
        }

        public void Rename(string firstName, string lastName)
        {
            Guard();
            GuardAgainstName(firstName, lastName);

            if (NameIsDifferent(firstName, lastName))
            {
                Apply(new CurrentParticipantRenamedEvent(firstName, lastName));
            }
        }

        public void Update(string note)
        {
            Apply(new CurrentParticipantNoteUpdatedEvent(note));
        }

        private static void GuardAgainstName(string firstName, string lastName)
        {
            EnsureNameIsValid("first", firstName);
            EnsureNameIsValid("last", lastName);
        }

        private static void EnsureNameIsValid(string part, string value)
        {
            EnsureNameIsNotNull(part, value);
            EnsureNameIsNotEmpty(part, value);
            EnsureNameIsNotOnlyWhiteSpace(part, value);
        }

        private static void EnsureNameIsNotNull(string part, string value)
        {
            if (value == null)
            {
                NameIsNotValid(part, "null");
            }
        }

        private static void EnsureNameIsNotEmpty(string part, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                NameIsNotValid(part, "empty");
            }
        }

        private static void EnsureNameIsNotOnlyWhiteSpace(string part, string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                NameIsNotValid(part, "only white space");
            }
        }

        private static void NameIsNotValid(string part, string reason)
        {
            throw new IsNotValidException("Participant's " + part + " name", "it is " + reason);
        }

        private bool NameIsDifferent(string firstName, string lastName)
        {
            return this.firstName != firstName && this.lastName != lastName;
        }

        private void InternalApply(CurrentParticipantCreatedEvent @event)
        {
            Id = @event.AggregateRootId;
            firstName = @event.FirstName;
            lastName = @event.LastName;
        }

        private void InternalApply(CurrentParticipantNoteUpdatedEvent @event)
        {
        }

        private void InternalApply(CurrentParticipantRenamedEvent @event)
        {
            firstName = @event.FirstName;
            lastName = @event.LastName;
        }
    }
}
