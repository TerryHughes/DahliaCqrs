namespace Dahlia.DataStore.Handlers
{
    using System.Data.SqlClient;
    using RetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version1;

    public class RetreatCreatedEventHandler : EventHandler<RetreatCreatedEvent>
    {
        protected override string Query
        {
            get { return "INSERT INTO [dbo].[Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }

        protected override void AddParameters(SqlCommand command, RetreatCreatedEvent @event)
        {
            command.Parameters.AddWithValue("@Date", @event.Date);
            command.Parameters.AddWithValue("@Description", @event.Description);
        }
    }
}
