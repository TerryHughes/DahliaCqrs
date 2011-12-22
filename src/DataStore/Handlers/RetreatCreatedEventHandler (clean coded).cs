/*
namespace Dahlia.DataStore.Handlers
{
    using System.Collections.Generic;

    public class RetreatCreatedEventHandler_Clean : EventHandler_Clean<Events.RetreatCreatedEvent.Version1>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(Events.RetreatCreatedEvent.Version1 @event)
        {
            yield return new KeyValuePair<string, object>("@Date", @event.Date);
            yield return new KeyValuePair<string, object>("@Description", @event.Description);
        }
    }
}
*/
