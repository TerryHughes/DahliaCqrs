namespace Dahlia.DataStore.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Common;
    using Events;

    public class ProcessedCommandHandler : EventHandler<Event>
    {
        public ProcessedCommandHandler(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [ProcessedCommands] ([Id]) VALUES (@CommandId)"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(Event @event)
        {
            yield return new KeyValuePair<string, object>("@CommandId", @event.CommandId);
        }
    }
}
