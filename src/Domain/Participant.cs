namespace Dahlia.Domain
{
    using Framework;
    using CurrentRegisteredEvent = Events.ParticipantRegisteredEvent.Version1;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;
    using CurrentUnregisteredEvent = Events.ParticipantUnregisteredEvent.Version1;

    public class Participant : AggregateRoot
    {
        public Participant()
        {
            RegisterHandler<CurrentRegisteredEvent>(InternalApply);
            RegisterHandler<CurrentParticipantRenamedEvent>(InternalApply);
            RegisterHandler<CurrentUnregisteredEvent>(InternalApply);
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
            Apply(new CurrentUnregisteredEvent());
        }

        void InternalApply(CurrentRegisteredEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            Id = @event.AggregateRootId;
        }

        void InternalApply(CurrentParticipantRenamedEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }

        void InternalApply(CurrentUnregisteredEvent @event)
        {
System.Console.WriteLine("applying: " + @event.Id);
            //
        }
    }
}
