namespace Dahlia.RelationalStore.ParticipantRegisteredEventHandlers
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantRegisteredEvent.Version2;
    using Data.Common;

    public abstract class Version2 : EventHandler<CurrentEvent>
    {
        protected Version2(WriteRepository repository) : base(repository)
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
