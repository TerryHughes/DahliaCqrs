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

    public class DahliaEventStore : EventStore
    {
        readonly ReadRepository readRepository;
        readonly WriteRepository writeRepository;

        public DahliaEventStore()
        {
            readRepository = new ReadRepository(new ConfigConnectionSettings("event"));
            writeRepository = new WriteRepository(new ConfigConnectionSettings("event"));
        }
readonly DateTime epoch = new DateTime(1979, 07, 09);
        public IEnumerable<Event> EventsFor(Guid aggregateRootId)
        {
            var idpair = new KeyValuePair<string, object>("@AggregateRootId", aggregateRootId);

            var snapshots = readRepository.All("SELECT * FROM [Snapshots] WHERE [AggregateRootId] = @AggregateRootId ORDER BY [DateTime] DESC", new[] { idpair });
            var snapshot = snapshots.FirstOrDefault();
            var date = epoch;
            if (snapshot != null)
                date = snapshot.DateTime;

            var events = readRepository.All("SELECT * FROM [Events] WHERE [AggregateRootId] = @AggregateRootId AND [DateTime] > @Date ORDER BY [DateTime]", new[] { idpair, new KeyValuePair<string, object>("@Date", date) });

            var formatter = new BinaryFormatter();

            if (date > epoch)
                yield return formatter.Deserialize(new MemoryStream((byte[])snapshot.Snapshot)) as Event;

            foreach (var @event in events)
            {
//Console.WriteLine("deserializing: " + @event.Id);
                var stream = new MemoryStream((byte[])@event.Event);

                yield return formatter.Deserialize(stream) as Event;
            }
        }

        public void AddEvent(Event @event)
        {
            var snapshot = @event as Events.ParticipantSnapshottedEvent.Version1;

            if (snapshot == null)
                writeRepository.Do("INSERT INTO [Events] ([Id], [AggregateRootId], [Event]) VALUES (@Id, @AggregateRootId, @Event)", Pairs(@event));
            else
                writeRepository.Do("INSERT INTO [Snapshots] ([Id], [AggregateRootId], [Snapshot]) VALUES (@Id, @AggregateRootId, @Event)", Pairs(@snapshot));
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
