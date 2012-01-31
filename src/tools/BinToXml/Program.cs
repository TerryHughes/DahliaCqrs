namespace Dahlia.BinToXml
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    using Data.Common;
    using Events;
    using Framework;

    static class Program
    {
        static void Main(string[] args)
        {
            var readRepository = new ReadRepository(new ConfigConnectionSettings("event"));
            var writeRepository = new WriteRepository(new ConfigConnectionSettings("event"));

            var binaryFormatter = new BinaryFormatter();

            var snapshots = readRepository.All("SELECT * FROM [Snapshots] ORDER BY [DateTime]", Enumerable.Empty<KeyValuePair<string, object>>());

            foreach (var snapshot in snapshots)
            {
                var actual = binaryFormatter.Deserialize(new MemoryStream((byte[])snapshot.Snapshot)) as Event;

                var stream = new MemoryStream();
                new XmlSerializer(actual.GetType()).Serialize(stream, actual);
                var content = stream.ToArray();

                var xmlpair = new KeyValuePair<string, object>("@Xml", content);
                var typepair = new KeyValuePair<string, object>("@Type", actual.ToString());
                var idpair = new KeyValuePair<string, object>("@Id", snapshot.Id);

                writeRepository.Do("UPDATE [Snapshots] SET [SnapshotXml] = @Xml, [Type] = @Type WHERE [Id] = @Id", new[] { xmlpair, typepair, idpair });
            }

            var events = readRepository.All("SELECT * FROM [Events] ORDER BY [DateTime]", Enumerable.Empty<KeyValuePair<string, object>>());

            foreach (var @event in events)
            {
                var actual = binaryFormatter.Deserialize(new MemoryStream((byte[])@event.Event)) as Event;

                var stream = new MemoryStream();
                new XmlSerializer(actual.GetType()).Serialize(stream, actual);
                var content = stream.ToArray();

                var xmlpair = new KeyValuePair<string, object>("@Xml", content);
                var typepair = new KeyValuePair<string, object>("@Type", actual.ToString());
                var idpair = new KeyValuePair<string, object>("@Id", @event.Id);
System.Threading.Thread.Sleep(10);
                writeRepository.Do("UPDATE [Events] SET [EventXml] = @Xml, [Type] = @Type WHERE [Id] = @Id", new[] { xmlpair, typepair, idpair });
            }
        }
    }
}
