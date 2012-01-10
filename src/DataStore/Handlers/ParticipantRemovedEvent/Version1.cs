namespace Dahlia.DataStore.Handlers.ParticipantRemovedEvent
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentEvent = Events.ParticipantRemovedEvent.Version1;

    public class Version1 : EventHandler<CurrentEvent>
    {
        protected override string Statement
        {
            get { return "DELETE FROM [Participants] WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
