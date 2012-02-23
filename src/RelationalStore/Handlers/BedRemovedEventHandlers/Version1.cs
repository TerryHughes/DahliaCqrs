namespace Dahlia.RelationalStore.BedRemovedEventHandlers
{
    using System.Collections.Generic;
    using CurrentEvent = Events.BedRemovedEvent.Version1;
    using Data.Common;

    public abstract class Version1 : EventHandler<CurrentEvent>
    {
        protected Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
        }
    }
}
