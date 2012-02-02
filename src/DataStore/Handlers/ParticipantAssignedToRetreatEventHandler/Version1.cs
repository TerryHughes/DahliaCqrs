namespace Dahlia.DataStore.ParticipantAssignedToRetreatEventHandlers
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantAssignedToRetreatEvent.Version1;
    using Data.Common;

    public abstract class Version1 : EventHandler<CurrentEvent>
    {
        protected Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@RetreatId", @event.AggregateRootId);
            yield return new KeyValuePair<string, object>("@ParticipantId", @event.ParticipantId);
            yield return new KeyValuePair<string, object>("@BedId", @event.BedId);
        }
    }
}
