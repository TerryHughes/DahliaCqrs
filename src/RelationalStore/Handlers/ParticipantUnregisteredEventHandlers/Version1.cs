namespace Dahlia.RelationalStore.ParticipantUnregisteredEventHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentEvent = Events.ParticipantUnregisteredEvent.Version1;
    using Data.Common;

    public abstract class Version1 : EventHandler<CurrentEvent>
    {
        protected Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
