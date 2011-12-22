namespace Dahlia.DataStore.Handlers
{
    using System.Data.SqlClient;
    using PreviousRetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version1;

    public class RetreatCreatedEventHandler : EventHandler<PreviousRetreatCreatedEvent>
    {
        protected override string Query
        {
            get { return "INSERT INTO [dbo].[Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }

        protected override void AddParameters(SqlCommand command, PreviousRetreatCreatedEvent @event)
        {
            command.Parameters.AddWithValue("@Date", @event.Date);
            command.Parameters.AddWithValue("@Description", @event.Description);
        }
    }
}
