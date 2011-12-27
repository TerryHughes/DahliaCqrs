namespace Dahlia.DataStore.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class ProcessedCommandHandler : EventHandler<Event>
    {
        protected override string Statement
        {
            get { return "INSERT INTO [ProcessedCommands] ([Id]) VALUES (@Id)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(Event @event)
        {
            return Enumerable.Empty<KeyValuePair<string, object>>();
        }
    }
}
