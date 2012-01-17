namespace Dahlia.DataStore.Handlers.ParticipantRenamedEvent.ParticipantsAssignedToRetreat
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantRenamedEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [ParticipantsAssignedToRetreat] SET [ParticipantName] = @Name WHERE [ParticipantId] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
        }
    }
}
