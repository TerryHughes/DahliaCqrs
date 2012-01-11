namespace Dahlia.DataStore.Handlers.ParticipantRegisteredEvent
{
    using System.Collections.Generic;
    using CurrentEvent = Events.ParticipantRegisteredEvent.Version1;

    public class Version1 : EventHandler<CurrentEvent>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [Participants] ([Id], [Name], [Note]) VALUES (@Id, @Name, @Note)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Name", @event.Name);
            yield return new KeyValuePair<string, object>("@Note", @event.Note);
        }
    }
}
