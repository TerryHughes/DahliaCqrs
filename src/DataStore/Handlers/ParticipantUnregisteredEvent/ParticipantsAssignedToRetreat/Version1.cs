namespace Dahlia.DataStore.Handlers.ParticipantUnregisteredEvent.ParticipantsAssignedToRetreat
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentEvent = Events.ParticipantUnregisteredEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsAssignedToRetreat] WHERE [ParticipantId] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
