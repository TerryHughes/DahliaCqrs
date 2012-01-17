namespace Dahlia.DataStore.Handlers.ParticipantAddedToRetreatEvent.ParticipantsAssignedToRetreat
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
            get { return "INSERT INTO [ParticipantsAssignedToRetreat] ([RetreatId], [ParticipantId], [ParticipantName]) VALUES (@RetreatId, @ParticipantId, (SELECT [Name] FROM [Participants] WHERE [Id] = @ParticipantId))"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentParticipantAddedEvent @event)
        {
            yield return new KeyValuePair<string, object>("@RetreatId", @event.AggregateRootId);
            yield return new KeyValuePair<string, object>("@ParticipantId", @event.ParticipantId);
        }
    }
}
