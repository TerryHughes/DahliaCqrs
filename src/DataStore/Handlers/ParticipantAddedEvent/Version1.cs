namespace Dahlia.DataStore.Handlers.ParticipantAddedEvent
{
    using System.Collections.Generic;
    using CurrentParticipantAddedEvent = Events.ParticipantAddedEvent.Version1;

    public class Version1 : EventHandler<CurrentParticipantAddedEvent>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [Participants] ([Id], [Name], [Note]) VALUES (@Id, @Name, @Note)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentParticipantAddedEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
            yield return new KeyValuePair<string, object>("@Note", @event.Note);
        }
    }
}
