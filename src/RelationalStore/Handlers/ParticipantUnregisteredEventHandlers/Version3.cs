namespace Dahlia.RelationalStore.ParticipantUnregisteredEventHandlers
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantUnregisteredEvent.Version3;
    using Data.Common;

    public abstract class Version3 : EventHandler<CurrentEvent>
    {
        protected Version3(WriteRepository repository) : base(repository)
        {
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
            yield return new KeyValuePair<string, object>("@Note", @event.Note);
            yield return new KeyValuePair<string, object>("@DateRecieved", @event.DateRecieved);
        }
    }
}
