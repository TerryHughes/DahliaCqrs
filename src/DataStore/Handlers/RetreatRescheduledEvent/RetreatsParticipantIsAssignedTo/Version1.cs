namespace Dahlia.DataStore.Handlers.RetreatRescheduledEvent.RetreatsParticipantIsAssignedTo
{
    using System.Collections.Generic;
    using CurrentEvent = Events.RetreatRescheduledEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [RetreatsParticipantIsAssignedTo] SET [RetreatDate] = @Date WHERE [RetreatId] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Date", @event.Date);
        }
    }
}
