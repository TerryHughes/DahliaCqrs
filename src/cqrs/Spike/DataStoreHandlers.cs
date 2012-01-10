namespace Dahlia
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Dahlia.Events;
    using Machine.Specifications;
    using CurrentParticipantCreatedEvent = Dahlia.Events.ParticipantCreatedEvent.Version1;
    using CurrentParticipantRenamedEvent = Dahlia.Events.ParticipantRenamedEvent.Version1;
    using CurrentParticipantNoteUpdatedEvent = Dahlia.Events.ParticipantNoteUpdatedEvent.Version1;

    public abstract class EventHandler<T> where T : Event
    {
        protected abstract string Query { get; }

        public void Handle(T @event)
        {
            var connectionString = @"Data Source=Prime\SQLExpress;Initial Catalog=DataStore;Integrated Security=SSPI;";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Id", @event.AggregateRootId);
                    AddParameters(command, @event);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected abstract void AddParameters(SqlCommand command, T @event);
    }

    public class ParticipantCreatedEventHandler : EventHandler<CurrentParticipantCreatedEvent>
    {
        protected override string Query
        {
            get { return "INSERT INTO [dbo].[Participants] ([Id], [FirstName], [LastName], [DateRecieved]) VALUES (@Id, @FirstName, @LastName, @DateRecieved)"; }
        }

        protected override void AddParameters(SqlCommand command, CurrentParticipantCreatedEvent @event)
        {
            command.Parameters.AddWithValue("@FirstName", @event.FirstName);
            command.Parameters.AddWithValue("@LastName", @event.LastName);
            command.Parameters.AddWithValue("@DateRecieved", @event.DateRecieved);
        }
    }

    public class ParticipantRenamedEventHandler : EventHandler<CurrentParticipantRenamedEvent>
    {
        protected override string Query
        {
            get { return "UPDATE [dbo].[Participants] SET [FirstName] = @FirstName, [LastName] = @LastName WHERE [Id] = @Id"; }
        }

        protected override void AddParameters(SqlCommand command, CurrentParticipantRenamedEvent @event)
        {
            command.Parameters.AddWithValue("@FirstName", @event.FirstName);
            command.Parameters.AddWithValue("@LastName", @event.LastName);
        }
    }

    public class ParticipantNoteUpdatedEventHandler : EventHandler<CurrentParticipantNoteUpdatedEvent>
    {
        protected override string Query
        {
            get { return "UPDATE [dbo].[Participants] SET [Note] = @Note WHERE [Id] = @Id"; }
        }

        protected override void AddParameters(SqlCommand command, CurrentParticipantNoteUpdatedEvent @event)
        {
            command.Parameters.AddWithValue("@Note", @event.Note);
        }
    }

    public class Populator
    {
        It should_be_able_to_execute =()=>
        {
            var handlers = new Dictionary<Type, IEnumerable<Action<Event>>>
                {
                    { typeof(CurrentParticipantCreatedEvent), new List<Action<Event>> { e => new ParticipantCreatedEventHandler().Handle(e as CurrentParticipantCreatedEvent) } },
                    { typeof(CurrentParticipantRenamedEvent), new List<Action<Event>> { e => new ParticipantRenamedEventHandler().Handle(e as CurrentParticipantRenamedEvent) } },
                    { typeof(CurrentParticipantNoteUpdatedEvent), new List<Action<Event>> { e => new ParticipantNoteUpdatedEventHandler().Handle(e as CurrentParticipantNoteUpdatedEvent) } }
                };

            var eddieDirkId = Guid.NewGuid();
            var doctorWhoId = Guid.NewGuid();
            var yosaffbridgeId = Guid.NewGuid();

            //Jeffrey Drew Wilschke => Beezow Doo-Doo Zopittybop-Bop-Bop
            //Bob Loblaw | Author of "The Bob Loblaw Law Blog"
            //Earl Sinclair | Somewhat thick-headed and very suggestible
            //Jack Bauer | Doesn't like suprises; looking for a relaxing and uneventful time to unwind
            //Silent Bob | Doesn't talk much
            //Kal-El => Clark Kent => Superman | Has trouble relating to others

            // no checks for a rename that happens before a create
            var events = new List<Event>
                {
                    new CurrentParticipantCreatedEvent("Eddie", "Adams", new DateTime(2011, 04, 20)) { AggregateRootId = eddieDirkId },
                    new CurrentParticipantNoteUpdatedEvent("Average kid") { AggregateRootId = eddieDirkId },
                    new CurrentParticipantNoteUpdatedEvent("Hanging out with the wrong crowd") { AggregateRootId = eddieDirkId },
                    new CurrentParticipantRenamedEvent("Dirk", "Diggler") { AggregateRootId = eddieDirkId },
                    new CurrentParticipantNoteUpdatedEvent("Pornstar") { AggregateRootId = eddieDirkId },
                    new CurrentParticipantCreatedEvent("First", "Doctor", new DateTime(2011, 04, 20)) { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Second", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Third", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantCreatedEvent("Ms", "Yolanda", new DateTime(2011, 04, 22)) { AggregateRootId = yosaffbridgeId },
                    new CurrentParticipantRenamedEvent("Fourth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Fifth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Ms", "Saffron") { AggregateRootId = yosaffbridgeId },
                    new CurrentParticipantRenamedEvent("Sixth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Seventh", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Eighth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Ms", "Bridget") { AggregateRootId = yosaffbridgeId },
                    new CurrentParticipantRenamedEvent("Ninth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Tenth", "Doctor") { AggregateRootId = doctorWhoId },
                    new CurrentParticipantRenamedEvent("Eleventh", "Doctor") { AggregateRootId = doctorWhoId }
                };

            foreach (var @event in events)
            {
                foreach (var handler in handlers[@event.GetType()])
                {
                    handler(@event);
                }
            }
        };
    }
}
