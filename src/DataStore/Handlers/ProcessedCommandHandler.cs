namespace Dahlia.DataStore.Handlers
{
    using System.Configuration;
    using System.Data.SqlClient;
    using NServiceBus;
    using Events;

    public class ProcessedCommandHandler : IHandleMessages<Event>
    {
        public void Handle(Event @event)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO [dbo].[ProcessedCommands] ([Id]) VALUES (@Id)", connection))
                {
                    command.Parameters.AddWithValue("@Id", @event.CommandId);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }
    }
}
