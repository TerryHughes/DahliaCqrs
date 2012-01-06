namespace Dahlia.DataStore.Handlers.RetreatRescheduledEvent
{
    using System.Collections.Generic;
    using CurrentRetreatRescheduledEvent = Events.RetreatRescheduledEvent.Version1;

    public class Version1 : EventHandler<CurrentRetreatRescheduledEvent>
    {
        protected override string Statement
        {
            get { return "UPDATE [Retreats] SET [Date] = @Date WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentRetreatRescheduledEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Date", @event.Date);
        }
    }
}
