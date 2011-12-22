namespace Dahlia.DataStore.Handlers
{
    using System.Configuration;
    using System.Data.SqlClient;
    using NServiceBus;
    using Dahlia.Events;

    public abstract class EventHandler<T> : IHandleMessages<T> where T : Event
    {
        protected abstract string Query { get; }

        public void Handle(T @event)
        {
var watch = System.Diagnostics.Stopwatch.StartNew();
System.Console.WriteLine("handling");
            var connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Id", @event.AggregateRootId);
                    AddParameters(command, @event);

System.Console.WriteLine(watch.ElapsedMilliseconds + " opening conn");
                    command.Connection.Open();
System.Console.WriteLine(watch.ElapsedMilliseconds + " conn opened | executing query");
                    command.ExecuteNonQuery();
System.Console.WriteLine(watch.ElapsedMilliseconds + " query executed | closing conn");
                    command.Connection.Close();
System.Console.WriteLine(watch.ElapsedMilliseconds + " conn closed");
                }
            }
System.Console.WriteLine(watch.ElapsedMilliseconds + " handled");
watch.Stop();
        }

        protected abstract void AddParameters(SqlCommand command, T @event);
    }
}
