namespace Dahlia.DataStore
{
    using System.Collections.Generic;
    using System.Linq;
    using NServiceBus;
    using Data.Common;
    using Events;
    using Framework;

    public class DatabaseInitializer : IWantToRunAtStartup
    {
        readonly IBus bus;

        public DatabaseInitializer(IBus bus)
        {
            this.bus = bus;
        }

        public void Run()
        {
            EmptyTheDatabase();
            PopulateTheDatabase();
        }

        public void Stop()
        {
        }

        void EmptyTheDatabase()
        {
            var repository = new WriteRepository(new ConfigConnectionSettings("data"));

            repository.Do("TRUNCATE TABLE [ProcessedCommands]", Enumerable.Empty<KeyValuePair<string, object>>());
            repository.Do("TRUNCATE TABLE [Retreats]", Enumerable.Empty<KeyValuePair<string, object>>());
            repository.Do("TRUNCATE TABLE [Participants]", Enumerable.Empty<KeyValuePair<string, object>>());
            repository.Do("TRUNCATE TABLE [ParticipantsAssignedToRetreat]", Enumerable.Empty<KeyValuePair<string, object>>());
            repository.Do("TRUNCATE TABLE [RetreatsParticipantIsAssignedTo]", Enumerable.Empty<KeyValuePair<string, object>>());
        }

        void PopulateTheDatabase()
        {
            bus.Send(new AllEvents());
        }
    }
}
