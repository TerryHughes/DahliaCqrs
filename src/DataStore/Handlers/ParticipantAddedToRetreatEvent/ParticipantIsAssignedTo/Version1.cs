namespace Dahlia.DataStore.Handlers.ParticipantAddedToRetreatEvent.RetreatsParticipantIsAssignedTo
{
    using System.Collections.Generic;
    using System.Linq;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedToRetreatEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentParticipantAddedEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsParticipantIsAssignedTo] ([ParticipantId], [RetreatId], [RetreatDate]) VALUES (@ParticipantId, @RetreatId, (SELECT [Date] FROM [Retreats] WHERE [Id] = @RetreatId))"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentParticipantAddedEvent @event)
        {
            yield return new KeyValuePair<string, object>("@ParticipantId", @event.ParticipantId);
            yield return new KeyValuePair<string, object>("@RetreatId", @event.AggregateRootId);
        }
    }
}
