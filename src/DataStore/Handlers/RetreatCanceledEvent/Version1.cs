namespace Dahlia.DataStore.Handlers.RetreatCanceledEvent
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentRetreatCanceledEvent = Events.RetreatCanceledEvent.Version1;

    public class Version1 : EventHandler<CurrentRetreatCanceledEvent>
    {
        protected override string Statement
        {
            get { return "DELETE FROM [Retreats] WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentRetreatCanceledEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
