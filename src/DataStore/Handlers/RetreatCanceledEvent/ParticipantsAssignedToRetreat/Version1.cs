namespace Dahlia.DataStore.Handlers.RetreatCanceledEvent.ParticipantsAssignedToRetreat
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentEvent = Events.RetreatCanceledEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsAssignedToRetreat] WHERE [RetreatId] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
