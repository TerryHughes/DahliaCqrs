namespace Dahlia.Domain
{
    using Framework;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedEvent.Version1;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;
    using CurrentRemovedEvent = Events.ParticipantRemovedEvent.Version1;

    public class Participant : AggregateRoot
    {
        public Participant()
        {
            RegisterHandler<CurrentParticipantAddedEvent>(InternalApply);
            RegisterHandler<CurrentParticipantRenamedEvent>(InternalApply);
            RegisterHandler<CurrentRemovedEvent>(InternalApply);
        }

        public void Create(string name, string note)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: " + name + " (" + note + ")");
            Apply(new CurrentParticipantAddedEvent { Name = name, Note = note });
        }

        public void Rename(string name)
        {
            Apply(new CurrentParticipantRenamedEvent { Name = name });
        }

        public void Remove()
        {
            Apply(new CurrentRemovedEvent());
        }

        void InternalApply(CurrentParticipantAddedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
        }

        void InternalApply(CurrentParticipantRenamedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }

        void InternalApply(CurrentRemovedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }
    }
}
