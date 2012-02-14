namespace Dahlia.Domain
{
    using Framework;
    using CurrentAddedEvent = Events.BedAddedEvent.Version1;
    using CurrentRenamedEvent = Events.BedRenamedEvent.Version1;
    using CurrentRemovedEvent = Events.BedRemovedEvent.Version1;

    public class Bed : AggregateRoot
    {
        string name;

        public Bed()
        {
            RegisterHandler<CurrentAddedEvent>(InternalApply);
            RegisterHandler<CurrentRenamedEvent>(InternalApply);
            RegisterHandler<CurrentRemovedEvent>(InternalApply);
        }

        public void Add(string name)
        {
            Id = SystemGuid.NewGuid();
System.Console.WriteLine("creating: " + name);
            Apply(new CurrentAddedEvent { Name = name });
        }

        public void Rename(string name)
        {
            Apply(new CurrentRenamedEvent { Name = name });
        }

        public void Remove()
        {
            Apply(new CurrentRemovedEvent { Name = name });
        }

        void InternalApply(CurrentAddedEvent @event)
        {
            Id = @event.AggregateRootId;
            name = @event.Name;
        }

        void InternalApply(CurrentRenamedEvent @event)
        {
            name = @event.Name;
        }

        void InternalApply(CurrentRemovedEvent @event)
        {
            //
        }
    }
}
