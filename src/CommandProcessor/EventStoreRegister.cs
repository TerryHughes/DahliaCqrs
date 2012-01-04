namespace Dahlia.CommandProcessor
{
    using NServiceBus;
    using EventStores;

    public class EventStoreRegister : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.RegisterSingleton(typeof(EventStore), new TempEventStore());
        }
    }
}
