namespace Dahlia.DataStore.Handlers.RetreatScheduledEvent
{
    using System.Collections.Generic;
    using CurrentRetreatScheduledEvent = Events.RetreatScheduledEvent.Version1;

    public class Version1 : EventHandler<CurrentRetreatScheduledEvent>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentRetreatScheduledEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Date", @event.Date);
            yield return new KeyValuePair<string, object>("@Description", @event.Description);
        }
    }
}