namespace Dahlia.DataStore.Handlers.ParticipantRenamedEvent
{
    using System.Collections.Generic;
    using CurrentParticipantRenamedEvent = Events.ParticipantRenamedEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentParticipantRenamedEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [Participants] SET [Name] = @Name WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentParticipantRenamedEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
        }
    }
}
