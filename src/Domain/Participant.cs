namespace Dahlia.Domain
{
    using System;
    using Framework;
    using CurrentRegisteredEvent = Events.ParticipantRegisteredEvent.Version2;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;
    using CurrentUnregisteredEvent = Events.ParticipantUnregisteredEvent.Version3;
    using CurrentSnapshottedEvent = Events.ParticipantSnapshottedEvent.Version2;

    public class Participant : AggregateRoot
    {
        string name;
        string note;
        DateTime dateRecieved;

        public Participant()
        {
            RegisterHandler<CurrentRegisteredEvent>(InternalApply);
            RegisterHandler<CurrentParticipantRenamedEvent>(InternalApply);
            RegisterHandler<CurrentUnregisteredEvent>(InternalApply);
            RegisterHandler<CurrentSnapshottedEvent>(InternalApply);

            RegisterConverter<Events.ParticipantRegisteredEvent.Version1, Events.ParticipantRegisteredEvent.Version2>(e => new Events.ParticipantRegisteredEvent.Version2
            {
                AggregateRootId = e.AggregateRootId,
                Name = e.Name,
                Note = e.Note,
                DateRecieved = new DateTime(1950, 01, 01)
            });
            RegisterConverter<Events.ParticipantUnregisteredEvent.Version1, Events.ParticipantUnregisteredEvent.Version2>(e => new Events.ParticipantUnregisteredEvent.Version2
            {
                AggregateRootId = e.AggregateRootId,
                Name = name,
                Note = note
            });
            RegisterConverter<Events.ParticipantUnregisteredEvent.Version2, Events.ParticipantUnregisteredEvent.Version3>(e => new Events.ParticipantUnregisteredEvent.Version3
            {
                AggregateRootId = e.AggregateRootId,
                Name = e.Name,
                Note = e.Note,
                DateRecieved = dateRecieved
            });
            RegisterConverter<Events.ParticipantSnapshottedEvent.Version1, Events.ParticipantSnapshottedEvent.Version2>(e => new Events.ParticipantSnapshottedEvent.Version2
            {
                AggregateRootId = e.AggregateRootId,
                Name = e.Name,
                Note = e.Note,
                DateRecieved = new DateTime(1950, 01, 01)
            });
        }

        public void Register(string name, string note, DateTime dateRecieved)
        {
            EnsureNameIsValid(name);

            Id = SystemGuid.NewGuid();

            Apply(new CurrentRegisteredEvent { Name = name, Note = note, DateRecieved = dateRecieved });
        }

        public void Rename(string name)
        {
            Gaurd();
            EnsureNameIsValid(name);

            if (NameIsDifferent(name))
                Apply(new CurrentParticipantRenamedEvent { Name = name });
        }

        public void Unregister()
        {
            Apply(new CurrentUnregisteredEvent { Name = name, Note = note, DateRecieved = dateRecieved });
        }

        public void Snapshot()
        {
            Apply(new CurrentSnapshottedEvent { Name = name, Note = note, DateRecieved = dateRecieved });
        }

        static void EnsureNameIsValid(string name)
        {
            EnsureNameIsNotNull(name);
            EnsureNameIsNotEmpty(name);
            EnsureNameIsNotOnlyWhiteSpace(name);
        }

        static void EnsureNameIsNotNull(string name)
        {
            if (name == null)
                NameIsNotValid("null");
        }

        static void EnsureNameIsNotEmpty(string name)
        {
            if (String.IsNullOrEmpty(name))
                NameIsNotValid("empty");
        }

        static void EnsureNameIsNotOnlyWhiteSpace(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                NameIsNotValid("only white space");
        }

        static void NameIsNotValid(string reason)
        {
            throw new IsNotValidException("Participant's name", "it is " + reason);
        }

        bool NameIsDifferent(string name)
        {
            return this.name != name;
        }

        void InternalApply(CurrentRegisteredEvent @event)
        {
            Id = @event.AggregateRootId;
            name = @event.Name;
            note = @event.Note;
            dateRecieved = @event.DateRecieved;
        }

        void InternalApply(CurrentParticipantRenamedEvent @event)
        {
            name = @event.Name;
        }

        void InternalApply(CurrentUnregisteredEvent @event)
        {
        }

        void InternalApply(CurrentSnapshottedEvent @event)
        {
            name = @event.Name;
            note = @event.Note;
            dateRecieved = @event.DateRecieved;
        }
    }
}
