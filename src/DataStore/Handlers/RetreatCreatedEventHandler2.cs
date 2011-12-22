namespace Dahlia.DataStore.Handlers
{
    using System.Data.SqlClient;
    using CurrentRetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version2;

    public class RetreatCreatedEventHandler2 : EventHandler<CurrentRetreatCreatedEvent>
    {
        protected override string Query
        {
            get { return "INSERT INTO [dbo].[Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }

        protected override void AddParameters(SqlCommand command, CurrentRetreatCreatedEvent @event)
        {
            command.Parameters.AddWithValue("@Date", @event.Date);
            command.Parameters.AddWithValue("@Description", @event.Description);
        }
    }
}
