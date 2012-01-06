namespace Dahlia.DataStore.Handlers.RetreatRenamedEvent
{
    using System.Collections.Generic;
    using CurrentRetreatRenamedEvent = Events.RetreatRenamedEvent.Version1;

    public class Version1 : EventHandler<CurrentRetreatRenamedEvent>
    {
        protected override string Statement
        {
            get { return "UPDATE [Retreats] SET [Description] = @Description WHERE [Id] = @Id"; }
        }

        protected override IEnumerable<KeyValuePair<string, object>> ComposePairs(CurrentRetreatRenamedEvent @event)
        {
            yield return new KeyValuePair<string, object>("@Description", @event.Description);
        }
    }
}
