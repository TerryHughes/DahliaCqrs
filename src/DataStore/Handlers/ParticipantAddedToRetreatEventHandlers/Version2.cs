namespace Dahlia.DataStore.ParticipantAddedToRetreatEventHandlers
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantAddedToRetreatEvent.Version2;
    using Data.Common;

    public abstract class Version2 : EventHandler<CurrentEvent>
    {
        protected Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@RetreatId", @event.AggregateRootId);
            yield return new KeyValuePair<string, object>("@RetreatDate", @event.RetreatDate);
            yield return new KeyValuePair<string, object>("@ParticipantId", @event.ParticipantId);
            yield return new KeyValuePair<string, object>("@ParticipantName", @event.ParticipantName);
        }
    }
}
