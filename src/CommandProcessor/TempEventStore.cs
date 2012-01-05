namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using Data.Common;
    using Events;
    using Framework;

    public class TempEventStore : EventStore
    {
        protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
        {
            var repository = new ReadRepository(new ConfigConnectionSettings("event"));
            var events = repository.All("SELECT * FROM [Events] WHERE [AggregateRootId] = @AggregateRootId ORDER BY [DateTime]", new[] { new KeyValuePair<string, object>("@AggregateRootId", aggregateRootId) });

            var formatter = new BinaryFormatter();

            foreach (var @event in events)
            {
Console.WriteLine("deserializing: " + @event.Id);
                var stream = new MemoryStream((byte[])@event.Event);

                yield return formatter.Deserialize(stream) as Event;
            }
        }

        protected override void AddEvent(Event @event)
        {
            var repository = new WriteRepository(new ConfigConnectionSettings("event"));

            repository.Do("INSERT INTO [Events] ([Id], [AggregateRootId], [Event]) VALUES (@Id, @AggregateRootId, @Event)", Pairs(@event));
        }

        IEnumerable<KeyValuePair<string, object>> Pairs(Event @event)
        {
            yield return new KeyValuePair<string, object>("@Id", @event.Id);
            yield return new KeyValuePair<string, object>("@AggregateRootId", @event.AggregateRootId);

            var stream = new MemoryStream();
/*
            // this will convert the object to a byte array but there doesnt appear to be a way to convert the byte array back to an object
            var writer = new StreamWriter(stream);
            writer.Write(@event);
            writer.Flush();
            var content = stream.GetBuffer();
*/
            new BinaryFormatter().Serialize(stream, @event);
            var content = stream.ToArray();
            Console.WriteLine("content: " + content.Length + " | " + content);
            yield return new KeyValuePair<string, object>("@Event", content);
        }
    }
}
