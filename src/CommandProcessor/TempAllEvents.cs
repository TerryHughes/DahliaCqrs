namespace Dahlia.EventStores
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using Data.Common;
    using Events;
    using Framework;

    public class TempAllEvents
    {
        public IEnumerable<Event> GetAll()
        {
            var repository = new ReadRepository(new ConfigConnectionSettings("event"));
            var events = repository.All("SELECT * FROM [Events] WHERE [AggregateRootId] != 'e20193e2-3fac-41ed-9bd1-0d6d61d65c97' ORDER BY [DateTime]", Enumerable.Empty<KeyValuePair<string, object>>());
            //var events = repository.All("SELECT * FROM [Events] ORDER BY [DateTime]", Enumerable.Empty<KeyValuePair<string, object>>());

            var formatter = new BinaryFormatter();

            foreach (var @event in events)
            {
                var stream = new MemoryStream((byte[])@event.Event);

                yield return formatter.Deserialize(stream) as Event;
            }
        }
    }
}
