namespace Dahlia.DataStore.Handlers.RetreatRenamedEvent
{
    using System.Collections.Generic;
    using CurrentRetreatRenamedEvent = Events.RetreatRenamedEvent.Version1;
    using Data.Common;

    public class Version1 : EventHandler<CurrentRetreatRenamedEvent>
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

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
