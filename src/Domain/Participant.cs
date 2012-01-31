namespace Dahlia.Domain
{
    using Framework;
    using CurrentRegisteredEvent = Events.ParticipantRegisteredEvent.Version1;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;
    using CurrentUnregisteredEvent = Events.ParticipantUnregisteredEvent.Version2;
    using CurrentSnapshottedEvent = Events.ParticipantSnapshottedEvent.Version1;

    public class Participant : AggregateRoot
    {
        string name;
        string note;

        public Participant()
        {
            RegisterHandler<CurrentRegisteredEvent>(InternalApply);
            RegisterHandler<CurrentParticipantRenamedEvent>(InternalApply);
            RegisterHandler<CurrentUnregisteredEvent>(InternalApply);
            RegisterHandler<CurrentSnapshottedEvent>(InternalApply);

            RegisterConverter<Events.ParticipantUnregisteredEvent.Version1, Events.ParticipantUnregisteredEvent.Version2>(e => new Events.ParticipantUnregisteredEvent.Version2
            {
                AggregateRootId = e.AggregateRootId,
                Name = name,
                Note = note
            });
        }

        public void Register(string name, string note)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: " + name + " (" + note + ")");
            Apply(new CurrentRegisteredEvent { Name = name, Note = note });
        }

        public void Rename(string name)
        {
            Apply(new CurrentParticipantRenamedEvent { Name = name });
        }

        public void Unregister()
        {
            Apply(new CurrentUnregisteredEvent { Name = name, Note = note });
        }

        public void Snapshot()
        {
            Apply(new CurrentSnapshottedEvent { Name = name, Note = note });
        }

        void InternalApply(CurrentRegisteredEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
            name = @event.Name;
            note = @event.Note;
        }

        void InternalApply(CurrentParticipantRenamedEvent @event)
        {
//System.Console.WriteLine("applying: " + @event.Id);
            name = @event.Name;
        }

        void InternalApply(CurrentUnregisteredEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }

        void InternalApply(CurrentSnapshottedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            name = @event.Name;
            note = @event.Note;
        }
    }
}
