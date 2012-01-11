namespace Dahlia.DataStore.Handlers.ParticipantUnregisteredEvent
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentEvent = Events.ParticipantUnregisteredEvent.Version1;

    public class Version1 : EventHandler<CurrentEvent>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [RemovedParticipants] SELECT * FROM [Participants] WHERE [Id] = @Id;DELETE FROM [Participants] WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
